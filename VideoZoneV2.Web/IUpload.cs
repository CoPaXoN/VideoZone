using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VideoZoneV2.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpload" in both code and config file together.
    [ServiceContract]
    public interface IUpload
    {
        [OperationContract]
        void DoWork();
    }
}
