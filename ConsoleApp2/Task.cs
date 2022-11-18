using System.Xml.Linq;

namespace FinalProject
{
    public abstract class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Deadline { get; set; }
        public Task(string name, int deadline)
        {
            Id = IdGenerator.GetNextId();
            Name = name;
            Deadline = deadline;
        }
        public override string ToString()
        {
            return $"{Id}. Name: {Name} \nDeadline(in days): {Deadline}";
        }
    }
}
