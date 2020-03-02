using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DALlab;

namespace LabstorageApp.Models
{
    [MetadataType(typeof(detailmetadata))]
    public partial class detail
    {
        public string ConfirmPassword { get; set; }
    }

    public class detailmetadata
    {
        public int id { get; set; }
        [Required(ErrorMessage ="User Name Required")]
        public string Username { get; set; }
        [RegularExpression("min length 7",ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("password",ErrorMessage ="Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}