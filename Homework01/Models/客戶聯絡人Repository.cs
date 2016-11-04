using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homework01.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(c=>c.Is刪除 == false);
        }

        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<客戶聯絡人> Find(string search)
        {
            return this.All().Where(c => c.姓名.Contains(search));
        }

        public bool IsRepeat(客戶聯絡人 customerContact)
        {
            var isRepeat = this.All().Where(c => c.客戶Id == customerContact.客戶Id && c.Email == customerContact.Email && c.Id != customerContact.Id).Count();
            return isRepeat == 0;
        }

        public override void Add(客戶聯絡人 customerContact)
        {
            base.Add(customerContact);
            base.UnitOfWork.Commit();
        }

        public void edit(客戶聯絡人 customerContact)
        {
            var db = this.UnitOfWork.Context;
            db.Entry(customerContact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = this.UnitOfWork.Context;
            var customerContact = this.All().FirstOrDefault(c => c.Id == id);
            customerContact.Is刪除 = true;
            //var contactList = this.All()..Where(co => co.客戶Id == 客戶資料.Id);
            //foreach (var contact in contactList)
            //{
            //    contact.Is刪除 = true;
            //}
            //var bankList = db.客戶銀行資訊.Where(co => co.客戶Id == 客戶資料.Id);
            //foreach (var bank in bankList)
            //{
            //    bank.Is刪除 = true;
            //}
            db.Entry(customerContact).State = EntityState.Modified;
            db.SaveChanges();
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}