﻿using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using CoreLayer.Aspects.AutoFac.Validation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ?
                _categoryDal.GetListAll() :
                _categoryDal.GetListAll(filter);
        }

        public Category TGetByFilter(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ?
                _categoryDal.GetByFilter() :
                _categoryDal.GetByFilter(filter);
        }

        public int GetCount(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetCount(filter);
        }

        public List<SelectListItem> GetCategoryList()
        {
            return (from x in GetList()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryID.ToString()
                    }).ToList();
        }
    }
}
