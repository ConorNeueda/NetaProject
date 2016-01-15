using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NetaDAL;
using System.Web.Script.Serialization;

namespace NetaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NetaService : INetaService
    
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string getJsonData()
        {
            string json;
            using (NetaDBEntities m = new NetaDBEntities())
            {
                var jsonData = from p in m.counties select p;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                json = serializer.Serialize(jsonData);

            }




            return json;
        }
    }

}
