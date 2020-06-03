using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RX2_Office.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.Xpo;

namespace RX2_Office.Module
{
    public class CurrentShipperDCOperator : ICustomFunctionOperator
    {



        public string Name
         {
            get
            {
                return "CurrentShipperDC";
            }
        }



        public object Evaluate(params object[] operands)

        {

            using (Session session = new Session())

            {

                string curUser = SecuritySystem.CurrentUserName;

                Shippers shipper = session.FindObject<Shippers>(new BinaryOperator("SecuritySystemUser.UserName", curUser));

                //Shippers shipper = ((Shippers)SecuritySystem.CurrentUserName);

                if (shipper == null || (shipper != null && shipper.DefaultDC == null))
                {
                    return null;
                }
                else
                {
                    return shipper.DefaultDC.Oid;
                }

            }
            //return ((Shippers)SecuritySystem.CurrentUser).DefaultDC.Oid;
            //return DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
        }

        public Type ResultType(params Type[] operands)
        {
            return typeof(object);
        }

        static CurrentShipperDCOperator()
        {
            CurrentShipperDCOperator instance = new CurrentShipperDCOperator();
            if (CriteriaOperator.GetCustomFunction(instance.Name) == null)
            {
                CriteriaOperator.RegisterCustomFunction(instance);
            }
        }

        public static void Register()  {
        }

    }
}