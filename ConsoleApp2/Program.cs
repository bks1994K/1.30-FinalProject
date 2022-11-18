using FinalProject;

Student student1 = new Student("First", "Ivan", "Ivanov", "888888888", "first@mail.ru");
Student student2 = new Student("Second", "Petr", "Petrov", "444444444", "second@mail.ru");
Student student3 = new Student("Third", "Dasha", "Dashina", "333333333", "third@mail.ru");

Student student4 = new Student("Fourth", "Masha", "Mashina", "111111111", "fourth@mail.ru");
Student student5 = new Student("Fifth", "Sidr", "Sidorov", "555555555", "fifth@mail.ru");

Occupation occupation1 = new Occupation(new DateTime(2011, 11, 11), new List<string> { "EnterToScience", "NecessityOfScience" }, "Lection is a power", OccupationType.Lection);
Occupation occupation2 = new Occupation(new DateTime(2012, 12, 12), new List<string> { "Consultation for you", "Consultation for us" }, "Consultation will be long", OccupationType.Consultation);
Occupation occupation3 = new Occupation(new DateTime(2013, 03, 13), new List<string> { "Theory", "Practice" }, "Other occupation", (OccupationType)2);

Occupation occupation4 = new Occupation(new DateTime(2014, 04, 14), new List<string>{ "Add occupation" }, "This is add occupation", OccupationType.Consultation);

UsualTask usualTask1ForOccupation1 = new UsualTask("Make a report", 5, new List<string> { "link1", "link2", "link3" }, "It is necessary to prepare a report on one of the topics from the list");
UsualTask usualTask2ForOccupation3 = new UsualTask("Learn a topic", 7, new List<string> { "link4" }, "You need to learn the topic for the next lesson");

TestTask testTask1ForOccupation2 = new TestTask("Test based on the material you listened to", 1, "Link to test");
TestTask testTask1ForOccupation3 = new TestTask("Test on the theory", 1, "Link to test");

ProjectTask projectTaskForOccupaton3 = new ProjectTask("Project for Practice", 15, "A project that consists of five practical tasks", new List<string> { "get acquainted with the case", "find court practice", "find regulations", "draw up a legal opinion" }, new List<string> { "link5", "link6" });
string subtask1 = "new subtask for students";

UsualTask usualTask3ForOccupation2 = new UsualTask("Prepare questions", 3, new List<string> { "link10", "link11" }, "You need to prepare 5 questions about the material you listened to");

Group group = new Group(
    new Student[] 
    { 
        student1,
        student2,
        student3
    },
    new Occupation[] 
    { 
        occupation1,
        occupation2,
        occupation3 
    }, 
    new FinalProject.Task[]
    {
        usualTask1ForOccupation1, 
        usualTask2ForOccupation3, 
        testTask1ForOccupation2,
        testTask1ForOccupation3,
        projectTaskForOccupaton3
    }
    );

// group.MarkAcceptedOrNotAcceptedTask(14, 1);

//group.RemoveTask(usualTask2ForOccupation3);
//group.RemoveStudent(student1);

//group.WriteToConsoleInformationAboutStudents();
//group.WriteToConsoletInformationAboutOccupations();
//group.WriteToConsoleInformationAboutTasks();

//group.AddStudent(student4);
//group.AddStudent(student5);
//Console.WriteLine();

//group.RemoveStudent(student4);
//group.AddStudent(student4);
//group.AddStudent(student4);


////group.RemoveStudent(student4);
////group.RemoveStudent(student3);
////group.RemoveStudent(student2);
////group.RemoveStudent(student1);

//Console.WriteLine("");


//group.AddOccupation(occupation4);
//group.RemoveOccupation(occupation2);
//Console.WriteLine();

//group.AddTask(usualTask3ForOccupation2);
////group.RemoveTask(projectTaskForOccupaton3);
//Console.WriteLine();

//projectTaskForOccupaton3.AddSubtask(subtask1);
//projectTaskForOccupaton3.RemoveSubtask(subtask1);
//projectTaskForOccupaton3.RemoveSubtask(projectTaskForOccupaton3.Subtasks[1]);
//Console.WriteLine();


//group.ReadFromConsoleTypesOfInformation();

group.InteractWithConsole();
//group.ViewListOfTasksWithThereMarksOfCertainStudent(10);
Console.WriteLine();
