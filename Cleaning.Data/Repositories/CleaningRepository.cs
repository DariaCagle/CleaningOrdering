using Cleaning.Data.Models;
using System;
using System.Collections.Generic;

namespace Cleaning.Data.Repositories
{
    public class CleaningRepository
    {
        private List<CleaningOrder> CleaningOrders { get; set; }

        public CleaningRepository()
        {
            CleaningOrders = new List<CleaningOrder>();
        }

        public void Create(CleaningOrder model)
        {
            CleaningOrders.Add(model);
        }

        public CleaningOrder GetById(Guid id)
        {
            foreach (var order in CleaningOrders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }

        public bool isNew(Guid id)
        {
            bool isNotOccupied = true;
            foreach (var order in CleaningOrders)
            {
                if (id == order.Id)
                {
                    isNotOccupied = false;
                    break;
                }
            }
            return isNotOccupied;
        }

        public bool isBusy(DateTime dateTime)
        {
            bool isOccupied = false;
            foreach (var order in CleaningOrders)
            {
                if (dateTime == order.Date)
                {
                    isOccupied = true;
                    break;
                }
            }
            return isOccupied;
        }
    }
}
