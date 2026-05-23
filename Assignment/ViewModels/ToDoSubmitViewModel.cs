using Assignment.Commands;
using Assignment.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Assignment.ViewModels
{
    public class ToDoSubmitViewModel : ViewModelBase
    {
        private string _itemName { get; set; }
        private int _selectedPriority { get; set; }
        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                OnPropertyChanged("ItemName");
            }
        }
        public int SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged("SelectedPriority");
            }
        }

        public List<int> Priorities { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        private ToDoListViewModel _toDoListViewModel;

        public ToDoSubmitViewModel(ToDoListViewModel toDoListViewModel) 
        {
            _toDoListViewModel = toDoListViewModel;
            Initialize();
        }

        private void Initialize()
        {
            SubmitCommand = new RelayCommand(SubmitItem);
            Priorities = new List<int> { 1, 2, 3};
        }

        private void SubmitItem(object obj)
        {
            if (string.IsNullOrEmpty(ItemName) || SelectedPriority == 0)
            {
                return;
            }

            _toDoListViewModel.ToDoItemList.Add(
                new ToDoItemViewModel(
                    new ToDoItem(ItemName, SelectedPriority)
                    )
                );

            _toDoListViewModel.ToDoItemList =
                new ObservableCollection<ToDoItemViewModel>(_toDoListViewModel.ToDoItemList.OrderBy(toDoItem => toDoItem.ToDo.Priority));
        }
    }
}
