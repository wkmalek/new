using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;


namespace SolManager
{
    class SPHandler
    {
        private SPFarm farm;
        public SPHandler()
        {
            //contenxt = new ClientContext("http://localhost/");
            farm = SPFarm.Local;
        }

        internal object GetListOfSolutions()
        {
            return farm.Solutions;
        }
    }
}
