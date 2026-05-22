using Assignment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class TotalProgressViewModel : ViewModelBase
    {
        private double _totalProgress {  get; set; }

        public double TotalProgress
        {
            get => _totalProgress;
            set
            {
                _totalProgress = value;
                OnPropertyChanged("TotalProgress");
            }
        }

        public TotalProgressViewModel()
        {

        }
    }
}
