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
        public async Task Should_AddImage_ToKindergarten()
        {
            Guid guid = Guid.Parse("9fdcacaa-8842-478a-ad87-472766b485c8");

            var dto = new KindergartenDto
            {
                Id = guid,
                GroupName = "Group B",
                ChildrenCount = 25,
                KindergartenName = "Happy Kids Updated",
                Teacher = "Mrs. Sol",
                Files = new List<FileToDatabase>
                {
                    new FileToDatabase { FileName = "image.jpg", Content = new byte[] { 255, 216, 255 } }
                }
            };

            var updatedKindergarten = await Svc<IKindergarten>().Update(dto);

            Assert.NotNull(updatedKindergarten);
            Assert.Equal(guid, updatedKindergarten.Id);
            Assert.Equal("image.jpg", updatedKindergarten.Files[0].FileName);
        }
    }
}