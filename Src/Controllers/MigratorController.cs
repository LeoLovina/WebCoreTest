using Microsoft.AspNetCore.Mvc;
using System;
using WebCoreTest.Interfaces;
using WebCoreTest.Models;

namespace WebCoreTest.Controllers
{
    public class MigratorController : Controller
    {
        private readonly IMigratorService ms;
        private readonly ToDoContext context;

        public MigratorController(IMigratorService ms, ToDoContext context)
        {
            this.ms = ms;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Version()
        {
            return Ok(new { Version = "1.00" });
        }

        //[HttpGet("VersionInfo")]
        public ActionResult VersionInfo()
        {
            var recs = context.VersionInfo.OrderByDescending(v => v.Version);

            return Ok(recs);
        }

        //[HttpGet("MigrateUp")]
        public ActionResult MigrateUp()
        {
            var resp = ms.MigrateUp();

            return Ok(resp);
        }

        //[HttpGet("MigrateDown/{version}")]
        public ActionResult MigrateDown(long version)
        {
            var resp = ms.MigrateDown(version);

            return Ok(resp);
        }

    }
}
