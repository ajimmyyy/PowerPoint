using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public class PresentationModel
    {
        public event ButtonClickEventHandler _toolButtonClick;
        public delegate void ButtonClickEventHandler(bool chicked1, bool chicked2, bool chicked3);
        private bool _isLinePressed;
        private bool _isRectanglePressed;
        private bool _isCirclePressed;
        public Cursor CurrentCursor { get; private set; }
        Model _model;

        public PresentationModel(Model model)
        {
            this._model = model;
            RefreshClickState();
        }

        public void ToolButtonClickHandler(string shapeType)
        {
            _model.SetDrawingMode(shapeType);
            RefreshClickState();
        }

        public void RefreshClickState()
        {
            this._isLinePressed = _model.IsLinePressed;
            this._isRectanglePressed = _model.IsRectanglePressed;
            this._isCirclePressed = _model.IsCirclePressed;
            _toolButtonClick?.Invoke(_isLinePressed, _isRectanglePressed, _isCirclePressed);
        }

        public void UpdateCursor()
        {
            if (IsToolButtonPressed())
                CurrentCursor = Cursors.Cross;
            else
                CurrentCursor = Cursors.Default;
        }

        private bool IsToolButtonPressed()
        {
            return _isLinePressed || _isRectanglePressed || _isCirclePressed;
        }
    }
}
