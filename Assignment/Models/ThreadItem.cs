using Caliburn.Micro;
using System;

namespace Assignment.Models
{
    public class ThreadItem : PropertyChangedBase
    {
        private double _progress;
        private string _name;
        private int _executionTime;
        private bool _isCanceled;

        public ThreadItem(string name, int executionTime)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (executionTime <= 0)
            {
                throw new ArgumentNullException(nameof(executionTime));
            }

            _progress = 0;
            _name = name;
            _executionTime = executionTime;
            _isCanceled = false;
        }

        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                NotifyOfPropertyChange(nameof(Progress));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        public int ExecutionTime
        {
            get => _executionTime;
            set
            {
                _executionTime = value;
                NotifyOfPropertyChange(nameof(ExecutionTime));
            }
        }

        public bool IsCanceled
        {
            get => _isCanceled;
            set
            {
                _isCanceled = value;
                NotifyOfPropertyChange(nameof(IsCanceled));
                NotifyOfPropertyChange(nameof(IsActive));
            }
        }

        public bool IsActive
        {
            get => !_isCanceled;
        }
    }

}
