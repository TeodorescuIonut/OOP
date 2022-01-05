using System;
using System.Collections.Generic;
using System.Text;

namespace DiagrammingTool
{
    class ElemSVG
    {
        internal readonly string Text;
        internal string Rectangle;
        internal string GroupStart;
        internal string GroupEnd = "</g>";
        internal string Arrow;
        private readonly int initPosX = 50;
        private readonly int initPosY = 50;
        private readonly int divideByTwo = 2;
        private readonly int textCenter = 20;

        public ElemSVG(string title, Node node, int width, int highestWidth, string direction, ref (int x, int y) pos)
        {
            int x = 0;
            int dif = 0;
            int y = 0;
            dif = width == highestWidth ? 0 : (highestWidth - width) / divideByTwo;

            if (direction == "x")
            {
                pos.x = initPosX + pos.x;
                x = pos.x + dif;
                y = pos.y == 0 ? initPosY : pos.y;
                pos.y = y;
                pos.x = x + width + dif;
            }

            if (direction == "y")
            {
                y = initPosY + pos.y;
                x = pos.x == 0 ? initPosX : pos.x + dif;
                pos.y = y;
            }

            node.Pos.x = x;
            node.Pos.y = y;
            this.Text = @$"<text fill = ""#000000"" font-family=""Source Sans Pro,Helvetica Neue,Courier,sans-serif"" font-size=""19"" id=""{title}""
            stroke=""#000000"" stroke-width=""0"" text-anchor=""middle"" text-align= ""justify"" x=""{x + width / divideByTwo}"" y=""{y + textCenter}"">{title}</text>";
            this.Rectangle = @$"<rect width=""{width}"" height=""33"" style=""fill:#ECECFF; stroke-width:1;stroke:#9370DB"" x=""{x}"" y=""{y}""/>";
            this.GroupStart = @$"<g id = ""{title}"">";
        }
    }
}
