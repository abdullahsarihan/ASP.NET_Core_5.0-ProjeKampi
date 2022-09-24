﻿using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [MaxLength(150)]
        public string BlogTitle { get; set; }
        [MaxLength(4000)]
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int WriterID { get; set; }
        public AppUser Writer { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
