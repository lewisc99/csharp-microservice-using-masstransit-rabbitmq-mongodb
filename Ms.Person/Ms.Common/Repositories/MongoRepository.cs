﻿using MongoDB.Driver;
using Ms.Common.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ms.Common.Repositories
{
   public class MongoRepository<T>:IRepository<T> where T: IEntity
    {

        private readonly IMongoCollection<T> dbCollection;

        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;


        public MongoRepository(IMongoDatabase database, string collectioName)
        {
            dbCollection = database.GetCollection<T>(collectioName);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {

            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {

            return await dbCollection.Find(filter).ToListAsync();
    
        }


        public async Task<T> GetAsync(Guid id)
        {

            FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.id, id);

            return await dbCollection.Find(filter).FirstOrDefaultAsync();

        }


        public async  Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {

            return await dbCollection.Find(filter).FirstOrDefaultAsync();

        }

        public async  Task CreateAsync(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await dbCollection.InsertOneAsync(entity);

        }



        public async Task RemoveAsync(Guid id)
        {

            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.id, id);

            await dbCollection.DeleteOneAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {

            if  (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));

            }

            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.id, entity.id);
            await dbCollection.ReplaceOneAsync(filter, entity);

        }
    }
}
