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
    public class DailyAppointmentsViewModel : ViewModelBase
    {
        public object Parent { get; set; }

        public DailyAppointmentsViewModel()
        {
            TasksControl = new ObservableCollection<DayAppointmentsOverviewViewModel>();
            DayList = new ObservableCollection<DayOverviewViewModel>();
            EntireMonth = new ObservableCollection<DayOverviewViewModel>();

            var today = DateTime.Now;
            SelectedMonth = today.Month;
            SelectedYear = today.Year;

            FillEntireMonth(today.Year, today.Month);
            FillDayList(today.Day);
            
           IsBusy = false;

            OnPropertyChanged("DayList");
            OnPropertyChanged("EntireMonth");
            OnPropertyChanged("TasksControl");
        }

        public void FillDayList(int dayFocus)
        {
            DayList = new ObservableCollection<DayOverviewViewModel>();

            foreach (var item in EntireMonth) item.IsSelected = false;

            EntireMonth[dayFocus - 1].IsSelected = true;
            _SelectedDay = EntireMonth[dayFocus - 1];
            if (dayFocus < 3)
            {
                for (int i = 0; i < 7; i++)
                {
                    DayList.Add(EntireMonth[i]);
                }
            }
            else if (EntireMonth.Count > dayFocus + 3)
            {
                DayList.Add(EntireMonth[dayFocus - 4]);
                DayList.Add(EntireMonth[dayFocus - 3]);
                DayList.Add(EntireMonth[dayFocus - 2]);
                DayList.Add(EntireMonth[dayFocus - 1]);
                DayList.Add(EntireMonth[dayFocus]);
                DayList.Add(EntireMonth[dayFocus + 1]);
                DayList.Add(EntireMonth[dayFocus + 2]);
            }
            else
            {

                for (int i = EntireMonth.Count - 8; i < EntireMonth.Count; i++)
                {
                    DayList.Add(EntireMonth[i]);
                }
            }
        }

        public void FillEntireMonth(int year, int month)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);

            EntireMonth = new ObservableCollection<DayOverviewViewModel>();

            for (int i = 1; i <= daysInMonth; i++)
            {
                var item = new DayOverviewViewModel()
                {
                    Date = new DateTime(year, month, i, 0, 0, 0),
                    IsSelected = false,
                    WorkedTime = new TimeSpan(7, 59, 0)
                };
                EntireMonth.Add(item);
            }
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

        public ObservableCollection<DayOverviewViewModel> EntireMonth { get; set; }
        public ObservableCollection<DayAppointmentsOverviewViewModel> TasksControl { get; set; }
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

        public async Task btnDay_Click(DayOverviewViewModel instance)
        {
            if (!instance.IsSelected && !IsBusy)
            {
                IsBusy = true;
                await LoadDayFromApi(instance);
            }
        }

        private DayOverviewViewModel _SelectedDay { get; set; }
        public DayOverviewViewModel SelectedDay { get { return _SelectedDay; } }

        public async Task LoadDayFromApi(DayOverviewViewModel instance)
        {
            foreach (var item in EntireMonth) item.IsSelected = false;

            instance.IsSelected = true;
            _SelectedDay = instance;
            OnPropertyChanged("SelectedDay");
            //finge que ta carregando as tasks da api
            await Task.Delay(222);

            try
            {
                if (Parent != null)
                {
                    if (Parent is MainWindowViewModel)
                    {
                        var pvm = Parent as MainWindowViewModel;
                        pvm.OnPropertyChanged("HeaderDate");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

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
            return !IsBusy && DayList.First().Date.Day > 1;
        }

        public void OneDayBeforeAction()
        {
            IsBusy = true;

            DayList.RemoveAt(DayList.Count - 1);

            DayList.Insert(0, EntireMonth[DayList.First().Date.Day - 2]);

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
            return !IsBusy && DayList.Last().Date.Day < EntireMonth.Last().Date.Day;
        }

        public void OneDayAfterAction()
        {
            IsBusy = true;

            DayList.RemoveAt(0);

            DayList.Add(EntireMonth[DayList.Last().Date.Day]);

            IsBusy = false;
        }
    }
}
