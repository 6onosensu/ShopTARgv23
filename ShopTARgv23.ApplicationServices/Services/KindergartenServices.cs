﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Kindergarten> Details(Guid id)
        {
            var result = await _context.Kindergarten.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;

            await _context.Kindergarten.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            Kindergarten domain = new();

            domain.Id = dto.Id;
            domain.GroupName = dto.GroupName;
            domain.ChildrenCount = dto.ChildrenCount;
            domain.KindergartenName = dto.KindergartenName;
            domain.Teacher = dto.Teacher;
            domain.CreatedAt = dto.CreatedAt;
            domain.UpdatedAt = DateTime.Now;

            _context.Kindergarten.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergarten.FirstOrDefaultAsync(x => x.Id == id);
            _context.Kindergarten.Remove(kindergarten);
            await _context.SaveChangesAsync();
            return kindergarten;
        }
    }
}