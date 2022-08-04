﻿using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Models
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }
    }
}
