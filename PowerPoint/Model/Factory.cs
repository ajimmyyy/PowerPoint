using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Factory
    {
        const int LEFT_TOP_X = 0;
        const int LEFT_TOP_Y = 1;
        const int RIGHT_BOTTOM_X = 2;
        const int RIGHT_BOTTOM_Y = 3;

        //創建新的圖形實體
        public static Shape CreateShape(string shapeType, int[] coordinate = null)
        {
            coordinate = coordinate ?? new int[] { 0, 0, 0, 0 };

            switch (shapeType)
            {
                case ModeType.LINE_NAME:
                    return new Line(coordinate[LEFT_TOP_X], coordinate[LEFT_TOP_Y], coordinate[RIGHT_BOTTOM_X], coordinate[RIGHT_BOTTOM_Y]);
                case ModeType.RECTANGLE_NAME:
                    return new Rectangle(coordinate[LEFT_TOP_X], coordinate[LEFT_TOP_Y], coordinate[RIGHT_BOTTOM_X], coordinate[RIGHT_BOTTOM_Y]);
                case ModeType.CIRCLE_NAME:
                    return new Circle(coordinate[LEFT_TOP_X], coordinate[LEFT_TOP_Y], coordinate[RIGHT_BOTTOM_X], coordinate[RIGHT_BOTTOM_Y]);
            }
            return null;
        }

        //創建新的頁面實體
        public static Shapes CreateShapes()
        {
            Shapes page = new Shapes();
            return page;
        } 
    }
}
