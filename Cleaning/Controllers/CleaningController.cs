using Cleaning.Domain;
using Cleaning.Domain.Models;
using Cleaning.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning.Controllers
{
    public class CleaningController
    {
        private readonly CleaningService _cleaningService;
        public CleaningController()
        {
            _cleaningService = new CleaningService();
        }

        public void CreateCleaningRequest(CreateCleaningPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new System.Exception("Invalid full name");
            if (model.Phone.Length != 13)
                throw new System.Exception("Invalid phone number");

            var cleaningModel = new CleaningModel
            {
                Date = model.Date,
                Phone = model.Phone,
                FullName = model.FullName,
                CleaningType = model.CleaningType
            };

            _cleaningService.CreateCleaningRequest(cleaningModel);
        }
    }
}
