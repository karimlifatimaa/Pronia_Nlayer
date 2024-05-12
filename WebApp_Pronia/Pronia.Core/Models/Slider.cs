using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Core.Models;

public class Slider: BaseEntity
{
    [Required(ErrorMessage = "Duzgun daxil edin")]
    public string Title { get; set; }
    [StringLength(15, ErrorMessage = "Uzunluq maksimum 15 ola biler")]
    public string SubTitle { get; set; }
    public string Description { get; set; }

    public string? ImgUrl { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; } = null!;
}
