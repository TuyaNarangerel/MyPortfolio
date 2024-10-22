using System;

namespace Portfolio.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TechStack { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string OtherInfo { get; set; }
    }
}
