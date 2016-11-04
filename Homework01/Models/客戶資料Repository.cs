using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homework01.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p=>p.Is刪除 == false);
        }

        public override void Add(客戶資料 entity)
        {
            base.Add(entity);
            base.UnitOfWork.Commit();
        }

        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<客戶資料> Find(string search)
        {
            return this.All().Where(c => c.客戶名稱.Contains(search));
        }

        public void Edit(客戶資料 customer)
        {
            var db = this.UnitOfWork.Context;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = this.UnitOfWork.Context;
            var customer = this.All().FirstOrDefault(c => c.Id ==id);
            customer.Is刪除 = true;
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
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}