using System.Numerics;

namespace VirtualLabAPI.Models
{
    public class Assignement
    {
        private int _durationTime;
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("");
                }
                _id = value;
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; }
        public DateTime Deadline {  get; set; }
        public int DurationTime
        {
            get => _durationTime;  // Getter uses the private backing field
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Duration time cannot be negative.");
                }
                _durationTime = value;  // Setter modifies the backing field
            }
        }
        public int Grade {  get; set; }
        public int MaxGrade {  get; set; }
        public int StudentId { get; set; }
    }
}
