using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                OnPropertyChanged("ToDo");
            }
        }

        public ToDoItemViewModel(ToDoItem toDoItem)
        {
            ToDo = toDoItem ?? throw new ArgumentNullException(nameof(toDoItem));
        }
    }
}
