using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public class Shapes
    {
        const int START_NUMBER = 200;
        const int END_NUMBER = 600;
        private BindingList<Shape> _shapeList = new BindingList<Shape>();

        public BindingList<Shape> GetShapeList
        {
            get
            { 
                return _shapeList; 
            }
        }

        //創建圖形並加入到list裡
        public void AddNewShape(string shapeType)
        {
            Random randomPosition = new Random();
            int top = randomPosition.Next(START_NUMBER, END_NUMBER);
            int left = randomPosition.Next(START_NUMBER, END_NUMBER);
            int bottom = randomPosition.Next(START_NUMBER, END_NUMBER);
            int right = randomPosition.Next(START_NUMBER, END_NUMBER);

            Shape newShape = Factory.CreateShape(shapeType);
            newShape.SetInitialPosition(top, left, bottom, right);
            _shapeList.Add(newShape);
        }

        //加入現有圖形
        public void AddShape(Shape shape)
        {
            _shapeList.Add(shape);
        }

        //刪除list裡的圖形
        public void DeleteShape(int rowIndex)
        {
            _shapeList.RemoveAt(rowIndex);
        }

        //畫出所有圖形
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapeList)
                shape.Draw(graphics);
        }
    }
}
