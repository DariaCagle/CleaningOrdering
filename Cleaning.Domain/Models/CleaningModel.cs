using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning.Domain.Models
{
    public class CleaningModel
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string CleaningType { get; set; }
    }
}
