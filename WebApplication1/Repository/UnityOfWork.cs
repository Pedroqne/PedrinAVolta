﻿using WebApplication1.DataContext;

namespace WebApplication1.Repository
{
    public class UnityOfWork : IUnityOfWork
    {

        private ProductRepository _productRepo;
        private CategoryRepository _categoryRepo;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepo = _productRepo ?? new ProductRepository(_context);
            }
        }


        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepo = _categoryRepo ?? new CategoryRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
