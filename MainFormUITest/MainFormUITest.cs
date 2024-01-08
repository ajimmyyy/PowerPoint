using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using OpenQA.Selenium;

namespace MainFormUITest
{
    [TestClass()]
    public class MainFormUITest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string POWERPOINT_FORM = "PowerPoint";

        //GUI測試初始化
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "PowerPoint";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "PowerPoint.exe");
            _robot = new Robot(targetAppPath, POWERPOINT_FORM);
        }

        //GUI測試清理
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        //GUI測試畫形狀
        [TestMethod]
        [DataRow("線", 200, 200, 300, 300, "((263, 263), (659, 659))")]
        [DataRow("矩形", 200, 200, 300, 300, "((263, 263), (659, 659))")]
        [DataRow("圓形", 200, 200, 300, 300, "((263, 263), (659, 659))")]
        public void DrawShapeTest(string shapeType, int pointX, int pointY, int offsetX, int offsetY, string expectedCoordinate)
        {
            string[] expected = new string[] {
                "刪除",
                shapeType,
                expectedCoordinate
            };

            _robot.ClickButton(shapeType);
            RunMoveShape(pointX, pointY, offsetX, offsetY);
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試RedoUndo刪除
        [TestMethod]
        public void UndoRedoDeleteTest()
        {
            string[] expected = new string[] {
                "刪除",
                "線",
                string.Format("(({0}, {1}), ({2}, {3}))", 395, 395, 659, 659)
            };

            _robot.ClickButton("線");
            RunMoveShape(300, 300, 200, 200);
            RunMoveShape(350, 350, 0, 0);
            _robot.PressKey(Keys.Delete);
            _robot.ClickButton("復原");
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試RedoUndo移動
        [TestMethod]
        public void UndoRedoMoveTest()
        {
            string[] expected = new string[] {
                "刪除",
                "線",
                string.Format("(({0}, {1}), ({2}, {3}))", 395, 395, 659, 659)
            };

            _robot.ClickButton("線");
            RunMoveShape(300, 300, 200, 200);
            RunMoveShape(250, 250, 0, 0);
            RunMoveShape(500, 500, 100, 100);
            _robot.ClickButton("復原");
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試RedoUndo縮圖
        [TestMethod]
        public void UndoRedoScaleTest()
        {
            string[] expected = new string[] {
                "刪除",
                "線",
                string.Format("(({0}, {1}), ({2}, {3}))", 395, 395, 659, 659)
            };

            _robot.ClickButton("線");
            RunMoveShape(300, 300, 200, 200);
            RunMoveShape(350, 350, 0, 0);
            RunMoveShape(500, 500, 100, 100);
            _robot.ClickButton("復原");
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試RedoUndoDataGridView
        [TestMethod]
        public void UndoRedoDataGridViewTest()
        {
            string[] expected = new string[] {
                "刪除",
                "線",
                string.Format("(({0}, {1}), ({2}, {3}))", 300, 300, 500, 500)
            };

            _robot.ClickComboBox("_shapeComboBox");
            _robot.EnterText("_shapeComboBox", "線");
            _robot.ClickButtonByID("_addButton");
            _robot.EnterText("_leftTopXBox", "300");
            _robot.EnterText("_leftTopYBox", "300");
            _robot.EnterText("_rightBottomXBox", "500");
            _robot.EnterText("_rightBottomYBox", "500");
            _robot.ClickButtonByID("_okButton");
            _robot.ClickButton("復原");
            _robot.ClickButton("重做");
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試縮放
        [TestMethod]
        public void ScaleTest()
        {
            string[] expected = new string[] {
                "刪除",
                "線",
                string.Format("(({0}, {1}), ({2}, {3}))", 395, 395, 659, 659)
            };

            _robot.ClickButton("線");
            RunMoveShape(300, 300, 100, 100);
            RunMoveShape(350, 350, 0, 0);
            RunMoveShape(400, 400, 100, 100);
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試移動
        [TestMethod]
        public void MoveTest()
        {
            string[] expected = new string[] {
                "刪除",
                "線",
                string.Format("(({0}, {1}), ({2}, {3}))", 395, 395, 659, 659)
            };

            _robot.ClickButton("線");
            RunMoveShape(200, 200, 200, 200);
            RunMoveShape(250, 250, 0, 0);
            RunMoveShape(250, 250, 100, 100);
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試DataGridView
        [TestMethod]
        [DataRow("線")]
        [DataRow("矩形")]
        [DataRow("圓形")]
        public void DataGridViewTest(string shapeType)
        {
            string[] expected = new string[] {
                "刪除",
                shapeType,
                string.Format("(({0}, {1}), ({2}, {3}))", 300, 300, 500, 500)
            };

            _robot.ClickComboBox("_shapeComboBox");
            _robot.EnterText("_shapeComboBox", shapeType);
            _robot.ClickButtonByID("_addButton");
            _robot.EnterText("_leftTopXBox", "300");
            _robot.EnterText("_leftTopYBox", "300");
            _robot.EnterText("_rightBottomXBox", "500");
            _robot.EnterText("_rightBottomYBox", "500");
            _robot.ClickButtonByID("_okButton");
                
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        //GUI測試視窗縮放
        [TestMethod]
        public void WindowScaleTest()
        {
            _robot.MouseDown("_windowSplitContainer", 215, 200);
            _robot.MouseUp(300, 0);
        }

        //GUI測試DataGridView縮放
        [TestMethod]
        public void DataGridViewScaleTest()
        {
            _robot.MouseDown("_dataGroupBox", 0, 200);
            _robot.MouseUp(-300, 0);
        }

        //GUI測試新增頁面
        [TestMethod]
        public void AddPageTest()
        {
            _robot.ClickButton("新增頁面");
        }

        //GUI測試刪除頁面
        [TestMethod]
        public void DeletePageTest()
        {
            _robot.ClickButton("新增頁面");
            _robot.Sleep(1);
            _robot.MouseDown("_windowSplitContainer", 100, 80);
            _robot.MouseUp(0, 0);
            _robot.Sleep(1);
            _robot.PressKey(Keys.Delete);
        }

        //GUI整合測試
        [TestMethod]
        public void SystemIntegrationTest()
        {
            _robot.ClickComboBox("_shapeComboBox");
            _robot.EnterText("_shapeComboBox", "矩形");
            _robot.ClickButtonByID("_addButton");
            _robot.EnterText("_leftTopXBox", "100");
            _robot.EnterText("_leftTopYBox", "100");
            _robot.EnterText("_rightBottomXBox", "1800");
            _robot.EnterText("_rightBottomYBox", "1000");
            _robot.ClickButtonByID("_okButton");

            _robot.ClickButton("圓形");
            RunMoveShape(300, 300, 100, 100);
            RunMoveShape(350, 350, 0, 0);
            RunMoveShape(400, 400, 100, 100);
            RunMoveShape(350, 350, 350, -200);

            _robot.ClickButton("圓形");
            RunMoveShape(600, 300, 300, 300);

            _robot.ClickButton("矩形");
            RunMoveShape(725, 170, 10, 10);

            _robot.ClickButton("矩形");
            RunMoveShape(780, 170, 10, 10);
            RunMoveShape(785, 175, 0, 0);
            RunMoveShape(785, 175, -25, 300);
            _robot.ClickButton("復原");

            _robot.ClickButton("線");
            RunMoveShape(500, 200, 500, 200);
            RunMoveShape(500, 200, 0, 0);
            _robot.PressKey(Keys.Delete);

            _robot.ClickButton("線");
            RunMoveShape(450, 200, 150, 250);

            _robot.ClickButton("線");
            RunMoveShape(1050, 200, -150, 250);

            _robot.ClickButton("圓形");
            RunMoveShape(500, 600, 600, 200);
            _robot.ClickButton("復原");
            _robot.ClickButton("重做");

            RunMoveShape(550, 650, 0, 0);
            RunMoveShape(550, 650, -70, -50);

            _robot.ClickButton("新增頁面");
            _robot.Sleep(1);
            _robot.MouseDown("_windowSplitContainer", 100, 200);
            _robot.MouseUp(0, 0);
            _robot.Sleep(1);
            _robot.PressKey(Keys.Delete);
        }

        //GUI測試移動同形
        private void RunMoveShape(int pointX, int pointY, int offsetX, int offsetY)
        {
            _robot.MouseDown("_canvas", pointX, pointY);
            _robot.MouseUp(offsetX, offsetY);
        }
    }
}
