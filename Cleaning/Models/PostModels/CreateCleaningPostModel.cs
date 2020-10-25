using System;

namespace Cleaning.Models.PostModels
{
    public class CreateCleaningPostModel
    {
        public string Phone { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string CleaningType { get; set; }
    }
}
