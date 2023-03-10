﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Controllers
{

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBusinessUserService _businessUserService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService,
            IBusinessUserService businessUserService, ICommentService commentService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _businessUserService = businessUserService;
            _commentService = commentService;
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string id, int page = 1, string search = null)
        {
            ViewData["Title"] = "Ana Sayfa";
            List<Blog> values = new();
            List<BlogandCommentCount> blogandCommentCount = new();
            if (id == null && search == null)
            {
                values = await _blogService.GetBlogListWithCategoryAsync();
                values = await values.Where(x => x.BlogStatus && x.Category.CategoryStatus).OrderByDescending(x => x.BlogCreateDate).ToListAsync();
            }
            if (id != null && search == null)
            {
                if (await _blogService.GetCountAsync(x => x.CategoryID == Convert.ToInt32(id)) != 0 &&
                    await _categoryService.GetCountAsync(x => x.CategoryID == Convert.ToInt32(id) && x.CategoryStatus) != 0)
                {
                    values = await _blogService.GetBlogListWithCategoryAsync(x => x.Category.CategoryStatus &&
                    x.CategoryID == Convert.ToInt32(id));
                    values = await values.OrderByDescending(x => x.BlogCreateDate).ToListAsync();
                    values.RemoveAll(x => x.CategoryID != Convert.ToInt32(id));
                    ViewBag.id = id;
                    ViewData["Title"] = values.FirstOrDefault().Category.CategoryName + " Blogları";
                }
                else
                {
                    values = await _blogService.GetBlogListWithCategoryAsync();
                    values = await values.OrderByDescending(x => x.BlogCreateDate).ToListAsync();
                }
            }
            if (search != null)
            {
                if (id == null)
                {
                    values = await _blogService.GetBlogListWithCategoryAsync(x => x.BlogTitle.ToLower().Contains(search.ToLower()));
                    ViewBag.Message = "'" + search + "' aramanız dair sonuçlar.";
                }
                else
                {
                    values = await _blogService.GetBlogListWithCategoryAsync(x => x.BlogTitle.ToLower().Contains(search.ToLower()) &&
                    x.CategoryID == Convert.ToInt32(id));
                    ViewBag.Message = values.FirstOrDefault().Category.CategoryName + " kategorisinde " +
                        " '" + search + "' aramanız dair sonuçlar.";
                }
                ViewData["Title"] = search;
                ViewBag.Sonuc = true;
                if (values.Count == 0)
                {
                    values = null;
                    values = await _blogService.GetBlogListWithCategoryAsync();
                    ViewBag.Message = "'" + search + "' aramanıza dair sonuç bulunamadı.";
                    ViewBag.Sonuc = false;
                }
            }
            var comments = await _commentService.GetListAsync();
            int commentCount = 0;
            foreach (var item in values)
            {
                BlogandCommentCount value = new()
                {
                    Blog = item
                };
                foreach (var comment in comments)
                {
                    if (comment.BlogID == item.BlogID)
                        commentCount++;
                }
                value.ContentCount = commentCount;
                blogandCommentCount.Add(value);
                commentCount = 0;
            }
            return View(await blogandCommentCount.ToPagedListAsync(page, 6));
        }
        [AllowAnonymous]
        public async Task<IActionResult> BlogReadAll(int id)
        {
            ViewBag.i = id;
            var value = await _blogService.GetBlogByIDAsync(id);
            if (value == null || !value.BlogStatus)
            {
                return RedirectToAction("Error404", "ErrorPage");
            }
            ViewBag.CommentCount = await _commentService.GetCountAsync(x => x.BlogID == id);
            var comments = await _commentService.TGetByFilterAsync(x => x.BlogID == id);
            if (comments != null)
            {
                ViewBag.Star = comments.BlogScore;
            }
            var writer = await _businessUserService.GetByIDAsync(value.WriterID.ToString());
            ViewBag.WriterId = writer.Id;
            ViewBag.WriterName = writer.NameSurname;
            ViewData["Title"] = value.BlogTitle;
            return View(value);
        }
        public async Task<IActionResult> BlogListByWriter(int page = 1)
        {
            var values = await _blogService.GetListWithCategoryByWriterBmAsync(User.Identity.Name);
            return View(await values.ToPagedListAsync(page, 5));
        }
        [HttpGet]
        public async Task<IActionResult> BlogAdd()
        {
            ViewBag.CategoryList = await _categoryService.GetCategoryListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog, IFormFile blogImage, IFormFile blogThumbnailImage)
        {
            var value = await _blogService.BlogAddAsync(blog, User.Identity.Name, blogImage, blogThumbnailImage);
            if (value.BlogImage == null)
            {
                ModelState.AddModelError("blogImage", "Lütfen blog resminizin linkini giriniz veya yükleyin.");
                return View(blog);
            }
            if (value.BlogThumbnailImage == null)
            {
                ModelState.AddModelError("blogThumbnailImage", "Lütfen blog küçük resminizin linkini giriniz veya yükleyin.");
                return View(blog);
            }
            ViewBag.CategoryList = await _categoryService.GetCategoryListAsync();
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blogValue = await _blogService.GetBlogByIDAsync(id);
            await _blogService.DeleteBlogAsync(blogValue, User.Identity.Name);
            return RedirectToAction("BlogListByWriter");
        }
        public async Task<IActionResult> ChangeStatusBlog(int id)
        {
            await _blogService.ChangedBlogStatusAsync(id, User.Identity.Name);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public async Task<IActionResult> EditBlog(int id)
        {
            var blogValue = await _blogService.GetBlogByIdForUpdate(id);
            ViewBag.CategoryList = await _categoryService.GetCategoryListAsync();
            return View(blogValue);
        }
        [HttpPost]
        public async Task<IActionResult> EditBlog(Blog blog, IFormFile blogImage, IFormFile blogThumbnailImage)
        {
            await _blogService.BlogUpdateAsync(blog, User.Identity.Name, blogImage, blogThumbnailImage);
            ViewBag.CategoryList = await _categoryService.GetCategoryListAsync();
            return RedirectToAction("BlogListByWriter");
        }
    }
}
