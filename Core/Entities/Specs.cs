using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Specs
    {
        public int ProductId {get; set;}
        public Product? Product {get; set;}
        public int SpecId {get; set;}
        public ProductSpecs? ProductSpecs {get; set;}
    }
}