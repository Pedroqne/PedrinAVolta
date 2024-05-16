﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContext;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        public CategoryRepository(AppDbContext context) : base(context) 
        {
        }
        public IEnumerable<Category> GetCategoryAndProducts()
        {
            return Get().Include(c => c.Products);
        }
    }
}
