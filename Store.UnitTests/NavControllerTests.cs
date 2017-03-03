using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Store.Controllers;
using Store.Domain.Abstract;
using Store.Domain.Entities;

namespace Store.UnitTests
{
    [TestFixture]
    class NavControllerTests
    {
        [Test]
        public void NavControllerMenu_WhenCalled_CreatesCorrectCategories()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>()
            {
                new Product {ProductId = 1,Name="P1",Category = "Category1",},
                new Product {ProductId = 2,Name="P2",Category = "Category1",},
                new Product {ProductId = 3,Name="P3",Category = "Category2",},
                new Product {ProductId = 4,Name="P4",Category = "Category3",}
            });

            NavController stubNavController = new NavController(mock.Object);

            string [] result = ((IEnumerable<string>) stubNavController.Menu().Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], "Category1");
            Assert.AreEqual(result[1], "Category2");
            Assert.AreEqual(result[2], "Category3");
        }
    }
}