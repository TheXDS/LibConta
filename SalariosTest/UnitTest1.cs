using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibSalarios;
using static LibSalarios.LibSalarios;

namespace SalariosTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetYearsTest()
        {
            // diferencia de 12 años
            string fechaInicio = "2005-11-01";
            string fechaFin = "2017-12-31";

            decimal salario = 25000;

            SalarioCalc s = new SalarioCalc(
                fechaInicio, fechaFin, salario);

            Assert.AreNotEqual(default(SalarioCalc), s);

            Assert.AreEqual(12, s.AnosAntig);

            Assert.AreEqual(1, s.MesesAntig);

            Assert.AreEqual(2, s.DiasAntig);

        }
    }
}
