using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyPOC.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string HeaderDate
        {
            get
            {
                if (DailyAppointmentsViewModel != null)
                {
                    string ret = DailyAppointmentsViewModel.SelectedDay.Date.ToString("ddd, dd") +
                        " de " +
                       DailyAppointmentsViewModel.SelectedDay.Date.ToString("MMM");

                    ret = ret.ToLower();

                    return ret.First().ToString().ToUpper() + ret.Substring(1);
                }
                return "--";
            }
        }

        private DailyAppointmentsViewModel _DailyAppointmentsViewModel { get; set; }
        public DailyAppointmentsViewModel DailyAppointmentsViewModel
        {
            get
            {
                return _DailyAppointmentsViewModel;
            }
            set
            {
                _DailyAppointmentsViewModel = value;
                OnPropertyChanged("DailyAppointmentsViewModel");
                OnPropertyChanged("HeaderDate");
            }
        }
    }
}
