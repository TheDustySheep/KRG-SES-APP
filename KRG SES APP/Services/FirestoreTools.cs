using KRG_SES_APP.Models.SignInSystem;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace KRG_SES_APP.Services
{
    public static class FirestoreTools
    {
        public static async Task AddDocument<T>(string collection, T item)
        {
            await CrossCloudFirestore.Current
                         .Instance
                         .Collection(collection)
                         .AddAsync(item);
        }

        public static async Task SetDocument<T>(string collection, string document, T item)
        {
            await CrossCloudFirestore.Current
                         .Instance
                         .Collection(collection)
                         .Document(document)
                         .SetAsync(item);
        }

        public static async Task<T> GetDocument<T>(string collection, string document)
        {
            var doc = await CrossCloudFirestore.Current
                         .Instance
                         .Collection(collection)
                         .Document(document)
                         .GetAsync();

            return doc.ToObject<T>();
        }

        public static async Task RemoveDocument(string collection, string document)
        {
            await CrossCloudFirestore.Current
                         .Instance
                         .Collection(collection)
                         .Document(document)
                         .DeleteAsync();
        }
    }
}
