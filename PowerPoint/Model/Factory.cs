using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Factory
    {
        //創建新的圖形實體
        public static Shape CreateShape(string shapeType)
        {
            const int RIGHT = 832;
            const int BOTTOM = 468;
            Random random = new Random();

            switch (shapeType)
            {
                case ModeType.LINE_NAME:
                    return new Line(random.Next(RIGHT), random.Next(BOTTOM), random.Next(RIGHT), random.Next(BOTTOM));
                case ModeType.RECTANGLE_NAME:
                    return new Rectangle(random.Next(RIGHT), random.Next(BOTTOM), random.Next(RIGHT), random.Next(BOTTOM));
                case ModeType.CIRCLE_NAME:
                    return new Circle(random.Next(RIGHT), random.Next(BOTTOM), random.Next(RIGHT), random.Next(BOTTOM));
                default:
                    return null;
            }
        }
    }
}
