using AutoMapper;
using Cleaning.Domain;
using Cleaning.Domain.Models;
using Cleaning.Models.PostModels;
using Cleaning.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace Cleaning.Controllers
{
    public class CleaningController
    {
        private readonly CleaningService _cleaningService;
        private readonly IMapper _mapper;

        public CleaningController()
        {
            _cleaningService = new CleaningService();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateCleaningPostModel, CleaningModel>();
                cfg.CreateMap<CleaningModel, CleaningViewModel>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public CleaningViewModel CreateCleaningRequest(CreateCleaningPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new Exception("Invalid full name");
            if (model.Phone.Length != 13)
                throw new Exception("Invalid phone number");

            var cleaningModel = _mapper.Map<CleaningModel>(model);

            var modelWithId = _cleaningService.CreateCleaningRequest(cleaningModel);

            return _mapper.Map<CleaningViewModel>(modelWithId);
        }

        public CleaningViewModel GetById(int id)
        {
            var model = _cleaningService.GetById(id);
            return _mapper.Map<CleaningViewModel>(model);
        }

        public IEnumerable<CleaningViewModel> GetAll()
        {
            var models = _cleaningService.GetAll();
            return _mapper.Map<IEnumerable<CleaningViewModel>>(models);
        }
    }
}
