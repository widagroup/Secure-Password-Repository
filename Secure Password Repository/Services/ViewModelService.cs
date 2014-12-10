﻿using Secure_Password_Repository.Models;
using Secure_Password_Repository.Repositories;
using Secure_Password_Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Secure_Password_Repository.Services
{

    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ViewModelService), "AutoMapperStart")]
    public class ViewModelService : IViewModelService
    {

        private ICategoryRepository categoryRepository;
        private IPasswordRepository passwordRepository;
        private IUserPasswordRepository userpasswordRepository;

        public ViewModelService(ICategoryRepository categoryRepository, IPasswordRepository passwordRepository, IUserPasswordRepository userpasswordRepository)
        {
            this.categoryRepository = categoryRepository;
            this.passwordRepository = passwordRepository;
            this.userpasswordRepository = userpasswordRepository;
        }

        /// <summary>
        /// Setup all of the automapper maps that will be used throughout this controller - this is called by WebActivatorEx
        /// </summary>
        public static void AutoMapperStart()
        {
            AutoMapper.Mapper.CreateMap<Category, CategoryItem>();
            AutoMapper.Mapper.CreateMap<Category, CategoryDelete>();
            AutoMapper.Mapper.CreateMap<CategoryAdd, Category>();
            AutoMapper.Mapper.CreateMap<CategoryEdit, Category>();

            AutoMapper.Mapper.CreateMap<Category[], IList<CategoryItem>>();
            AutoMapper.Mapper.CreateMap<Password[], IList<PasswordItem>>();
            AutoMapper.Mapper.CreateMap<UserPassword[], IList<PasswordUserPermission>>().ReverseMap();

            AutoMapper.Mapper.CreateMap<UserPassword, PasswordUserPermission>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Password, PasswordItem>();
            AutoMapper.Mapper.CreateMap<Password, PasswordEdit>();
            AutoMapper.Mapper.CreateMap<Password, PasswordDisplay>();
            AutoMapper.Mapper.CreateMap<Password, PasswordDelete>();
            AutoMapper.Mapper.CreateMap<PasswordAdd, Password>();
            AutoMapper.Mapper.CreateMap<PasswordEdit, PasswordDisplay>();
        }

        public ViewModels.CategoryDisplayItem GetCategoryDisplayItem(int parentcategoryid)
        {
            //get the root node, and include it's subcategories
            var rootCategoryItem = categoryRepository.GetCategoryWithChildren(rootCategoryId, passwordRepository.GetPasswordIdsByParentId(rootCategoryId), CurrentUser.CanOverridePasswordPermissions());



        }
    }
}