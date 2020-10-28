using Cleaning.Data.Models;
using System;
using System.Collections.Generic;

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
