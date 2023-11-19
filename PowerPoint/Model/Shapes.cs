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

        //創建形狀並加入到list裡
        public void AddNewShape(string shapeType)
        {
            Shape newShape = Factory.CreateShape(shapeType);
            _shapeList.Add(newShape);
        }

        //加入現有形狀
        public void AddShape(Shape shape)
        {
            _shapeList.Add(shape);
        }

        //刪除list裡的形狀(by index)
        public void DeleteShape(int rowIndex)
        {
            if (_shapeList.Count != 0)
            {
                _shapeList.RemoveAt(rowIndex);
            }
        }

        //刪除list裡的形狀(by shape)
        public void DeleteShape(Shape shape)
        {
            for (int i = 0; i < _shapeList.Count; i++)
            {
                if (shape == _shapeList[i])
                {
                    _shapeList.RemoveAt(i);
                }
            }
        }

        //選取形狀
        public Shape FindShape(double pointX, double pointY)
        {
            for (int i = _shapeList.Count - 1; i >= 0; i --)
            {
                Shape shape = _shapeList[i];
                if (shape.GetPosition().IsInside(pointX, pointY))
                {
                    return shape;
                }
            }
            return null;
        }

        //畫出所有圖形
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapeList)
                shape.Draw(graphics);
        }

        //取得形狀數量
        public int GetCount()
        {
            return _shapeList.Count;
        }
    }
}
