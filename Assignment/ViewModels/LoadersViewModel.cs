using Assignment.Models;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Threading;

namespace Assignment.ViewModels
{
    public class LoadersViewModel : ViewModelBase
    {
        private TotalProgressViewModel _totalProgress;

        private ObservableCollection<ThreadProgressViewModel> _threadProgressList;

        private DispatcherTimer _timer;

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

        public LoadersViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            TotalProgress = new TotalProgressViewModel();
            InitializeThreads();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void InitializeThreads()
        {
            Random randomExecution = new Random();

            int threadCount = int.Parse(ConfigurationManager.AppSettings["ThreadCount"]);
            int minimumExecutionTimeInSeconds = int.Parse(ConfigurationManager.AppSettings["MinimumExecutionTimeInSeconds"]);
            int maximumExecutionTimeInSeconds = int.Parse(ConfigurationManager.AppSettings["MaximumExecutionTimeInSeconds"]);

            ThreadProgressList = new ObservableCollection<ThreadProgressViewModel>();

            for (int i = 0; i < threadCount; i++)
            {
                ThreadProgressList.Add(
                    new ThreadProgressViewModel(
                        new ThreadItem($"Thread{i}", randomExecution.Next(minimumExecutionTimeInSeconds, maximumExecutionTimeInSeconds + 1))
                        )
                    );
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            IncrementThreadProgress();
            CalculateTotalProgress();
        }

        public void IncrementThreadProgress()
        {
            foreach (var thread in ThreadProgressList)
            {
                if (thread.Thread.IsCanceled) continue;

                thread.Thread.Elapsed++;
                if (thread.Thread.Elapsed >= thread.Thread.ExecutionTime)
                {
                    thread.Thread.Elapsed = thread.Thread.ExecutionTime;
                }
            }
        }

        public void CalculateTotalProgress()
        {
            double totalProgress = 0;
            int activeThreads = 0;

            foreach (var thread in ThreadProgressList)
            {
                if (thread.Thread.IsCanceled) continue;

                totalProgress += thread.Thread.Progress;
                activeThreads++;
            }

            TotalProgress.TotalProgress = activeThreads == 0 ? 0 : totalProgress / activeThreads;
        }
    }
}
