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
            const int LEFT = 161;
            const int TOP = 74;
            const int RIGHT = 1040;
            const int BOTTOM = 695;
            Random random = new Random();

            switch (shapeType)
            {
                case ModeType.LINE_NAME:
                    return new Line(random.Next(LEFT, RIGHT), random.Next(TOP, BOTTOM), random.Next(LEFT, RIGHT), random.Next(TOP, BOTTOM));
                case ModeType.RECTANGLE_NAME:
                    return new Rectangle(random.Next(LEFT, RIGHT), random.Next(TOP, BOTTOM), random.Next(LEFT, RIGHT), random.Next(TOP, BOTTOM));
                case ModeType.CIRCLE_NAME:
                    return new Circle(random.Next(LEFT, RIGHT), random.Next(TOP, BOTTOM), random.Next(LEFT, RIGHT), random.Next(TOP, BOTTOM));
                default:
                    return null;
            }
        }
    }
}
