﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public event ModelChangedEventHandler _gridViewChanged;
        public delegate void ModelChangedEventHandler();
        private string _toolModePressed = "";
        private bool _isPressed = false;
        private double _firstPointX;
        private double _firstPointY;
        private Shape _hint;
        private Selection _selection = new Selection(null);
        private Shapes _shapes = new Shapes();

        //當DataGridView新增按鈕被按下的處理
        public void AddButtonClickEvent(string shapeType)
        {
            if (shapeType == "")
            {
                return;
            }

            _shapes.AddNewShape(shapeType);
            NotifyModelChanged();
            NotifyGridViewChanged();
        }

        //當DataGridView刪除按鈕被按下的處理
        public void DeleteButtonClickEvent(int rowIndex, int columnIndex)
        {
            _selection.Unselect();

            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.DeleteShape(rowIndex);
            }

            NotifyModelChanged();
            NotifyGridViewChanged();
        }

        //回傳list裡的資訊做顯示
        public List<ShapeGridViewModel> GetShapesDisplay()
        {
            return _shapes.GetShapeListInfo();
        }

        //滑鼠被按下
        public void PressPointer(IState state)
        {
            _isPressed = true;
            state.MouseDown();
        }

        //滑鼠移動
        public void MovePointer(IState state)
        {
            state.MouseMove();
            NotifyModelChanged();
        }

        //滑鼠釋放
        public void ReleasePointer(IState state)
        {
            state.MouseRelease();
            _isPressed = false;
            _toolModePressed = "";
            NotifyModelChanged();
            NotifyGridViewChanged();
        }

        //鍵盤刪除按下
        public void PressDelete(IState state)
        {
            state.DeletePress();
            NotifyModelChanged();
            NotifyGridViewChanged();
        }

        //創建即時形狀
        public void CreateHint()
        {
            _hint = Factory.CreateShape(_toolModePressed);
        }

        //設定即時形狀位置
        public void SetHintPosition(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint.SetPosition(_firstPointX, _firstPointY, pointX, pointY);
            }
        }

        //加入即時形狀
        public void AddHint()
        {
            if (_isPressed)
            {
                _shapes.AddShape(_hint);
                _hint = null;
            }
        }

        //設定起始點
        public void SetFirstPoint(double pointX, double pointY)
        {
            _firstPointX = pointX;
            _firstPointY = pointY;
        }

        //選擇形狀
        public void SelectShape(double pointX, double pointY)
        {
            _selection.ShapeSelect = _shapes.FindShape(pointX, pointY);
            SetFirstPoint(pointX, pointY);
        }

        //移動形狀
        public void MoveShape(double pointX, double pointY)
        {
            if (_isPressed)
            {
                Coordinate range = _selection.ShapeRange;
                double distanceX = pointX - _firstPointX;
                double distanceY = pointY - _firstPointY;

                _selection.SetPosition(range._left + distanceX, range._top + distanceY, range._right + distanceX, range._bottom + distanceY);
                _selection.UpdatePosition();
                SetFirstPoint(pointX, pointY);
            }
        }

        //刪除選取形狀
        public void DeleteShape()
        {
            _shapes.DeleteShape(_selection.ShapeSelect);
            _selection.Unselect();
        }

        //畫出所有形狀和即時形狀
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            _selection.Draw(graphics);

            if (_isPressed && _hint != null)
                _hint.Draw(graphics);                
        }

        //通知模型改變
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        //通知DataGridView改變
        void NotifyGridViewChanged()
        {
            if (_gridViewChanged != null)
                _gridViewChanged();
        }

        //設定繪圖模式
        public void SetToolMode(string shapeType)
        {
            _toolModePressed = shapeType;
        }
    }
}
