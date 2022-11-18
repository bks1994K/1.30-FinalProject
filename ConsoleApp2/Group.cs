using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalProject
{
    public class Group
    {
        private Dictionary<int, Dictionary<int, bool>> _taskJournal = new Dictionary<int, Dictionary<int, bool>>();
        public Student[] Students { get; set; }
        public Occupation[] Occupations { get; set; }
        public Task[] Tasks { get; set; }

        public Group(Student[] students, Occupation[] occupations, Task[] task)
        {
            Students = students;
            Occupations = occupations;
            Tasks = task;
            UpdateDictionary();
        }

        public void WriteToConsoleInformationAboutStudents()
        {
            Console.WriteLine("There are list of Students:");
            for (int i = 0; i < Students.Length; i++)
            {
                Console.WriteLine(Students[i]);
            }
            Console.WriteLine();
        }

        public void WriteToConsoletInformationAboutOccupations()
        {
            Console.WriteLine("There are list of Occupations:");
            for (int i = 0; i < Occupations.Length; i++)
            {
                Console.WriteLine($"{i + 1}.) {Occupations[i]}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void WriteToConsoleInformationAboutTasks()
        {
            Console.WriteLine("There are list of Tasks:");
            for (int i = 0; i < Tasks.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Tasks[i].Name}: ");
                Console.WriteLine(Tasks[i]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void AddStudent(Student addStudent)
        {
            if (Students.Contains(addStudent))
            {
                return;
            }
            Student[] newStudent = new Student[Students.Length + 1];
            for (int i = 0; i < Students.Length; i++)
            {
                newStudent[i] = Students[i];
            }
            newStudent[Students.Length] = addStudent;
            Students = newStudent;
            UpdateDictionary();
        }

        public void RemoveStudent(Student student)
        {
            if (!Students.Contains(student))
            {
                return;
            }
            Student[] newStudent = new Student[Students.Length - 1];
            int j = 0;
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != student)
                {
                    newStudent[j] = Students[i];
                    j++;
                }
            }
            Students = newStudent;
            UpdateDictionary();
        }

        public void AddOccupation(Occupation addOccupation)
        {
            if (Occupations.Contains(addOccupation))
            {
                return;
            }
            Occupation[] newOccupation = new Occupation[Occupations.Length + 1];
            for (int i = 0; i < Occupations.Length; i++)
            {
                newOccupation[i] = Occupations[i];
            }
            newOccupation[Occupations.Length] = addOccupation;
            Occupations = newOccupation;
        }

        public void RemoveOccupation(Occupation occupation)
        {
            if (!Occupations.Contains(occupation))
            {
                return;
            }
            Occupation[] newOccupation = new Occupation[Occupations.Length - 1];
            int j = 0;
            for (int i = 0; i < Occupations.Length; i++)
            {
                if (Occupations[i] != occupation)
                {
                    newOccupation[j] = Occupations[i];
                    j++;
                }
            }
            Occupations = newOccupation;
        }

        public void AddTask(Task addTask)
        {
            if (Tasks.Contains(addTask))
            {
                return;
            }
            Task[] newTask = new Task[Tasks.Length + 1];
            for (int i = 0; i < Tasks.Length; i++)
            {
                newTask[i] = Tasks[i];
            }
            newTask[Tasks.Length] = addTask;
            Tasks = newTask;
            UpdateDictionary();
        }

        public void RemoveTask(Task Task)
        {
            if (!Tasks.Contains(Task))
            {
                return;
            }
            Task[] newTask = new Task[Tasks.Length - 1];
            int j = 0;
            for (int i = 0; i < Tasks.Length; i++)
            {
                if (Tasks[i] != Task)
                {
                    newTask[j] = Tasks[i];
                    j++;
                }
            }
            Tasks = newTask;
            UpdateDictionary();
        }

        public void ReadFromConsoleTypesOfInformation()
        {

            Console.WriteLine("If you want to know information about Students - press 1\nabout Occupations - press 2\nabout Tasks - press 3");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    WriteToConsoleInformationAboutStudents();
                    break;
                case 2:
                    WriteToConsoletInformationAboutOccupations();
                    break;
                case 3:
                    WriteToConsoleInformationAboutTasks();
                    break;
                default:
                    Console.WriteLine("You should enter number 1 or 2 or 3");
                    break;
            }

        }

        private void AddStudentWithConsole()
        {
            Console.WriteLine("Enter lastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter firstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter patronymic");
            string patronymic = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Student addStudent = new Student(lastName, firstName, patronymic, phoneNumber, email);
            AddStudent(addStudent);
            Console.WriteLine($"You add a student with Id:{addStudent.Id}");
        }

        private void RemoveStudentWithConsole()
        {
            Console.WriteLine("Enter Id of Student which you want to remove");
            int studentId = Convert.ToInt32(Console.ReadLine());
            bool isRemoved = false;
            for (int i = 0; i < Students.Length; i++)
            {
                if (studentId == Students[i].Id)
                {
                    RemoveStudent(Students[i]);
                    isRemoved = true;
                }
            }
            if (isRemoved)
            {
                Console.WriteLine($"You remove a student with Id: {studentId}");
            }
            else
            {
                Console.WriteLine("You should enter Id of existing student");
            }
        }

        private void AddOccupationWithConsole()
        {
            Console.WriteLine("Enter date");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter topic for 1 piece each");
            Console.WriteLine("If you want to end enter list of topics you should enter /");
            List<string> topics = new List<string>();
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "/")
                {
                    break;
                }
                else
                {
                    topics.Add(userInput);
                }
            }
            Console.WriteLine("Enter some comments from teacher if you have these");
            string comment = Console.ReadLine();
            Console.WriteLine("Enter number of occupation type where 0 is lection; 1 is consultation; 2 is other");
            OccupationType type = (OccupationType)Convert.ToInt32(Console.ReadLine());
            Occupation addOccupation = new Occupation(date, topics, comment, type);
            AddOccupation(addOccupation);
            Console.WriteLine($"You add a new occupation with date:{addOccupation.Date}");
        }

        private void RemoveOccupationWithConsole()
        {
            Console.WriteLine("Enter Id of Occupation what you want to delete");
            int occupationId = Convert.ToInt32(Console.ReadLine());
            bool isRemoved = false;
            for (int i = 0; i < Occupations.Length; i++)
            {
                if (occupationId == Occupations[i].Id)
                {
                    RemoveOccupation(Occupations[i]);
                    isRemoved = true;
                }
            }
            if (isRemoved)
            {
                Console.WriteLine($"You remove an occupation with Id: {occupationId}");
            }
            else
            {
                Console.WriteLine("You should enter Id of existing occupation");
            }
        }

        private void AddTaskWithConsole()
        {
            Console.WriteLine("For additions Usual Task - press 1");
            Console.WriteLine("For additions Test Task - press 2");
            Console.WriteLine("For additions Project Task - press 3");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    AddUsualTaskWithConsole();
                    break;
                case 2:
                    AddTestTaskWithConsole();
                    break;
                case 3:
                    AddProjectTaskWithConsole();
                    break;
                default:
                    Console.WriteLine("You should enter number 1 or 2 or 3");
                    break;
            }
        }

        private void AddUsualTaskWithConsole()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter deadline");
            int deadline = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter link for 1 piece each");
            Console.WriteLine("If you want to end enter list of links you should enter /");
            List<string> links = new List<string>();
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "/")
                {
                    break;
                }
                else
                {
                    links.Add(userInput);
                }
            }
            Console.WriteLine("Enter formulation");
            string formulation = Console.ReadLine();
            UsualTask usualTask = new UsualTask(name, deadline, links, formulation);
            AddTask(usualTask);
            Console.WriteLine($"You add an usual task with name:{usualTask.Name}");
        }

        private void AddTestTaskWithConsole()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter deadline");
            int deadline = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1 link");
            string link = Console.ReadLine();
            TestTask testTask = new TestTask(name, deadline, link);
            AddTask(testTask);
            Console.WriteLine($"You add an test task with name:{testTask.Name}");
        }

        private void AddProjectTaskWithConsole()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter deadline");
            int deadLine = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter subtask for 1 piece each");
            Console.WriteLine("If you want to end enter list of subtasks you should enter /");
            List<string> subtasks = new List<string>();
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "/")
                {
                    break;
                }
                else
                {
                    subtasks.Add(userInput);
                }
            }
            Console.WriteLine("Enter link for 1 piece each");
            Console.WriteLine("If you want to end enter list of links you should enter /");
            List<string> links = new List<string>();
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "/")
                {
                    break;
                }
                else
                {
                    links.Add(userInput);
                }
            }
            ProjectTask projectTask = new ProjectTask(name, deadLine, description, subtasks, links);
            AddTask(projectTask);
            Console.WriteLine($"You add an project task with name:{projectTask.Name}");
        }

        private void RemoveTaskWithConsole()
        {
            Console.WriteLine("Enter Id of Task what you want to delete");
            int taskId = Convert.ToInt32(Console.ReadLine());
            bool isRemoved = false;
            for (int i = 0; i < Tasks.Length; i++)
            {
                if (taskId == Tasks[i].Id)
                {
                    RemoveTask(Tasks[i]);
                    isRemoved = true;
                }
            }
            if (isRemoved)
            {
                Console.WriteLine($"You remove a task with Id: {taskId}");
            }
            else
            {
                Console.WriteLine("You should enter Id of existing task");
            }
        }

        private void AddSubtaskWithConsole()
        {
            Console.WriteLine("Enter id of Project task where you want to add subtask");
            int id = Convert.ToInt32(Console.ReadLine());
            bool isAdded = false;
            for (int i = 0; i < Tasks.Length; i++)
            {
                if (Tasks[i] is ProjectTask projectTask && id == projectTask.Id)
                {
                    Console.WriteLine("Enter subtask which you want to add");
                    string subtask = Console.ReadLine();
                    projectTask.AddSubtask(subtask);
                    Console.WriteLine("You add a new subtask");
                    isAdded = true;
                }
            }
            if (!isAdded)
            {
                Console.WriteLine("You should enter existing id of project task");
            }
        }

        private void RemoveSubtaskWithConsole()
        {
            Console.WriteLine("Enter id of Project task where you want to remove subtask");
            int id = Convert.ToInt32(Console.ReadLine());
            bool isRemoved = false;
            for (int i = 0; i < Tasks.Length; i++)
            {
                if (Tasks[i] is ProjectTask projectTask && id == projectTask.Id)
                {
                    Console.WriteLine("Enter subtask which you want to remove");
                    string removeSubtask = Console.ReadLine();
                    if (projectTask.RemoveSubtask(removeSubtask))
                    {
                        Console.WriteLine("You remove subtask");
                    }
                    isRemoved = true;
                }
            }
            if (!isRemoved)
            {
                Console.WriteLine("You should enter existing id of project task");
            }
        }

        public void UpdateDictionary()
        {
            foreach (int taskId in _taskJournal.Keys)
            {
                bool isActual = false;
                for (int i = 0; i < Tasks.Length; i++)
                {
                    if (taskId == Tasks[i].Id)
                    {
                        isActual = true;
                        break;
                    }
                }
                if (!isActual)
                {
                    _taskJournal.Remove(taskId);
                }
                else
                {
                    foreach (int studentId in _taskJournal[taskId].Keys)
                    {
                        bool isActualStudent = false;
                        for (int i = 0; i < Students.Length; i++)
                        {
                            if (studentId == Students[i].Id)
                            {
                                isActualStudent = true;
                                break;
                            }
                        }
                        if (!isActualStudent)
                        {
                            _taskJournal[taskId].Remove(studentId);
                        }
                    }
                }
            }
            for (int i = 0; i < Tasks.Length; i++)
            {
                Dictionary<int, bool> studentJournal = new Dictionary<int, bool>();
                _taskJournal.TryAdd(Tasks[i].Id, studentJournal);
                for (int j = 0; j < Students.Length; j++)
                {
                    studentJournal.TryAdd(Students[j].Id, false);
                }
            }
        }

        public void MarkAcceptedOrNotAcceptedTask(int taskId, int studentId)
        {
            //if (_taskJournal.TryGetValue(taskId, out Dictionary<int, bool> studentJournal))
            if (_taskJournal.ContainsKey(taskId))
            {
                Dictionary<int, bool> studentJournal = _taskJournal[taskId];
                if (studentJournal.ContainsKey(studentId))
                {
                    studentJournal[studentId] = !studentJournal[studentId];
                }
            }
        }

        public void WatchInConsoleMarkOfTaskAndAcceptedOrNotAcceptedTask()
        {
            int number = -1;
            while (number != 0)
            {
                Console.WriteLine("For view a student's current mark of task - press 1");
                Console.WriteLine("For change a student's current mark of task - press 2");
                Console.WriteLine("For exit - press 0");
                number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("For view - You should enter first id of task and then enter id of student");
                        WatchInConsoleStudentSCurrentMarkOfTask(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("For change - You should enter first id of task and then enter id of student");
                        int taskId = Convert.ToInt32(Console.ReadLine());
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        MarkAcceptedOrNotAcceptedTask(taskId, studentId);
                        Console.WriteLine($"A changed mark of task with id: {taskId} for student with id: {studentId} is {ReturnValueBoolOfStudentJournal(taskId, studentId)}");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("You should enter number 1 or 2 or 3");
                        break;
                }
            }
        }

        private bool ReturnValueBoolOfStudentJournal(int taskId, int studentId)
        {
            if (_taskJournal.ContainsKey(taskId))
            {
                Dictionary<int, bool> studentJournal = _taskJournal[taskId];
                if (studentJournal.ContainsKey(studentId))
                {
                    return studentJournal[studentId];
                }
            }
            throw new ArgumentException("You should enter correct id of student and id of task");
        }

        public void WatchInConsoleStudentSCurrentMarkOfTask(int taskId, int studentId)
        {
            if (_taskJournal.ContainsKey(taskId))
            {
                Dictionary<int, bool> studentJournal = _taskJournal[taskId];
                if (studentJournal.ContainsKey(studentId))
                {
                    Console.WriteLine($"A current mark of task with id: {taskId} for student with id: {studentId} is {studentJournal[studentId]}");
                }
            }
        }

        public void ViewListOfStatusOfAllStudentsForOneCertainTask(int taskId)
        {
            if (_taskJournal.ContainsKey(taskId))
            {
                Dictionary<int, bool> studentJournal = GetDictionaryOfStudents(taskId);

                Console.WriteLine($"For task with id: {taskId} there is list of students:");
                foreach (KeyValuePair<int, bool> student in studentJournal)
                {
                    Console.WriteLine($"Id of student: {student.Key} - mark of task: {student.Value}");
                }
            }
        }

        private Dictionary<int, bool> GetDictionaryOfStudents(int taskId)
        {
            if (_taskJournal.ContainsKey(taskId))
            {
                Dictionary<int, bool> studentJournal = _taskJournal[taskId];
                return _taskJournal[taskId];
            }
            throw new ArgumentException("You should enter correct id of task");
        }

        public void ViewListOfTasksWithThereMarksOfCertainStudent(int studentId)
        {
            Dictionary<int, bool> journalWithTaskIdAndMark = GetTasksWithTehereMarks(studentId);
            if (journalWithTaskIdAndMark.Count > 0)
            {
                Console.WriteLine($"For student with id: {studentId} there is list of tasks with there marks:");
                foreach (KeyValuePair<int, bool> taskAndMark in journalWithTaskIdAndMark)
                {
                    Console.WriteLine($"Id of task: {taskAndMark.Key} - mark of task: {taskAndMark.Value}");
                }
            }
            else 
            {
                Console.WriteLine("Id of students or Id of tasks are not found");
            }
        }

        private Dictionary<int, bool> GetTasksWithTehereMarks(int studentId)
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();
            foreach (KeyValuePair<int, Dictionary<int, bool>> task in _taskJournal)
            {
                if (task.Value.ContainsKey(studentId))
                {
                    int taskId = task.Key;
                    bool isDone = task.Value[studentId];
                    result.Add(taskId, isDone);
                }
            }
            return result;
        }

        public void InteractWithConsole()
        {
            int number = -1;
            while (number != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Hi, student!\nIf you want to know some information about your group - press 1");
                Console.WriteLine("If you want to add a student in your group - press 2");
                Console.WriteLine("If you want to remove a student in your group - press 3");
                Console.WriteLine("If you want to add an occupation in your group - press 4");
                Console.WriteLine("If you want to remove an occupation in your group - press 5");
                Console.WriteLine("If you want to add a task in your group - press 6");
                Console.WriteLine("If you want to remove a task in your group - press 7");
                Console.WriteLine("If you want to add a subtask in your group - press 8");
                Console.WriteLine("If you want to remove a subtask in your group - press 9");
                Console.WriteLine("If you want to view or change the mark of acceptance of the task - press 10");
                Console.WriteLine("If you want to view list of students with there marks for one certain task - press 11");
                Console.WriteLine("If you want to view list of tasks with there marks of certain student - press 12");
                Console.WriteLine("For exit - press 0");
                number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        ReadFromConsoleTypesOfInformation();
                        break;
                    case 2:
                        AddStudentWithConsole();
                        break;
                    case 3:
                        RemoveStudentWithConsole();
                        break;
                    case 4:
                        AddOccupationWithConsole();
                        break;
                    case 5:
                        RemoveOccupationWithConsole();
                        break;
                    case 6:
                        AddTaskWithConsole();
                        break;
                    case 7:
                        RemoveTaskWithConsole();
                        break;
                    case 8:
                        AddSubtaskWithConsole();
                        break;
                    case 9:
                        RemoveSubtaskWithConsole();
                        break;
                    case 10:
                        WatchInConsoleMarkOfTaskAndAcceptedOrNotAcceptedTask();
                        break;
                    case 11:
                        Console.WriteLine("Enter id of task you want to view the list of students and marks for");
                        int taskId = Convert.ToInt32(Console.ReadLine());
                        ViewListOfStatusOfAllStudentsForOneCertainTask(taskId);
                        break;
                    case 12:
                        Console.WriteLine("Enter id of student you want to view the list of tasks and marks for");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        ViewListOfTasksWithThereMarksOfCertainStudent(studentId);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("You should enter number 1 or 2 or 3");
                        break;
                }
            }
        }
    }
}
