using DataAccessLayer.Interface;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class HomeStayRepository : GenericRepository<HomeStay> , IHomeStayRepository
    {
        public HomeStayRepository(AppDbContext context) : base(context)
        {

        }
    }
}
