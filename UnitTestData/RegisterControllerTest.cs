using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using EBusiness.Data.Models;
using EBusiness.Repositories;
using Moq;
using EBusiness.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EbuisnessUnitTest
{
    public class RegisterControllerTest
    {
        [Fact]
        public void Adding_a_User_to_the_mock_database_and_Redirect()
        {
            //arrange
            Mock<Context> context_mock = new Mock<Context>();
            User u = new User()
            {
                Durum = true,
                Role = "User",
                UserAd = "koro",
                Userid = 009,
                UserMail="o2",
                UserSehir="ist",
                UserSifre="aasdlfsadf",
                UserSoyad="Koro"
            };
            context_mock.Object.Add(u);
            RegisterController pc = new RegisterController(context_mock.Object);
            //act
            RedirectToActionResult a = (RedirectToActionResult)pc.RegisterUser(u);
            //assert
            Assert.IsType<RedirectToActionResult>(a);
        }

    }
}
