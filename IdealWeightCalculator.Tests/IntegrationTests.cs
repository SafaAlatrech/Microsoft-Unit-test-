using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod] 
        public void AddUser_withGoodUser_ShouldSave() 
        {
            User user = new User { BirthDate = new DateTime(2000,02,1),Email="testuser@gmail.com", Name="TestUser" };

            DataAccessLayer data = new DataAccessLayer(new WeightContext());    
           data.AddUser(user);

            User userToFind = data.GetUser("TestUser");
            userToFind.Should().BeEquivalentTo(user);
        }
    }
}
