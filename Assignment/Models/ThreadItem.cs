using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class ThreadItem : ViewModelBase
    {
        private double _progress;
        private string _name;
        private int _executionTime;
        private bool _canceled;

        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public int ExecutionTime
        {
            get => _executionTime;
            set { _executionTime = value; OnPropertyChanged(nameof(ExecutionTime)); }
        }

        public bool Canceled
        {
            get => _canceled;
            set { _canceled = value; OnPropertyChanged(nameof(Canceled)); }
        }
    }

}
