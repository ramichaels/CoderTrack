using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CoderTrack.Models
{
    public class CoderModel

    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAddress { get; set; }

        public String FullName()
        {
            return FirstName + " " + LastName;

        }
    }
}