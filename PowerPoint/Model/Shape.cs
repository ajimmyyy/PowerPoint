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
        Coordinate _info;
        string _shapeName;
        protected double _ratio = 1;
        protected bool _isSelect = false;
        protected Selection _selection = new Selection();

        //取得圖形資訊
        public string Info
        {
            get
            {
                return _info.Clone(_ratio).ToString();
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

        //設定座標(不改變Info)
        public abstract void SetCoordinate(double left, double top, double right, double bottom);

        //取得位置
        public abstract Coordinate GetPosition();

        //繪圖
        public abstract void Draw(IGraphics graphics);
        
        //取得選取框資訊
        public Selection GetSelection()
        {
            return _selection;
        }

        //是否被選取
        public bool IsSelect()
        {
            return _isSelect;
        }

        //設定是否被選取
        public void SetSelect(bool value)
        {
            _isSelect = value;
        }

        public void SetInfo(Coordinate value)
        {
            _info = value;
            NotifyPropertyChanged(INFO);
        }

        public void SetRatio(double ratio)
        {
            _ratio = ratio;
            NotifyPropertyChanged(INFO);
        }

        //通知資料改變
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
