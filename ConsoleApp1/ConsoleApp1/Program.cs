namespace ConsoleApp1
{
    internal class Program
    {
        public static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            while (true)
            {
                ListChoices();

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine(); 
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task name: ");
                        string name = Console.ReadLine();
                        AddTask(new Task(name, TaskStatus.ToDo));
                        break;
                    case "2":
                        Console.Write("Enter task Id to mark as done: ");
                        int doneId = int.Parse(Console.ReadLine());
                        DoneTask(doneId);
                        break;
                    case "3":
                        Console.Write("Enter task Id to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        DeleteTask(deleteId);
                        break;
                    case "4":
                        Console.Write("Enter task Id to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new task name: ");
                        string newName = Console.ReadLine();
                        UpdateTask(updateId, newName, TaskStatus.ToDo);
                        break;
                    case "5":
                        ListTasks();
                        break;
                    case "6":
                        ListToDoTasks();
                        break;
                    case "7":
                        ListInProgressTasks();
                        break;
                    case "8":
                        ListDoneTasks();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                PrintSpace();
            }
        }

        public static void ListChoices()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Done Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Update Task");
            Console.WriteLine("5. List All Tasks");
            Console.WriteLine("6. List ToDo Tasks");
            Console.WriteLine("7. List InProgress Tasks");
            Console.WriteLine("8. List Done Tasks");
            Console.WriteLine("9. Exit");
        }

        public static void PrintSpace()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }

        public static void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public static void DoneTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Status = TaskStatus.Done;
            }
            else
            {
                Console.WriteLine($"Task with Id {id} not found.");
            }
        }

        public static void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            else
            {
                Console.WriteLine($"Task with Id {id} not found.");
            }
        }

        public static void UpdateTask(int id, string name, TaskStatus status)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Name = name;
                task.Status = status;
            }
            else
            {
                Console.WriteLine($"Task with Id {id} not found.");
            }
        }

        public static void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        public static void ListToDoTasks()
        {
            var todoTasks = tasks.Where(t => t.Status == TaskStatus.ToDo).ToList();
            if (todoTasks.Count == 0)
            {
                Console.WriteLine("No ToDo tasks available.");
                return;
            }
            foreach (var task in todoTasks)
            {
                Console.WriteLine(task);
            }
        }

        public static void ListInProgressTasks()
        {
            var inProgressTasks = tasks.Where(t => t.Status == TaskStatus.InProgress).ToList();
            if (inProgressTasks.Count == 0)
            {
                Console.WriteLine("No InProgress tasks available.");
                return;
            }
            foreach (var task in inProgressTasks)
            {
                Console.WriteLine(task);
            }
        }

        public static void ListDoneTasks()
        {
            var doneTasks = tasks.Where(t => t.Status == TaskStatus.Done).ToList();
            if (doneTasks.Count == 0)
            {
                Console.WriteLine("No Done tasks available.");
                return;
            }
            foreach (var task in doneTasks)
            {
                Console.WriteLine(task);
            }
        }
    }
}
