using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationApi.Models;
using AuthenticationApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<PackageModel> GetPackages()
        {
            return _packageService.GetAll();
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Moderator,Admin")]
        public ActionResult CreatePackage([FromBody] PackageModel packageModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }



            return Ok(_packageService.CreatePackage(packageModel)); // Was created
        }

        [HttpPut]
        [Route("{trackingNumber}/update")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdatePackage(string trackingNumber, [FromBody] PackageModel packageModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            return Ok(_packageService.UpdatePackage(trackingNumber, packageModel)); // Was updated
        }

        [HttpDelete]
        [Route("{trackingNumber}/remove")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePackage(string trackingNumber)
        {
            return Ok(_packageService.DeletePackage(trackingNumber)); // Was deleted
        }
    }
}