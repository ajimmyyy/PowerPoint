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

        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "PowerPoint";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "PowerPoint.exe");
            _robot = new Robot(targetAppPath, POWERPOINT_FORM);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

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

        
        [TestMethod]
        public void WindowScaleTest()
        {
            _robot.MouseDown("_windowSplitContainer", 215, 200);
            _robot.MouseUp(300, 0);
        }

        [TestMethod]
        public void DataGridViewScaleTest()
        {
            _robot.MouseDown("_dataGroupBox", 0, 200);
            _robot.MouseUp(-300, 0);
        }

        [TestMethod]
        public void AddPageTest()
        {
            _robot.ClickButton("新增頁面");
        }

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

        [TestMethod]
        public void SaveTest()
        {
            _robot.ClickButton("線");
            RunMoveShape(200, 200, 200, 200);
            _robot.ClickButton("save");
            _robot.ClickButtonByID("_saveButton");
            RunMoveShape(250, 250, 0, 0);
            RunMoveShape(250, 250, 100, 100);
        }


        private void RunMoveShape(int pointX, int pointY, int offsetX, int offsetY)
        {
            _robot.MouseDown("_canvas", pointX, pointY);
            _robot.MouseUp(offsetX, offsetY);
        }
    }
}
