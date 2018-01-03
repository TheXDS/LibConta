using System;
using Xunit;
using LibConta;
using static LibConta.Helpers;

namespace SalariosTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetYearsTest()
        {
            var fechaInicio = new DateTime(2005, 11, 01);
            var fechaFin = new DateTime(2017, 12, 31);

            decimal salario = 25000;

            // Crear un helper...
            var s = new PrestacionesHelper(fechaInicio, fechaFin, salario);

            Assert.NotEqual(default(PrestacionesHelper), s);

            Assert.Equal(12, s.AnosAntig);

            Assert.Equal(1, s.MesesAntig);

            Assert.Equal(29, s.DiasAntig);

        }

        [Fact]
        public void EFLogTest()
        {
            TestModel empleado1 = new TestModel
            {
                Id = 1,
                Name = "Jhon Doe",
                Salario = 20000,
                Inicio = new DateTime(1991, 11, 12)
            };

            var db = new TestDB();
            db.Empleados.Add(empleado1);

            // Si el log contiene algo, no debe porqué estar vacío.
            Assert.False(string.IsNullOrWhiteSpace(db.Log));
        }
    }
}