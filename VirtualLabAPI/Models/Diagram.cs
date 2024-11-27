using System.Runtime.CompilerServices;

namespace VirtualLabAPI.Models
{
    public class Diagram
    {
        public int Id { get; set; }
        public List<Class> classes { get; set; }
        public Diagram()
        {
            classes = new List<Class>();
        }

    }
}
