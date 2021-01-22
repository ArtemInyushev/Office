using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication2.Models;
using WebApplication2.Repository;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using CsvHelper;

namespace WebApplication2.Controllers {
    [Route("[controller]")]
    public class WorkersController : Controller {
        private readonly string connString;
        public WorkersController(IConfiguration configuration) {
            connString = configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet]
        [Route("")]
        [Route("~/")]
        public IActionResult Workers() {
            using (OfficeContext db = new OfficeContext(connString)) {
                List<Worker> workers = (from w in db.Workers select w).ToList();
                return View(workers);
            }
        }
        [HttpPost]
        [Route("")]
        public IActionResult AddWorkers(IFormFile file) {
            using (OfficeContext db = new OfficeContext(connString)) {
                using (StreamReader reader = new StreamReader(file.OpenReadStream())) {
                    using (CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))) {
                        List<Worker> workers = csvReader.GetRecords<Worker>().ToList();
                        db.Workers.AddRange(workers).ToList();
                        db.SaveChanges();
                    }
                }
                return Redirect("/");
            }
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteWorker(int id) {
            using (OfficeContext db = new OfficeContext(connString)) {
                Worker worker = (from w in db.Workers
                                where w.Id == id
                                select w).First();
                db.Workers.Remove(worker);
                db.SaveChanges();
                return Redirect("/");
            }
        }
    }
}
