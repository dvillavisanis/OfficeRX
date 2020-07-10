using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System.Collections;

namespace RX2_Office.Module.BusinessObjects.BusinessLogic
{
    class ComplianceBL
    {
        static bool success = true;
        static bool failed = false;
        public XafApplication application;
        public ComplianceBL(XafApplication papp)
        {
            application = papp;
        }
        public Boolean CustomerActiveDEALicense(Customer Cust)
        {


            if (Cust != null)
            {
                if (Cust.DeaExpDate >= DateTime.Now && (IsValidDEANumber(Cust.DeaNo) == 0))
                {
                    return success;

                }

            }
            return failed;
        }
        #region isValidDEANumber
        /// <summary>
        ///  A valid DEA number consists of 2 letters, 6 digits, and 1 check digit.
        /// </summary>
        /// <param name="aDeaNo"></param>
        /// <returns></returns>

        public int IsValidDEANumber(string aDeaNo)
        {
            char[] adea = aDeaNo.ToCharArray();
            int ireturn = 1;
            if (string.IsNullOrEmpty(aDeaNo))
            {
                return -1;
            }
            // A valid DEA number consists of 2 letters, 6 digits, and 1 check digit. The first letter is a code identifying the type of registrant. 
            //  The second letter is the first letter of the registrant's last name. 
            // Here are the steps to verify a DEA number: 
            //   Step 1: add the first, third, and fifth digits of the DEA number. 
            //   Step 2: add the second, fourth, and sixth digits of the DEA number. 
            //   Step 3: multiply the result of Step 2 by two. 
            //   Step 4: add the result of Step 1 to the result of Step 3. 
            //   Then, the last digit of this sum must be the same as the last digit of the DEA number. 
            //Example: DEA number AP5836727 
            //Step 1: 5 + 3 + 7 = 15 
            //Step 2: 8 + 6 + 2 = 16 
            //Step 3: 16 * 2 = 32 
            //Step 4: 15 + 32 = 47 
            // last diget of the dea number is equal the the last digit in the calc 
            if (aDeaNo.Length == 9)
            {
                // check to see if first two digits are letters
                if (Char.IsLetter(aDeaNo[0]) && Char.IsLetter(aDeaNo[1]))
                {

                    int step1 = 0;
                    // int step4 = 0;
                    // int step2 = 0;

                    int deaa = 0;
                    int deab = 0;
                    int deac = 0;
                    int dead = 0;
                    int deae = 0;
                    int deaf = 0;
                    int deag = 0;
                    int compval = 0;

                    string sdeaa;
                    string sdeab;
                    string sdeac;
                    string sdead;
                    string sdeae;
                    string sdeaf;
                    string sdeag;


                    sdeaa = adea[2].ToString();
                    sdeab = adea[3].ToString();
                    sdeac = adea[4].ToString();
                    sdead = adea[5].ToString();
                    sdeae = adea[6].ToString();
                    sdeaf = adea[7].ToString();
                    sdeag = adea[8].ToString();



                    Int32.TryParse(sdeaa, out deaa);
                    Int32.TryParse(sdeab, out deab);
                    Int32.TryParse(sdeac, out deac);
                    Int32.TryParse(sdead, out dead);
                    Int32.TryParse(sdeae, out deae);
                    Int32.TryParse(sdeaf, out deaf);
                    Int32.TryParse(sdeag, out deag);


                    // Step
                    //1: add the first, third, and fifth digits of the DEA number. 

                    int stepa = deaa + deac + deae;

                    //   Step 2: add the second, fourth, and sixth digits of the DEA number. 
                    //   Step 3: multiply the result of Step 2 by two. 
                    int stepb = (deab + dead + deaf) * 2;
                                       
                    //step2 = step2 * 2;

                    //   Step 4: add the result of Step 1 to the result of Step 3. 

                    int stepc = stepa + stepb;

                    // Compare the checksum and the last digits
                    Int32 step4pos = stepc.ToString().Length - 1;
                    Char compstr = stepc.ToString()[step4pos];


                    Int32.TryParse(compstr.ToString(), out compval);

                    if (deag != compval)
                    {
                        ireturn = -1;
                    }
                    else
                        return 1; //Good to go
                }
                else
                { ireturn = -3; }

            }
            else
            { ireturn = -4; }

            return ireturn;
        }


