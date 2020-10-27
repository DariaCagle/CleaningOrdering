using Cleaning.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Cleaning.Data.Repositories
{
    public class CleaningRepository
    {
        private List<CleaningOrder> CleaningOrders { get; set; }
        private int count = 0;

        public CleaningRepository()
        {
            CleaningOrders = new List<CleaningOrder>();
        }

        public void Create(CleaningOrder model)
        {
            model.Id = count++;
            CleaningOrders.Add(model);
        }

        public CleaningOrder GetByDateTime (DateTime date)
        {
            return CleaningOrders.FirstOrDefault(x => x.Date.CompareTo(date) == 0);
        }

        public CleaningOrder GetById(int id)
        {
            return CleaningOrders.FirstOrDefault(x => x.Id == id);
        }

    }
}
