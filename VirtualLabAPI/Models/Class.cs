namespace VirtualLabAPI.Models
{
    public class Class
    {
        public string Name { get; set; }
        public List<string> attributes { get; set; }
        public List<string> methods { get; set; }
        public List<Dictionary<string, string>> relatedClasses { get; set; }

    }
}
