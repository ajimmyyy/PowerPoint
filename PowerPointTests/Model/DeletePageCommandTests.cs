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
    public class DeletePageCommandTests
    {
        Shapes _page;
        Pages _pages;
        Model _model;
        PrivateObject _modelPrivate;
        DeletePageCommand _deletePageCommand;

        //測試DeletePageCommand初始化
        [TestInitialize()]
        public void Initialize()
        {
            _page = new Shapes();
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _pages = _modelPrivate.GetField("_pages") as Pages;
            _model.AddPage(_page);
            _deletePageCommand = new DeletePageCommand(_model, _page);
        }

        //測試DeletePageCommand執行命令
        [TestMethod()]
        public void ExecuteTest()
        {
            int expected = 1;
            _deletePageCommand.Execute();

            Assert.AreEqual(expected, _pages.Count);
        }

        //測試DeletePageCommand執行復原命令
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            int expected = 2;
            _deletePageCommand.Execute();
            _deletePageCommand.ReverseExecute();

            Assert.AreEqual(expected, _pages.Count);
        }
    }
}