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
            Shape newShape = Factory.CreateShape(shapeType);
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
