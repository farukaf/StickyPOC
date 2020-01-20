using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StickyPOC.ViewModel
{
    public class DailyTasksViewModel : ViewModelBase
    {
        public DailyTasksViewModel()
        {
            DayList = new ObservableCollection<DayOverviewViewModel>();

            DayList.Add(new DayOverviewViewModel()
            {
                Date = DateTime.Now.AddDays(-3),
                WorkedTime = new TimeSpan(28, 10, 0)
            }); ;
            DayList.Add(new DayOverviewViewModel()
            {
                Date = DateTime.Now.AddDays(-2),
                WorkedTime = new TimeSpan(3, 10, 0)
            });
            DayList.Add(new DayOverviewViewModel()
            {
                Date = DateTime.Now.AddDays(-1),
                WorkedTime = new TimeSpan(3, 10, 0)
            });
            DayList.Add(new DayOverviewViewModel()
            {
                Date = DateTime.Now,
                IsSelected = true,
                WorkedTime = new TimeSpan(3, 10, 0),
                Tasks = new ObservableCollection<DayOverviewTaskViewModel>()
                {
                    new DayOverviewTaskViewModel() {
                        Project = "Projeto Teste",
                        Status = "Testing",
                        TaskID = "NS-12345",
                        WorkedTime = new TimeSpan(1,5,0)
                    },
                    new DayOverviewTaskViewModel() {
                        Project = "Projeto Teste",
                        Status = "Testing",
                        TaskID = "NS-12346",
                        WorkedTime = new TimeSpan(2,5,0)
                    },
                }
            });

            DayList.Add(new DayOverviewViewModel()
            {
                Date = DateTime.Now.AddDays(1),
                WorkedTime = new TimeSpan(0, 0, 0)
            });
            DayList.Add(new DayOverviewViewModel()
            {
                Date = DateTime.Now.AddDays(2),
                WorkedTime = new TimeSpan(0, 0, 0)
            });
            DayList.Add(new DayOverviewViewModel()
            {
                Date = DateTime.Now.AddDays(3),
                WorkedTime = new TimeSpan(0, 0, 0)
            });

            IsBusy = false;
        }
        public ObservableCollection<DayOverviewViewModel> DayList { get; set; }

        private bool _IsBusy { get; set; }
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                this.OnPropertyChanged(nameof(this.IsBusy));
                this.OnPropertyChanged(nameof(this.SpinnerVisibility));
            }
        }

        public Visibility SpinnerVisibility
        {
            get
            {
                if (IsBusy)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
    }
}
