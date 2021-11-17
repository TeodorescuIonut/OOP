using System;
using System.IO;
using System.Linq;
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
                        string dir = Path.GetDirectoryName(path);
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
                        string newFile = System.IO.Path.Combine(dir, $"{fileName}.svg");
                        string newtext = ValidateFile(text);
                        System.IO.File.Copy(path, newFile, true);
                        System.IO.File.WriteAllText(newFile, newtext);
                    }
                }
            }
        }

        private static string ValidateFile(string[] text)
        {
            SVG svg = new SVG();
            string firstLine = text[0];
            string result = "";
            string direction = "";
            string[] directionY = { "BT", "TD", "TB" };
            string[] directionX = { "LR", "RL" };
            (int x, int y) pos = (0, 0);
            if (firstLine.StartsWith("flowchart", StringComparison.InvariantCultureIgnoreCase))
            {
                if (firstLine.Split(' ').Any(x => directionX.Any(y => x.Equals(y))))
                {
                    direction = "y";
                    result = text.Skip(1).Distinct().Select(text => ProcessText(text, direction, ref pos))
                        .Aggregate("", (line, next) => line + "\n" + next);
                }

                if (firstLine.Split(' ').Any(x => directionY.Any(y => x.Equals(y))))
                {
                    direction = "x";
                    result = text.Skip(1).Distinct().Select(text => ProcessText(text, direction, ref pos))
                        .Aggregate("", (line, next) => next + "\n" + line);
                }

                return svg.Start + result + svg.End;
            }

            return "this is not a flowChart";
        }

        private static string ProcessText(string text, string direction, ref (int x, int y) pos)
            {
            const string symbols = "[]{}()>->";
            string title = LimitTextLength(text);
            const string connection = "-->";
            string result = "";
            const int initposX = 50;
            int currPos = 0;
            (int x, int y) altpos;
            if (text.Contains(connection))
            {
                var firstNode = text.Split(connection).First();
                currPos = pos.x + initposX;
                string firstElem = ProcessText(firstNode, direction, ref pos);
                altpos = pos;
                string orientation = (direction == "x") ? "y" : "x";
                if (orientation == "x")
                {
                    altpos.x = pos.x + CalculateTitleWidth(firstNode);
                }
                else
                {
                    altpos.y = pos.y;
                    altpos.x = currPos;
                }

                result = text.Split(connection).Skip(1).Select(text => CreateNode(LimitTextLength(text), CalculateTitleWidth(text), orientation, ref altpos))
                        .Aggregate("", (line, next) => line + next);

                return firstElem + result;
            }

            int width = CalculateTitleWidth(title);
            if (!text.Contains(symbols))
            {
                return CreateNode(title, width, direction, ref pos);
            }

            return "not compatible";
            }

        private static string CreateConnection()
        {
            Connection arrow = new Connection();
            return arrow.Arrow;
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

        private static string CreateNode(string title, int width, string direction, ref (int, int) pos)
        {
            Node node = new Node(title, width, direction, ref pos);
            return node.GroupStart + node.Rectangle + node.Text + node.GroupEnd;
        }
    }
}
