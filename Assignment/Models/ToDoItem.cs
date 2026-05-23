using System;

namespace Assignment.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public ToDoItem(string name, int priority)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (priority <= 0)
            {
                throw new ArgumentNullException(nameof(priority));
            }

            Name = name;
            Priority = priority;
        }
    }
}
