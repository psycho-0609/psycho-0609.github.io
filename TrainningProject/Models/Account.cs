using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainningProject.Models
{
    public class Account
    {
        [Required]
        [Key]
        public String UserName { get; set; }
        [Required]
        
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        
        [DataType(DataType.Password)]
        public String ConfirmPassword { set; get; }



    }
}