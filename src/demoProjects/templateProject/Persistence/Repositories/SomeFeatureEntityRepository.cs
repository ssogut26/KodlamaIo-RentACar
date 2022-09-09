using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using rentACar.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACar.Persistence.Repositories
{
    public class SomeFeatureEntityRepository : EfRepositoryBase<SomeFeatureEntity, BaseDbContext>, ISomeFeatureEntityRepository
    {
        public SomeFeatureEntityRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
