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
    public class AddPageCommandTests
    {
        Shapes _page;
        Pages _pages;
        Model _model;
        PrivateObject _modelPrivate;
        AddPageCommand _addPageCommand;

        //測試AddPageCommand初始化
        [TestInitialize()]
        public void Initialize()
        {
            _page = new Shapes();
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _pages = _modelPrivate.GetField("_pages") as Pages;
            _addPageCommand = new AddPageCommand(_model);
        }

        //測試AddPageCommand執行命令
        [TestMethod()]
        public void ExecuteTest()
        {
            int expected = 2;
            _addPageCommand.Execute();

            Assert.AreEqual(expected, _pages.Count);
        }

        //測試AddPageCommand執行復原命令
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            int expected = 1;
            _addPageCommand.Execute();
            _addPageCommand.ReverseExecute();

            Assert.AreEqual(expected, _pages.Count);
        }
    }
}