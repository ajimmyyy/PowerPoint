using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Factory
    {
        const int END_NUMBER = 100;

        //創建新的形狀實體
        public static Shape CreateShape(string shapeType)
        {
            Random randomPosition = new Random();
            int top = randomPosition.Next(0, END_NUMBER);
            int left = randomPosition.Next(0, END_NUMBER);
            int bottom = randomPosition.Next(0, END_NUMBER);
            int right = randomPosition.Next(0, END_NUMBER);

            switch (shapeType)
            {
                case ShapeType.LINE_NAME:
                    return new Line(top, left, bottom, right);
                case ShapeType.RECTANGLE_NAME:
                    return new Rectangle(top, left, bottom, right);
                default:
                    return null;
            }
        }
    }
}
