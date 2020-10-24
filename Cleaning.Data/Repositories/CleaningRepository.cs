using Cleaning.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public CleaningOrder Find(int id)
        {
            foreach(var order in CleaningOrders)
            {
                if(order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }

        public bool isBusy(DateTime dateTime)
        {
            bool isOccupied = false;
            foreach(var order in CleaningOrders)
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
