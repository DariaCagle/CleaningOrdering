using AutoMapper;
using Cleaning.Domain;
using Cleaning.Domain.Models;
using Cleaning.Models.PostModels;
using Cleaning.Models.ViewModels;
using System;

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

        public void CreateCleaningRequest(CreateCleaningPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new Exception("Invalid full name");
            if (model.Phone.Length != 13)
                throw new Exception("Invalid phone number");

            var cleaningModel = _mapper.Map<CleaningModel>(model);

            _cleaningService.CreateCleaningRequest(cleaningModel);
        }

        public CleaningViewModel GetById(int id)
        {
            return _mapper.Map<CleaningViewModel>(_cleaningService.GetById(id));
        }
    }
}
