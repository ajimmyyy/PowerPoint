using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ModelTests
    {
        const double INIT_LEFT = 1;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 300;
        Shape _shape;
        Shapes _shapes;
        Pages _pages;
        Model _model;
        PrivateObject _modelPrivate;
        private string _tempFilePath;

        //測試Model初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _shapes = new Shapes();
            _pages = new Pages();
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _shapes = _modelPrivate.GetField("_shapes") as Shapes;
            _pages = _modelPrivate.GetField("_pages") as Pages;
            _tempFilePath = Path.Combine(Directory.GetCurrentDirectory(), "test.json");
        }

        //測試Model清理
        [TestCleanup]
        public void Cleanup()
        {
            if (System.IO.File.Exists(_tempFilePath))
            {
                System.IO.File.Delete(_tempFilePath);
            }
        }

        //測試Model當DataGridView新增按鈕被按下的處理
        [TestMethod()]
        public void AddButtonClickEventTest()
        {
            List<string> testShapeName = new List<string> { ModeType.LINE_NAME, ModeType.CIRCLE_NAME, ModeType.RECTANGLE_NAME };
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            int[] coordinate = new int[] { 0, 0, 0, 0 };

            for (int i = 0; i < testShapeName.Count; i++)
            {
                _model.AddButtonClickEvent(testShapeName[i], coordinate);
                Assert.IsTrue(shapes.GetCount() == i + 1);
            }
            _model.AddButtonClickEvent("", coordinate);
            Assert.IsTrue(shapes.GetCount() == testShapeName.Count);
        }

        //測試Model當DataGridView刪除按鈕被按下的處理
        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(-1, 0, 1)]
        [DataRow(0, 1, 1)]
        public void DeleteButtonClickEventTest(int rowIndex, int columnIndex, int expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            int[] coordinate = new int[] { 0, 0, 0, 0 };

            _model.AddButtonClickEvent(ModeType.LINE_NAME, coordinate);
            _model.DeleteButtonClickEvent(rowIndex, columnIndex);

            Assert.AreEqual(expected, shapes.GetCount());
        }

        //測試Model滑鼠被按下
        [TestMethod()]
        public void PressPointerTest()
        {
            bool expectedIsPressed = true;
            int expectedPressPointer = 1;
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);

            _model.PressPointer(0, 0);

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedPressPointer, state.MouseDownCount);
        }

        //測試Model滑鼠移動
        [TestMethod()]
        public void MovePointerTest()
        {
            int expectedMovePointer = 1;
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", true);

            _model.MovePointer(0, 0);

            Assert.AreEqual(expectedMovePointer, state.MouseMoveCount);
        }

        //測試Model滑鼠移動(未按下)
        [TestMethod()]
        public void MovePointerNullPressTest()
        {
            int expectedMovePointer = 0;
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", false);

            _model.MovePointer(0, 0);

            Assert.AreEqual(expectedMovePointer, state.MouseMoveCount);
        }

        //測試Model滑鼠釋放
        [TestMethod()]
        public void ReleasePointerTest()
        {
            int expectedReleasePointer = 1;
            bool expectedIsPressed = false;
            String expectedToolModePressed = "";
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", true);

            _model.ReleasePointer();

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedToolModePressed, _modelPrivate.GetField("_toolModePressed"));
            Assert.AreEqual(expectedReleasePointer, state.MouseReleaseCount);
        }

        //測試Model滑鼠釋放(未按下)
        [TestMethod()]
        public void ReleasePointerNullPressTest()
        {
            int expectedReleasePointer = 0;
            bool expectedIsPressed = false;
            String expectedToolModePressed = ModeType.SELECT_NAME;
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", false);

            _model.ReleasePointer();

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedToolModePressed, _modelPrivate.GetField("_toolModePressed"));
            Assert.AreEqual(expectedReleasePointer, state.MouseReleaseCount);
        }

        //測試Model鍵盤刪除按下
        [TestMethod()]
        public void PressDeleteTest()
        {
            int expected = 0;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);

            _modelPrivate.SetField("_selection", _shape);
            _model.PressDelete();

            Assert.AreEqual(expected, shapes.GetCount());
            Assert.IsNull(_modelPrivate.GetField("_selection"));
        }

        //測試Model鍵盤刪除按下(未選取)
        [TestMethod()]
        public void PressDeleteNullSelectTest()
        {
            int expected = 1;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);

            _model.PressDelete();

            Assert.AreEqual(expected, shapes.GetCount());
        }

        //測試Model改變操作模式(縮放模式)
        [TestMethod()]
        public void ChangeStateScaleTest()
        {
            _modelPrivate.SetField("_selection", _shape);
            _modelPrivate.SetField("_isInScaleArea", true);
            _model.ChangeState(0, 0);

            IState state = _modelPrivate.GetField("_state") as IState;

            Assert.IsNotNull(state);
        }

        //測試Model改變操作模式(圖形模式)
        [TestMethod()]
        public void ChangeStateToolTest()
        {
            _modelPrivate.SetField("_selection", _shape);
            _modelPrivate.SetField("_toolModePressed", ModeType.LINE_NAME);
            _model.ChangeState(0, 0);

            IState state = _modelPrivate.GetField("_state") as IState;
            Shape hint = _modelPrivate.GetField("_hint") as Shape;

            Assert.IsNotNull(state);
            Assert.IsNotNull(hint);
        }

        //測試Model紀錄命令
        [TestMethod()]
        public void LogCommandTest()
        {
            int expected = 1;
            CommandManagerMock commandManager = new CommandManagerMock();
            ICommand command = new DrawCommand(_model, _shape, _shapes);
            _modelPrivate.SetField("_commandManager", commandManager);

            _model.LogCommand(command);

            Assert.AreEqual(expected, commandManager.ExecuteCount);
        }

        //測試Model加入形狀
        [TestMethod()]
        public void AddShapeTest()
        {
            int expected = 1;

            _model.AddShape(_shape, _shapes);

            Assert.AreEqual(expected, _shapes.GetCount());
        }

        //測試Model刪除形狀
        [TestMethod()]
        public void DeleteShapeTest()
        {
            int expected = 0;

            _model.AddShape(_shape, _shapes);
            _model.DeleteShape(_shape, _shapes);

            Assert.AreEqual(expected, _shapes.GetCount());
        }

        //測試Model移動形狀
        [TestMethod()]
        public void MoveShapeTest()
        {
            Coordinate coordinate = _shape.GetPosition().Clone();
            Shape selection = new Line(0, 0, 0, 0);

            _model.MoveShape(selection, coordinate, _shapes);

            Assert.AreEqual(INIT_LEFT, selection.GetPosition()._left);
            Assert.AreEqual(INIT_TOP, selection.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT, selection.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM, selection.GetPosition()._bottom);
        }

        //測試Model加入新頁面
        [TestMethod()]
        public void ClickNewPageTest()
        {
            int expected = 1;
            CommandManagerMock commandManager = new CommandManagerMock();
            _modelPrivate.SetField("_commandManager", commandManager);
            _model.ClickNewPage();

            Assert.AreEqual(expected, commandManager.ExecuteCount);
        }

        //測試Model刪除頁面
        [TestMethod()]
        [DataRow(0)]
        [DataRow(1)]
        public void ClickDeletePageTest(int index)
        {
            int expected = 1;
            Shapes page = new Shapes();
            CommandManagerMock commandManager = new CommandManagerMock();
            _modelPrivate.SetField("_commandManager", commandManager);
            _model.AddPage(page);
            _model.ClickDeletePage(index);

            Assert.AreEqual(expected, commandManager.ExecuteCount);
        }

        //測試Model改變選取頁面
        [TestMethod()]
        public void ChangePageTest()
        {
            _model.ChangePage(0);
            Shapes shapes = _modelPrivate.GetField("_shapes") as Shapes;

            Assert.AreSame(_shapes, shapes);
        }

        //測試Model加入新頁面
        [TestMethod()]
        public void AddPageTest()
        {
            int expected = 2;
            Shapes page = new Shapes();
            _model.AddPage(page);

            Assert.AreEqual(expected, _pages.Count);
        }

        //測試Model刪除頁面
        [TestMethod()]
        public void DeletePageTest()
        {
            int expected = 1;
            Shapes page = new Shapes();
            _model.AddPage(page);
            _model.DeletePage(_shapes);

            Assert.AreEqual(expected, _pages.Count);
        }

        //測試Model保存頁面
        [TestMethod()]
        public void SavePagesTest()
        {
            _model.SavePages(_tempFilePath);
            var fileContent = System.IO.File.ReadAllText(_tempFilePath);
            var deserializedPages = JsonConvert.DeserializeObject<Pages>(fileContent);

            Assert.IsNotNull(deserializedPages);
        }

        //測試Model載入頁面
        [TestMethod()]
        public void LoadPagesTest()
        {
            _model.SavePages(_tempFilePath);
            _model.LoadPages(_tempFilePath);

            Assert.IsNotNull(_pages);
        }

        //測試Model更新頁面
        [TestMethod()]
        [DataRow(1, 2)]
        [DataRow(2, 1)]
        public void UpdatePagesTest(int pageCount, int pageNow)
        {
            bool eventRaised = false;
            _model._modelChanged += (int i) => eventRaised = true;
            _model.UpdatePages(pageCount, pageNow);
        
            Assert.IsTrue(eventRaised);
        }

        //測試Model改變操作模式(選取模式)
        [TestMethod()]
        public void ChangeStateSelectTest()
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_selection", _shape);
            _modelPrivate.SetField("_toolModePressed", ModeType.SELECT_NAME);

            _model.ChangeState(INIT_LEFT, INIT_TOP);

            IState state = _modelPrivate.GetField("_state") as IState;
            Shape selection = _modelPrivate.GetField("_selection") as Shape;

            Assert.IsNotNull(state);
            Assert.IsNotNull(selection);
        }

        //測試Model選取圖形
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(INIT_LEFT, INIT_TOP, true)]
        public void SelectShapeTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _shape.SetSelect(true);
            _modelPrivate.SetField("_selection", _shape);

            shapes.AddShape(_shape);
            _model.SelectShape(pointX, pointY);

            Shape selection = _modelPrivate.GetField("_selection") as Shape;

            Assert.AreEqual(expected, selection != null);
            Assert.AreEqual(false, _shape.IsSelect());
        }

        //測試Model選取圖形(已選取)
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(INIT_LEFT, INIT_TOP, true)]
        public void SelectShapeHadSelectTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;


            shapes.AddShape(_shape);
            _model.SelectShape(pointX, pointY);

            Shape selection = _modelPrivate.GetField("_selection") as Shape;

            Assert.AreEqual(expected, selection != null);
        }

        //測試Model操作復原
        [TestMethod()]
        public void UndoTest()
        {
            int expected = 1;
            CommandManagerMock commandManager = new CommandManagerMock();
            _modelPrivate.SetField("_commandManager", commandManager);

            _model.Undo();

            Assert.AreEqual(expected, commandManager.UndoCount);
        }

        //測試Model操作重做
        [TestMethod()]
        public void RedoTest()
        {
            int expected = 1;
            CommandManagerMock commandManager = new CommandManagerMock();
            _modelPrivate.SetField("_commandManager", commandManager);

            _model.Redo();

            Assert.AreEqual(expected, commandManager.RedoCount);
        }

        //測試Model繪圖
        [TestMethod()]
        public void DrawTest()
        {
            int expectedClear = 1;
            int expectedLine = 1;
            int expectedCircle = 1;
            int expectedRectangle = 0;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();
            Shape hint = Factory.CreateShape(ModeType.CIRCLE_NAME);
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_toolModePressed", ModeType.CIRCLE_NAME);
            _modelPrivate.SetField("_isPressed", true);

            shapes.AddShape(_shape);
            _shape.SetSelect(true);
            _modelPrivate.SetField("_hint", hint);

            _model.Draw(graphics);

            Assert.AreEqual(expectedClear, graphics.ClearAllCount);
            Assert.AreEqual(expectedLine, graphics.DrawLineCount);
            Assert.AreEqual(expectedCircle, graphics.DrawCircleCount);
            Assert.AreEqual(expectedRectangle, graphics.DrawRectangleCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }

        //測試Model繪圖(無即時形狀)
        [TestMethod()]
        public void DrawTestNoHint()
        {
            int expectedClear = 1;
            int expectedLine = 1;
            int expectedCircle = 0;
            int expectedRectangle = 0;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_toolModePressed", ModeType.CIRCLE_NAME);
            _modelPrivate.SetField("_isPressed", false);

            shapes.AddShape(_shape);
            _shape.SetSelect(true);

            _model.Draw(graphics);

            Assert.AreEqual(expectedClear, graphics.ClearAllCount);
            Assert.AreEqual(expectedLine, graphics.DrawLineCount);
            Assert.AreEqual(expectedCircle, graphics.DrawCircleCount);
            Assert.AreEqual(expectedRectangle, graphics.DrawRectangleCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }

        //測試Model縮圖繪圖
        [TestMethod()]
        public void DrawSlideTest()
        {
            int expectedClear = 1;
            int expectedLine = 1;
            int expectedCircle = 1;
            int expectedRectangle = 0;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();
            Shape hint = Factory.CreateShape(ModeType.CIRCLE_NAME);
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_toolModePressed", ModeType.CIRCLE_NAME);
            _modelPrivate.SetField("_isPressed", true);

            shapes.AddShape(_shape);
            _shape.SetSelect(true);
            _modelPrivate.SetField("_hint", hint);

            _model.DrawSlide(graphics, 0);

            Assert.AreEqual(expectedClear, graphics.ClearAllCount);
            Assert.AreEqual(expectedLine, graphics.DrawLineCount);
            Assert.AreEqual(expectedCircle, graphics.DrawCircleCount);
            Assert.AreEqual(expectedRectangle, graphics.DrawRectangleCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }

        //測試Model縮圖繪圖(無即時形狀)
        [TestMethod()]
        public void DrawSlideTestNoHint()
        {
            int expectedClear = 1;
            int expectedLine = 1;
            int expectedCircle = 0;
            int expectedRectangle = 0;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();

            _modelPrivate.SetField("_toolModePressed", ModeType.CIRCLE_NAME);
            _modelPrivate.SetField("_isPressed", false);

            _shapes.AddShape(_shape);
            _shape.SetSelect(true);
            _model.DrawSlide(graphics, 0);

            Assert.AreEqual(expectedClear, graphics.ClearAllCount);
            Assert.AreEqual(expectedLine, graphics.DrawLineCount);
            Assert.AreEqual(expectedCircle, graphics.DrawCircleCount);
            Assert.AreEqual(expectedRectangle, graphics.DrawRectangleCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }

        //測試Model通知模型改變
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            bool eventRaised = false;
            _model._modelChanged += (int i) => eventRaised = true;

            _modelPrivate.Invoke("NotifyModelChanged");
            Assert.IsTrue(eventRaised);
        }

        //測試Model通知頁面新增
        [TestMethod()]
        public void NotifyPageAddTest()
        {
            bool eventRaised = false;
            _model._pageAdd += () => eventRaised = true;

            _modelPrivate.Invoke("NotifyPageAdd", 1);
            Assert.IsTrue(eventRaised);
        }

        //測試Model通知頁面刪除
        [TestMethod()]
        public void NotifyPageDeleteTest()
        {
            bool eventRaised = false;
            _model._pageDelete += (int i) => eventRaised = true;

            _modelPrivate.Invoke("NotifyPageDelete", 1);
            Assert.IsTrue(eventRaised);
        }

        //測試Model設定繪圖模式
        [TestMethod()]
        [DataRow(ModeType.LINE_NAME)]
        [DataRow(ModeType.CIRCLE_NAME)]
        [DataRow(ModeType.RECTANGLE_NAME)]
        public void SetToolModeTest(string shapeType)
        {
            _model.SetToolMode(shapeType);

            Assert.AreEqual(shapeType, _modelPrivate.GetField("_toolModePressed"));
        }

        //測試Model是否在縮放區域
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(400, 300, true)]
        public void IsInScaleAreaTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_selection", _shape);

            _model.IsInScaleArea(pointX, pointY, 1);

            Assert.AreEqual(expected, _modelPrivate.GetField("_isInScaleArea"));
        }

        //測試Model是否在縮放區域(無選取)
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(400, 300, false)]
        public void IsInScaleAreaNullSelectTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_selection", null);

            _model.IsInScaleArea(pointX, pointY, 1);

            Assert.AreEqual(expected, _modelPrivate.GetField("_isInScaleArea"));
        }

        //Undo是否enabled
        [TestMethod()]
        public void IsUndoEnabledTest()
        {
            Assert.IsFalse(_model.IsUndoEnabled);
        }

        //Redo是否enabled
        [TestMethod()]
        public void IsRedoEnabledTest()
        {
            Assert.IsFalse(_model.IsRedoEnabled);
        }

        //測試Model取得binding List
        [TestMethod()]
        public void GetShapeListTest()
        {
            Assert.IsNotNull(_model.ShapeList);
        }
    }
}