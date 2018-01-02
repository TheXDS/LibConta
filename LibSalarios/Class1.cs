using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSalarios
{
    public class LibSalarios
    {
    }

    public struct SalarioCalc
    {
        DateTime inicio, fin;
        decimal salario;

        public SalarioCalc(string fechaInicio, string fechaFin, decimal salario)
        {
            if (!DateTime.TryParse(fechaInicio, out inicio)) throw new ArgumentException(nameof(fechaInicio));
            if (!DateTime.TryParse(fechaFin, out fin)) throw new ArgumentException(nameof(fechaFin));

            this.salario = salario;
        }

        TimeSpan Antiguedad => fin - inicio;

        /// <summary>
        /// Obtiene los años de antigüedad.
        /// </summary>
        /// <remarks>
        /// El 365.25 toma en cuenta los años bisiestos.
        /// </remarks>
        public int AnosAntig => (int)(Antiguedad.Days / 365.25);

        public int MesesAntig
        {
            get
            {
                int m1 = inicio.Month;
                int m2 = fin.Month;
                return m1 < m2 ? m2 - m1 : (m2 + 12) - m1;
            }
        }

        public int DiasAntig
        {
            get
            {
                int d1 = inicio.Day > 30 ? 30 : inicio.Day;
                int d2 = fin.Day > 30 ? 30 : fin.Day;
                return d1 <= d2 ? d2 - d1 : (d2 + 30) - d1;
            }
        }


        public int DiasPromedio
        {
            get
            {
                return 12 - Antiguedad.Days;

            }
        }
    }
}
