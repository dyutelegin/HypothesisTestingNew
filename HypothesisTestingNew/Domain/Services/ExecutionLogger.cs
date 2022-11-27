using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypothesisTestingNew.Domain.Services
{
    public interface IExecutionLogger
    {
        void AddLog(string log);

        IEnumerable<string> GetLog();
    }

public class ExecutionLogger : IExecutionLogger
    {
            private readonly ICollection<string> _log;

            public ExecutionLogger()
            {
                _log = new List<string>();
            }

            public void AddLog(string log)
            {
                _log.Add(log);
            }

            public IEnumerable<string> GetLog()
            {
                return _log;
            }
     }
}
