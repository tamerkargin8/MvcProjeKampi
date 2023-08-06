using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = headingManager.GetHeadingList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()}).ToList();

            List<SelectListItem> valueWriter = (from x in writerManager.GetWriterList()
                                                select new SelectListItem
                                                { 
                                                 Text = x.WriterName + " " + x.WriterSurName,
                                                 Value = x.WriterID.ToString(),
                                                }).ToList();
            ViewBag.vCategory = valueCategory;
            ViewBag.vWriter = valueWriter;
            //dropdown list yaptık. Böylece başlık eklerken categoryList aşağı açılan bir liste şeklinde gelecek
            return View();

        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vCategory = valueCategory;
            var HeadingValue = headingManager.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading) 
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id) 
        {
            var headingvalues = headingManager.GetByID(id);
            if (headingvalues.HeadingStatus == true)
            {
                headingvalues.HeadingStatus = false;
            }
            else
            {
                headingvalues.HeadingStatus = true;
            }
            headingManager.HeadingDelete(headingvalues);
            return RedirectToAction("Index");
        }
    }
}