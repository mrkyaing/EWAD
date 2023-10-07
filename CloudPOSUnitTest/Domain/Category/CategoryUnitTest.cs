using CloudPOS.Services;
using Moq;
using CloudPOS.Models.ViewModels;
using CloudPOS.UnitOfWorks;
using CloudPOS.Repisitories.Domain;
using CloudPOS.Models;

namespace CloudPOSUnitTest.Domain.Category
{
    public class CategoryUnitTest
    {
        public Mock<ICategoryService> categoryServiceMock = new Mock<ICategoryService>();
        public Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        public Mock<ICategoryRepository> cateroryRepositoryMock = new Mock<ICategoryRepository>();
        [Fact]
        public void GetById()
        {
            //arrange 
            string id = "1";
            var c1 = new CategoryEntity()
            {
                Id = "1",
                Code = "c1",
                Description = "Hello",
                CreatedAt =Convert.ToDateTime("2020-10-10")
            };
            IEnumerable<CategoryEntity> c =new CategoryEntity[] { c1 };
            var expextedCategory = new CategoryViewModel()
            {
                Id ="1",
                Code = "c1",
                Description = "Hello"
            };
            cateroryRepositoryMock.Setup(m => m.ReteriveBy(x=>x.Id==id)).Returns(c);
            unitOfWorkMock.Setup(u=>u.CategoryRepository).Returns(cateroryRepositoryMock.Object);
            var categoryService = new CategoryService(unitOfWorkMock.Object);
            //Act
            var result = categoryService.GetBy(id);
            //Assert 
            Assert.Equal(expextedCategory.Id, result.Id);
        }

        [Fact]
        public void Create()
        {
            //arrange
            string id = "1";
            var c1 = new CategoryEntity()
            {
                Id = id,
                Code = "c1",
                Description = "Hello",
                CreatedAt =Convert.ToDateTime("2020-10-10")
            };
            var expextedCategory = new CategoryViewModel()
            {
                Id = id,
                Code = "c2",
                Description = "Hello"//,
            };
            cateroryRepositoryMock.Setup(m => m.Create(c1));
            unitOfWorkMock.Setup(u => u.CategoryRepository).Returns(cateroryRepositoryMock.Object);
            var categoryService=new CategoryService(unitOfWorkMock.Object);
            categoryService.Create(expextedCategory);
            //act
            //Assert
        }
        [Fact]
        public void Delete()
        {
            //Arrange
            string id = "1";
            var c1 = new CategoryEntity()
            {
                Id = id,
                Code = "c1",
                Description = "Hello",
                CreatedAt =Convert.ToDateTime("2020-10-10")
            };
            var expextedCategory = new CategoryViewModel()
            {
                Id = id,
                Code = "c2",
                Description = "Hello",
            };
            cateroryRepositoryMock.Setup(m => m.Delete(c1));
            var uow = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.CategoryRepository).Returns(cateroryRepositoryMock.Object);
            var categoryService = new CategoryService(unitOfWorkMock.Object);
            categoryService.Delete("5");
            //Act
            //Assert
        }
    }
}
