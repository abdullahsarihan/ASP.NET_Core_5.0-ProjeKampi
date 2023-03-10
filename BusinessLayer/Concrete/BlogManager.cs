﻿using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using CoreLayer.Aspects.AutoFac.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Utilities.FileUtilities;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IBusinessUserService _userService;

        public BlogManager(IBlogDal blogDal, IBusinessUserService userService)
        {
            _blogDal = blogDal;
            _userService = userService;
        }

        public async Task<List<Blog>> GetBlogListWithCategoryAsync(Expression<Func<Blog, bool>> filter = null)
        {
            var values = await _blogDal.GetListWithCategoryAsync(filter);
            foreach (var item in values)
                item.BlogContent = await TextFileManager.ReadTextFileAsync(item.BlogContent, 50);
            return values;
        }
        public async Task<List<Blog>> GetListWithCategoryByWriterBmAsync(string userName, Expression<Func<Blog, bool>> filter = null)
        {
            var user = await _userService.FindByUserNameAsync(userName);
            var values = await _blogDal.GetListWithCategoryByWriterAsync(user.Id, filter);
            foreach (var item in values)
                item.BlogContent = await TextFileManager.ReadTextFileAsync(item.BlogContent, 50);
            return values;
        }
        public async Task<Blog> GetBlogByIDAsync(int id)
        {
            var value = await _blogDal.GetByIDAsync(id);
            if (value == null)
                return value;
            value.BlogContent = await TextFileManager.ReadTextFileAsync(value.BlogContent);
            return value;
        }

        public async Task<Blog> GetBlogByIdForUpdate(int id)
        {
            var value = await _blogDal.GetByIDAsync(id);

            if (value == null)
                return value;

            if (value.BlogThumbnailImage[..4] != "http")
            {
                value.BlogThumbnailImage = null;
            }
            if (value.BlogImage[..4] != "http")
            {
                value.BlogImage = null;
            }
            value.BlogContent = await TextFileManager.ReadTextFileAsync(value.BlogContent);
            return value;
        }

        public async Task<List<Blog>> GetLastBlogAsync(int count)
        {
            var value = await _blogDal.GetListAllAsync();
            return value.TakeLast(count).ToList();
        }

        public async Task<List<Blog>> GetBlogListByWriterAsync(int id)
        {
            return await _blogDal.GetListAllAsync(x => x.WriterID == id);
        }
        [ValidationAspect(typeof(BlogValidator))]
        public async Task<Blog> BlogAddAsync(Blog blog, string userName, IFormFile blogImage, IFormFile blogThumbnailImage)
        {
            var user = await _userService.FindByUserNameAsync(userName);
            if (user == null)
                return blog;
            if (blogImage != null && blogThumbnailImage != null)
            {
                blog.BlogImage = await ImageFileManager.ImageAddAsync(blogImage, ImageFileManager.StaticProfileImageLocation());
                blog.BlogThumbnailImage = await ImageFileManager.ImageAddAsync(blogThumbnailImage, ImageFileManager.StaticProfileImageLocation());
            }
            else if (blog.BlogImage == null || blog.BlogThumbnailImage == null)
                return blog;
            blog.BlogContent = await TextFileManager.TextFileAddAsync(blog.BlogContent, TextFileManager.GetBlogContentFileLocation());
            blog.WriterID = user.Id;
            blog.BlogCreateDate = DateTime.Now;
            await _blogDal.InsertAsync(blog);
            return blog;
        }

        [ValidationAspect(typeof(BlogValidator))]
        public async Task<Blog> BlogUpdateAsync(Blog blog, string userName, IFormFile blogImage = null, IFormFile blogThumbnailImage = null)
        {
            var user = await _userService.FindByUserNameAsync(userName);
            var oldValue = await GetBlogByIDAsync(blog.BlogID);
            blog.WriterID = oldValue.WriterID;
            blog.BlogCreateDate = oldValue.BlogCreateDate;

            if (user == null || user.Id != oldValue.WriterID)
                return blog;

            if (blogImage != null && ImageFileManager.StaticProfileImageLocation() + blog.BlogImage != oldValue.BlogImage)
            {
                DeleteFileManager.DeleteFile(oldValue.BlogImage);
                blog.BlogImage = await ImageFileManager.ImageAddAsync(blogImage, ImageFileManager.StaticProfileImageLocation());
            }

            if (blogThumbnailImage != null && ImageFileManager.StaticProfileImageLocation() + blog.BlogThumbnailImage != oldValue.BlogThumbnailImage)
            {
                DeleteFileManager.DeleteFile(oldValue.BlogThumbnailImage);
                blog.BlogThumbnailImage = await ImageFileManager.ImageAddAsync(blogThumbnailImage, ImageFileManager.StaticProfileImageLocation());
            }

            blog.BlogImage ??= oldValue.BlogImage;

            blog.BlogThumbnailImage ??= oldValue.BlogThumbnailImage;

            var oldBlogValue = await GetFileNameContentBlogByIDAsync(blog.BlogID);
            if (blog.BlogContent != oldValue.BlogContent)
            {
                DeleteFileManager.DeleteFile(oldBlogValue.BlogContent);
                blog.BlogContent = await TextFileManager.TextFileAddAsync(blog.BlogContent, TextFileManager.GetBlogContentFileLocation());
            }
            else
                blog.BlogContent = oldBlogValue.BlogContent;
            await _blogDal.UpdateAsync(blog);
            return blog;
        }

        [ValidationAspect(typeof(BlogValidator))]
        public async Task<Blog> BlogAdminUpdateAsync(Blog blog, IFormFile blogImage = null, IFormFile blogThumbnailImage = null)
        {
            var oldValue = await GetBlogByIDAsync(blog.BlogID);
            blog.WriterID = oldValue.WriterID;
            blog.BlogCreateDate = oldValue.BlogCreateDate;

            if (blogImage != null && ImageFileManager.StaticProfileImageLocation() + blog.BlogImage != oldValue.BlogImage)
            {
                DeleteFileManager.DeleteFile(oldValue.BlogImage);
                blog.BlogImage = await ImageFileManager.ImageAddAsync(blogImage, ImageFileManager.StaticProfileImageLocation());
            }

            if (blogThumbnailImage != null && ImageFileManager.StaticProfileImageLocation() + blog.BlogThumbnailImage != oldValue.BlogThumbnailImage)
            {
                DeleteFileManager.DeleteFile(oldValue.BlogThumbnailImage);
                blog.BlogThumbnailImage = await ImageFileManager.ImageAddAsync(blogThumbnailImage, ImageFileManager.StaticProfileImageLocation());
            }

            blog.BlogImage ??= oldValue.BlogImage;

            blog.BlogThumbnailImage ??= oldValue.BlogThumbnailImage;

            var oldBlogValue = await GetFileNameContentBlogByIDAsync(blog.BlogID);
            if (blog.BlogContent != oldValue.BlogContent)
            {
                DeleteFileManager.DeleteFile(oldBlogValue.BlogContent);
                blog.BlogContent = await TextFileManager.TextFileAddAsync(blog.BlogContent, TextFileManager.GetBlogContentFileLocation());
            }
            else
                blog.BlogContent = oldBlogValue.BlogContent;
            await _blogDal.UpdateAsync(blog);
            return blog;
        }

        public async Task DeleteBlogAsync(Blog blog, string userName)
        {
            var user = await _userService.FindByUserNameAsync(userName);
            if (user.Id == blog.WriterID)
                await _blogDal.DeleteAsync(blog);
        }

        public async Task<int> GetCountAsync(Expression<Func<Blog, bool>> filter = null)
        {
            return await _blogDal.GetCountAsync(filter);
        }

        public async Task<List<Blog>> GetListAsync(Expression<Func<Blog, bool>> filter = null)
        {
            var values = await _blogDal.GetListAllAsync();
            foreach (var item in values)
                item.BlogContent = await TextFileManager.ReadTextFileAsync(item.BlogContent, 50);
            return values;
        }

        public async Task ChangedBlogStatusAsync(int id, string userName)
        {
            var blog = await GetFileNameContentBlogByIDAsync(id);
            var user = await _userService.FindByUserNameAsync(userName);
            if (user.Id == blog.WriterID)
            {
                var value = await _blogDal.GetByIDAsync(blog.BlogID);
                if (value.BlogStatus)
                    value.BlogStatus = false;
                else
                    value.BlogStatus = true;

                await _blogDal.UpdateAsync(value);
            }
        }

        public async Task<Blog> GetFileNameContentBlogByIDAsync(int id)
        {
            return await _blogDal.GetByIDAsync(id);
        }

        public async Task DeleteBlogByAdminAsync(Blog blog)
        {
            await _blogDal.DeleteAsync(blog);
        }

        public async Task ChangedBlogStatusByAdminAsync(int id)
        {
            var blog = await GetFileNameContentBlogByIDAsync(id);
            var value = await _blogDal.GetByIDAsync(blog.BlogID);
            if (value.BlogStatus)
                value.BlogStatus = false;
            else
                value.BlogStatus = true;
            await _blogDal.UpdateAsync(value);
        }
    }
}
