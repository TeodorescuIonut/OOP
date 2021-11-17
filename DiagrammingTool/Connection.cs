using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammingTool
{
    class Connection
    {
        internal string Arrow;

        public Connection()
        {
            this.Arrow = @"<defs>
    <marker id=""arrowhead"" markerWidth=""10"" markerHeight=""7"" 
    refX = ""0"" refY = ""3.5"" orient = ""auto"" >    
          <polygon points = ""0 0, 10 3.5, 0 7"" />     
         </marker>    
       </defs>   
       <line transform=""rotate(-90 50 100)"" x1 = ""0"" y1 = ""50"" x2 = ""100"" y2 = ""50"" stroke = ""#000""
  stroke-width = ""2"" display=""none"" marker-end = ""url(#arrowhead)"" /> ";
        }
    }
}
