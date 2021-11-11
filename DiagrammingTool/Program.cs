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
            int pos = 0;
            if (firstLine.StartsWith("flowchart", StringComparison.InvariantCultureIgnoreCase))
            {
                if (firstLine.Split(' ').Any(x => directionX.Any(y => x.Equals(y))))
                {
                    pos = 0;
                    direction = "y";
                    result = text.Skip(1).Distinct().Select(text => ProcessText(text, direction, ref pos))
                        .Aggregate("", (line, next) => line + "\n" + next);
                }

                if (firstLine.Split(' ').Any(x => directionY.Any(y => x.Equals(y))))
                {
                    pos = 0;
                    direction = "x";
                    result = text.Skip(1).Distinct().Select(text => ProcessText(text, direction, ref pos))
                        .Aggregate("", (line, next) => next + "\n" + line);
                }

                return svg.Start + result + svg.End;
            }

            return "this is not a flowChart";
        }

        private static string ProcessText(string text, string direction, ref int pos)
            {
            const string symbols = "[]{}()>->";
            string title = LimitTextLength(text);

            const int padding = 20;
            int width = (title.ToCharArray().Length * 15) + padding;
            if (!text.Contains(symbols))
            {
                return CreateRectangleNode(title, width, direction, ref pos);
            }

            return "not compatible";
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

        private static string CreateRectangleNode(string title, int width, string direction, ref int pos)
        {
            Node node = new Node(title, width, direction, ref pos);
            return node.GroupStart + node.Rectangle + node.Text + node.GroupEnd;
        }
    }
}
