using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace zerohungerv2.DTO
{
    public class emploginDTO
    {
        public int E_ID { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        public string E_NAME { get; set; }
        public string E_CONTACT { get; set; }
        public string ROLE { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string E_PASS { get; set; }
    }
}