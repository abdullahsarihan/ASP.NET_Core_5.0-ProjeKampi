﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminBlogController : Controller
    {
        readonly IBlogService _blogService;
        readonly ICategoryService _categoryService;
        readonly IBusinessUserService _businessUserService;
        public AdminBlogController(IBlogService blogService, ICategoryService categoryService, IBusinessUserService businessUserService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _businessUserService = businessUserService;
        }

        public async Task<IActionResult> Index(int id = 0, int page = 1)
        {
            var blogs = new List<Blog>();

            if (id != 0)
            {
                var user = await _businessUserService.GetByIDAsync(id.ToString());
                var value = await _blogService.GetBlogListWithCategoryByPagingAsync(4, page, x => x.WriterID == id);
                if (value.Data.Count > 0)
                {
                    blogs = value.Data;
                    ViewBag.UserName = user.Data.UserName+ " kullanıcısına ait bloglar.";
                }
                else
                {
                    ViewBag.UserName = user.Data.UserName + " kullanıcısına ait blog bulunamadı.";
                }
            }
            else
            {
                var result = await _blogService.GetBlogListWithCategoryByPagingAsync(4, page);
                blogs = result.Data;
            }
            var values = await blogs.ToPagedListAsync(page, 4);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            ViewBag.CategoryList = _categoryService.GetCategorySelectedListItemAsync().Result.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog, IFormFile blogImage, IFormFile blogThumbnailImage)
        {
            var result = await _blogService.BlogAddAsync(blog, User.Identity.Name, blogImage, blogThumbnailImage);
            if (!result.Success)
            {
                ViewBag.CategoryList = _categoryService.GetCategorySelectedListItemAsync().Result.Data;
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> BlogUpdate(int id)
        {
            var categoryList = await _categoryService.GetCategorySelectedListItemAsync();
            ViewBag.CategoryList = categoryList.Data;
            var blogValue = await _blogService.GetBlogByIdForUpdate(id);
            return View(blogValue.Data);
        }

        [HttpPost]
        public async Task<IActionResult> BlogUpdate(Blog blog, IFormFile blogImage, IFormFile blogThumbnailImage)
        {
            var result = await _blogService.BlogAdminUpdateAsync(blog, blogImage, blogThumbnailImage);
            if (!result.Success)
            {
                ViewBag.CategoryList = _categoryService.GetCategorySelectedListItemAsync().Result.Data;
                ModelState.AddModelError("", result.Message);
                return View(blog);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _blogService.GetFileNameContentBlogByIDAsync(id);
            await _blogService.DeleteBlogByAdminAsync(blog.Data);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatusBlog(int id)
        {
            await _blogService.ChangedBlogStatusByAdminAsync(id);
            return RedirectToAction("Index");
        }
    }
}
