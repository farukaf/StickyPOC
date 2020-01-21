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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });

#if DEBUG
            this.ShowInTaskbar = true;
#endif

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LowerBlock.ViewModel.TasksControl.Add(
                new ViewModel.DayOverviewTaskViewModel()
                {
                    Project = "Prjt Teste",
                    Status = "Testing",
                    TaskID = "NS-1234",
                    Title = "Bug fixes on post Bug fixes on post Bug fixes on post Bug fixes on post Bug fixes on post Bug fixes on post ",
                    WorkedTime = new TimeSpan(2, 15, 0),
                });
            LowerBlock.ViewModel.TasksControl.Add(
                new ViewModel.DayOverviewTaskViewModel()
                {
                    Project = "Project",
                    Status = "Status",
                    TaskID = "TaskID",
                    Title = "Title",
                    WorkedTime = new TimeSpan(2, 15, 0),
                });
            LowerBlock.ViewModel.TasksControl.Add(
                new ViewModel.DayOverviewTaskViewModel()
                {
                    Project = "Project",
                    Status = "Status",
                    TaskID = "TaskID",
                    Title = "Title",
                    WorkedTime = new TimeSpan(2, 15, 0),
                });
            LowerBlock.ViewModel.TasksControl.Add(
                new ViewModel.DayOverviewTaskViewModel()
                {
                    Project = "Project",
                    Status = "Status",
                    TaskID = "TaskID",
                    Title = "Title",
                    WorkedTime = new TimeSpan(2, 15, 0),
                });
            LowerBlock.ViewModel.TasksControl.Add(
                new ViewModel.DayOverviewTaskViewModel()
                {
                    Project = "Project",
                    Status = "Status",
                    TaskID = "TaskID",
                    Title = "Title",
                    WorkedTime = new TimeSpan(2, 15, 0),
                });
            LowerBlock.ViewModel.TasksControl.Add(
                new ViewModel.DayOverviewTaskViewModel()
                {
                    Project = "Project",
                    Status = "Status",
                    TaskID = "TaskID",
                    Title = "Title",
                    WorkedTime = new TimeSpan(2, 15, 0),
                });
            LowerBlock.ViewModel.TasksControl.Add(
                new ViewModel.DayOverviewTaskViewModel()
                {
                    Project = "Project",
                    Status = "Status",
                    TaskID = "TaskID",
                    Title = "Title",
                    WorkedTime = new TimeSpan(2, 15, 0),
                });
        }

    }
}
