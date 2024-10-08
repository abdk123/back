﻿namespace Souccar.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly SouccarDbContext _context;

        public InitialHostDbBuilder(SouccarDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultSaleMangementCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
