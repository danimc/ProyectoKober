using Newtonsoft.Json;
using Stripe;

//using Stripe.Checkout;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Stripe.Checkout;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using TMEPortal.DataContext;

namespace TMEPortal.Controllers
{  

    public class CollectDetailsRequest
    {
        [JsonProperty("payment_method_id")]
        public string PaymentMethodId { get; set; }
    }

    public class ConfirmPaymentRequest
    {
        [JsonProperty("payment_intent_id")]
        public string PaymentIntentId { get; set; }

        [JsonProperty("selected_plan")]
        public PaymentIntentPaymentMethodOptionsCardInstallmentsPlan SelectedPlan { get; set; }
    }

    [System.Web.Http.Route("/")]
    public class PayoutsController : Controller
    {
        KoberEntities db = new KoberEntities();

        public PayoutsController()
        {
            StripeConfiguration.ApiKey =
                "sk_test_51JPs4jHcWweoTFXWqVGuSxA8W8OAzS6c9N2IF6YDwiqy4lSGq1yjg5ayU0sBt3kR5Jo4NZ2EjxCe5pI8AX2lJT2v00khXvkPkq";
        }

        [System.Web.Http.HttpPost()]
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

        [System.Web.Http.HttpGet]
        public void Exito()
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


        //[System.Web.Http.Route("/collect_details")]
       // [System.Web.Http.HttpPost]

        public async Task<ActionResult> Datos([FromBody] CollectDetailsRequest request)
        {
            var service = new PaymentIntentService();
            var options = new PaymentIntentCreateOptions
            {
                Amount = 30000,
                Currency = "mxn",
                PaymentMethodTypes = new List<string> { "card" },
                PaymentMethod = request.PaymentMethodId,
                PaymentMethodOptions = new PaymentIntentPaymentMethodOptionsOptions
                {
                    Card = new PaymentIntentPaymentMethodOptionsCardOptions
                    {
                        Installments = new PaymentIntentPaymentMethodOptionsCardInstallmentsOptions
                        {
                            Enabled = true,
                        },
                    },
                },
            };

            try
            {
                var intent = await service.CreateAsync(options);

                return Json(new
                {
                    intent_id = intent.Id,
                    available_plans = intent.PaymentMethodOptions.Card.Installments.AvailablePlans,
                });
            }
            catch (StripeException e)
            {
                // "e" contains a message explaining why the request failed
                
                int estatus =  (int)e.HttpStatusCode;
                return Json(new {error = estatus, data = e.StripeError.Message });
            }
        }

        public async Task<ActionResult> Confirma([FromBody] ConfirmPaymentRequest request)
        {
            var service = new PaymentIntentService();

            try
            {
                var options = new PaymentIntentConfirmOptions();

                if (request.SelectedPlan != null)
                {
                    options.PaymentMethodOptions = new PaymentIntentPaymentMethodOptionsOptions
                    {
                        Card = new PaymentIntentPaymentMethodOptionsCardOptions
                        {
                            Installments = new PaymentIntentPaymentMethodOptionsCardInstallmentsOptions
                            {
                                Enabled = true,
                                Plan = new PaymentIntentPaymentMethodOptionsCardInstallmentsPlanOptions
                                {
                                    Count = request.SelectedPlan.Count,
                                    Type = request.SelectedPlan.Type,
                                    Interval = request.SelectedPlan.Interval,
                                },
                            },
                        },
                    };
                }

                var intent = await service.ConfirmAsync(request.PaymentIntentId, options);

                return Json(new
                {
                    status = intent.Status,
                });
            }
            catch (StripeException e)
            {
                // "e" contains a message explaining why the request failed
                int estatus = (int)e.HttpStatusCode;
                return Json(new { error = estatus, data = e.StripeError.Message });
            }
        }
    }
    
}