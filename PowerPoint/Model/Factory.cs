using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Factory
    {
        //創建新的圖形實體
        public static Shape CreateShape(string shapeType)
        {
            const int START = 200;
            const int END = 600;
            Random random = new Random();

            switch (shapeType)
            {
                case ModeType.LINE_NAME:
                    return new Line(random.Next(START, END), random.Next(START, END), random.Next(START, END), random.Next(START, END));
                case ModeType.RECTANGLE_NAME:
                    return new Rectangle(random.Next(START, END), random.Next(START, END), random.Next(START, END), random.Next(START, END));
                case ModeType.CIRCLE_NAME:
                    return new Circle(random.Next(START, END), random.Next(START, END), random.Next(START, END), random.Next(START, END));
                default:
                    return null;
            }
        }
    }
}
