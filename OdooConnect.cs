using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdooRpc.CoreCLR.Client.Internals;
using OdooRpc.CoreCLR.Client.Models;

namespace WindowsFormsApplication1
{
    class OdooConnect
    {

        OdooConnectionInfo connectionInfo;
    
        public class HttpEndpoint
        {
            OdooConnectionInfo connectionInfo;

            public HttpEndpoint()
            {
                this.connectionInfo = new OdooConnectionInfo()
                {
                    IsSSL = false,
                    Host = "https://demo-18-07-1.nubeadhoc.com/",
                    Port = 443,
                    Username = "demo",
                    Password = "demo"
                };
            }

            
            public void GetJsonRpcUri_ShouldCreateHttpUri()
            {
                //var uri = OdooEndpoints.GetJsonRpcUri(this.connectionInfo);
                //Assert.Equal("https://demo-18-07-1.nubeadhoc.com:443/jsonrpc", uri.ToString());
            }
        }
    }

}
