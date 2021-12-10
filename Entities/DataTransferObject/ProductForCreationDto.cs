using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class ProductForCreationDto
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Title { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
    }
}
