using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Coordinate
    {
        const string TO_STRING_FORMAT = "({0}, {1})";
        public double _coordinateX
        { 
            get;
            set;
        }
        public double _coordinateY
        {
            get;
            set;
        }

        //重載ToString()，將座標轉為字串
        public override string ToString()
        {
            return string.Format(TO_STRING_FORMAT, _coordinateX, _coordinateY);
        }
    }
}
