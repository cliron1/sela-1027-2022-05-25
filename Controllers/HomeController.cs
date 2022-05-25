using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Options.Models;
using Options.Models.Settings;
using System.Diagnostics;

namespace Options.Controllers {
	public class HomeController : Controller {
		private readonly IConfiguration config;
		private readonly SmsSettings smsSettings;
		private readonly ILogger<HomeController> _logger;

		public HomeController(IConfiguration config, IOptionsSnapshot<SmsSettings> smsSettings, ILogger<HomeController> logger) {
			this.config = config;
			this.smsSettings = smsSettings.Value;
			_logger = logger;
		}

		public IActionResult Index() {
			var emailSettings = new EmailSettings();
			config.GetSection("Email").Bind(emailSettings);

			//config["Email:Smtp"]
			//config["Email:Whitelist[1]"]
			//config.GetSection("Email").GetValue<int>("Port")

			var url = smsSettings.Url;

			return View();
		}

		public IActionResult Privacy() {

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}