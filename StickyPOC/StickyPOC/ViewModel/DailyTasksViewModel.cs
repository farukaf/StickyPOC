using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyPOC.ViewModel
{
    public class DailyTasksViewModel
    {
        public DailyTasksViewModel()
        {
            DayList = new ObservableCollection<DayOverviewViewModel>();

            DayList.Add(new DayOverviewViewModel() { 
                Date = DateTime.Now.AddDays(-3) ,
                WorkedTime = new TimeSpan(28,10,0)
            });;
            DayList.Add(new DayOverviewViewModel() { 
                Date = DateTime.Now.AddDays(-2),
                WorkedTime = new TimeSpan(3, 10, 0)
            });
            DayList.Add(new DayOverviewViewModel() { 
                Date = DateTime.Now.AddDays(-1),
                WorkedTime = new TimeSpan(3, 10, 0)
            });
            DayList.Add(new DayOverviewViewModel() { 
                Date = DateTime.Now, 
                IsSelected = true,
                WorkedTime = new TimeSpan(3, 10, 0)
            });
            DayList.Add(new DayOverviewViewModel() { 
                Date = DateTime.Now.AddDays(1),
                WorkedTime = new TimeSpan(0, 0, 0)
            });
            DayList.Add(new DayOverviewViewModel() { 
                Date = DateTime.Now.AddDays(2),
                WorkedTime = new TimeSpan(0, 0, 0)
            });
            DayList.Add(new DayOverviewViewModel() { 
                Date = DateTime.Now.AddDays(3),
                WorkedTime = new TimeSpan(0, 0, 0)
            });
        }
       public ObservableCollection<DayOverviewViewModel> DayList { get; set; }
    }
}
