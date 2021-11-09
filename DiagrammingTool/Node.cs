using System;
using System.Collections.Generic;
using System.Text;

namespace DiagrammingTool
{
    class Node
    {
        internal readonly string Text;
        internal string Rectangle;
        internal int PosX = 141;
        internal string GroupStart;
        internal string GroupEnd = "</g>";
        private readonly int divideByTwo = 2;

        public Node(string title, int width, ref int x)
        {
            this.Text = @$"<text fill = ""#000000"" font-family=""Source Sans Pro,Helvetica Neue,Courier,sans-serif"" font-size=""24"" id=""svg_2""
            stroke=""#000000"" stroke-width=""0"" text-anchor=""middle"" text-align= ""justify"" x=""{PosX + width / divideByTwo + x}"" y=""160"">{title}</text>";
            this.Rectangle = @$"<rect width=""{width}"" height=""50"" style=""fill:#ECECFF; stroke-width:1;stroke:#9370DB"" x=""{PosX + x}"" y=""126""/>";
            this.GroupStart = @$"<g id = ""{title}"">";
            x = PosX + width + x;
        }
    }
}
