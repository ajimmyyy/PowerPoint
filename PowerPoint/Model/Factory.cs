﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Factory
    {
        //創建新的圖形實體
        public static Shape CreateShape(string shapeType, double ratio)
        {
            const int RIGHT = 832;
            const int BOTTOM = 468;
            Random random = new Random();

            switch (shapeType)
            {
                case ModeType.LINE_NAME:
                    return new Line(random.Next(RIGHT), random.Next(BOTTOM), random.Next(RIGHT), random.Next(BOTTOM), ratio);
                case ModeType.RECTANGLE_NAME:
                    return new Rectangle(random.Next(RIGHT), random.Next(BOTTOM), random.Next(RIGHT), random.Next(BOTTOM), ratio);
                case ModeType.CIRCLE_NAME:
                    return new Circle(random.Next(RIGHT), random.Next(BOTTOM), random.Next(RIGHT), random.Next(BOTTOM), ratio);
                default:
                    return null;
            }
        }

        public static Shapes CreateShapes()
        {
            return new Shapes();
        } 
    }
}
