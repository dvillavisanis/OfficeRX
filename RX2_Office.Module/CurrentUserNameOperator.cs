using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RX2_Office.Module.BusinessObjects;
using DevExpress.ExpressApp;

namespace RX2_Office.Module
{
    public class CurrentUserNameOperator : ICustomFunctionOperator
    {
        public string Name
        {
            get
            {
                return "CurrentUserName";
            }
        }

        public object Evaluate(params object[] operands)
        {
            return SecuritySystem.CurrentUserName;
        }

        public Type ResultType(params Type[] operands)
        {
            return typeof(object);
        }

        static CurrentUserNameOperator()
        {
            CurrentUserNameOperator instance = new CurrentUserNameOperator();
            if (CriteriaOperator.GetCustomFunction(instance.Name) == null)
            {
                CriteriaOperator.RegisterCustomFunction(instance);
            }
        }

        public static void Register()  {
        }

    }
}