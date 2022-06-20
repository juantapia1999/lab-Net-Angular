using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tp7.MVC.Models.FormViewModel
{
    public class CategoryFormModel
    {
        public int? CategoryID { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Categoria es requerido")]
        [MaxLength(15,ErrorMessage ="El campo Nombre de Categoria debe tener maximo 15 carcateres")]
        [MinLength(3,ErrorMessage ="El campo Nombre de Categoria deb tener minimo 3 caracteres")]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}