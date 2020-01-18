using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StickyPOC.ViewModel
{
    public class DayOverviewViewModel
    {
        public DateTime Date { get; set; }
        public string Day { get { return Date.Day.ToString(); } }

        public TimeSpan WorkedTime { get; set; }
        public string WorkedTimeShow { get { return WorkedTime.TotalHours.ToString("##0") + ":" + WorkedTime.Minutes.ToString("00"); } }

        public bool IsSelected { get; set; }
        public Color ButtonBackGroundColor
        {
            get
            {
                if (IsSelected)
                {
                    return new Color()
                    {
                        ScA = 0.3f,
                        R = 0,
                        G = 115,
                        B = 193,
                    };
                }
                else
                {
                    return new Color()
                    {
                        ScA = 0,
                        ScR = 1,
                        ScG = 1,
                        ScB = 1,
                    };
                }
            }
        }
    }
}
