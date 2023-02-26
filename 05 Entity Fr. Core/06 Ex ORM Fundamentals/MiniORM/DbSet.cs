namespace MiniORM
{
    using System.Collections;

    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        // TODO: Create your DbSet class here.
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        internal IList<TEntity> Entities { get; set; }

        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        public void Add(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("Item cannot be null");

            this.Entities.Add(entity);
            this.ChangeTracker.Add(entity);
        }

        public void Clear()
        {
            while(this.Entities.Any())
            {
                var entity = this.Entities.First();
                this.Remove(entity);
            }
        }

        public bool Contains(TEntity entity) { return this.Entities.Contains(entity); }

        public void CopyTo(TEntity[] array, int arrayIndex) { this.Entities.CopyTo(array, arrayIndex); }

        public int Count { get { return this.Entities.Count; } }

        public bool IsReadOnly { get { return this.Entities.IsReadOnly; } }

        public bool Remove(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("Item cannot be null");

            var removedSuccessfully = this.Entities.Remove(entity);

            if (removedSuccessfully) 
            { 
                this.ChangeTracker.Remove(entity); 
            }

            return removedSuccessfully;
        }

        public IEnumerator<TEntity> GetEnumerator() {
            return this.Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() 
        { 
            return this.Entities.GetEnumerator(); 
        }

        public void RemoveRange(IEnumerable<TEntity> collection)
        {
            foreach(var entity in collection.ToArray())
            {
                this.Remove(entity);
            }
        }

    }
}
