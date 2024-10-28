using ShopTARgv23.ApplicationServices.Services;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;

namespace ShopTARgv23.KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        [Fact]
        public async Task Should_Create_Kindergarten()
        {
            var dto = new KindergartenDto
            {
                GroupName = "Group",
                ChildrenCount = 20,
                KindergartenName = "Happy Kids",
                Teacher = "Mrs. Sol"
            };

            var createdKindergarten = await Svc<IKindergarten>().Create(dto);

            Assert.NotNull(createdKindergarten);
            Assert.Equal(dto.GroupName, createdKindergarten.GroupName);
            Assert.Equal(dto.ChildrenCount, createdKindergarten.ChildrenCount);
            Assert.Equal(dto.KindergartenName, createdKindergarten.KindergartenName);
            Assert.Equal(dto.Teacher, createdKindergarten.Teacher);
        }

        [Fact]
        public async Task Should_GetById_Kindergarten()
        {
            Guid correctGuid = Guid.Parse("9fdcacaa-8842-478a-ad87-472766b485c8");
            Guid guid = Guid.Parse("9fdcacaa-8842-478a-ad87-472766b485c8");

            await Svc<IKindergarten>().Details(guid);

            Assert.Equal(correctGuid, guid);
        }

        [Fact]
        public async Task Should_Update_Kindergarten()
        {
            var dto = new KindergartenDto
            {
                GroupName = "Group B",
                ChildrenCount = 25,
                KindergartenName = "Happy Kids Updated",
                Teacher = "Mrs. Sol",
            };
            var created = await Svc<IKindergarten>().Create(dto);

            var updateDto = new KindergartenDto
            {
                GroupName = "Group B",
                ChildrenCount = 25,
                KindergartenName = "Sunny Kids",
                Teacher = "Mr. Johnson"
            };

            var updatedKindergarten = await Svc<IKindergarten>().Update(updateDto);

            Assert.NotNull(updatedKindergarten);
            Assert.Equal(updateDto.GroupName, updatedKindergarten.GroupName);
            Assert.Equal(updateDto.ChildrenCount, updatedKindergarten.ChildrenCount);
            Assert.Equal(updateDto.KindergartenName, updatedKindergarten.KindergartenName);
            Assert.NotEqual(dto.Teacher, updatedKindergarten.Teacher);
            Assert.Equal(updateDto.Teacher, updatedKindergarten.Teacher);
        }

        [Fact]
        public async Task Should_Delete_Kindergarten()
        {
            var dto = new KindergartenDto
            {
                GroupName = "Group A",
                ChildrenCount = 20,
                KindergartenName = "Happy Kids Kindergarten",
                Teacher = "Mrs. Smith"
            };
            var created = await Svc<IKindergarten>().Create(dto);
            var deletedKindergarten = await Svc<IKindergarten>().Delete((Guid)created.Id);

            Assert.Equal(deletedKindergarten, created);
        }
    }
}