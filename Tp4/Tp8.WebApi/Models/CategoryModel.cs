using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tp8.WebApi.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "El campo CategoryName es requerido")]
        [MaxLength(15, ErrorMessage = "El campo CategoryName debe tener maximo 15 carcateres")]
        [MinLength(3, ErrorMessage = "El campo CategoryName debe tener minimo 3 caracteres")]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}