using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace TMEPortal.Controllers
{
    public class PayoutsController : Controller
    {

        public PayoutsController()
        {
            StripeConfiguration.ApiKey =
                "sk_test_51JPs4jHcWweoTFXWqVGuSxA8W8OAzS6c9N2IF6YDwiqy4lSGq1yjg5ayU0sBt3kR5Jo4NZ2EjxCe5pI8AX2lJT2v00khXvkPkq";
        }

        [HttpPost()]
        public ActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
        {
          "card",
        },
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount = 2000,
              Currency = "usd",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "T-shirt",
              },

            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "http://localhost:50125/Payouts/exito?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://example.com/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new HttpStatusCodeResult(303);
        }


        // GET: Payouts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public void exito ()
        {
            Response.ContentType = "application/json";
            StripeConfiguration.ApiKey = "sk_test_51JPs4jHcWweoTFXWqVGuSxA8W8OAzS6c9N2IF6YDwiqy4lSGq1yjg5ayU0sBt3kR5Jo4NZ2EjxCe5pI8AX2lJT2v00khXvkPkq";

            string session = Request.QueryString["session_id"];



            var service = new SessionService();
            service.Get(session);


            var json = JsonConvert.SerializeObject(service);


            Response.Write(json);


           // return View("Index");
        }
    }


}