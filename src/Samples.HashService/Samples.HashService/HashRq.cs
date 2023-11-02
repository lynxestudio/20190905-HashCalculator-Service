using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samples.HashService
{
    public sealed class HashRq
    {
        public string HashType { get; set; }
        public string Text { get; set; }
    }
}