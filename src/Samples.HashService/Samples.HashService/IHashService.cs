using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace Samples.HashService
{
	[ServiceContract]
    interface IHashService {
		[WebInvoke(UriTemplate="/hash",
            Method = "POST"
            ,BodyStyle = WebMessageBodyStyle.WrappedRequest
            ,RequestFormat = WebMessageFormat.Json
            ,ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
        Task<HashRs> GetHash(HashRq rq);
    } 
}