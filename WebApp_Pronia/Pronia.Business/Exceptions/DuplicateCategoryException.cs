using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Exceptions;

public class DuplicateCategoryException : Exception
{
    public string PropertyName { get; set; }
    public DuplicateCategoryException(string propertyname,string? message) : base(message)
    {
        PropertyName = propertyname;
    }
}
