using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSecurityBddApiTests.ApiObjects
{
    public class TagObject
    {
        public List<string> tags { get; set; }
        public List<string> traces_id { get; set; }

        public string tag { get; set; }
    }
}
