using Cleaning.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning.Data.Interfaces
{
    public interface ICleaningRepository
    {
        CleaningOrder Create(CleaningOrder model);

        CleaningOrder GetByDateTime(DateTime date);

        CleaningOrder GetById(int id);

        IEnumerable<CleaningOrder> GetAll();
    }
}
