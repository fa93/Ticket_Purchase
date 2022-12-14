using Autofac;
using Microsoft.AspNetCore.Mvc;
using TicketPurchase.Booking.Exceptions;
using TicketPurchase.Web.Areas.Admin.Models;

namespace TicketPurchase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<TicketController> _logger;
        public TicketController(ILogger<TicketController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<TicketBookingModel>();
            return View(model);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Create(TicketBookingModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                try
                {
                    model.PurchaseTicket();
                   
                    TempData["ResponseTitle"] = "Success";
                    TempData["ResponseMessage"] = "Successfully purchased a ticket";
                    TempData["ResponseType"] = "Success";
                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);
                    
                    TempData["ResponseTitle"] = "Error";
                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = "Danger";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                  
                    TempData["ResponseTitle"] = "Error";
                    TempData["ResponseMessage"] = "There was a problem in booking a ticket.";
                    TempData["ResponseType"] = "Danger";
                }

            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _scope.Resolve<TicketEditModel>();
            model.LoadData(id);
            return View(model);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(TicketEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                try
                {
                    model.EditTicket();
                    /*TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        MessageTitle = "Success",
                        MessageBody = "Successfully added a new course.",
                        Type = ResponseTypes.Success
                    });*/
                    TempData["ResponseTitle"] = "Success";
                    TempData["ResponseMessage"] = "Successfully updated a ticket";
                    TempData["ResponseType"] = "Success";
                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);
                    /*TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        MessageTitle = "Error",
                        MessageBody = ioe.Message,
                        Type = ResponseTypes.Danger
                    });*/
                    TempData["ResponseTitle"] = "Error";
                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = "Danger";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    /* TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                     {
                         MessageTitle = "Error",
                         MessageBody = "There was a problem in creating course.",
                         Type = ResponseTypes.Danger
                     });*/
                    TempData["ResponseTitle"] = "Error";
                    TempData["ResponseMessage"] = "There was a problem in updating a ticket Info.";
                    TempData["ResponseType"] = "Danger";
                }

            }
            return View(model);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _scope.Resolve<BookingListModel>();
                model.DeleteTicket(id);

                TempData["ResponseTitle"] = "Success";
                TempData["ResponseMessage"] = "Successfully deleted a ticket";
                TempData["ResponseType"] = "Success";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData["ResponseTitle"] = "Error";
                TempData["ResponseMessage"] = "There was a problem in deleting a ticket Info.";
                TempData["ResponseType"] = "Danger";
            }
            return RedirectToAction("Index");
        }


    }
}
