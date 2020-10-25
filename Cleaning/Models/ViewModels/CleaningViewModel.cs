using System;

namespace Cleaning.Models.ViewModels
{
    public class CleaningViewModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string CleaningType { get; set; }
    }
}
