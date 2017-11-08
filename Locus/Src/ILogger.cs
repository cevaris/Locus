using System;
using System.Collections.Generic;
using System.Linq;

namespace Locus
{
    public interface ILogger
    {
        void Error(object obj);
        void Error(object obj, Exception e);
        void Error(object obj, AggregateException e);
        void Info(object obj);
        void Info(params object[] objs);
    }

    public class ConsoleLogger : ILogger
    {
        String Scope { get; set; }

        public ConsoleLogger(string scope)
        {
            Scope = scope;
        }

        public void Info(object obj)
        {
            System.Diagnostics.Debug.WriteLine($"{prefix("INFO")} - {obj}");
        }

        public void Error(object obj)
        {
            System.Diagnostics.Debug.WriteLine($"{prefix("ERROR")} - {obj}");
        }

        public void Error(object obj, Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"{prefix("ERROR")} - {obj} - {e.Message}");
        }

        public void Error(object obj, AggregateException e)
        {
            System.Diagnostics.Debug.WriteLine($"{prefix("ERROR")} - {obj}");
            foreach (var inner in e.InnerExceptions)
            {
                System.Diagnostics.Debug.WriteLine($"{inner.Message}");
            }
        }

        private string prefix(string level)
        {
            string now = DateTime.UtcNow.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            string scope = Scope == null ? "root" : Scope;
            return $"{now} - {level} - {scope}";
        }

        public void Info(params object[] objs)
        {
            List<string> strObjs = objs.Select(x => x.ToString()).ToList();
            System.Diagnostics.Debug.WriteLine($"{prefix("INFO")} - {string.Join(" ", strObjs)}");   
        }
    }
}