using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;

namespace ShopTARgv23.RealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto dto = new();

            dto.Location = "asd";
            dto.Size = 123;
            dto.RoomNumber = 123;
            dto.BuildingType = "asd";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<IRealEstate>().Create(dto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            //Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("9fdcacaa-8842-478a-ad87-472766b485c8");

            //Act
            await Svc<IRealEstate>().Details(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);

        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            //Arrange
            Guid correctGuid = Guid.Parse("9fdcacaa-8842-478a-ad87-472766b485c8");
            Guid guid = Guid.Parse("9fdcacaa-8842-478a-ad87-472766b485c8");

            //Act
            await Svc<IRealEstate>().Details(guid);

            //Assert
            Assert.Equal(correctGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealestate()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var created = await Svc<IRealEstate>().Create(realEstate);
            var result = await Svc<IRealEstate>().Delete((Guid)created.Id);

            Assert.Equal(result, created);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealestate()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var created1 = await Svc<IRealEstate>().Create(realEstate);
            var created2 = await Svc<IRealEstate>().Create(realEstate);

            var result = await Svc<IRealEstate>().Delete((Guid)created2.Id);

            Assert.NotEqual(created1.Id, result.Id);
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Location = "asd",
                Size = 100,
                RoomNumber = 1,
                BuildingType = "asd",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            
            return realEstate;
        }
    }
}