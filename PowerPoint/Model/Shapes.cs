using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shapes
    {
        const string DELETE = "刪除";
        const int END_NUMBER = 100;
        private List<Shape> _shapeList = new List<Shape>();

        //將圖形加入到list裡
        public void AddNewShape(string shapeType)
        {
            Random randomPosition = new Random();
            int top = randomPosition.Next(0, END_NUMBER);
            int left = randomPosition.Next(0, END_NUMBER);
            int bottom = randomPosition.Next(0, END_NUMBER);
            int right = randomPosition.Next(0, END_NUMBER);

            Shape newShape = Factory.CreateShape(shapeType);
            newShape.SetInitialPosition(top, left, bottom, right);
            _shapeList.Add(newShape);
        }

        //刪除list裡的圖形
        public void DeleteShape(int rowIndex)
        {
            _shapeList.RemoveAt(rowIndex);
        }

        //取得shapes資訊
        public List<ShapeGridViewModel> GetShapeListInfo()
        {
            List<ShapeGridViewModel> shapeListData = _shapeList.Select(item => new ShapeGridViewModel
            { 
                _column1 = DELETE,
                _column2 = item.GetShapeName(),
                _column3 = item.GetInfo() }).ToList();

            return shapeListData;
        }
    }
}
