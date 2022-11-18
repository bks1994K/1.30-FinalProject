namespace FinalProject
{
    public class TestTask : Task
    {
        public TestTask(string name, int deadline, string link) : base(name, deadline)
        {
            Link = link;
        }
        public string Link { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} \nLink: {Link}";
        }
    }
}
