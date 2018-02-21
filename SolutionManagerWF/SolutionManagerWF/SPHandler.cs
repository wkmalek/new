using System;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Client;
namespace SolutionManagerWF
{
    public class SPHandler
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