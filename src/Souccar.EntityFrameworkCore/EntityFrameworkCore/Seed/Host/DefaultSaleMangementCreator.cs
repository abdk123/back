﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Souccar.EntityFrameworkCore.Seed.Host
{
    public class DefaultSaleMangementCreator
    {
        private readonly SouccarDbContext _context;
        public DefaultSaleMangementCreator(SouccarDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUnits();
        }

        private void CreateUnits()
        {

            if (_context.Languages.IgnoreQueryFilters().Any(l => l.Name.Contains("طن")))
            {
                return;
            }

            _context.Unit.Add(new SaleManagement.Settings.Units.Unit() { Name ="طن"});
            _context.SaveChanges();
        }
    }
}