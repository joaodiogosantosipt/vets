using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vets.Models;

namespace vet_meu.Data
{
    //esta classe funciona como a base do nosso projeto
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        //definir as tabelas
        public DbSet<Animais> Animais { get; set; }
        public DbSet<Veterinarios> Veterinarios { get; set; }
        public DbSet<Donos> Donos { get; set; }
        public DbSet<Consultas> Consultas { get; set; }  

    }
}

