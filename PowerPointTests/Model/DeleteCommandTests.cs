using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class DeleteCommandTests
    {
        Shape _shape;
        Model _model;
        PrivateObject _modelPrivate;
        DeleteCommand _deleteCommand;

        //測試DeleteCommand初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line(0, 0, 0, 0);
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _deleteCommand = new DeleteCommand(_model, _shape);

            _model.AddShape(_shape);
        }

        //測試DeleteCommand執行命令
        [TestMethod()]
        public void ExecuteTest()
        {
            int expectedCount = 0;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _deleteCommand.Execute();

            Assert.AreEqual(expectedCount, shapes.GetCount());
        }

        //測試DeleteCommand執行復原命令
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            int expectedCount = 1;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _deleteCommand.Execute();
            _deleteCommand.ReverseExecute();

            Assert.AreEqual(expectedCount, shapes.GetCount());
        }
    }
}