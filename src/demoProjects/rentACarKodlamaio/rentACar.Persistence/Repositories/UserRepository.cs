﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using rentACar.Application.Services.Repositories;
using rentACar.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACar.Persistence.Repositories
{
    public class UserRepository:EfRepositoryBase<User, BaseDbContext>,IUserRepository 
    {
        public UserRepository(BaseDbContext context) : base(context)
        {

        }
    }

}
