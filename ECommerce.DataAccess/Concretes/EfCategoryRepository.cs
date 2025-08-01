﻿using ECommerce.Core.Repositories;
using ECommerce.DataAccess.Abstracts;
using ECommerce.DataAccess.Contexts;
using ECommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Concretes;

public class EfCategoryRepository : EfBaseRepository<BaseDbContext, Category, int>, ICategoryRepository
{
  public EfCategoryRepository(BaseDbContext context) : base(context)
  {

  }

  public async Task<Category?> GetByNameAsync(string name)
  {
    return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
  }
}