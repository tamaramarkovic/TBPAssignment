using Assignment.Models;
using System;

namespace Assignment.ViewModels
{
    public class ToDoItemViewModel : ViewModelBase
    {
        private ToDoItem _toDoItem;

        public ToDoItem ToDo
        {
            get => _toDoItem;
            set
            {
                _toDoItem = value;
                OnPropertyChanged(nameof(ToDo));
            }
        }

        public ToDoItemViewModel(ToDoItem toDoItem)
        {
            ToDo = toDoItem ?? throw new ArgumentNullException(nameof(toDoItem));
        }
    }
}
