using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homework01.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => p.Is刪除 == false);
        }

        public override void Add(客戶銀行資訊 customerBank)
        {
            base.Add(customerBank);
            base.UnitOfWork.Commit();
        }

        public 客戶銀行資訊 Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<客戶銀行資訊> Find(string search)
        {
            return this.All().Where(c => c.銀行名稱.Contains(search));
        }

        public void Edit(客戶銀行資訊 customer)
        {
            var db = this.UnitOfWork.Context;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = this.UnitOfWork.Context;
            var customer = this.All().FirstOrDefault(c => c.Id == id);
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

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}