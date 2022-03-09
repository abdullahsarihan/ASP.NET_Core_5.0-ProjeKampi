﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public DashBoardController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
            //int id = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);
            //ViewBag.ToplamBlogSayisi = _blogService.GetCount(x => x.BlogStatus == true);
            //ViewBag.YazarinBlogSayisi = _blogService.GetBlogByWriter(id).Count();
            //ViewBag.KategoriSayisi = _categoryService.GetList().Count();
            return View();
        }
    }
}
