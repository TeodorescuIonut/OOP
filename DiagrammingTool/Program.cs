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
                string path = args[0];
                if (File.Exists(path))
                {
                    string[] text = File.ReadAllLines(path);
                    string dir = Path.GetDirectoryName(path);
                    string newFile = System.IO.Path.Combine(dir, "text.svg");
                    string newtext = ValidateFile(text);
                    System.IO.File.Copy(path, newFile, true);
                    System.IO.File.WriteAllText(newFile, newtext);
                }
            }
        }

        private static string ValidateFile(string[] text)
        {
            SVG svg = new SVG();
            string result = "";
            if (text[0].StartsWith("flowchart", StringComparison.InvariantCultureIgnoreCase))
            {
                if (text[0].Contains("RL"))
                {
                    int directionX = 0;
                    result = text.Skip(1).Reverse().Distinct().Select(text => ProcessText(text, ref directionX))
                        .Aggregate("", (line, next) => line + "\n" + next);
                }

                if (text[0].Contains("LR"))
                {
                    int directionX = 0;
                    result = text.Skip(1).Distinct().Select(text => ProcessText(text, ref directionX))
                        .Aggregate("", (line, next) => next + "\n" + line);
                }

                return svg.Start + result + svg.End;
            }

            return "this is not a flowChart";
        }

        private static string ProcessText(string text, ref int directionX)
            {
            const string symbols = "[]{}()>->";
            string title = text.TrimStart(' ').TrimEnd(' ');
            const int padding = 20;
            int width = (title.ToCharArray().Length * 15) + padding;
            if (!text.Contains(symbols))
            {
                return CreateRectangleNode(title, width, ref directionX);
            }

            return "not compatible";
            }

        private static string CreateRectangleNode(string title, int width, ref int x)
        {
            Node node = new Node(title, width, ref x);
            return node.GroupStart + node.Rectangle + node.Text + node.GroupEnd;
        }
    }
}
