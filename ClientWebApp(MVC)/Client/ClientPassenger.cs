//using ClientWebApp_MVC_.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ClientWebApp_MVC_.Client
//{
//    public partial class APIClient
//    {
//      //A passenger will be created when buying a new ticket
//        readonly string baseuri = "https://localhost:44381/api/Passengers";

//        public async Task<StatusMessage<PassengerModel>> SavePassenger(PassengerModel model)
//        {
//            var requestUrl = CreateRequestUri(baseuri);

//            return await PostAsync<PassengerModel>(requestUrl, model);
//        }
//    }
//}
