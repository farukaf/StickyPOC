using StickyPOC.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StickyPOC.ViewModel
{
    public class DailyTasksViewModel : ViewModelBase
    {
        public DailyTasksViewModel()
        {
            TasksControl = new ObservableCollection<DayOverviewTaskViewModel>();
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
            SelectedMonth = DateTime.Now.Month;
            SelectedYear = DateTime.Now.Year;
        }
        public int SelectedYear { get; set; }
        public int SelectedMonth { get; set; }
        public string SelectedMonthName
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(SelectedMonth).ToUpper();
            }
        }

        public ObservableCollection<DayOverviewTaskViewModel> TasksControl { get; set; }
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
                this.OnPropertyChanged(nameof(this.TasksControlVisibility));
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
        public Visibility TasksControlVisibility
        {
            get
            {
                if (!IsBusy)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public async Task btnDay_Click(DayOverviewViewModel dayOverviewViewModel)
        {
            if (!dayOverviewViewModel.IsSelected && !IsBusy)
            {
                IsBusy = true;
                await LoadDayFromApi(dayOverviewViewModel);
            }
        }

        public async Task LoadDayFromApi(DayOverviewViewModel dayOverviewViewModel)
        {
            foreach (var day in DayList)
            {
                day.IsSelected = false;
            }

            dayOverviewViewModel.IsSelected = true;

            //finge que ta carregando as tasks da api
            await Task.Delay(222);

            IsBusy = false;
        }

        private ICommand _OneDayBeforeClick { get; set; }
        public ICommand OneDayBeforeClick
        {
            get
            {
                return _OneDayBeforeClick ?? (_OneDayBeforeClick = new CommandHandler(() => OneDayBeforeAction(), () => OneDayBeforeAllow()));
            }
        }

        public bool OneDayBeforeAllow()
        {
            return !IsBusy && DayList[0].Date.Day > 1;
        }

        public void OneDayBeforeAction()
        {
            IsBusy = true;
            DayList.RemoveAt(DayList.Count - 1);
            DayList.Insert(0, new DayOverviewViewModel() { Date = DayList[0].Date.AddDays(-1) });

            IsBusy = false;
        }
        //after
        private ICommand _OneDayAfterClick { get; set; }
        public ICommand OneDayAfterClick
        {
            get
            {
                return _OneDayAfterClick ?? (_OneDayAfterClick = new CommandHandler(() => OneDayAfterAction(), () => OneDayAfterAllow()));
            }
        }

        public bool OneDayAfterAllow()
        {
            var _date = DayList.Last().Date;
            var daysInMonth = DateTime.DaysInMonth(_date.Year, _date.Month);
            return !IsBusy && _date.Day < daysInMonth;
        }

        public void OneDayAfterAction()
        {
            IsBusy = true;
            var _date = DayList.Last().Date;
            DayList.RemoveAt(0);
            DayList.Add(new DayOverviewViewModel() { Date = _date.AddDays(+1) });

            IsBusy = false;
        }
    }
}
