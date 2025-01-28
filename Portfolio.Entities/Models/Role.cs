
using Microsoft.AspNetCore.Identity;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entities.Models
{
    public class Role:IdentityRole,IEntity
    {
    }
}
