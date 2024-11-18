using ShopTARgv23.Core.Dto.Coctails;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface ICoctailsServices
    {
        Task<CoctailsResultDto> GetDrink(CoctailsResultDto dto);
    }
}
