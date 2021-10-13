using MongoDB.Driver;
using MongoSQL.API.Collections.Versions.V1;
using MongoSQL.API.Collections.Versions.V1.Models;
using MongoSQL.API.Contexts.Context;
using MongoSQL.API.Services.Versions.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoSQL.API.Services.Versions.V1
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> _category;
        public static string Success { get; set; } = "Success";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings"></param>
        public CategoryService(IDataContextMongo settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            // Init the connection and access to the MongoDB collection
            _category = database.GetCollection<Category>(DataCollectionsDB.Category);
        }

        /// <summary>
        /// Get all my categories that are not in true
        /// Get all categories per user (logged user)
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public async Task<GenericOperationResponse<object>> GetCategories(string emailAddress, bool isActive)
        {
            try
            {
                var categories = await _category
                    .Find(cat => cat.EmailAddress == emailAddress && cat.IsActive == isActive)
                    .ToListAsync();
                return new GenericOperationResponse<object>(categories, Success);
            }
            catch (Exception ex)
            {
                return new GenericOperationResponse<object>(true, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Create the category per user
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<GenericOperationResponse<object>> CreateCategory(Category category)
        {
            try
            {
                await _category.InsertOneAsync(category); // TODO Get the inserted record to return
                return new GenericOperationResponse<object>(category, Success);
            }
            catch (Exception ex)
            {
                return new GenericOperationResponse<object>(true, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Archive a category
        /// This categories should be displayed in archived section
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<UpdateResult> ArchiveCategory(string categoryId, bool archiveReq)
        {
            var filter = Builders<Category>.Filter.Eq(x => x.Id, categoryId);
            var updateRequest = Builders<Category>.Update.Set(x => x.IsActive, archiveReq);
            var result = await _category.UpdateOneAsync(filter, updateRequest);

            return result;
        }
    }
}
