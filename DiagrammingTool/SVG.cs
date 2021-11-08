using System;
using System.Collections.Generic;
using System.Text;

namespace DiagrammingTool
{
    public class SVG
    {
        internal readonly string Text;
        internal string Start = @"<svg xmlns=""http://www.w3.org/2000/svg"" xmlns:svg=""http://www.w3.org/2000/svg"">";
        internal string Rectangle;
        internal int PosX = 141;
        internal int DivideByTwo = 2;
        internal string GroupStart = "<g>";
        internal string End = "</svg>";
        internal string GroupEnd = "</g>";

        public SVG(string title, int width)
        {
            this.Text = @$"<text fill = ""#000000"" font-family=""Source Sans Pro,Helvetica Neue,Courier,sans-serif"" font-size=""24"" id=""svg_2""
            stroke=""#000000"" stroke-width=""0"" text-anchor=""middle"" text-align= ""justify"" x=""{PosX + width / DivideByTwo}"" y=""160"">{title}</text>";
            this.Rectangle = @$"<rect width=""{width}"" height=""50"" style=""fill:#ECECFF; stroke-width:1;stroke:#9370DB"" x=""{PosX}"" y=""126""/>";
        }
    }
}
