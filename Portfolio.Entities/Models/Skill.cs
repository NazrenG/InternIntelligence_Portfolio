using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entities.Models
{
    public class Skill:IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public string? Category { get; set; }

    }
}
