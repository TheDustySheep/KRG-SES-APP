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
        public static async Task SetDocument<T>(string collection, string document, T item)
        {
            await CrossCloudFirestore.Current
                         .Instance
                         .Collection(collection)
                         .Document(document)
                         .SetAsync(item);
        }

        public static async Task GetDocument<T>(string collection, string document, T item)
        {
            await CrossCloudFirestore.Current
                         .Instance
                         .Collection(collection)
                         .Document(document)
                         .SetAsync(item);
        }
    }
}
