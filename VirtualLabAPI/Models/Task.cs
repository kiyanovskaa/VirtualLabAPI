using System.Numerics;

namespace VirtualLabAPI.Models
{
    public class Assignement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; }
        public DateTime Deadline {  get; set; }
        public int DurationTime { get; set; }
        public int Grade {  get; set; }
        public int MaxGrade {  get; set; }
        public int StudentId { get; set; }
    }
}
