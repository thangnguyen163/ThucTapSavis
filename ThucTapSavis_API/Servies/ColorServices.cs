﻿using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Servies
{
    public class ColorServices : IColorServices
    {
        public MyDbContext context;
        public ColorServices(MyDbContext _context)
        {
            context = _context;
        }
        public async Task<Color> AddColor(Color color)
        {
            try
            {
                var a = await context.Colors.AddAsync(color);
                context.SaveChanges();
                return color;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteColor(Guid Id)
        {
            try
            {
                var a = await context.Colors.FindAsync(Id);
                a.Status = 0;
                context.Colors.Update(a);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Color>> GetAllColor()
        {
            var a = await context.Colors.ToListAsync();
            return a;
        }

        public Task<List<Color>> GetAllColorById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Color> UpdateColor(Color color)
        {
            try
            {
                var a = await context.Colors.FindAsync(color.Id);
                a.Status = color.Status;
                a.Name = color.Name;
                context.Colors.Update(a);
                context.SaveChanges();
                return color;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
