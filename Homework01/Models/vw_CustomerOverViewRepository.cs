using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework01.Models
{   
	public  class vw_CustomerOverViewRepository : EFRepository<vw_CustomerOverView>, Ivw_CustomerOverViewRepository
	{
        public override IQueryable<vw_CustomerOverView> All()
        {
            return base.All();
        }
    }

	public  interface Ivw_CustomerOverViewRepository : IRepository<vw_CustomerOverView>
	{

	}
}