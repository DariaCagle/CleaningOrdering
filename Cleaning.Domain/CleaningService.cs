using AutoMapper;
using Cleaning.Data.Models;
using Cleaning.Data.Repositories;
using Cleaning.Domain.Models;
using System;

namespace Cleaning.Domain
{
    public class CleaningService
    {
        private readonly CleaningRepository _cleaningRepository;
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

        public void CreateCleaningRequest(CleaningModel model)
        {

            if (_cleaningRepository.GetByDateTime(model.Date) != null)
            {
                throw new Exception("Choose another date and time");
            }

            var cleaningOrder = _mapper.Map<CleaningOrder>(model);

            _cleaningRepository.Create(cleaningOrder);
        }

        public CleaningModel GetById(int id)
        {
            var model = _cleaningRepository.GetById(id);
            return _mapper.Map<CleaningModel>(model);
        }
    }
}
