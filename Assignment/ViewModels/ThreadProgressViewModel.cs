using Assignment.Commands;
using Assignment.Models;
using System;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class ThreadProgressViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; private set; }

        private ThreadItem _thread { get; set; }

        public ThreadItem Thread
        {
            get => _thread;
            set
            {
                _thread = value;
                OnPropertyChanged("Thread");
            }
        }

        public ThreadProgressViewModel(ThreadItem threadItem)
        {
            Thread = threadItem;
            Initialize();
        }

        private void Initialize()
        {
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Cancel(object obj)
        {
            Thread.Canceled = true;
        }
    }
}
