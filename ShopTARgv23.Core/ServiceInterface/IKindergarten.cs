using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using System;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface IKindergarten
    {
        Task<Kindergarten> Details(Guid id);
        Task<Kindergarten> Update(KindergartenDto dto);
        Task<Kindergarten> Delete(Guid id);
        Task<Kindergarten> Create(KindergartenDto dto);
    }
}
