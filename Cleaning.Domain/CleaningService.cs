using AutoMapper;
using Cleaning.Data.Interfaces;
using Cleaning.Data.Models;
using Cleaning.Data.Repositories;
using Cleaning.Domain.Models;
using System;
using System.Collections.Generic;

namespace Cleaning.Domain
{
    public class CleaningService
    {
        private readonly ICleaningRepository _cleaningRepository;
        private readonly IMapper _mapper;

        public CleaningService()
        {
            _cleaningRepository = new CleaningRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CleaningModel, CleaningOrder>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public CleaningModel CreateCleaningRequest(CleaningModel model)
        {
            var existingCleaning = _cleaningRepository.GetByDateTime(model.Date);

            if (existingCleaning != null)
            {
                throw new Exception("Choose another date and time");
            }

            var cleaningOrder = _mapper.Map<CleaningOrder>(model);

            var reservedCleaning = _cleaningRepository.Create(cleaningOrder);

            return _mapper.Map<CleaningModel>(reservedCleaning);
        }

        public CleaningModel GetById(int id)
        {
            var model = _cleaningRepository.GetById(id);
            return _mapper.Map<CleaningModel>(model);
        }

        public IEnumerable<CleaningModel> GetAll()
        {
            var models = _cleaningRepository.GetAll();
            return _mapper.Map<IEnumerable<CleaningModel>>(models);
        }
    }
}
