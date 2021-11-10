using System;
using System.Collections.Generic;
using System.Text;

namespace DiagrammingTool
{
    class Node
    {
        internal readonly string Text;
        internal string Rectangle;
        internal string GroupStart;
        internal string GroupEnd = "</g>";
        private readonly int initPosX = 141;
        private readonly int initPosY = 126;
        private readonly int divideByTwo = 2;
        private readonly int textCenter = 32;

        public Node(string title, int width, string direction, ref int pos)
        {
            int x = 0;
            int y = 0;
            if (direction == "x")
            {
                pos = initPosX + pos;
                x = pos;
                y = initPosY;
            }

            if (direction == "y")
            {
                pos = initPosY + pos;
                y = pos;
                x = initPosX;
            }

            this.Text = @$"<text fill = ""#000000"" font-family=""Source Sans Pro,Helvetica Neue,Courier,sans-serif"" font-size=""24"" id=""svg_2""
            stroke=""#000000"" stroke-width=""0"" text-anchor=""middle"" text-align= ""justify"" x=""{x + width / divideByTwo}"" y=""{y + textCenter}"">{title}</text>";
            this.Rectangle = @$"<rect width=""{width}"" height=""50"" style=""fill:#ECECFF; stroke-width:1;stroke:#9370DB"" x=""{x}"" y=""{y}""/>";
            this.GroupStart = @$"<g id = ""{title}"">";
        }
    }
}
