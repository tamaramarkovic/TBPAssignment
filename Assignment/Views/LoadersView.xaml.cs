using Assignment.ViewModels;
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
using System.Windows.Threading;

namespace Assignment.Views
{
    /// <summary>
    /// Interaction logic for LoadersView.xaml
    /// </summary>
    public partial class LoadersView : UserControl
    {
        public LoadersViewModel LoadersViewModel { get; set; }

        DispatcherTimer timer = new DispatcherTimer();

        public LoadersView()
        {
            InitializeComponent();


            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadersViewModel = (LoadersViewModel)this.DataContext;

            double totalProgress = 0;
            int activeThreads = 0;

            foreach (var thread in LoadersViewModel.ThreadProgressList)
            {
                if (thread.Thread.Canceled)
                {
                    continue;
                }

                thread.Thread.Progress += 100 / thread.Thread.ExecutionTime;

                if (thread.Thread.Progress >= 100)
                {
                    thread.Thread.Progress = 100;
                }

                totalProgress += thread.Thread.Progress;

                activeThreads++;
            }

            LoadersViewModel.TotalProgress.TotalProgress = activeThreads == 0 ? 0 : totalProgress / activeThreads;


        }
    }
}
