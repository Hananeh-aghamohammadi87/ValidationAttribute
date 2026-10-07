using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ValidationAttribute
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام الزامی است")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        public string LastName { get; set; }

    }
}