        /// <summary>
        /// If a DC has a license into a state
        /// </summary>
        /// <param name="DC"></param>
        /// <param name="Into"></param>
        /// <returns></returns>
        public bool AbleToShipInto(DistributionCenter DC, State Into)
        {


            string statecode = Into.StateCode;

            IObjectSpace objectSpace = this.application.CreateObjectSpace(typeof(DistributionCenterLicenses));
            int goodcount = 0;

            CriteriaOperator op = CriteriaOperator.Parse("DistributionCenterId = ? AND State = ? AND LicenseTypeCode = ?", DC.Oid, statecode, "STAT");
            IList DCLic = objectSpace.GetObjects(typeof(DistributionCenterLicenses), op);
            if (DCLic.Count > 0)
                foreach (DistributionCenterLicenses dl in DCLic)
                {
                    if (dl.ExpirationDate >= DateTime.Now)
                    {
                        goodcount++;
                    }
                }
            if (goodcount > 0) return success;
            return failed;
        }
        /// <summary>
        /// Checks all lines of a Sales Order to make sure all CI and CII drugs has a 222 form attached
        /// 
        /// </summary>
        /// <param name="so"></param>
        /// <returns></returns>
        public bool ControlLinesHas222(SOHeader so)

        {
            int errcount = 0;
            IObjectSpace objectSpace = this.application.CreateObjectSpace(typeof(SODetails));
            // int goodcount = 0;

            CriteriaOperator op = CriteriaOperator.Parse("SalesOrder = ?", so.SalesOrderNumber);
            IList SOD = objectSpace.GetObjects(typeof(SODetails), op);

            foreach (SODetails sod in SOD)
            {
                if (sod.Item.ItemNumber.DeaClass == DeaClassEnum.CII || sod.Item.ItemNumber.DeaClass == DeaClassEnum.CI)
                {
                    if (sod.Form222Img.Length <= 100)
                    {
                        errcount++;

                    }
                }
            }
            if (errcount == 0) return success;

            return failed;

        }
        #endregion

        #region IsValidStateLicense
        /// <summary>
        /// Checks to see if the state license info is valid
        /// </summary>
        /// <param name="Cust"></param>
        /// <returns></returns>
        public Boolean IsValidStateLicense(Customer Cust)
        {
            if (Cust != null)
            {
                if (Cust.StateLicense.Length > 4 && Cust.StateLicExpDate >= DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion


        /// <summary>
        /// Checks for the following
        /// 1) valid DEA Number and Exp Date
        /// 2) Has a State License and state Exp date or state Pharma License
        /// 3) whse has license to ship into cust state.
        /// 4) All CI and CII drugs has a 222 form attached.
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public int SoComplianceCheck(SOHeader SO, out string erromsg)
        {
            string errmsg = "";
            int errcount = 0;

            // Check dea

            if (IsValidDEANumber(SO.CustomerNumber.DeaNo) < 0)
            {
                errcount++;
                errmsg = errmsg + "(" + errcount.ToString() + ") Invalid Dea Number. Does not comply with the format  of  AA####### ." + Environment.NewLine;
            }


            if (!(SO.CustomerNumber.DeaExpDate >= DateTime.Now))
            {
                errcount++;
                errmsg = errmsg + "(" + errcount.ToString() + ") Expired DEA Number '" + SO.CustomerNumber.DeaExpDate + "' " + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(SO.CustomerNumber.StateLicense) || SO.CustomerNumber.StateLicense.Trim().Length < 4)
            {
                errcount++;
                errmsg = errmsg + "(" + errcount.ToString() + ") Invalid State License Must be longer then 4" + Environment.NewLine;
            }
            if (!(SO.CustomerNumber.StateLicExpDate >= DateTime.Now))
            {
                errcount++;
                errmsg = errmsg + "(" + errcount.ToString() + ") Expired State License '" + SO.CustomerNumber.DeaExpDate + "' " + Environment.NewLine;
            }
            if (!AbleToShipInto(SO.DistributionCenterWhse.DistributionCenter, SO.CustomerNumber.ShipState))
            {
                errcount++;
                errmsg = errmsg + "(" + errcount.ToString() + ")" + string.Format("Unable to ship into ? from ? ", SO.CustomerNumber.ShipState.StateCode, SO.DistributionCenterWhse.DistributionCenter.DCName) + Environment.NewLine;
            }
            if (!ControlLinesHas222(SO))
            {
                errcount++;
                errmsg = errmsg + "(" + errcount.ToString() + ") No 222 Form attached" + Environment.NewLine;
            }

            SO.LastComplianceMsg = errmsg;
            SO.Save();

            if (errcount > 0)
            {
                erromsg = errmsg;
                SO.CustomerNumber.AddNote(SO.CustomerNumber, errmsg);
                return errcount;
            }
            erromsg = "";
            return 0;
        }

    }
}
