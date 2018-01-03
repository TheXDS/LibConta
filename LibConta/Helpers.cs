using System;
using MCART;

namespace LibConta
{
    /// <summary>
    /// Contiene Helpers para realizar cálculos contables.
    /// </summary>
    public static class Helpers
    {

    }

    /// <summary>
    /// Clase auxiliar que permite realizar cálculos sobre prestaciones de los
    /// empleados.
    /// </summary>
    public class PrestacionesHelper
    {
        const int MonthDays = 30;
        DateTime inicio, fin;
        decimal salario;

        public PrestacionesHelper(DateTime fechaInicio, DateTime fechaFin, decimal salario)
        {
            inicio = fechaInicio;
            fin = fechaFin;
            this.salario = salario;
        }

        /// <summary>
        /// Obtiene la antigüedad exacta del empleado.
        /// </summary>
        public TimeSpan Antiguedad => fin - inicio;

        /// <summary>
        /// Obtiene los años de antigüedad del empleado.
        /// </summary>
        /// <remarks>
        /// El 365.25 toma en cuenta los años bisiestos.
        /// </remarks>
        public int AnosAntig => (int)(Antiguedad.Days / 365.25);

        /// <summary>
        /// A partir del año actual, obtiene los meses de antigüedad del
        /// empleado.
        /// </summary>
        public int MesesAntig
        {
            get
            {
                int m1 = inicio.Month;
                int m2 = fin.Month;
                return m1 < m2 ? m2 - m1 : (m2 + 12) - m1;
            }
        }

        /// <summary>
        /// A partir del mes actual, obtiene los días de antigüedad del
        /// empleado.
        /// </summary>
        public int DiasAntig
        {
            get
            {
                int d1 = inicio.Day.Clamp(MonthDays);
                int d2 = fin.Day.Clamp(MonthDays);
                return d1 <= d2 ? d2 - d1 : (d2 + MonthDays) - d1;
            }
        }
    }
}