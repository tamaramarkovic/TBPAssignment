using Assignment.Commands;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment.ViewModels
{
    public class LoadersViewModel : ViewModelBase
    {
        private TotalProgressViewModel _totalProgress { get; set; }

        private ObservableCollection<ThreadProgressViewModel> _threadProgressList { get; set; }

        public TotalProgressViewModel TotalProgress
        {
            get => _totalProgress;
            set
            {
                _totalProgress = value;
                OnPropertyChanged("TotalProgress");
            }
        }

        public ObservableCollection<ThreadProgressViewModel> ThreadProgressList
        {
            get => _threadProgressList;
            set
            {
                _threadProgressList = value;
                OnPropertyChanged("ThreadProgressList");
            }
        }

        public DateTime StartExecutionTime { get; set; }

        public LoadersViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateThreads();
            TotalProgress = new TotalProgressViewModel();
            StartExecutionTime = DateTime.Now;
        }

        private void CreateThreads()
        {
            Random randomExecution = new Random();
            ThreadProgressList = new ObservableCollection<ThreadProgressViewModel>();

            for (int i = 0; i < 3; i++)
            {
                ThreadItem threadItem = new ThreadItem();

                threadItem.Name = $"Thread{i}";

                threadItem.ExecutionTime = randomExecution.Next(10, 51);
                threadItem.Progress = 0;
                threadItem.Canceled = false;

                ThreadProgressViewModel threadProgressViewModel = new ThreadProgressViewModel(threadItem);

                ThreadProgressList.Add(threadProgressViewModel);
            }
        }
    }
}
