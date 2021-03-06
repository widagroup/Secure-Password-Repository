﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Secure_Password_Repository.Models
{

    [Table("Category")]
    public class Category
    {
        [Key]
        public Int32? CategoryId { get; set; }
        
        public string CategoryName { get; set; }
        
        public Int32? Category_ParentID { get; set; }
        
        public virtual Category Parent_Category { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }
        
        public virtual ICollection<Password> Passwords { get; set; }
        
        public Int16 CategoryOrder { get; set; }
        
        public bool Deleted { get; set; }

    }
}