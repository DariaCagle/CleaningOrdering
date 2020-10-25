using System;

namespace Cleaning.Domain.Models
{
    public class CleaningModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string CleaningType { get; set; }
    }
}
