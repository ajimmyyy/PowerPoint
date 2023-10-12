using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        Shapes _shapes = new Shapes();

        //當新增按鈕被按下的處理
        public void AddButtonClickEvent(string shapeType)
        {
            if (shapeType == "")
            {
                return;
            }

            _shapes.AddNewShape(shapeType);
        }

        //當刪除按鈕被按下的處理
        public void DeleteButtonClickEvent(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.DeleteShape(rowIndex);
            }
        }

        //回傳list裡的資訊做顯示
        public List<ShapeGridViewModel> GetShapesDisplay()
        {
            return _shapes.GetShapeListInfo();
        }
    }
}
