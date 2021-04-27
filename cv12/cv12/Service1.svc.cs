using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace cv12
{
    // POZNÁMKA: Pomocí příkazu Přejmenovat v nabídce Refaktorovat můžete změnit název třídy Service1 společně v kódu, svc a konfiguračním souboru.
    // POZNÁMKA: Pokud chcete spustit klienta testu WCF pro otestování této služby, vyberte v Průzkumníkovi řešení Service1.svc nebo Service1.svc.cs a spusťte ladění.
    public class Service1 : IService1
    {
        public decimal Spocti(decimal operand1, decimal operand2, string operace) {
            switch (operace) {
                case "+": return operand1 + operand2;
                case "-": return operand1 - operand2;
                case "*": return operand1 * operand2;
                case "/": return operand1 / operand2;
                default:return 0;
            }
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
    }
}
