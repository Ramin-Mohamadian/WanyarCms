using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.DataLayer.Entities;

namespace Wanyar.DataLayer.Context
{
    public class WanyarContext : DbContext
    {
        public WanyarContext(DbContextOptions<WanyarContext> options) : base(options)
        {

        }

        #region Users
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion


        #region ArticleGroup
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        #endregion

        #region Article
        public DbSet<Article> Articles { get; set; }
        #endregion

        #region Permission
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermissions> RolePermissions { get; set; }
        #endregion

    }
}