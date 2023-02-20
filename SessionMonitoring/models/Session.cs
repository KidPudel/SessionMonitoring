using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionMonitoring.models
{
    public class Session
    {
        public Session() {
            StartTime = DateTime.Now;
        }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // => EndTime.HasValue ? EndTime.Value - StartTime : TimeSpan.Zero;
        public TimeSpan? Duration { get; set; }
    }
}
