using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace cv12
{
    // POZNÁMKA: Pomocí příkazu Přejmenovat v nabídce Refaktorovat můžete změnit název rozhraní IService1 společně v kódu i konfiguračním souboru.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        decimal Spocti(decimal operand1, decimal operand2, string operace);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Sem přidejte servisní operace.
    }


    // Pomocí kontraktu dat, jak je znázorněný v následující ukázce, přidejte do servisních operací složené typy.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
