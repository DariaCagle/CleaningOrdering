using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaning.Data.Repositories;
using Cleaning.Domain.Models;
using Cleaning.Data.Models;
using AutoMapper;
using System.Runtime.CompilerServices;

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
                cfg.CreateMap<CleaningModel, CleaningOrder>();                
            });
            var mapper = new Mapper(mapperConfig);
        }

        public void CreateCleaningRequest(CleaningModel model)
        {
            if (_cleaningRepository.isBusy(model.Date))
            {
                throw new Exception("Choose another date and time");
            }

            var cleaningOrder = _mapper.Map<CleaningOrder>(model);

            _cleaningRepository.Create(cleaningOrder);
        }
    }
}
