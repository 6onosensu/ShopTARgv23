using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using System;

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
            await Svc<IRealEstate>().GetAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);

        }
    
        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            //Arrange
            Guid theGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("9fdcacaa-8842-478a-ad87-472766b485c8");

            //Act
            await Svc<IRealEstate>().GetAsync(guid);

            //Assert
            Assert.Equal(theGuid, guid);
        }
    }
}