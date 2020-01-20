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
            var today = new DayOverviewViewModel()
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
                        Title = "Bug Integração Teste",
                        WorkedTime = new TimeSpan(1,5,0)
                    },
                    new DayOverviewTaskViewModel() {
                        Project = "Projeto Teste",
                        Status = "Testing",
                        TaskID = "NS-12346",
                        Title = "Adição de Categoria Adição de Categoria Adição de Categoria Adição de Categoria",
                        WorkedTime = new TimeSpan(2,5,0)
                    },
                }
            };
            DayList.Add(today);
            TasksControl = today.Tasks;
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
    }
}
