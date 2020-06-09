using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.Models
{
    public class Item
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public long price { get; set; }
        public int brandId { get; set; }
        public virtual Brand Brand { get; set; }     
        [Required]
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }
        public string image { get; set; }
    }
}