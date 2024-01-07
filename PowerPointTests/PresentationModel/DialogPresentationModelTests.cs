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
    public class DialogPresentationModelTests
    {
        DialogPresentationModel _dialogPresentationModel;

        //測試DialogPresentationModel初始化
        [TestInitialize]
        public void Initialize()
        {
            _dialogPresentationModel = new DialogPresentationModel();
        }

        //測試DialogPresentationModel數字是否合法
        [TestMethod()]
        public void IsValidNumberTest()
        {
            string[] coordinate = { "2", "4", "6", "8"};
            int[] maxRange = { 1980, 1080, 1980, 1080 };

            Assert.IsTrue(_dialogPresentationModel.IsValidNumber(coordinate, maxRange));

            coordinate = new string[] { "1981", "4", "6", "8" };
            maxRange = new int[] { 1980, 1080, 1980, 1080 };

            Assert.IsFalse(_dialogPresentationModel.IsValidNumber(coordinate, maxRange));
        }
    }
}