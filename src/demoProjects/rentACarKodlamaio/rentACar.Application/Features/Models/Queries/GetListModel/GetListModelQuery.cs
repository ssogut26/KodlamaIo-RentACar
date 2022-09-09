using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using rentACar.Application.Features.Brands.Dtos;
using rentACar.Application.Features.Brands.Models;
using rentACar.Application.Features.Brands.Rules;
using rentACar.Application.Features.Models.Models;
using rentACar.Application.Services.Repositories;
using rentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACar.Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }
            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                //car models
                IPaginate<Model> models = await _modelRepository.GetListAsync(include:
                    m => m.Include(c => c.Brand),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                // data model
                ModelListModel model = _mapper.Map<ModelListModel>(models);
                return model;
            }

        }
    }
}
