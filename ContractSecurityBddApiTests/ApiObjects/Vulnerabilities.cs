using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSecurityBddApiTests.ApiObjects
{
    public class Vulnerabilities
    {
        public bool success { get; set; }

        public List<Traces> traces { get; set; }
    }
}
