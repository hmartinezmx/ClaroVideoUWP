using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClaroVideoWebAPIs;
using ClaroVideoWebAPIs.Controllers;
using ClaroVideoWebAPIs.Models;
using System.Web.Http.Results;
using System.Net;

namespace ClaroVideoWebAPIs.Tests.Controllers
{
    [TestClass]
    public class VCardsControllerTest
    {

        [TestMethod]
        public void GetById()
        {
            VCardsController controller = new VCardsController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = controller.GetVCard(1);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsCompleted);

        }

    }
}
