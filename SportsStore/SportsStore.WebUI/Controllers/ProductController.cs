﻿using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var productsListViewModel = new ProductsListViewModel
            {
                Products =
                    _productRepository.Products.Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.ProductId)
                        .Skip((page - 1)*PageSize)
                        .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? _productRepository.Products.Count()
                        : _productRepository.Products.Count(p => p.Category == category)
                },

                CurrentCategory = category
            };

            return View(productsListViewModel);
        }
    }
}
