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
        [DataRow("線", 10, 10, 100, 100)]
        [DataRow("矩形", 100, 100, 200, 200)]
        [DataRow("圓形", 200, 200, 300, 300)]
        public void DrawShapeTest(string shapeType, int pointX, int pointY, int offsetX, int offsetY)
        {
            string[] expected = new string[] {
                shapeType,
                string.Format("(({0}, {1}), ({2}, {3}))", pointX, pointY, pointX + offsetX, pointY + offsetY)
            };

            RunScriptDrawShape(shapeType, pointX, pointY, offsetX, offsetY);
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 1, expected);
        }

        private void RunScriptDrawShape(string shapeType, int pointX, int pointY, int offsetX, int offsetY)
        {
            _robot.ClickButton(shapeType);
            _robot.MouseDown("_canvas", pointX, pointY);
            _robot.MouseUp(offsetX, offsetY);
        }
    }
}
