using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyPOC.ViewModel
{
   public class DayOverviewTaskViewModel : ViewModelBase
    {
        public string TaskID { get; set; }
        public string Project { get; set; }
        public string Status { get; set; }
        public TimeSpan WorkedTime { get; set; }
        public string WorkedTimeShow { get { return WorkedTime.TotalHours.ToString("##0") + ":" + WorkedTime.Minutes.ToString("00"); } }

    }
}
