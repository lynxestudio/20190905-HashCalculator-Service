using System;

namespace Samples.HashService {
public sealed class HashRs
{
        private short code;

        public short Code
        {
            get { return code; }
            set
            {
                code = value;
            }
        }
        public string Error { get; set; }
        public string HashCode { get; set; }
}
}

