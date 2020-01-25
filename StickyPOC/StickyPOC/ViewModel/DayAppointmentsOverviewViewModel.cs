using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyPOC.ViewModel
{
    public class DayAppointmentsOverviewViewModel : ViewModelBase
    {
        public bool IsSelected { get; set; }
        public DateTime Date { get; set; }
        public string Project { get; set; }
        public string Status { get; set; }
        public string TaskID { get; set; }
        public string Title { get; set; }
        public TimeSpan WorkedTime { get; set; }
        public string WorkedTimeShow
        {
            get
            {
                if (WorkedTime != null)
                {
                    return WorkedTime.TotalHours.ToString("0.00");
                }
                return "~";
            }
        }

        public DateTime DateTimeStart { get; set; }
        public string DateTimeStartShow
        {
            get
            {
                if (DateTimeStart != null)
                {
                    return DateTimeStart.Hour.ToString("00") + ":" + DateTimeStart.Minute.ToString("00");
                }
                return "~";
            }
        }
    }
}
