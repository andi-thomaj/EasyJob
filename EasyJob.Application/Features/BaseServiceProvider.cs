using AutoMapper;
using MediatR;

namespace EasyJob.Application.Features
{
    public class BaseServiceProvider
    {
        public IMapper Mapper { get; set; }
        public IMediator Mediator { get; set; }
        
    }
}