using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORACLELab.Models;

namespace ORACLELab.Controllers
{
    public class HomeController : Controller
    {
        OracleDB aConn = new OracleDB();
        
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult InsertClientForm()
        {

            return View();
        }

        [Authorize]
        public ActionResult UpdateClientForm(int clientID)
        {
            aConn.GetClientById(clientID);
            List<client> aListOfClients = new List<client>();
            aListOfClients = aConn.GetClientList();
            ViewBag.Client = aListOfClients;

            return View();
        }

        [Authorize]
        public ActionResult updateClient(int clientID, string LName, string FName, string StreetAddress, string Zip, string DateOfBirth, string Borough)
        {
            aConn.updateCLient(clientID, LName, FName, StreetAddress, Zip, DateOfBirth, Borough);
            
            List<client> aListOfClients = new List<client>();
            aListOfClients = aConn.GetClientList();
            ViewBag.Clients = aListOfClients;

            return View("ViewClients");
        }

        [Authorize]
        public ActionResult AddClient(string LName, string FName, string StreetAddress, string Zip, string DateOfBirth, string Borough)
        {
            aConn.addClient(LName, FName, StreetAddress, Zip, DateOfBirth, Borough);

            
            List<client> aListOfClients = new List<client>();
            aListOfClients = aConn.GetClientList();
            ViewBag.Clients = aListOfClients;
           
            return View("ViewClients");
        }



        [Authorize]
        public ActionResult ViewClients(string selectedBorough)
        {
            List<client> aListOfClients = new List<client>();
            aListOfClients = aConn.GetClientList();

            if (selectedBorough == null)
            { 
                ViewBag.Clients = aListOfClients;
            }
            else
            {
                var queryClientList = from aClient in aListOfClients
                                      where aClient.Borough == selectedBorough
                                      select aClient;

                ViewBag.Clients = queryClientList;
            }

            return View();
        }



        public ActionResult ViewLowerLevelClients(string selectedBorough)
        {
            List<client> aListOfClients = new List<client>();
            aListOfClients = aConn.GetClientList();

            if (selectedBorough == null)
            {
                ViewBag.Clients = aListOfClients;
            }
            else
            {
                var queryClientList = from aClient in aListOfClients
                                      where aClient.Borough == selectedBorough
                                      select aClient;

                ViewBag.Clients = queryClientList;
            }

            return View();
        }



        public ActionResult DeleteClient(int clientID)
        {
            aConn.deleteClient(clientID);

            List<client> aListOfClients = new List<client>();
            aListOfClients = aConn.GetClientList();
            ViewBag.Clients = aListOfClients;

            return View("ViewCLients");
        } 
    }
}