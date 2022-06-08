//using Amazon.Util.Internal.PlatformServices;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using ClientWebApp_MVC_.Services;

//namespace ClientWebApp_MVC_.Client
//{
//    internal static class APIClientClient
//    {
//        private static Uri apiUri;

//        private static Lazy<APIClient> restClient = new Lazy<APIClient>(
//          () => new APIClient(apiUri),
//          LazyThreadSafetyMode.ExecutionAndPublication);

//        static APIClientClient()
//        {
//            apiUri = new Uri(Services.ApplicationSettings.WebApiUrl);
//        }

//        public static APIClient Instance
//        {
//            get
//            {
//                return restClient.Value;
//            }

//        }

//    }
//}
