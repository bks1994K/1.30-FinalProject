namespace FinalProject
{
    public class Occupation
    {
        public DateTime Date { get; set; }
        public List<string> Topic { get; set; }
        public string Comment { get; set; }
        public OccupationType Type { get; set; }

        public int Id { get; set; }

        public Occupation(DateTime date, List<string> topic, string comment, OccupationType type)
        {
            Id = IdGenerator.GetNextId();
            Date = date;
            Topic = topic;
            Comment = comment;
            Type = type;
        }
        public override string ToString()
        {
            return $"{Id}. {Date} \nList of topics: {ReturnValuesFromArrayTopic(Topic)}\nComment from teacher: {Comment}\nType of occupation: {Type}";
        }

        private string ReturnValuesFromArrayTopic(List<string> topic)
        {
            string rezult = Topic[0];
            for (int i = 1; i < Topic.Count; i++)
            {
                rezult = rezult + ", " + Topic[i];
            }
            return rezult;
        }
    }
}
