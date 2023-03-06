using BusinessLogicLayer.ViewModel;
using DataAccessLayer.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class HomeStayService
    {
        private IHomeStayRepository _homeStayRepository;

        public HomeStayService(IHomeStayRepository homeStayRepository)
        {
            _homeStayRepository = homeStayRepository;
        }

        public void AddHomeStay(HomeStayVM homeStay)
        {

            try
            {
                HomeStay _homeStay = new HomeStay()
                {
                    Id = Guid.NewGuid(),
                    Name = homeStay.Name,
                };
                _homeStayRepository.Insert(_homeStay);
                _homeStayRepository.Save();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }


        public List<HomeStay> GetHomeStays()
        {
            try
            {
                return _homeStayRepository.GetAll();
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }


    }
}
