using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tp8.WebApi.Models
{
    public class ShipperModel
    {
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "El campo CompanyName es requerido")]
        [MaxLength(40, ErrorMessage = "El campo CompanyName debe tener maximo 40 carcateres")]
        [MinLength(1, ErrorMessage = "El campo CompanyName debe tener minimo 1 carcateres")]
        public string CompanyName { get; set; }

        [StringLength(24, ErrorMessage = "El campo Phone debe tener maximo 24 carcateres")]
        public string Phone { get; set; }
    }
}