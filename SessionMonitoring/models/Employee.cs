using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionMonitoring.models
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string AccessLevel { get; set; }
        public Session Session { get; set; }
        public SessionStatus SessionStatus { get; set; }

        public Employee(string employeeName, string accessLevel, Session session, SessionStatus status)
        {
            EmployeeName = employeeName;
            AccessLevel = accessLevel;
            Session = session;
            SessionStatus = status;
        }
    }
}
