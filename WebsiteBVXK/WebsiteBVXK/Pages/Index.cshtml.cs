using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;


        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            //string username = _config.GetValue<string>("mailTrapUser:Username");
            //string password = _config.GetValue<string>("mailTrapUser:Password");

            SendEmail send = new SendEmail();

            send.Send("hoanganh18346@gmail.com", "Hi", "test mail");
        }
    }
}
