using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaning.Data.Repositories;
using Cleaning.Domain.Models;
using Cleaning.Data.Models;

namespace Cleaning.Domain
{
    public class CleaningService
    {
        private readonly CleaningRepository _cleaningRepository;

        public CleaningService()
        {
            _cleaningRepository = new CleaningRepository();
        }

        public void CreateCleaningRequest(CleaningModel model)
        {
            // Проверка, есть ли свободное время, чтобы записать на мойку машину

            var cleaningOrder = new CleaningOrder
            {
                Date = model.Date,
                Phone = model.Phone,
                FullName = model.FullName,
                CleaningType = model.CleaningType
            };

            _cleaningRepository.Create(cleaningOrder);
        }
    }
}
