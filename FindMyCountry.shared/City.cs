using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCountry.shared
{
    public class City
    {
        public int Id {  get; set; }
        [Required(ErrorMessage ="City Name is rrquired")]
        public string cityName { get; set; }
        public int cId { get; set; }
        public Country? country { get; set; }
    }
}