using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyPOC.ViewModel
{
    public class MonthPickerDialogViewModel : ViewModelBase
    {
        public MonthPickerDialogViewModel() : this(DateTime.Now.Year, DateTime.Now.Month)
        {

        }


        public MonthPickerDialogViewModel(int selectedYear, int selectedMonth)
        {
            YearCollection = new Dictionary<int, int>();
            SelectedYear = selectedYear;
            SelectedMonth = selectedMonth;
            for (int i = selectedYear - 3; i < selectedYear + 3; i++)
            {
                YearCollection.Add(i, i);
            }
        }
        public Dictionary<int, int> YearCollection { get; set; }
        public int SelectedYear { get; set; }
        public int SelectedMonth { get; set; }
        public DateTime? SelectedDateTime
        {
            get
            {
                if (SelectedMonth < 1 || SelectedMonth > 12)
                {
                    return null;
                }
                return new DateTime(SelectedYear, SelectedMonth, 1);

            }
        }
    }
}
