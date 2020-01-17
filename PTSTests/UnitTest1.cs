using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTSLibrary;
namespace PTSTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParameterizedAuthTest1()
        {
            PTSAdminFacade facade = new PTSAdminFacade();
            Assert.AreEqual(facade.Authenticate("Eric", "4444"), 3);
        }
    }
}
