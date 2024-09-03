using System.ServiceModel;
using System.ServiceModel.Web;

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
        HashRs GetHash(HashRq rq);
    } 
}