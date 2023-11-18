using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductSpecs : BaseEntity
    {
        public string? SpecType { get; set; }
        public string? Spec { get; set; }
        public List<Specs>? Specs { get; set; }
    }
}