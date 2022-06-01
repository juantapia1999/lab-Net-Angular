using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof (NotImplementedException))]
        public void NoImplementado()
        {
            Logic l = new Logic()
        }
    }
}
