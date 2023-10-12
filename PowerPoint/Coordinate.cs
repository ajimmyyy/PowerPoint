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
        public int _coordinateX
        { 
            get;
            set;
        }
        public int _coordinateY
        {
            get;
            set;
        }

        public Coordinate(int coordinateX, int coordinateY)
        {
            _coordinateX = coordinateX;
            _coordinateY = coordinateY;

        }

        //重載ToString()，將座標轉為字串
        public override string ToString()
        {
            return string.Format(TO_STRING_FORMAT, _coordinateX, _coordinateY);
        }
    }
}
