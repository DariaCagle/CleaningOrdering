using AutoMapper;
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
        private readonly IMapper _mapper;
        public CleaningController()
        {
            _cleaningService = new CleaningService();
            var mapperConfig = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<CreateCleaningPostModel, CleaningModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => new Guid()));
            });
            var mapper = new Mapper(mapperConfig);
        }

        public void CreateCleaningRequest(CreateCleaningPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new System.Exception("Invalid full name");
            if (model.Phone.Length != 13)
                throw new System.Exception("Invalid phone number");

            var cleaningModel =_mapper.Map<CleaningModel>(model);

            _cleaningService.CreateCleaningRequest(cleaningModel);
        }
    }
}
