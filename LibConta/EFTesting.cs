using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MCART.Types.Extensions;
using System.Linq;
using System.Collections;

namespace LibConta
{
    /// <summary>
    /// Esta clase es compatible con Entity Framework (únicamente le falta 
    /// heredar la clase abstracta DbContext)
    /// </summary>
    public class TestDB //: DbContext
    {
        StringBuilder log = new StringBuilder();

        public readonly ObservableCollection<TestModel> Empleados;

        public TestDB()
        {
            Empleados = new ObservableCollection<TestModel>();
            Empleados.CollectionChanged += UpdtLog;
        }

        private void UpdtLog(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {            
            log.AppendLine($"{DateTime.Now}: {e.Action.ToString()} en colección observable de {sender.GetType().GetGenericArguments().Single().Name}");
            log.AppendLine("  - Elementos afectados:");
            foreach (var item in e.NewItems)
            {
                log.AppendLine($"   * {item.ToString()}");
            }
        }

        public string Log => log.ToString();
    }

    public class TestModel
    {
        public int Id;
        public string Name;
        public decimal Salario;
        public DateTime Inicio;

        public override string ToString()
        {
            return $"{Id} | {Name} | {Salario} | {Inicio}";
        }
    }
}