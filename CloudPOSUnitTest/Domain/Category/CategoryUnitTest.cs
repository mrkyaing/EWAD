using CloudPOS.Services;
using Moq;
using CloudPOS.Models.ViewModels;
using CloudPOS.UnitOfWorks;
using CloudPOS.Repisitories.Domain;
using CloudPOS.Models;
using Newtonsoft.Json;

namespace CloudPOSUnitTest.Domain.Category
{
    public class CategoryUnitTest
    {
        public Mock<ICategoryService> categoryServiceMock = new Mock<ICategoryService>();
        public Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        public Mock<ICategoryRepository> cateroryRepositoryMock = new Mock<ICategoryRepository>();
        [Fact]
        public void GetAll()
        {
            //Arrange data 
            var expectedResults = new List<CategoryViewModel>()
            {
                new CategoryViewModel{Id="1",Code="t1",Description="test1"},
                new CategoryViewModel{Id="2",Code="t2",Description="test2"},
                new CategoryViewModel{Id="3",Code="t3",Description="test3"}
            };
            IEnumerable<CategoryEntity> dbCategoryEntities = new CategoryEntity[]
            {
                new CategoryEntity{Id="1",Code="t1",Description="test1"},
                new CategoryEntity{Id="2",Code="t2",Description="test2"},
                new CategoryEntity{Id="3",Code="t3",Description="test3"}
            };
            cateroryRepositoryMock.Setup(r => r.ReteriveAll()).Returns(dbCategoryEntities);
            unitOfWorkMock.Setup(u=>u.CategoryRepository).Returns(cateroryRepositoryMock.Object);
            // Action the to do list
            var categoryService = new CategoryService(unitOfWorkMock.Object);
            var actualResults= categoryService.GetAll().Select(s=>new CategoryViewModel
            {
                Id=s.Id,Code=s.Code,Description=s.Description
            }).ToList();
            //Check/Verify with Assert object 
            var j1 = JsonConvert.SerializeObject(expectedResults);
            var j2 = JsonConvert.SerializeObject(actualResults);
            Assert.Equal(j1, j2);
        }
        [Fact]
        public void GetById()
        {
            //1)Arrange
            string id = "303";
            var expectedCategoryViewModel = new CategoryViewModel()
            {
                Id = id,
                Code = "c1",
                Description = "ElectronicItem",
                CreatedAt = Convert.ToDateTime("2021-10-10")
            };
            var dbCategoryEntity = new CategoryEntity()
            {
                Id = id,
                Code = "c1",
                Description = "ElectronicItem",
                CreatedAt = Convert.ToDateTime("2021-10-10")
            };
            var categories = new CategoryEntity[] { dbCategoryEntity };
            cateroryRepositoryMock.Setup(r => r.ReteriveBy(x => x.Id == id)).Returns(categories);
            unitOfWorkMock.Setup(u => u.CategoryRepository).Returns(cateroryRepositoryMock.Object);
            //2)Action
            var categoryService = new CategoryService(unitOfWorkMock.Object);
            var result = categoryService.GetBy(id);
            //3)Assert 
            var expectedResultInJson = JsonConvert.SerializeObject(expectedCategoryViewModel);
            var actualResultInJson = JsonConvert.SerializeObject(result);
            //compare the whole json object 
            Assert.Equal(actualResultInJson, expectedResultInJson);
        }
        [Fact]
        public void Create()
        {
            //arrange
            string id = "1";
            var expextedCategory = new CategoryViewModel()
            {
                Id = id,
                Code = "c2",
                Description = "Hello",
            };
            var dbCategoryEntity = new CategoryEntity()
            {
                Id = id,
                Code = "c1",
                Description = "Hello",
                CreatedAt = Convert.ToDateTime("2020-10-10")
            };
            cateroryRepositoryMock.Setup(r => r.Create(dbCategoryEntity));//mock categoryRepository
            unitOfWorkMock.Setup(u => u.CategoryRepository).Returns(cateroryRepositoryMock.Object);//mock UnitOfWork
            //act
            var categoryService = new CategoryService(unitOfWorkMock.Object);//create a service object with unitOfWork mock 
            var result = categoryService.Create(expextedCategory);
            //Assert
            Assert.Equal(result.Description, expextedCategory.Description);
        }
        [Fact]
        public void Update()
        {
            //Arrange
            var updateCategoryEntity = new CategoryEntity()
            {
                Id = "u1",
                Code = "test",
                Description = "unitTest"
            };
            var inputCategoryViewModel = new CategoryViewModel()
            {
                Id = "u1",
                Code = "test",
                Description = "unitTest"
            };
            cateroryRepositoryMock.Setup(r => r.Update(updateCategoryEntity));
            unitOfWorkMock.Setup(u => u.CategoryRepository).Returns(cateroryRepositoryMock.Object);
            //Action
            var categorySerice = new CategoryService(unitOfWorkMock.Object);
            var result = categorySerice.Update(inputCategoryViewModel);
            //Assert
            Assert.Equal(inputCategoryViewModel.Id, result.Id);
        }
        [Fact]
        public void Delete()
        {
            //Arrange
            string id = "1";
            var dbCategoryEntity = new CategoryEntity()
            {
                Id = id,
                Code = "c1",
                Description = "Hello",
                CreatedAt = Convert.ToDateTime("2020-10-10")
            };
            var categories = new CategoryEntity[] { dbCategoryEntity };
            cateroryRepositoryMock.Setup(r => r.ReteriveBy(x=>x.Id==id)).Returns(categories);
            unitOfWorkMock.Setup(u => u.CategoryRepository).Returns(cateroryRepositoryMock.Object);
            //Act
            var categoryService = new CategoryService(unitOfWorkMock.Object);
            var actualResult = categoryService.Delete(id);
            //Assert
            Assert.True(actualResult);
        }
    }
}
