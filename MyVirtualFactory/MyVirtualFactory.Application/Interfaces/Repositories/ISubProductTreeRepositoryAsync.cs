﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Domain.Entities;

namespace MyVirtualFactory.Application.Interfaces.Repositories
{
    public interface ISubProductTreeRepositoryAsync : IGenericRepositoryAsync<SubProductTree>
    {
        Task<List<SubProductTree>> GetAllIncludeProduct();
    }
}
