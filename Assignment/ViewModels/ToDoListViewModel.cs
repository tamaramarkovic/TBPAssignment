using System.Collections.ObjectModel;

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
                OnPropertyChanged(nameof(ToDoItemList));
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
