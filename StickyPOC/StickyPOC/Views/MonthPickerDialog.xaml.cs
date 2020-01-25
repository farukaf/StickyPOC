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
using System.Windows.Shapes;

namespace StickyPOC.Views
{
    /// <summary>
    /// Interaction logic for MonthPicker.xaml
    /// </summary>
    public partial class MonthPickerDialog : Window
    {
        public MonthPickerDialogViewModel ViewModel { get; set; }
        public DateTime? SelectedDateTime { get { return ViewModel.SelectedDateTime; } }

        private List<Button> BtnMeses;

        public MonthPickerDialog(int? month = null, int? year = null)
        {
            InitializeComponent();

            int _year = year ?? DateTime.Now.Year;
            int _month = month ?? DateTime.Now.Month;
            DataContext = ViewModel = new MonthPickerDialogViewModel(_year, _month);

            BtnMeses = new List<Button>() {
                this.btnJan, this.btnFev, this.btnMar, this.btnAbr,
                this.btnMai, this.btnJun, this.btnJul, this.btnAgo,
                this.btnSet, this.btnOut, this.btnNov, this.btnDez,
            };
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedMonth = 0;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnMes_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int btnMonth = Convert.ToInt32(button.DataContext);
            SelectMonth(btnMonth);
        }

        private void SelectMonth(int month)
        {
            ViewModel.SelectedMonth = month;
            for (int i = 0; i < BtnMeses.Count; i++)
            {
                if (i != month - 1)
                {
                    BtnMeses[i].Background = new SolidColorBrush(Colors.Transparent);
                    BtnMeses[i].FontWeight = FontWeights.Normal;
                }
                else
                {
                    BtnMeses[i].Background = new SolidColorBrush(Color.FromRgb(210, 210, 210));
                    BtnMeses[i].FontWeight = FontWeights.Bold;
                }
            }
        }

        private void btnMes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MoveWindowToMouse()
        {
            var point = System.Windows.Forms.Control.MousePosition;
            this.Left = point.X; 
            this.Top = point.Y;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MoveWindowToMouse();
            SelectMonth(ViewModel.SelectedMonth);
        }
    }
}
