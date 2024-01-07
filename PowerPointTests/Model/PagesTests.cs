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
    public class PagesTests
    {
        Pages _pages;
        PrivateObject _pagePrivate;

        //測試Pages初始化
        [TestInitialize()]
        public void Initialize()
        {
            _pages = new Pages();
            _pagePrivate = new PrivateObject(_pages);
        }

        //測試Pages加入新頁面
        [TestMethod()]
        public void AddPageTest()
        {
            int expected = 1;
            Shapes page = new Shapes();
            _pages.AddPage(page);

            Assert.AreEqual(expected, _pages.Count);
        }

        //測試Pages刪除頁面
        [TestMethod()]
        public void DeletePageTest()
        {
            int expected = 0;
            Shapes page = new Shapes();
            _pages.AddPage(page);
            _pages.DeletePage(page);

            Assert.AreEqual(expected, _pages.Count);
        }

        //測試Pages取得頁面
        [TestMethod()]
        public void GetPageTest()
        {
            Shapes page = new Shapes();
            _pages.AddPage(page);
            Shapes pageGet = _pages.GetPage(0);

            Assert.AreSame(page, pageGet);
        }

        //測試Pages取得頁面index
        [TestMethod()]
        public void GetPageIndexTest()
        {
            int expected = 0;
            Shapes page = new Shapes();
            _pages.AddPage(page);
            int index = _pages.GetPageIndex(page);

            Assert.AreEqual(expected, index);
        }

        //測試Pages取得頁面
        [TestMethod()]
        public void GetPageListTest()
        {
            List<Shapes> pageList = _pagePrivate.GetFieldOrProperty("_pages") as List<Shapes>;

            Assert.AreSame(pageList, _pages.PagesList);
        }

        //測試Pages設定PageList
        [TestMethod()]
        public void SetPageListTest()
        {
            List<Shapes> pageList = new List<Shapes>();
            _pages.PagesList = pageList;

            Assert.AreSame(pageList, _pages.PagesList);
        }
    }
}