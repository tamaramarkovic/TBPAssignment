using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ToDoSubmitViewModel ToDoSubmitViewModel { get; set; }

        private ObservableCollection<ToDoItemViewModel> _toDoItemList;

        public ObservableCollection<ToDoItemViewModel> ToDoItemList
        {
            get => _toDoItemList;
            set
            {
                _toDoItemList = value;
                OnPropertyChanged("ToDoItemList");
            }
        }

        public ToDoListViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            ToDoItemList = new ObservableCollection<ToDoItemViewModel>();
            ToDoSubmitViewModel = new ToDoSubmitViewModel(this);
        }
    }
}
