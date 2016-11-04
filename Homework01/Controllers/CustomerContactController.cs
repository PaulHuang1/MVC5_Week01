using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework01.Models;

namespace Homework01.Controllers
{
    public class CustomerContactController : Controller
    {
        客戶聯絡人Repository _customerContactRepository = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository _customerRepository = RepositoryHelper.Get客戶資料Repository();

        // GET: CustomerContact
        public ActionResult Index(string search)
        {
            var 客戶聯絡人 = _customerContactRepository.All();

            if (!string.IsNullOrEmpty(search))
            {
                客戶聯絡人 = _customerContactRepository.Find(search);
            }

            return View(客戶聯絡人.ToList());
        }

        // GET: CustomerContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = _customerContactRepository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: CustomerContact/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(_customerRepository.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: CustomerContact/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                if (_customerContactRepository.IsRepeat(客戶聯絡人))
                {
                    _customerContactRepository.Add(客戶聯絡人);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Email", "該客戶聯絡人已經有相同信箱帳號存在!!");
            }

            ViewBag.客戶Id = new SelectList(_customerRepository.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = _customerContactRepository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(_customerRepository.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: CustomerContact/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                if (_customerContactRepository.IsRepeat(客戶聯絡人))
                {
                    _customerContactRepository.edit(客戶聯絡人);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Email", "該客戶聯絡人已經有相同信箱帳號存在!!");
            }
            ViewBag.客戶Id = new SelectList(_customerRepository.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = _customerContactRepository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: CustomerContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _customerContactRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _customerContactRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
