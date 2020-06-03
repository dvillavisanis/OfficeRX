using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;

namespace RX2_Office.Module.BusinessObjects.BusinessLogic
{
    public class CustomFunctionOperator : ICustomFunctionOperator
    {
        public CustomFunctionOperator()
        {

        }
        public string Name { get; set; }
        public Type ResultType(System.Type[] operands)
        {
            throw new NotImplementedException();
        }
        public object Evaluate(object[] operands)
        {
            throw new NotImplementedException();
        }
    }
}
