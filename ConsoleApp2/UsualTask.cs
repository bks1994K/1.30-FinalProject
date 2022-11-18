namespace FinalProject
{
    public class UsualTask : Task
    {
        public UsualTask(string name, int deadline, List<string> links, string formulation) : base(name, deadline)
        {
            Links = links;
            Formulation = formulation;
        }

        public List<string> Links { get; set; }

        public string Formulation { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} \nLinks: {ReturnValuesFromArrayOfLinks(Links)} \nFormulation: {Formulation}";
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
    }
}
