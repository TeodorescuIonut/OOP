using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiagrammingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please enter a valid path.");
            }
            else
            {
                foreach (var arg in args)
                {
                    string path = arg;

                    if (File.Exists(path))
                    {
                        string[] text = File.ReadAllLines(path);
                        string textRaw = File.ReadAllText(path);
                        string dir = Path.GetDirectoryName(path);
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
                        string newFile = System.IO.Path.Combine(dir, $"{fileName}.svg");
                        string newtext = ValidateFile(textRaw, text);
                        System.IO.File.Copy(path, newFile, true);
                        System.IO.File.WriteAllText(newFile, newtext);
                    }
                }
            }
        }

        private static string ValidateFile(string textRaw, string[] text)
        {
            SVG svg = new SVG();
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            DirectedGraph graph = new DirectedGraph();
            var nodes = new List<string>(CheckTextFormat(textRaw));
            string[] processedText = nodes.SelectMany(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();
            int length = processedText.Length;
            const int two = 2;
            const string con = @"-{2,}\>";
            for (int i = 0; i < length; i++)
            {
                Node currNode = new Node(processedText[i]);
                Node nextNode = i + 1 >= length ? new Node(processedText[length - 1]) : new Node(processedText[i + 1]);
                if (graph.HasNode(currNode) && !Regex.IsMatch(currNode.Name, con) && Regex.IsMatch(nextNode.Name, con))
                {
                        Node existingNode = graph.GetNode(currNode);
                        string conLabel = nextNode.Name;
                        nextNode = new Node(processedText[i + two]);
                        existingNode.AddNode(nextNode, conLabel);
                        processedText[i + 1] = "";
                }

                if (!graph.HasNode(currNode) && currNode.Name != "" && !Regex.IsMatch(currNode.Name, con))
                {
                    graph.AddNode(currNode);
                }

                if (Regex.IsMatch(currNode.Name, con))
                {
                    Node prev = graph.AllNodes.Values.Last();
                    prev.AddNode(nextNode, currNode.Name);
                }
            }

            AddHeadAndTale(graph);
            string firstLine = text[0];
            return svg.Start + ProcessNodes(graph) + svg.End;
        }

        private static void AddHeadAndTale(DirectedGraph graph)
        {
            for (int i = 0; i < graph.AllNodes.Values.Count; i++)
            {
                var node = graph.AllNodes.Values.ElementAt(i);
                if (i == 0 || (i - 1 >= 0 && graph.AllNodes.Values.ElementAt(i - 1).Tale))
                {
                    node.Head = true;
                }

                if (node.ChildNodes.Count == 0)
                {
                    node.Tale = true;
                }
            }
        }

        private static string ProcessNodes(DirectedGraph graph)
        {
            (int x, int y) pos = (0, 0);
            const string direction = "x";
            const int posY = 50;
            string resultText = "";
            string nodeText = "";
            Node[][] lines = GetLines(graph);
            Node[][] columns = GetColumns(lines);
            int widthHighest;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    int nodeWidth = CalculateTitleWidth(lines[i][j].Name);
                    widthHighest = CheckHighestTitleWidthOnColumn(columns[j], j, nodeWidth);
                    var childs = lines[i][j].ChildNodes;
                    if (childs.Count == 0)
                    {
                        nodeText = "";
                        nodeText += CreateNode(lines[i][j], nodeWidth, widthHighest, direction, ref pos);
                        resultText += nodeText;
                        pos.y += posY;
                        pos.x = 0;
                    }

                    if (childs.Count > 0)
                    {
                        nodeText = "";
                        nodeText += CreateNode(lines[i][j], nodeWidth, widthHighest, direction, ref pos);
                        resultText += nodeText;
                    }
                }
            }

            UpdateChildCoordinates(lines, graph);
            resultText += GenerateConnections(lines);
            return resultText;
        }

        private static string GenerateConnections(Node[][] lines)
        {
            string res = "";
            foreach (var child in lines.SelectMany(x => x.Where(y => y.ChildNodes.Count > 0)))
            {
                 res += CreateConnection(child, CalculateTitleWidth(child.Name));
            }

            return res;
        }

        private static void UpdateChildCoordinates(Node[][] lines, DirectedGraph graph)
        {
            foreach (var child in lines.Select(x => x.Where(y => y.ChildNodes.Count > 0).SelectMany(x => x.ChildNodes)))
            {
                foreach (var node in child)
                {
                    if (graph.HasNode(node.Value))
                    {
                        var existingNode = graph.GetNode(node.Value);
                        node.Value.Pos = existingNode.Pos;
                    }
                }
            }
        }

        private static int CheckHighestTitleWidthOnColumn(Node[] columns, int j, int nodeWidth)
        {
            return j < columns.Length ? CheckMaxWidth(columns) : nodeWidth;
        }

        private static int CheckMaxWidth(Node[] columns)
        {
            return columns.Max(n => CalculateTitleWidth(n.Name));
        }

        private static Node[][] GetLines(DirectedGraph graph)
        {
            int graphLEngth = graph.AllNodes.Count;
            int intLinesCount = graph.AllNodes.Values.Count(n => n.Head);
            List<Node> line = new List<Node>();
            int k = 0;
            Node[][] lines = new Node[intLinesCount][];
            for (int i = 0; i < graphLEngth; i++)
            {
                var node = graph.AllNodes.Values.ElementAt(i);
                line.Add(node);
                if (node.Tale)
                {
                    lines[k] = new Node[line.Count];
                    for (int j = 0; j < line.Count; j++)
                    {
                        lines[k][j] = line[j];
                    }

                    k++;
                    line.Clear();
                }
            }

            return lines;
        }

        private static Node[][] GetColumns(Node[][] jagArr)
        {
            int maxNo = jagArr.OrderByDescending(c => c.Length).First().Length;
            var selectedArray = new Node[maxNo][];
            for (int i = 0; i < maxNo; i++)
            {
                selectedArray[i] = jagArr
                .Where(o => o?.Length > i)
                .Select(o => o[i])
                .ToArray();
            }

            return selectedArray;
        }

        private static List<string> CheckTextFormat(string text)
            {
            var lines = Regex.Split(text, "\r\n?|\n");
            const string pipe = "|";
            const string title = @"\s*(flowchart)\s+?(LR|BT|RL|TD|TB)?\s*";
            const string phrase = @"(?'frNode'(^\s*\w+\s*))((?'connection'(\s*\-{2,}\>))(?'toNode'(\s*\w+\s*)))*$";
            const RegexOptions options = RegexOptions.Multiline;
            var nodes = new List<string>();
            if (Regex.IsMatch(text, title, options))
            {
                MatchCollection col = Regex.Matches(text, phrase, options);
                var groups = col.SelectMany(x => x.Groups.Values.Where(gr => gr.Name == "frNode" || gr.Name == "toNode" || gr.Name == "connection").
                SelectMany(y => y.Captures).OrderBy(z => z.Index).Select(x => x.Value));
                foreach (var group in groups)
                {
                        nodes.Add(group.Replace("\n", "").Replace("\r", "").Replace(" ", ""));
                }

                if (nodes.Count == 0)
                {
                    throw new ArgumentException(text);
                }

                return nodes;
            }

            throw new ArgumentException(text);
        }

        private static bool CheckAllLinesifValid(string[] lines, string pattern)
        {
            bool result = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string prevLine = "";
                if (!Regex.IsMatch(lines[i], pattern))
                {
                    prevLine = lines[i - 1] + lines[i];
                    string nextLine = lines[i] + lines[i + 1];
                    if (Regex.IsMatch(prevLine, pattern) || Regex.IsMatch(nextLine, pattern))
                    {
                        continue;
                    }

                    return false;
                }

                result = true;
            }

            return result;
        }

        private static string CreateConnection(Node node, int nodeWidth)
        {
            string res = "";
            foreach (var elem in node.ChildNodes.Select(child => new Connection(node, child.Value, nodeWidth)))
            {
                res += elem.Arrow;
            }

            return res;
        }

        private static int CalculateTitleWidth(string title)
        {
            const int padding = 20;
            const int x = 15;
            return (title.ToCharArray().Length * x) + padding;
        }

        private static string LimitTextLength(string text)
        {
            const int maxLength = 30;
            string title = text.TrimStart(' ').TrimEnd(' ');
            if (title.Length > maxLength)
            {
                return title.Substring(0, maxLength) + "...";
            }

            return title;
        }

        private static string CreateNode(Node node, int width, int highestWidth, string direction, ref (int, int) pos)
        {
            ElemSVG nodeElem = new ElemSVG(LimitTextLength(node.Name), node, width, highestWidth, direction, ref pos);
            return nodeElem.GroupStart + nodeElem.Rectangle + nodeElem.Text + nodeElem.GroupEnd;
        }
    }
}