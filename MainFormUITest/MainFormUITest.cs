using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
        [DataRow("線", 230, 230, 150, 150)]
        [DataRow("矩形", 300, 300, 200, 200)]
        [DataRow("圓形", 300, 300, 300, 300)]
        public void DrawShapeTest(string shapeType, int pointX, int pointY, int offsetX, int offsetY)
        {
            string[] expected = new string[] {
                "刪除",
                shapeType,
                string.Format("(({0}, {1}), ({2}, {3}))", pointX - 1, pointY - 1, pointX + offsetX - 1, pointY + offsetY - 1)
            };

            _robot.ClickButton(shapeType);
            RunScriptDrawShape(pointX, pointY, offsetX, offsetY);
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        [TestMethod]
        public void UndoRedoTest()
        {
            string[] expected = new string[] {
                "刪除",
                "線",
                string.Format("(({0}, {1}), ({2}, {3}))", 299, 299, 499, 499)
            };

            _robot.ClickButton("線");
            RunScriptDrawShape(300, 300, 200, 200);
            _robot.ClickButton("復原");
            _robot.ClickButton("重做");
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, expected);
        }

        [TestMethod]
        public void DataGridViewTest()
        {
            _robot.MouseDown("_shapeComboBox", 1, 1);
            _robot.ClickButton("新增");
        }


        private void RunScriptDrawShape(int pointX, int pointY, int offsetX, int offsetY)
        {
            _robot.MouseDown("_canvas", pointX, pointY);
            _robot.MouseUp(offsetX, offsetY);
        }

        private void RunScaleShape(int pointX, int pointY, int offsetX, int offsetY)
        {
            _robot.MouseDown("_canvas", pointX, pointY);
            _robot.MouseUp(offsetX, offsetY);
        }
    }
}
