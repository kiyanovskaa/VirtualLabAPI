namespace VirtualLabAPI.Models
{
    public class StarterDiagram
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<string> attributes { get; set; }
        public List<string> methods { get; set; }
        public List<string> classNames { get; set; }
    }
}
