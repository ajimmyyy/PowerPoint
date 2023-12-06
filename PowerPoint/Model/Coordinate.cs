using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Coordinate
    {
        const double HALF = 0.5;
        const string TO_STRING_FORMAT = "(({0}, {1}), ({2}, {3}))";
        public double _left
        { 
            get;
            set;
        }
        public double _top
        {
            get;
            set;
        }
        public double _right
        {
            get;
            set;
        }
        public double _bottom
        {
            get;
            set;
        }
        public double middleX
        {
            get
            {
                return (_left + _right) * HALF;
            }
        }
        public double middleY
        {
            get
            {
                return (_top + _bottom) * HALF;
            }
        }

        //是否在範圍內
        public bool IsInside(double pointX, double pointY)
        {
            return 
                pointX >= Math.Min(_left, _right) && 
                pointX <= Math.Max(_left, _right) && 
                pointY >= Math.Min(_top, _bottom) && 
                pointY <= Math.Max(_top, _bottom); 
        }

        //重載ToString()，將座標轉為字串
        public override string ToString()
        {
            return string.Format(TO_STRING_FORMAT, Math.Floor(_left), Math.Floor(_top), Math.Floor(_right), Math.Floor(_bottom));
        }

        //克隆座標
        public Coordinate Clone()
        {
            Coordinate coordinateCopy = new Coordinate();
            coordinateCopy._left = _left;
            coordinateCopy._right = _right;
            coordinateCopy._top = _top;
            coordinateCopy._bottom = _bottom;

            return coordinateCopy;
        }
    }
}
