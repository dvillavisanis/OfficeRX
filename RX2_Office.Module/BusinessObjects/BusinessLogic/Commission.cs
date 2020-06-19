using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX2_Office.Module.BusinessObjects.BOCustomers
{
    class Commission
    {

        /// <summary>
        /// Calculate all items on an invoice and calculates the commission
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        public int RecalcInvoiceCommission(string InvoiceNumber)
        {
            int ret = 0;




            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PtbDate"></param>
        /// <param name="NDC"></param>
        /// <returns></returns>
        public decimal GetPTB(DateTime PtbDate, string NDC)
        {
            //ItemPTB IPTB = repacklot.RepackLot;
            //CriteriaOperator op = CriteriaOperator.Parse("RepackLot.LotId = ? AND IsCommission = ? AND LabelType = ? AND CommissionBatchId is Null", repacklotid, true, eLabelType.InnerCarton);
            //IList Innnercomlist = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);



            return 0.00M;

        }

        public void GetRepCommissionStructure(string Rep, Items ItemsNDC)
        {




        }


    }





}
