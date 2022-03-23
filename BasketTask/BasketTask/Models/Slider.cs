using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<SliderImage> Images { get; set; }
    }
}
