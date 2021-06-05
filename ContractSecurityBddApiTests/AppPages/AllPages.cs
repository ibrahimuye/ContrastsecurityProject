using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSecurityBddApiTests.AppPages
{
    public class AllPages
    {
        // we need a private page object and a getter function for each page class created for each physical page .

        private BasePage _basePage;
                
        public BasePage BasePage()
        {
            if (_basePage == null) _basePage = new BasePage();
            return _basePage;
        }
              

    }
}
