using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;
using Microsoft.Extensions.Logging;

namespace TheWorld.Controllers.Web
{
  public class AppController : Controller
  {
    private IMailService _mailService;
    private IConfigurationRoot _config;
    private IWorldRepository _repository;
    private ILogger<AppController> _logger;

    //private WorldContext _context; //Removed to add the repository call

    public AppController(IMailService mailService, IConfigurationRoot config,
        IWorldRepository repository, ILogger<AppController> logger)
    {
      _mailService = mailService;
      _config = config;
      _repository = repository;
      _logger = logger;
    }

    public IActionResult Index()
    {
      try
      {
        return View();
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get the trips in Index page : {ex.Message}");
        return Redirect("/error");
      }
    }

    [Authorize]
    public IActionResult Trips()
    {
      try
      {
        var data = _repository.GetAllTrips();
        return View(data);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get the trips in Index page : {ex.Message}");
        return Redirect("/error");
      }
    }

    public IActionResult About()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Contact(ContactViewModel model)
    {

      if (ModelState.IsValid)
      {
        _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From TheWorld", model.Message);

        ModelState.Clear();

        ViewBag.UserMessage = "Message Sent";
      }


      return View();
    }

    public IActionResult Contact()
    {
      return View();
    }
  }
}
