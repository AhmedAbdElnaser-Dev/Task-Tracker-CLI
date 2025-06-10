using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum TaskStatus
    {
        ToDo,
        InProgress,
        Done,
    }

    internal class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }

        private static int idCounter = 0;

        public Task(string name, TaskStatus status)
        {
            Id = ++idCounter;
            Name = name;
            Status = status;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Status: {Status}";
        }
    }
}
