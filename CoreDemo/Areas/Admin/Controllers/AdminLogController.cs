﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLogController : Controller
    {
        private readonly ILogService _logService;

        public AdminLogController(ILogService logService)
        {
            _logService = logService;
        }

        public async Task<IActionResult> Index(string search = null, int page = 1)
        {
            if (search != null)
            {
                ViewBag.Search = search;
            }
            var result = await _logService.GetLogListAsync(5, page, search);
            if (result.Success)
            {
                return View(await result.Data.ToPagedListAsync(page, 5));
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _logService.GetLogByIdAsync(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
    }
}
