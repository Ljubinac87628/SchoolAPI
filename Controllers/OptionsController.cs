using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly AutoMapper.Configuration.IConfiguration _configuration;

        public OptionsController(AutoMapper.Configuration.IConfiguration config)
        {
            _configuration = config;
        }
        [HttpOptions("reloadconfig")]

        public IActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot) _configuration;
                root.Reload();
                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");

            }
        }

    }
}
