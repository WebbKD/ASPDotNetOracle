using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORACLELab.Models
{
    public class client
    {
        private int clientID = 0;
        private string lName = "";
        private string fName = "";
        private string streetAddress = "";
        private string zip = "";
        private string dateOfBirth = "";
        private string borough = ""; 

        public int ClientID {
            get { return this.clientID; }
            set { this.clientID = value; }
        }

        public string LName {
            get { return this.lName; }
            set { this.lName = value; }
        }

        public string FName {
            get { return this.fName; }
            set { this.fName = value; }
        }

        public string StreetAddress {
            get { return this.streetAddress; }
            set { this.streetAddress = value; }
        }

        public string Zip {
            get { return this.zip; }
            set { this.zip = value; }
        }

        public string DateOfBirth {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        public string Borough {
            get { return this.borough; }
            set { this.borough = value; }
        }

        public client()
        { }

        public client(int aClientID, string aLName, string aFName, string aStreetAddress, string aZip, string aDateOfBirth, string aBorough)
        {
            this.ClientID = aClientID;
            this.LName = aLName;
            this.FName = aFName;
            this.StreetAddress = aStreetAddress;
            this.Zip = aZip;
            this.DateOfBirth = aDateOfBirth;
            this.Borough = aBorough;
        }
    }
}