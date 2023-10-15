using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Factory
    {
        //創建新的形狀實體
        public static Shape CreateShape(string shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.LINE_NAME:
                    return new Line();
                case ShapeType.RECTANGLE_NAME:
                    return new Rectangle();
                case ShapeType.CIRCLE_NAME:
                    return new Circle();
                default:
                    return null;
            }
        }
    }
}
