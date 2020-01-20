using StickyPOC.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StickyPOC
{
    /// <summary>
    /// Interaction logic for DailyTasks.xaml
    /// </summary>
    public partial class DailyTasks : UserControl
    {
        public DailyTasksViewModel ViewModel { get; set; }

        public DailyTasks()
        {
            InitializeComponent();

            DataContext = ViewModel = new DailyTasksViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(gridDayList.ActualWidth);
        }

        private void btnDay_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var dayOverView = btn.DataContext as DayOverviewViewModel;
            if (!dayOverView.IsSelected)
            {
                ViewModel.IsBusy = true;
                Task.Run(async () =>
                {
                    foreach (var day in ViewModel.DayList)
                    {
                        day.IsSelected = false;
                    }

                    dayOverView.IsSelected = true;

                    //finge que ta carregando as tasks da api
                    await Task.Delay(2222);

                    ViewModel.IsBusy = false;
                });
            }
        }
    }
}
