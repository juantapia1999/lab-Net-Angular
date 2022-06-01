using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicioExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioExcepciones.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void NoImplementadoTest()
        {
            Logic l = new Logic();
            //l.DisparadorExcepcion(); //esto genera que no pase el test porque genera otro tipo de excepcion
            l.NoImplementado();
            //Assert.Fail();
        }
    }
}