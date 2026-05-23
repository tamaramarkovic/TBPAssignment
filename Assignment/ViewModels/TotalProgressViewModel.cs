namespace Assignment.ViewModels
{
    public class TotalProgressViewModel : ViewModelBase
    {
        private double _totalProgress;

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
            TotalProgress = 0;
        }
    }
}
