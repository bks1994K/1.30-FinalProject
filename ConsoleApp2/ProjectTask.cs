using System.Linq;

namespace FinalProject
{
    public class ProjectTask : Task
    {
        public ProjectTask(string name, int deadLine, string description, List<string> subtasks, List<string> links) : base(name, deadLine)
        {
            Description = description;
            Subtasks = subtasks;
            Links = links;
        }

        public string Description { get; set; }
        public List<string> Subtasks { get; set; }
        public List<string> Links { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} \nDescription: {Description} \nSubtasks: {ReturnValuesFromArrayOfSubtasks(Subtasks)} \nLinks: {ReturnValuesFromArrayOfLinks(Links)}";
        }

        private string ReturnValuesFromArrayOfLinks(List<string> links)
        {
            string rezult = Links[0];
            for (int i = 1; i < Links.Count; i++)
            {
                rezult = $"{rezult}, {Links[i]}";
            }
            return rezult;
        }

        private string ReturnValuesFromArrayOfSubtasks(List<string> subtasks)
        {
            string rezult = Subtasks[0];
            for (int i = 1; i < Subtasks.Count; i++)
            {
                rezult = $"{rezult}, {Subtasks[i]}";
            }
            return rezult;
        }

        public bool AddSubtask(string addSubtask)
        {
            if (Subtasks.Contains(addSubtask))
            {
                return false;
            }
            Subtasks.Add(addSubtask);
            return true;
        }

        public bool RemoveSubtask(string subtask)
        {
            if (!Subtasks.Contains(subtask))
            {
                return false;
            }
            Subtasks.Remove(subtask);
            return true;
        }
    }
}
