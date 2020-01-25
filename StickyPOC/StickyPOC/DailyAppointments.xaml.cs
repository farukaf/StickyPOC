using StickyPOC.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DailyAppointments.xaml
    /// </summary>
    public partial class DailyAppointments : UserControl
    {
        public DailyAppointmentsViewModel ViewModel { get; set; }
        public DailyAppointments()
        {
            InitializeComponent();
            DataContext = ViewModel = new DailyAppointmentsViewModel();
        }
        private void btnDay_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var dayOverView = btn.DataContext as DayOverviewViewModel;
            _ = ViewModel.btnDay_Click(dayOverView);
        }
    }
}
