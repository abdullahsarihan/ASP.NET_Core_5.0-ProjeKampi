﻿using AutoMapper;
using BusinessLayer.Abstract;
using CoreDemo.Areas.Admin.Models;
using CoreDemo.Models;
using DocumentFormat.OpenXml.Vml;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        readonly IBusinessUserService _userService;
        readonly WriterCity _writerCity;
        readonly SignInManager<AppUser> _signInManager;
        public AdminUserController(IBusinessUserService userService, IMapper mapper, WriterCity writerCity,
            SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            Mapper = mapper;
            _writerCity = writerCity;
            _signInManager = signInManager;
        }
        protected IMapper Mapper { get; }
        public async Task<IActionResult> Index(int page = 1)
        {
            var users = await _userService.GetUserListAsync();
            var values = await users.Data.ToPagedListAsync(page, 10);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> BannedUser(int id)
        {
            var user = await _userService.GetByIDAsync(id.ToString());
            if (user != null)
            {
                var value = Mapper.Map<BannedUserModel>(user);
                return View(value);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> BannedUser(BannedUserModel bannedUserModel)
        {
            var user = await _userService.GetByIDAsync(bannedUserModel.Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var result = await _userService.BannedUser(bannedUserModel.Id, bannedUserModel.BanExpirationTime, bannedUserModel.BanMessage);
            if (!result.Success)
            {
                ModelState.AddModelError("BanExpirationTime", result.Message);
                return View(user);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> BannedUserDay(int date, string id)
        {
            var result = await _userService.BannedUser(id, DateTime.Now.AddDays(date), null);
            if (!result.Success)
            {
                ModelState.AddModelError("BanExpirationTime", result.Message);
            }
            return RedirectToAction("BannedUser");
        }
        public async Task<IActionResult> OpenBanUser(string Id)
        {
            var result = await _userService.BanOpenUser(Id);
            if (!result.Success)
            {
                ModelState.AddModelError("BanExpirationTime", result.Message);
            }
            return RedirectToAction("BannedUser");
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var value = await _userService.GetByIDAsync(id.ToString());
            if (value.Success)
            {
                ViewBag.Cities = _writerCity.GetCityList();
                return View(value.Data);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserDto userDto)
        {
            var oldValue = await _userService.GetByIDAsync(userDto.Id.ToString());
            var result = await _userService.UpdateUserForAdminAsync(userDto);
            if (!result.Success)
            {
                ModelState.AddModelError("Email", "Kullanıcı bilgilerinizi güncellerken bir hata meydana geldi." +
                    " Lütfen daha sonra tekrar deneyiniz");
                ViewBag.Cities = _writerCity.GetCityList();
                return View(userDto);
            }
            var user = await _userService.GetByIDAsync(userDto.Id.ToString());
            if (user.Data.PasswordHash == oldValue.Data.PasswordHash && userDto.Password != null &&
                userDto.PasswordAgain != null && userDto.OldPassword != null)
            {
                ModelState.AddModelError("Password", "Parola güncellenirken bir hata oluştu lütfen değerleri düzgün girdiğinizden" +
                    "emin olunuz. Eğer Düzenlediyseniz diğer bilgileriniz güncellenmiştir.");
            }
            ViewBag.Cities = _writerCity.GetCityList();
            return View(userDto);
        }
    }
}
