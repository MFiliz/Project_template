using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Fountain.Domain;
using Fountain.Domain.BaseClass;
using System.Linq.Expressions;

namespace Fountain.Repository.Context
{
    public class MyEnt : DbContext
    {
        public MyEnt()
            : base("FountainContext")
        {
        }

        public override int SaveChanges()
        {
            InsertListener();
            UpdateListener();
            DeleteListener();
            return base.SaveChanges();
        }

        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }

        private void InsertListener()
        {
           
            foreach (var entity in ChangeTracker.Entries<BaseDomain>().Where(x => x.State == EntityState.Added).ToList())
            {
                entity.Entity.CreateDate = DateTime.Now;
                entity.Entity.IsActive = true;
                entity.Entity.IsDeleted = false;
                entity.Entity.UpdateDate = DateTime.Now;
            }
        }

        private void UpdateListener()
        {
            foreach (
                var entity in ChangeTracker.Entries<BaseDomain>().Where(x => x.State == EntityState.Modified).ToList())
            {
                entity.Entity.UpdateDate = DateTime.Now;
            }
        }

        private void DeleteListener()
        {
            foreach (
                var entity in ChangeTracker.Entries<BaseDomain>().Where(x => x.State == EntityState.Deleted).ToList())
            {
                entity.Entity.IsDeleted = true;
                entity.Entity.UpdateDate = DateTime.Now;
                entity.State = EntityState.Modified;
            }
        }

        


        public DbSet<User> Users { get; set; }


        public DbSet<Menu> Menu { get; set; }



    }
}