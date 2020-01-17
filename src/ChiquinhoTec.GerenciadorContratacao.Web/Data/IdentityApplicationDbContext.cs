using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChiquinhoTec.GerenciadorContratacao.Web.Data
{
    public class IdentityApplicationDbContext : IdentityDbContext
    {
        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : base(options) { }
    }
}
