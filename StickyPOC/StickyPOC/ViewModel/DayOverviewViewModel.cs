using StickyPOC.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace StickyPOC.ViewModel
{
    public class DayOverviewViewModel : ViewModelBase
    {
        public DayOverviewViewModel()
        {
            Tasks = new ObservableCollection<DayOverviewTaskViewModel>();
            IsSelected = false;
        }
       public ObservableCollection<DayOverviewTaskViewModel> Tasks { get; set; }

        public DateTime Date { get; set; }
        public string Day { get { return Date.Day.ToString(); } }

        public TimeSpan WorkedTime { get; set; }
        public string WorkedTimeShow { get { return WorkedTime.TotalHours.ToString("##0") + ":" + WorkedTime.Minutes.ToString("00"); } }

        private bool _IsSelected { get; set; }
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                this.OnPropertyChanged(nameof(this.IsSelected));
                this.OnPropertyChanged(nameof(this.ButtonBackGroundColor));
            }
        }
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
                        R = 0,
                        G = 115,
                        B = 193,
                    };
                }
            }
        }

    }
}
