﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDontList.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Description { get; set; }
    }
}