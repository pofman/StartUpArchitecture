using System;
using System.Collections.Generic;
using System.Data.Entity;
using CnG.Foundations.Persistence;

namespace CnG.Domain.Model.Mappings.Contexts
{
    public class EfContext : DbContext, IPersistenceContext
    {
        private readonly IDictionary<Type, object> _dbset;

        public EfContext()
            : base("entityFramework")
        {
            Database.SetInitializer(new DbInit());
            _dbset = new Dictionary<Type, object>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration())
                .Add(new MembershipConfiguration());
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            if (_dbset.ContainsKey(typeof(T)))
                return _dbset[typeof(T)] as DbSet<T>;

            var set = Set<T>();
            _dbset.Add(typeof(T), set);
            return set;
        }

        public DbContext InnerContext
        {
            get { return this; }
        }
    }
}