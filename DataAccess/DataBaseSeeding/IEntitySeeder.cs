﻿using Microsoft.EntityFrameworkCore;

namespace TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}