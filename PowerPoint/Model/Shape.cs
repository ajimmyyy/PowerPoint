using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string INFO = "Info";
        const string SHAPE_NAME = "ShapeName";
        string _info;
        string _shapeName;

        //取得圖形資訊
        public string Info
        {
            get
            { 
                return _info; 
            }
            set
            {
                _info = value;
                NotifyPropertyChanged(SHAPE_NAME);
            }
        }

        //取得圖形名稱
        public string ShapeName
        {
            get
            { 
                return _shapeName; 
            }
            set
            {
                _shapeName = value;
                NotifyPropertyChanged(SHAPE_NAME);
            }
        }

        //設定位置
        public abstract void SetPosition(double left, double top, double right, double bottom);

        //繪圖
        public abstract void Draw(IGraphics graphics);

        //通知資料改變
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
