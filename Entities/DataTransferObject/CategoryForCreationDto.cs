using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class CategoryForCreationDto
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
