using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Заполните название услуги")]
        public string Name { get; set; }
        [Display(Name = "Изображение")]
        public byte[] Image{ get; set; }
        [Display(Name = "Описание")]
        public String Description { get; set; }
    }
}
