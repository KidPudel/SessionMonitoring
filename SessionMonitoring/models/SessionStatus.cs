using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionMonitoring.models
{
    public class SessionStatus
    {
        public bool IsActive { get; set; }

        public string Status { get; set; }

        public SessionStatus(string status, bool isActive)
        {
            Status = status;
            IsActive = isActive;
        }
    }
}
