using System;

namespace Cleaning.Data.Models
{
    public class CleaningOrder
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string CleaningType { get; set; }
    }
}
