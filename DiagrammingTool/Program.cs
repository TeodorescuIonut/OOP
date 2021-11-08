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
            return text[0].StartsWith("flowchart", StringComparison.InvariantCultureIgnoreCase) ? ProcessText(text) : "this is not a flowChart";
        }

        private static string ProcessText(string[] text)
            {
            const string symbols = "[]{}()>->";
            string title = text[1].TrimStart(' ').TrimEnd(' ');
            const int padding = 20;
            int width = (title.ToCharArray().Length * 15) + padding;
            if (!text[1].Contains(symbols))
            {
                return CreateRectangleNode(title, width);
            }

            return "not compatible";
            }

        private static string CreateRectangleNode(string title, int width)
        {
            SVG svg = new SVG(title, width);
            return svg.Start + svg.Rectangle + svg.Text + svg.End;
        }
    }
}
