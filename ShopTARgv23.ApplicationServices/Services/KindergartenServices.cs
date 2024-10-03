using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class KindergartenServices : IKindergarten
    {
        private readonly ShopTARgv23Context _context;
        public KindergartenServices(ShopTARgv23Context context) 
        { 
            _context = context;
        }

        public async Task<Kindergarten> DetailsAsync(Guid id)
        {
            var result = await _context.Kindergarten.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new();


            return kindergarten;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            Kindergarten domain = new();


            return domain;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergarten.FirstOrDefaultAsync(x => x.Id == id);


            return kindergarten;
        }
    }
}
