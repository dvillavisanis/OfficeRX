using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.Xml;
using System.IO;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System.Collections;

namespace RX2_Office.Module.BusinessObjects.BusinessLogic
{
    class RFEXCEL
    {
        public enum eRFXLImpType { Dev, QA, Production }

        public string url { get; set; }
        public string url2 { get; set; }
        public string ResponseXML { get; set; }
        public string LastError { get; set; }
        public List<string> sGTIN { get; set; }
        public List<string> SerialList { get; set; }
        public XafApplication application;
        public string rfxUserName;
        public string rfxPassWord;

        /// <summary>
        /// Create  rfexcel class to automate data transmittion
        /// </summary>
        /// <param name="GTNid"></param>
        /// <param name="QtySerial"></param>
        /// <param name="papp"></param>
        public RFEXCEL(string GTNid, int QtySerial, XafApplication papp, eRFXLImpType impType = eRFXLImpType.Production)

        {
            switch (impType)
            {
                case eRFXLImpType.Dev:
                    rfxUserName = "unitdose_dev_wsuser";
                    rfxPassWord = "UnitDose12!";
                    url = "https://unitdose-dev.track-n-trace.net/rfxcelwss/services/ISerializationServiceSoapHttpPort";
                    url2 = "https://unitdose-dev.track-n-trace.net/rfxcelwss/services/IMessagingServiceSoapHttpPort";

                    break;
                case eRFXLImpType.QA:
                    rfxUserName = "unitdose_qa_wsuser";
                    rfxPassWord = "Test1212!";
                    url = "https://unitdose-qa.track-n-trace.net/rfxcelwss/services/ISerializationServiceSoapHttpPort";
                    url2 = "https://unitdose-qa.track-n-trace.net/rfxcelwss/services/IMessagingServiceSoapHttpPort";
                    break;
                case eRFXLImpType.Production:
                    rfxUserName = "rfx_arbor_unitdose";
                    rfxPassWord = "UnitDose*1";
                    url = "https://unitdose.track-n-trace.net/rfxcelwss/services/ISerializationServiceSoapHttpPort";
                    url2 = "https://unitdose.track-n-trace.net/rfxcelwss/services/IMessagingServiceSoapHttpPort";
                    break;
            }

            application = papp;
            sGTIN = new List<string>();
            SerialList = new List<string>();
            // Creates path to keep the files that are sent (local computer that made request)
            string Path = "c://Temp";
            bool exists = System.IO.Directory.Exists(Path);
            if (!exists) System.IO.Directory.CreateDirectory(Path);
        }

        /// <summary>
        /// Request Serial Numbers
        /// </summary>
        /// <param name="GTNid"></param>
        /// <param name="QtySerial"></param>
        /// <param name="e"></param>
        public void PostRequest(string GTNid, int QtySerial, SimpleActionExecuteEventArgs e)

        {
            RepackLots repacklot = (RepackLots)e.CurrentObject;
            // test gtin 00324338200124
            //HttpWebRequest request = CreateWebRequest(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add(@"SOAP:Action");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Method = "POST";
            DateTime centuryBegin = new DateTime(2019, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            string eventid = elapsedTicks.ToString();
            //      XmlDocument soapEnvelope = new XmlDocument();

            string oRequest = "";
            oRequest = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns=\"http://xmlns.rfxcel.com/traceability/serializationService/3\" xmlns:ns1=\"http://xmlns.rfxcel.com/traceability/3\" xmlns:xm=\"http://www.w3.org/2004/11/xmlmime\">" + Environment.NewLine;
            oRequest = oRequest + "	<soapenv:Header>" + Environment.NewLine;
            oRequest = oRequest + "   <wsa:Action xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\">http://wsop.rfxcel.com/messaging/2/getMessages</wsa:Action>" + Environment.NewLine;
            oRequest = oRequest + "    <wsa:ReplyTo xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\">" + Environment.NewLine;
            oRequest = oRequest + "    <wsa:Address>http://schemas.xmlsoap.org/ws/2004/08/addressing/role/anonymous</wsa:Address>" + Environment.NewLine;
            oRequest = oRequest + "     </wsa:ReplyTo>" + Environment.NewLine;
            oRequest = oRequest + "    <wsa:To xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\">https://test.rfxcel.net/services/IrfxMessagingSoapHttpPort</wsa:To>" + Environment.NewLine;
            oRequest = oRequest + "    <wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\"> " + Environment.NewLine;
            oRequest = oRequest + "    <wsu:Timestamp wsu:Id=\"TS-2\">" + Environment.NewLine;
            oRequest = oRequest + "    <wsu:Created>2018-09-20T16:29:08Z</wsu:Created>" + Environment.NewLine;
            oRequest = oRequest + "     <wsu:Expires>2019-09-20T16:29:08Z</wsu:Expires>" + Environment.NewLine;
            oRequest = oRequest + "     </wsu:Timestamp>" + Environment.NewLine;
            oRequest = oRequest + "     <wsse:UsernameToken wsu:Id=\"UsernameToken-1\"> " + Environment.NewLine;
            oRequest = oRequest + "     <wsse:Username>" + rfxUserName + "</wsse:Username> " + Environment.NewLine;
            oRequest = oRequest + "     <wsse:Password Type=\"http://docs.osis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" + rfxPassWord + "</wsse:Password> " + Environment.NewLine;
            oRequest = oRequest + "     </wsse:UsernameToken> " + Environment.NewLine;
            oRequest = oRequest + "     </wsse:Security> " + Environment.NewLine;
            oRequest = oRequest + " </soapenv:Header>" + Environment.NewLine;
            oRequest = oRequest + " <soapenv:Body>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:syncAllocateTraceIds contentStructVer=\"3.1.3\" createDateTime=\"2018-11-14T13:29:34.111Z\" requestId=\"Allocate" + eventid + "\">" + Environment.NewLine;
            oRequest = oRequest + "     <ns:orgId qlfr=\"ORG_DEF\">0860000387903</ns:orgId>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:eventId>Alloc-Product-" + DateTime.Now.ToString("yyyymmddhhmmss") + "</ns:eventId>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:itemId qlfr=\"GTIN\">" + GTNid + "</ns:itemId>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:siteHierId qlfr=\"ORG_DEF\">Manufacturing</ns:siteHierId>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:siteId qlfr=\"GLN\" type=\"LOCATION\">" + repacklot.RepackPackager.SiteId + "</ns:siteId>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:idTextFormat>PURE_ID_URI</ns:idTextFormat>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:separatePrefixSuffix>false</ns:separatePrefixSuffix>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:returnDataStruct>LIST</ns:returnDataStruct>" + Environment.NewLine;
            oRequest = oRequest + "     <ns:idCount>" + QtySerial.ToString() + "</ns:idCount>" + Environment.NewLine;
            oRequest = oRequest + "     </ns:syncAllocateTraceIds>" + Environment.NewLine;
            oRequest = oRequest + "     </soapenv:Body>" + Environment.NewLine;
            oRequest = oRequest + " </soapenv:Envelope>" + Environment.NewLine;

            try
            {
                request.Timeout = 100000;
                request.ContentLength = oRequest.Length;
                request.ContentType = "text/xml;charset=utf-8";
                byte[] bytes = Encoding.UTF8.GetBytes(oRequest);
                request.Headers.Add("SOAP:Action");

                // for testing only
                using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\dan.xml"))
                {
                    stmw2.Write(oRequest);
                }

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }
                    StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                    ResponseXML = responseReader.ReadToEnd();
                    // for testing only *********************************
                    using (StreamWriter stmw3 = new StreamWriter("c:\\temp\\serialResponse.xml"))
                    {
                        stmw3.Write(ResponseXML);
                    }
                    // **************************************************
                    PopulateSerialList();
                }
            }
            catch (SystemException ex)
            {

                LastError = ex.Message + "  ";
                throw new System.ArgumentException(ex.Message);
            }
        }
        /// <summary>
        ///Create a list of serial numbers from XML back from RFXcel
        ///Populates the sGtin list 
        ///
        /// </summary>
        private void PopulateSerialList()
        {
            XmlDocument xdoc = new XmlDocument();//xml doc used for xml parsing
            xdoc.Load(new StringReader(ResponseXML));
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsmgr.AddNamespace("ns2", "http://xmlns.rfxcel.com/traceability/3");
            nsmgr.AddNamespace("ns4", "http://xmlns.rfxcel.com/traceability/api/3");
            nsmgr.AddNamespace("ns5", "http://xmlns.rfxcel.com/traceability/serializationQueryService/3");
            nsmgr.AddNamespace("ns6", "http://xmlns.rfxcel.com/traceability/serializationService/3");
            XmlNodeList xNodelsttest = xdoc.DocumentElement.SelectNodes("soap:Envelope/soap:Body/syncAllocateTraceIdsResponse/ns4:result", nsmgr);
            XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("soap:Envelope/soap:Body/syncAllocateTraceIdsResponse/allocIdSetCont/ns6:idSetCont/ns6:idList", nsmgr);
            XmlNode node = xdoc.SelectSingleNode("soap:Envelope/soap:Body/syncAllocateTraceIdsResponse/allocIdSetCont/ns6:idSetCont", nsmgr);
            XmlNode node2 = xdoc.GetElementsByTagName("ns7:idList").Item(0);

            foreach (XmlNode xn in node2.ChildNodes)
            {
                string SID = xn.InnerText;
                string sid = "";

                if (SID.IndexOf("sgtin:") > 3)
                {
                    sid = SID.Substring(SID.IndexOf("sgtin:") + 6);
                }
                else if (SID.IndexOf("sscc:") > 3)
                {
                    sid = SID.Substring(SID.IndexOf("sscc:") + 5);
                }

                SerialList.Add(sid.Substring(sid.LastIndexOf(".") + 1));
                sGTIN.Add(sid);
            }
        }

        /// <summary>
        /// Create and post Commissioning/Aggreagtion event
        /// </summary>
        /// <param name="e"></param>
        public void PostRxCommissioningEvent(SimpleActionExecuteEventArgs e)
        {
            bool posttovender = true; // must be true to send to RFXL
            string dt = System.DateTime.UtcNow.ToString("o");
            string shippinggtin = "";
            // string UnitGtin;

            //string input = System.DateTime.Now.ToString();
            //DateTime dt = DateTime.ParseExact(input, "yyyy-MM-dd'T'hh:mm:ss%K", System.Globalization.CultureInfo.InvariantCulture);
            DateTime centuryBegin = new DateTime(2018, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            string eventid = elapsedTicks.ToString();
            RepackLotSerialNo repacklot = (RepackLotSerialNo)e.CurrentObject;
            IObjectSpace objectSpace = this.application.CreateObjectSpace(typeof(RepackLotSerialNo));
            string repacklotid = repacklot.RepackLot.LotId;
            RepackLots rl = repacklot.RepackLot;
            CriteriaOperator op = CriteriaOperator.Parse("RepackLot.LotId = ? AND IsCommission = ? AND LabelType = ? AND CommissionBatchId is Null", repacklotid, true, eLabelType.InnerCarton);
            IList Innnercomlist = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);

            op = CriteriaOperator.Parse("RepackLot.LotId = ? AND IsCommission = ? AND LabelType = ? AND CommissionBatchId is Null", repacklotid, true, eLabelType.Pallet);
            IList palletList = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);

            op = CriteriaOperator.Parse("RepackLot.LotId = ? AND isCommission = ? AND LabelType = ? AND CommissionBatchId is Null", repacklotid, true, eLabelType.Shipping);
            IList Casecomlist = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);

            string urltemp = url2;

            // url = "https://unitdose.track-n-trace.net/rfxcelwss/services/IMessagingServiceSoapHttpPort";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urltemp);
            request.Headers.Add(@"SOAP:Action");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Method = "POST";
            //      XmlDocument soapEnvelope = new XmlDocument();
            string oRequest = "";
            oRequest = oRequest + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            oRequest = oRequest + Environment.NewLine + "<SOAP-ENV:Envelope xmlns:ns3=\"http://xmlns.rfxcel.com/traceability/3\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:ns0=\"http://xmlns.rfxcel.com/traceability/api/3\" xmlns:ns1=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns2=\"http://xmlns.rfxcel.com/traceability/messagingService/3\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"> ";
            oRequest = oRequest + Environment.NewLine + "	<SOAP-ENV:Header xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\" xsi:schemaLocation=\"http://schemas.xmlsoap.org/ws/2004/08/addressing ../SOAP-Security/addressing.xsd\">";
            oRequest = oRequest + Environment.NewLine + "		<wsse:Security mustUnderstand=\"true\">";
            oRequest = oRequest + Environment.NewLine + "		    <wsse:UsernameToken>";
            oRequest = oRequest + Environment.NewLine + "		    <wsse:Username>" + rfxUserName + "</wsse:Username>";
            oRequest = oRequest + Environment.NewLine + "		    <wsse:Password>" + rfxPassWord + "</wsse:Password>";
            oRequest = oRequest + Environment.NewLine + "		    <wsu:Created>" + dt + "</wsu:Created>";
            oRequest = oRequest + Environment.NewLine + "		</wsse:UsernameToken>";
            oRequest = oRequest + Environment.NewLine + "		</wsse:Security>";
            oRequest = oRequest + Environment.NewLine + "	</SOAP-ENV:Header>";
            oRequest = oRequest + Environment.NewLine + "	<ns1:Body>";
            oRequest = oRequest + Environment.NewLine + "	    <ns2:processMessages contentStructVer=\"3.1.3\" createDateTime=\"" + dt + "\" requestId=\"udCom-" + eventid + "\">";
            oRequest = oRequest + Environment.NewLine + "		    <ns2:msgEnvelopeList>";
            oRequest = oRequest + Environment.NewLine + "			    <ns0:envelope>";
            oRequest = oRequest + Environment.NewLine + "				    <ns0:header>";
            oRequest = oRequest + Environment.NewLine + "					    <!-- Predefined Values in the System -->";
            oRequest = oRequest + Environment.NewLine + "				    	  <ns0:msgInfo>";
            oRequest = oRequest + Environment.NewLine + "	    					<ns0:sysDeploymentId xsi:type=\"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\">" + rfxUserName + "</ns0:sysDeploymentId>";
            oRequest = oRequest + Environment.NewLine + "		    				<ns0:senderInstId xsi:type=\"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\">" + rfxUserName + "</ns0:senderInstId>";
            oRequest = oRequest + Environment.NewLine + "                           <ns0:senderId xsi:type=\"ns3:TypedQualifiedIdType\" qlfr=\"ORG_DEF\" type=\"ORG_ID\">0860000387903</ns0:senderId>";
            oRequest = oRequest + Environment.NewLine + "			    			<ns0:receiverInstId xsi:type=\"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\">rfXcel</ns0:receiverInstId>";
            oRequest = oRequest + Environment.NewLine + "				    		<ns0:receiverId xsi:type=\"ns3:TypedQualifiedIdType\" qlfr=\"ORG_DEF\" type=\"ORG_ID\">1</ns0:receiverId>";
            oRequest = oRequest + Environment.NewLine + "					    	<ns0:msgFormat xsi:type=\"ns3:OptionallyVersionedEnumType\">XML</ns0:msgFormat>";
            oRequest = oRequest + Environment.NewLine + "						    <ns0:msgType xsi:type=\"ns3:OptionallyVersionedEnumType\" ver=\"1.1\">SYS_EVENTS_ENV</ns0:msgType>";
            oRequest = oRequest + Environment.NewLine + "						    <ns0:msgId/>";
            oRequest = oRequest + Environment.NewLine + "	            			<ns0:corrMsgId/>";
            oRequest = oRequest + Environment.NewLine + "				    	  </ns0:msgInfo>";
            oRequest = oRequest + Environment.NewLine + "	    			</ns0:header>";
            oRequest = oRequest + Environment.NewLine + "				    <ns0:body>";
            oRequest = oRequest + Environment.NewLine + "				    	<XML_SYS_EVENTS_ENV>";
            oRequest = oRequest + Environment.NewLine + "						<epcis:EPCISDocument xmlns:epcis=\"urn:epcglobal:epcis:xsd:1\" xmlns:rfx=\"http://xmlns.rfxcel.com/epcis_extension/1.2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" schemaVersion=\"1.0\" creationDate=\"2015-12-15T17:56:01Z\" xsi:schemaLocation=\"http://xmlns.rfxcel.com/epcis_extension/1.2 rfx-extension-1_2.xsd urn:epcglobal:epcis:xsd:1 EPCglobal-epcis-1_1.xsd\" > ";
            oRequest = oRequest + Environment.NewLine + "						<EPCISBody>";
            oRequest = oRequest + Environment.NewLine + "							<EventList>";
            oRequest = oRequest + Environment.NewLine + "					    	<!-- Commission Carton / Unit level product -->";
            oRequest = oRequest + Environment.NewLine + "							<ObjectEvent>";
            oRequest = oRequest + Environment.NewLine + "							<eventTime>" + System.DateTime.UtcNow.ToString("o") + "</eventTime>";
            oRequest = oRequest + Environment.NewLine + "							<eventTimeZoneOffset>-05:00</eventTimeZoneOffset>";
            oRequest = oRequest + Environment.NewLine + "							<epcList>";
            foreach (RepackLotSerialNo c in Innnercomlist)
            {
                if (c.CommissionPostedToVendor == false)
                {
                    oRequest = oRequest + Environment.NewLine + "							<epc>urn:epc:id:sgtin:" + c.sGTIN + "</epc>";
                    c.CommissionBatchId = eventid;
                    c.CommissionPostedToVendor = true;
                    shippinggtin = c.sGTIN;
                    c.Session.Save(c);
                    c.Session.CommitTransaction();

                }
            }
            objectSpace.CommitChanges();
            oRequest = oRequest + Environment.NewLine + "							</epcList>";
            oRequest = oRequest + Environment.NewLine + "							<action>ADD</action>";
            oRequest = oRequest + Environment.NewLine + "							<bizStep>urn:epcglobal:cbv:bizstep:commissioning</bizStep>";
            oRequest = oRequest + Environment.NewLine + "							<disposition>urn:epcglobal:cbv:disp:active</disposition>";
            oRequest = oRequest + Environment.NewLine + "							<readPoint>";
            oRequest = oRequest + Environment.NewLine + "							    <id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>";
            oRequest = oRequest + Environment.NewLine + "							</readPoint>";
            oRequest = oRequest + Environment.NewLine + "							<bizLocation>";
            oRequest = oRequest + Environment.NewLine + "								<id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>";
            oRequest = oRequest + Environment.NewLine + "							</bizLocation>";
            oRequest = oRequest + Environment.NewLine + "							<!-- CommissionExtension -->";
            oRequest = oRequest + Environment.NewLine + "							<commissionExtension>";
            oRequest = oRequest + Environment.NewLine + "							    <eventID>IC Com-" + eventid + "</eventID>";
            oRequest = oRequest + Environment.NewLine + "	    						<itemIdentifiers>";
            oRequest = oRequest + Environment.NewLine + "									<standardItemIdentifier type=\"GTIN\">" + rl.RepackItem.Gtin + "</standardItemIdentifier>";
            oRequest = oRequest + Environment.NewLine + "									<internalItemIdentifier type=\"MaterialID\">mat1</internalItemIdentifier>";
            oRequest = oRequest + Environment.NewLine + "								</itemIdentifiers>";
            oRequest = oRequest + Environment.NewLine + "								<processDetail>";
            oRequest = oRequest + Environment.NewLine + "									<packageLevel>EA</packageLevel>";
            oRequest = oRequest + Environment.NewLine + "									<lotOrBatch>" + rl.LotId + "</lotOrBatch>";
            oRequest = oRequest + Environment.NewLine + "									<productionDate qualifier=\"MANUFACTURE\">";
            oRequest = oRequest + Environment.NewLine + "		    							<chronoDate>" + System.DateTime.Now.ToString("yyyy-MM-dd") + "</chronoDate>";
            oRequest = oRequest + Environment.NewLine + "			    						<labelDate>" + rl.CreatedDate.ToString("MMyy") + "</labelDate>";
            oRequest = oRequest + Environment.NewLine + "									</productionDate>";
            oRequest = oRequest + Environment.NewLine + "									<productionDate qualifier=\"EXPIRY\">";
            oRequest = oRequest + Environment.NewLine + "										<chronoDate>" + rl.LotExpirationDt.ToString("yyyy-MM-dd") + "</chronoDate>";
            oRequest = oRequest + Environment.NewLine + "										<labelDate> " + rl.LotExpirationDt.ToString("MMyy") + "</labelDate>";
            oRequest = oRequest + Environment.NewLine + "									</productionDate>";
            oRequest = oRequest + Environment.NewLine + "								</processDetail>";
            oRequest = oRequest + Environment.NewLine + "								<!--packagingLine>";
            oRequest = oRequest + Environment.NewLine + "								<locationIdentifiers>";
            oRequest = oRequest + Environment.NewLine + "									<internalLocationIdentifier qualifier=\"LineName\">LineName15</internalLocationIdentifier>";
            oRequest = oRequest + Environment.NewLine + "								</locationIdentifiers>";
            oRequest = oRequest + Environment.NewLine + "								<user role=\"SUPERVISOR\">";
            oRequest = oRequest + Environment.NewLine + "								    <userID>Supervisor Id</userID>";
            oRequest = oRequest + Environment.NewLine + "		    						<userName>Supervisor name</userName>";
            oRequest = oRequest + Environment.NewLine + "								</user>";
            oRequest = oRequest + Environment.NewLine + "								<user role=\"OPERATOR\">";
            oRequest = oRequest + Environment.NewLine + "									<userID>Operator Id</userID>";
            oRequest = oRequest + Environment.NewLine + "									<userName>Operator name</userName>";
            oRequest = oRequest + Environment.NewLine + "								</user>";
            oRequest = oRequest + Environment.NewLine + "				    		    </packagingLine-->";
            oRequest = oRequest + Environment.NewLine + "					    	</commissionExtension>";
            oRequest = oRequest + Environment.NewLine + "							</ObjectEvent>";
            oRequest = oRequest + Environment.NewLine + "";
            if (palletList.Count > 0)
            {
                oRequest = oRequest + Environment.NewLine + "						<!-- Pallet Commission -->";
                oRequest = oRequest + Environment.NewLine + "						<ObjectEvent>";
                oRequest = oRequest + Environment.NewLine + "							<eventTime>" + System.DateTime.UtcNow.ToString("o") + "</eventTime>";
                oRequest = oRequest + Environment.NewLine + "							<eventTimeZoneOffset>+05:30</eventTimeZoneOffset>";
                oRequest = oRequest + Environment.NewLine + "							<epcList>";
                foreach (RepackLotSerialNo palList in palletList)
                {
                    if (palList.CommissionPostedToVendor == false)
                    {
                        oRequest = oRequest + Environment.NewLine + "								<epc>urn:epc:id:sscc:" + palList.sGTIN + "</epc>";
                        palList.CommissionPostedToVendor = true;
                        shippinggtin = palList.sGTIN;
                        palList.Session.Save(palList);
                        palList.Session.CommitTransaction();
                    }
                }
                oRequest = oRequest + Environment.NewLine + "							</epcList>";
                oRequest = oRequest + Environment.NewLine + "							<action>ADD</action>";
                oRequest = oRequest + Environment.NewLine + "							<bizStep>urn:epcglobal:cbv:bizstep:commissioning</bizStep>";
                oRequest = oRequest + Environment.NewLine + "							<disposition>urn:epcglobal:cbv:disp:active</disposition>";
                oRequest = oRequest + Environment.NewLine + "							<!-- Partner GLN or SGLN value -->";
                oRequest = oRequest + Environment.NewLine + "							<readPoint>";
                oRequest = oRequest + Environment.NewLine + "							<id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN+ "</id>";
                oRequest = oRequest + Environment.NewLine + "							</readPoint>";
                oRequest = oRequest + Environment.NewLine + "							<!-- Partner GLN or SGLN value -->";
                oRequest = oRequest + Environment.NewLine + "							<bizLocation>";
                oRequest = oRequest + Environment.NewLine + "								<id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN+ "</id>";
                oRequest = oRequest + Environment.NewLine + "							</bizLocation>";
                oRequest = oRequest + Environment.NewLine + "							<eventID>pallet-" + eventid + "</eventID>";
                oRequest = oRequest + Environment.NewLine + "						</ObjectEvent>";

            }
            if (Casecomlist.Count > 0)
            {
                oRequest = oRequest + Environment.NewLine + "						<!-- Commission Case -->";
                oRequest = oRequest + Environment.NewLine + "						   <ObjectEvent>";
                oRequest = oRequest + Environment.NewLine + "								<eventTime>" + System.DateTime.UtcNow.ToString("o") + "</eventTime>";
                oRequest = oRequest + Environment.NewLine + "								<eventTimeZoneOffset>-05:00</eventTimeZoneOffset>";
                oRequest = oRequest + Environment.NewLine + "								<epcList>";
                foreach (RepackLotSerialNo caseList in Casecomlist)
                {
                    if (caseList.CommissionPostedToVendor == false)
                    {
                        oRequest = oRequest + Environment.NewLine + "	    							<epc>urn:epc:id:sgtin:" + caseList.sGTIN + "</epc>";
                        caseList.CommissionBatchId = eventid;
                        caseList.CommissionPostedToVendor = true;
                        caseList.Session.Save(caseList);
                        caseList.Session.CommitTransaction();
                    }
                }
                oRequest = oRequest + Environment.NewLine + "								</epcList>";
                oRequest = oRequest + Environment.NewLine + "								<action>ADD</action>";
                oRequest = oRequest + Environment.NewLine + "									<bizStep>urn:epcglobal:cbv:bizstep:commissioning</bizStep>";
                oRequest = oRequest + Environment.NewLine + "									<disposition>urn:epcglobal:cbv:disp:active</disposition>";
                oRequest = oRequest + Environment.NewLine + "									<readPoint>";
                oRequest = oRequest + Environment.NewLine + "										<id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>";
                oRequest = oRequest + Environment.NewLine + "									</readPoint>";
                oRequest = oRequest + Environment.NewLine + "						   			<bizLocation>";
                oRequest = oRequest + Environment.NewLine + "										<id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>";
                oRequest = oRequest + Environment.NewLine + "									</bizLocation>";
                oRequest = oRequest + Environment.NewLine + "									<commissionExtension>";
                oRequest = oRequest + Environment.NewLine + "										<eventID>CaseCom-" + eventid + "</eventID>";
                oRequest = oRequest + Environment.NewLine + "										<itemIdentifiers>";
                oRequest = oRequest + Environment.NewLine + "							    			<standardItemIdentifier type=\"GTIN\">" + rl.RepackItem.ShipperGtin + "</standardItemIdentifier>";
                oRequest = oRequest + Environment.NewLine + "						    	    		<internalItemIdentifier type=\"MaterialID\">mat2</internalItemIdentifier>";
                oRequest = oRequest + Environment.NewLine + "										</itemIdentifiers>";
                oRequest = oRequest + Environment.NewLine + "							            <processDetail>";
                oRequest = oRequest + Environment.NewLine + "									        <packageLevel>CA</packageLevel>";
                oRequest = oRequest + Environment.NewLine + "										   	<lotOrBatch>" + rl.LotId + "</lotOrBatch>";
                oRequest = oRequest + Environment.NewLine + "										      	<productionDate qualifier=\"MANUFACTURE\">";
                oRequest = oRequest + Environment.NewLine + "										   	    <chronoDate>" + rl.LotExpirationDt.ToString("yyyy-MM-dd") + "</chronoDate>";
                oRequest = oRequest + Environment.NewLine + "										        <labelDate>" + rl.LotExpirationDt.ToString("MMyy") + "</labelDate>";
                oRequest = oRequest + Environment.NewLine + "   										</productionDate>";
                oRequest = oRequest + Environment.NewLine + "                                           <productionDate qualifier=\"EXPIRY\">";
                oRequest = oRequest + Environment.NewLine + "                                              <chronoDate>" + rl.LotExpirationDt.ToString("yyyy-MM-dd") + "</chronoDate>";
                oRequest = oRequest + Environment.NewLine + "	        								   <labelDate>" + rl.LotExpirationDt.ToString("MMyy") + "</labelDate>";
                oRequest = oRequest + Environment.NewLine + "   										</productionDate>";
                oRequest = oRequest + Environment.NewLine + "	    								</processDetail>";
                oRequest = oRequest + Environment.NewLine + "		     							<!--packagingLine>";
                oRequest = oRequest + Environment.NewLine + "									    	<locationIdentifiers>";
                oRequest = oRequest + Environment.NewLine + "										        <internalLocationIdentifier qualifier=\"LineName\">LineName15</internalLocationIdentifier>";
                oRequest = oRequest + Environment.NewLine + "										</locationIdentifiers>";
                oRequest = oRequest + Environment.NewLine + "										    <user role=\"SUPERVISOR\">";
                oRequest = oRequest + Environment.NewLine + "										   	    <userID>Supervisor Id</userID>";
                oRequest = oRequest + Environment.NewLine + "										      	<userName>Supervisor name</userName>";
                oRequest = oRequest + Environment.NewLine + "										   	</user>";
                oRequest = oRequest + Environment.NewLine + "											<user role=\"OPERATOR\">";
                oRequest = oRequest + Environment.NewLine + "											   <userID>Operator Id</userID>";
                oRequest = oRequest + Environment.NewLine + "											   <userName>Operator name</userName>";
                oRequest = oRequest + Environment.NewLine + "											 </user>";
                oRequest = oRequest + Environment.NewLine + "										 </packagingLine-->";
                oRequest = oRequest + Environment.NewLine + "										</commissionExtension>";
                oRequest = oRequest + Environment.NewLine + "									</ObjectEvent>";
            }
            oRequest = oRequest + Environment.NewLine + "							</EventList>";
            oRequest = oRequest + Environment.NewLine + "						</EPCISBody>";
            oRequest = oRequest + Environment.NewLine + "				      </epcis:EPCISDocument>";
            oRequest = oRequest + Environment.NewLine + "					</XML_SYS_EVENTS_ENV>";
            oRequest = oRequest + Environment.NewLine + "				   </ns0:body>";
            oRequest = oRequest + Environment.NewLine + "				</ns0:envelope>";
            oRequest = oRequest + Environment.NewLine + "			</ns2:msgEnvelopeList>";
            oRequest = oRequest + Environment.NewLine + "		</ns2:processMessages>";
            oRequest = oRequest + Environment.NewLine + "	</ns1:Body>";
            oRequest = oRequest + Environment.NewLine + "</SOAP-ENV:Envelope>";

            //******************************************
            // f o r  t e s t i n g O N L Y  

            using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\danCOMMISSIONING.xml"))
            {
                stmw2.Write(oRequest);
            }
            //******************************************
            objectSpace.CommitChanges();
            objectSpace.Refresh();
            if (posttovender)
            {

                try
                {
                    request.Timeout = 100000;
                    request.ContentLength = oRequest.Length;
                    request.ContentType = "text/xml;charset=utf-8";
                    byte[] bytes = Encoding.UTF8.GetBytes(oRequest);
                    request.Headers.Add("SOAP:Action");

                    // for testing only
                    using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\dan.xml"))
                    {
                        stmw2.Write(oRequest);
                    }

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Flush();
                        requestStream.Close();


                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                            throw new ApplicationException(message);
                        }

                        StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                        ResponseXML = responseReader.ReadToEnd();
                        // for testing only *********************************
                        using (StreamWriter stmw3 = new StreamWriter("c:\\temp\\serialResponse.xml"))
                        {
                            stmw3.Write(ResponseXML);
                        }
                        // **************************************************


                    }
                }
                catch (SystemException ex)
                {

                    LastError = ex.Message + "  ";
                    throw new System.ArgumentException(ex.Message);
                }
            }
        }

        /// <summary>
        /// Get Pallet sscc labels serial numbers
        ///
        /// </summary>
        /// <author>Daniel Villavisanis</author>
        /// <param name="gtin"></param>
        /// <param name="qtyToGenerate"></param>
        /// <param name="e"></param>
        public void PostPalletRequest(string GTNid, int QtySerial, SimpleActionExecuteEventArgs e)
        {

            RepackLots repacklot = (RepackLots)e.CurrentObject;
            IObjectSpace objectSpace = this.application.CreateObjectSpace(typeof(RepackLots));
            string repacklotid = repacklot.LotId;
            RepackLots rl = repacklot;
            string oRequest = "";
            string dt = System.DateTime.UtcNow.ToString("o");
            DateTime centuryBegin = new DateTime(2018, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            string eventid = elapsedTicks.ToString();
            string urltemp = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urltemp);

            request.Headers.Add(@"SOAP:Action");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Method = "POST";
            oRequest = oRequest + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            oRequest = oRequest + Environment.NewLine + "<soapenv:Envelope ";
            oRequest = oRequest + Environment.NewLine + "xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" ";
            oRequest = oRequest + Environment.NewLine + "xmlns:ns=\"http://xmlns.rfxcel.com/traceability/serializationService/3\" ";
            oRequest = oRequest + Environment.NewLine + "xmlns:ns1=\"http://xmlns.rfxcel.com/traceability/3\" ";
            oRequest = oRequest + Environment.NewLine + "xmlns:xm=\"http://www.w3.org/2004/11/xmlmime\">";
            oRequest = oRequest + Environment.NewLine + "	<soapenv:Header>";
            oRequest = oRequest + Environment.NewLine + "		<wsa:Action xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\">http://wsop.rfxcel.com/messaging/2/getMessages</wsa:Action>";
            oRequest = oRequest + Environment.NewLine + "		<wsa:ReplyTo xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\">";
            oRequest = oRequest + Environment.NewLine + "			<wsa:Address>http://schemas.xmlsoap.org/ws/2004/08/addressing/role/anonymous</wsa:Address>";
            oRequest = oRequest + Environment.NewLine + "		</wsa:ReplyTo>";
            oRequest = oRequest + Environment.NewLine + "		<wsa:To xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\">https://rfxcel.net/services/IrfxMessagingSoapHttpPort</wsa:To>";
            oRequest = oRequest + Environment.NewLine + "		<wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\"> ";
            oRequest = oRequest + Environment.NewLine + "			<!--optional";
            oRequest = oRequest + Environment.NewLine + "			<wsu:Timestamp wsu:Id=\"TS - 2\">";
            oRequest = oRequest + Environment.NewLine + "			<wsu:Created>" + System.DateTime.UtcNow.ToString("o") + "</wsu:Created>";
            oRequest = oRequest + Environment.NewLine + "				<wsu:Expires>" + rl.LotExpirationDt.ToString("MMyy") + "</wsu:Expires>";
            oRequest = oRequest + Environment.NewLine + "			</wsu:Timestamp>-->";
            oRequest = oRequest + Environment.NewLine + "			<wsse:UsernameToken wsu:Id=\"UsernameToken - 1\"> ";
            oRequest = oRequest + Environment.NewLine + "				<wsse:Username>" + rfxUserName + "</wsse:Username>";
            oRequest = oRequest + Environment.NewLine + "				<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" + rfxPassWord + "</wsse:Password>";
            oRequest = oRequest + Environment.NewLine + "			</wsse:UsernameToken> ";
            oRequest = oRequest + Environment.NewLine + "		</wsse:Security> ";
            oRequest = oRequest + Environment.NewLine + " ";
            oRequest = oRequest + Environment.NewLine + "	</soapenv:Header>";
            oRequest = oRequest + Environment.NewLine + "	<soapenv:Body>";
            oRequest = oRequest + Environment.NewLine + "		<ns:syncAllocateTraceIds contentStructVer=\"3.1.3\" createDateTime=\"2016-11-03T17:40:34.111Z\" requestId=\"pallet-" + eventid + " \">";
            oRequest = oRequest + Environment.NewLine + "			<ns:orgId qlfr=\"ORG_DEF\">" + rl.RepackItem.ReceiverOwnerId + "</ns:orgId>";
            oRequest = oRequest + Environment.NewLine + "			<ns:allocOrgId qlfr=\"GS1_COMPANY_PREFIX\">" + rl.RepackItem.GS1CompanyPrefix + "</ns:allocOrgId>";
            oRequest = oRequest + Environment.NewLine + "			<ns:eventId>palllet-" + eventid + "</ns:eventId>";
            oRequest = oRequest + Environment.NewLine + "			<ns:siteHierId qlfr=\"ORG_DEF\">Manufacturing</ns:siteHierId>";
            oRequest = oRequest + Environment.NewLine + "			<ns:siteId qlfr=\"SGLN\" type=\"LOCATION\">" + rl.RepackPackager.SiteId + "</ns:siteId>";
            oRequest = oRequest + Environment.NewLine + "			<ns:idTextFormat>PURE_ID_URI</ns:idTextFormat>";
            oRequest = oRequest + Environment.NewLine + "			<ns:separatePrefixSuffix>false</ns:separatePrefixSuffix>";
            oRequest = oRequest + Environment.NewLine + "			<ns:returnDataStruct>LIST</ns:returnDataStruct>";
            oRequest = oRequest + Environment.NewLine + "			<ns:extAttrList>";
            oRequest = oRequest + Environment.NewLine + "			<!-- Extension which could be seen in product code -->";
            oRequest = oRequest + Environment.NewLine + "				<ns1:val name=\"SSCC_EXT_DIGIT\">" + rl.RepackItem.SSCC_EXT_DIGIT + "</ns1:val>";
            oRequest = oRequest + Environment.NewLine + "			</ns:extAttrList>";
            oRequest = oRequest + Environment.NewLine + "			<ns:idCount>" + QtySerial.ToString() + "</ns:idCount>";
            oRequest = oRequest + Environment.NewLine + "		</ns:syncAllocateTraceIds>";
            oRequest = oRequest + Environment.NewLine + "	</soapenv:Body>";
            oRequest = oRequest + Environment.NewLine + "</soapenv:Envelope>";

            try
            {
                request.Timeout = 1000000;
                request.ContentLength = oRequest.Length;
                request.ContentType = "text/xml;charset=utf-8";
                byte[] bytes = Encoding.UTF8.GetBytes(oRequest);
                request.Headers.Add("SOAP:Action");

                // for testing only
                using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\rfxPalletRequest.xml"))
                {
                    stmw2.Write(oRequest);
                }

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                    ResponseXML = responseReader.ReadToEnd();
                    // for testing only *********************************
                    using (StreamWriter stmw3 = new StreamWriter("c:\\temp\\PalletResponse.xml"))
                    {
                        stmw3.Write(ResponseXML);
                    }
                    // **************************************************

                    PopulateSerialList();
                }
            }
            catch (SystemException ex)
            {

                LastError = ex.Message + "  ";
                throw new System.ArgumentException(ex.Message);
            }

        }


        public void PostAggEvent(SimpleActionExecuteEventArgs e)
        {



            string dt = System.DateTime.UtcNow.ToString("o");
            //    string shippinggtin = "";
            //   string UnitGtin;

            //string input = System.DateTime.Now.ToString();
            //DateTime dt = DateTime.ParseExact(input, "yyyy-MM-dd'T'hh:mm:ss%K", System.Globalization.CultureInfo.InvariantCulture);
            DateTime centuryBegin = new DateTime(2018, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            string eventid = elapsedTicks.ToString();
            RepackLotSerialNo repacklot = (RepackLotSerialNo)e.CurrentObject;
            IObjectSpace objectSpace = this.application.CreateObjectSpace(typeof(RepackLotSerialNo));
            string repacklotid = repacklot.RepackLot.LotId;
            RepackLots rl = repacklot.RepackLot;
            CriteriaOperator op = CriteriaOperator.Parse("RepackLot.LotId = ? AND IsCommission = ? AND LabelType = ? AND CommissionPostedToVendor =? and AggPostedToVendor = ?", repacklotid, true, eLabelType.InnerCarton, true, false);
            IList Innnercomlist = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);

            op = CriteriaOperator.Parse("RepackLot.LotId = ? AND IsCommission = ? AND LabelType = ? AND CommissionPostedToVendor =? and AggPostedToVendor = ?", repacklotid, true, eLabelType.Pallet, true, false);
            IList palletList = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);

            op = CriteriaOperator.Parse("RepackLot.LotId = ? AND isCommission = ? AND LabelType = ? AND CommissionPostedToVendor =? and AggPostedToVendor = ? ", repacklotid, true, eLabelType.Shipping, true, false);
            IList Casecomlist = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);
            string urltemp = url2;

            //url = "https://UnitDose.track-n-trace.net/rfxcelwss/services/IMessagingServiceSoapHttpPort";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urltemp);
            request.Headers.Add(@"SOAP:Action");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Method = "POST";
            //      XmlDocument soapEnvelope = new XmlDocument();
            string oRequest = "";
            oRequest = oRequest + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            oRequest = oRequest + Environment.NewLine + "<SOAP-ENV:Envelope xmlns:ns3=\"http://xmlns.rfxcel.com/traceability/3\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:ns0=\"http://xmlns.rfxcel.com/traceability/api/3\" xmlns:ns1=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns2=\"http://xmlns.rfxcel.com/traceability/messagingService/3\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"> ";
            oRequest = oRequest + Environment.NewLine + "	<SOAP-ENV:Header xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\" xsi:schemaLocation=\"http://schemas.xmlsoap.org/ws/2004/08/addressing ../SOAP-Security/addressing.xsd\">";
            oRequest = oRequest + Environment.NewLine + "		<wsse:Security mustUnderstand=\"true\">";
            oRequest = oRequest + Environment.NewLine + "		    <wsse:UsernameToken>";
            oRequest = oRequest + Environment.NewLine + "		    <wsse:Username>" + rfxUserName + "</wsse:Username>";
            oRequest = oRequest + Environment.NewLine + "		    <wsse:Password>" + rfxPassWord + "</wsse:Password>";
            oRequest = oRequest + Environment.NewLine + "		    <wsu:Created>" + System.DateTime.UtcNow.ToString("o") + "</wsu:Created>";
            oRequest = oRequest + Environment.NewLine + "		</wsse:UsernameToken>";
            oRequest = oRequest + Environment.NewLine + "		</wsse:Security>";
            oRequest = oRequest + Environment.NewLine + "	</SOAP-ENV:Header>";
            oRequest = oRequest + Environment.NewLine + "	<ns1:Body>";
            oRequest = oRequest + Environment.NewLine + "  <ns2:processMessages contentStructVer = \"3.1.3\" createDateTime = \"2018-12-12T22:56:02Z\" requestId = \"Aggregate" + eventid + "\">";
            oRequest = oRequest + Environment.NewLine + " <ns2:msgEnvelopeList>";
            oRequest = oRequest + Environment.NewLine + " <ns0:envelope>";
            oRequest = oRequest + Environment.NewLine + "   <ns0:header>";
            oRequest = oRequest + Environment.NewLine + "    <ns0:msgInfo>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:sysDeploymentId xsi:type = \"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\">" + rfxUserName + "</ns0:sysDeploymentId>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:senderInstId xsi:type =\"ns3:QualifiedIdType\" qlfr = \"SYS_DEF\">" + rfxUserName + "</ns0:senderInstId>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:senderId xsi:type=\"ns3:TypedQualifiedIdType\" qlfr=\"ORG_DEF\" type=\"ORG_ID\">" + repacklot.RepackLot.RepackItem.SenderOwnerId.Trim() + "</ns0:senderId>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:receiverInstId xsi:type=\"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\"> rfXcel</ns0:receiverInstId>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:receiverId xsi:type=\"ns3:TypedQualifiedIdType\" qlfr=\"ORG_DEF\" type=\"ORG_ID\">" + repacklot.RepackLot.RepackItem.ReceiverOwnerId.Trim() + "</ns0:receiverId>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:msgFormat xsi:type=\"ns3:OptionallyVersionedEnumType\">XML</ns0:msgFormat>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:msgType xsi:type=\"ns3:OptionallyVersionedEnumType\" ver=\"1.1\">SYS_EVENTS_ENV</ns0:msgType>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:msgId/>";
            oRequest = oRequest + Environment.NewLine + "     <ns0:corrMsgId/>";
            oRequest = oRequest + Environment.NewLine + "   </ns0:msgInfo>";
            oRequest = oRequest + Environment.NewLine + "  </ns0:header>";
            oRequest = oRequest + Environment.NewLine + "  <ns0:body>";
            oRequest = oRequest + Environment.NewLine + "	 <XML_SYS_EVENTS_ENV>";
            oRequest = oRequest + Environment.NewLine + "    <epcis:EPCISDocument xmlns:epcis=\"urn:epcglobal:epcis:xsd:1\" xmlns:gs1ushc=\"http://epcis.gs1us.org/hc/ns\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" schemaVersion=\"1.0\" creationDate=\"2015-12-15T17:56:01Z\" xsi:schemaLocation=\"urn:epcglobal:epcis:xsd:1 EPCglobal-epcis-1_1.xsd\">";
            oRequest = oRequest + Environment.NewLine + "	  <EPCISBody>";
            oRequest = oRequest + Environment.NewLine + "	  <EventList>";
            int icount = 0;
            foreach (RepackLotSerialNo c in Casecomlist)
            {
                if (c.AggPostedToVendor == false)
                {


                    oRequest = oRequest + Environment.NewLine + "    <AggregationEvent>";
                    oRequest = oRequest + Environment.NewLine + "       <eventTime>" + System.DateTime.UtcNow.ToString("o") + "</eventTime>";
                    oRequest = oRequest + Environment.NewLine + "       <eventTimeZoneOffset>-05:00</eventTimeZoneOffset>";
                    oRequest = oRequest + Environment.NewLine + "       <parentID>urn:epc:id:sgtin:" + c.sGTIN + "</parentID>";
                    oRequest = oRequest + Environment.NewLine + "          <childEPCs>";
                    CriteriaOperator op1 = CriteriaOperator.Parse("RepackLot = ? AND IsCommission = ? AND  ParentSerialNo=? and commissionPostedToVendor = ? and AggPostedToVendor = ?", c.RepackLot, true, c.SerialNo, true, false);
                    //CriteriaOperator op1 = CriteriaOperator.Parse("RepackLot = ? AND IsCommission = ? AND LabelType = ?  And ParentSerialNo=? and commissionPostedToVendor = ? and AggPostedToVendor = ?", c.RepackLot, true, 0, c.SerialNo, true, false);
                    IList Iclist1 = objectSpace.GetObjects(typeof(RepackLotSerialNo), op1);
                    foreach (RepackLotSerialNo ic in Iclist1)
                    {
                        if (ic.AggPostedToVendor == false)
                        {
                            oRequest = oRequest + Environment.NewLine + "            <epc>urn:epc:id:sgtin:" + ic.sGTIN + "</epc>";
                            ic.AggPostedToVendor = true;
                            ic.Save();
                            ic.Session.Save(ic);
                            ic.Session.CommitTransaction();
                        }
                    }

                    oRequest = oRequest + Environment.NewLine + "            </childEPCs>";

                    oRequest = oRequest + Environment.NewLine + "            <action>ADD</action>";
                    oRequest = oRequest + Environment.NewLine + "            <bizStep>urn:epcglobal:cbv:bizstep:packing</bizStep>";
                    oRequest = oRequest + Environment.NewLine + "            <disposition>urn:epcglobal:cbv:disp:in_progress</disposition>";
                    oRequest = oRequest + Environment.NewLine + "            <readPoint>";
                    oRequest = oRequest + Environment.NewLine + "               <id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>"; ;
                    oRequest = oRequest + Environment.NewLine + "            </readPoint>";
                    oRequest = oRequest + Environment.NewLine + "            <bizLocation>";
                    oRequest = oRequest + Environment.NewLine + "               <id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>"; ;
                    oRequest = oRequest + Environment.NewLine + "            </bizLocation>";
                    oRequest = oRequest + Environment.NewLine + "            <gs1ushc:eventID>Aggregate-" + eventid + icount++.ToString() + "</gs1ushc:eventID>";
                    oRequest = oRequest + Environment.NewLine + "      </AggregationEvent>";
                }
                c.AggPostedToVendor = true;
                c.Save();
                c.Session.Save(c);
                c.Session.CommitTransaction();
            }
            ///Pallet aggregation
            foreach (RepackLotSerialNo c in palletList)
            {
                if (c.AggPostedToVendor == false)
                {

                    oRequest = oRequest + Environment.NewLine + "    <AggregationEvent>";
                    oRequest = oRequest + Environment.NewLine + "       <eventTime>" + System.DateTime.UtcNow.ToString("o") + "</eventTime>";
                    oRequest = oRequest + Environment.NewLine + "       <eventTimeZoneOffset>-05:00</eventTimeZoneOffset>";
                    oRequest = oRequest + Environment.NewLine + "       <parentID>urn:epc:id:sscc:" + c.sGTIN + "</parentID>";
                    oRequest = oRequest + Environment.NewLine + "          <childEPCs>";
                    CriteriaOperator op1 = CriteriaOperator.Parse("RepackLot= ? AND IsCommission = ? And ParentSerialNo=? ", c.RepackLot, true, c.SerialNo);
                    IList Iclist1 = objectSpace.GetObjects(typeof(RepackLotSerialNo), op1);
                    foreach (RepackLotSerialNo ic in Iclist1)
                    {
                        // if (ic.AggPostedToVendor == false)
                        //{
                        oRequest = oRequest + Environment.NewLine + "            <epc>urn:epc:id:sgtin:" + ic.sGTIN + "</epc>";
                        ic.AggPostedToVendor = true;
                        ic.Save();
                        ic.Session.Save(ic);
                        ic.Session.CommitTransaction();
                        //}
                    }

                    oRequest = oRequest + Environment.NewLine + "            </childEPCs>";
                    oRequest = oRequest + Environment.NewLine + "            <action>ADD</action>";
                    oRequest = oRequest + Environment.NewLine + "            <bizStep>urn:epcglobal:cbv:bizstep:packing</bizStep>";
                    oRequest = oRequest + Environment.NewLine + "            <disposition>urn:epcglobal:cbv:disp:in_progress</disposition>";
                    oRequest = oRequest + Environment.NewLine + "            <readPoint>";
                    oRequest = oRequest + Environment.NewLine + "               <id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>"; ;
                    oRequest = oRequest + Environment.NewLine + "            </readPoint>";
                    oRequest = oRequest + Environment.NewLine + "            <bizLocation>";
                    oRequest = oRequest + Environment.NewLine + "               <id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>"; ;
                    oRequest = oRequest + Environment.NewLine + "            </bizLocation>";
                    oRequest = oRequest + Environment.NewLine + "            <gs1ushc:eventID>Aggregate-" + eventid + icount++.ToString() + "</gs1ushc:eventID>";
                    oRequest = oRequest + Environment.NewLine + "      </AggregationEvent>";
                    c.AggPostedToVendor = true;
                    c.Save();
                    c.Session.Save(c);
                    c.Session.CommitTransaction();


                }

            }

            oRequest = oRequest + Environment.NewLine + "	  </EventList>";
            oRequest = oRequest + Environment.NewLine + "     </EPCISBody>";
            oRequest = oRequest + Environment.NewLine + "     </epcis:EPCISDocument>";
            oRequest = oRequest + Environment.NewLine + "	  </XML_SYS_EVENTS_ENV>";

            oRequest = oRequest + Environment.NewLine + "	</ns0:body>";
            oRequest = oRequest + Environment.NewLine + "	</ns0:envelope>";
            oRequest = oRequest + Environment.NewLine + "	</ns2:msgEnvelopeList>";
            oRequest = oRequest + Environment.NewLine + "	</ns2:processMessages>";
            oRequest = oRequest + Environment.NewLine + "	</ns1:Body>";

            oRequest = oRequest + Environment.NewLine + "</SOAP-ENV:Envelope>";

            //******************************************
            using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\soloAggEvent1.xml"))
            {
                stmw2.Write(oRequest);
            }
            //******************************************
            try
            {
                request.Timeout = 100000;
                request.ContentLength = oRequest.Length;
                request.ContentType = "text/xml;charset=utf-8";
                byte[] bytes = Encoding.UTF8.GetBytes(oRequest);
                request.Headers.Add("SOAP:Action");

                // for testing only
                using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\SOLOaggEvent2.xml"))
                {
                    stmw2.Write(oRequest);
                }

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    requestStream.Close();


                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("POST failed. Received HTTP {0} {1}", response.StatusCode, response.StatusDescription);
                        throw new ApplicationException(message);
                    }

                    StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                    ResponseXML = responseReader.ReadToEnd();
                    // for testing only *********************************
                    using (StreamWriter stmw3 = new StreamWriter("c:\\temp\\aggResponse.xml"))
                    {
                        stmw3.Write(ResponseXML);
                    }
                    // **************************************************


                }
            }
            catch (SystemException ex)
            {

                LastError = ex.Message + "  ";
                throw new System.ArgumentException(ex.Message);
            }

        }

        /// <summary>
        /// PostShipEvent
        /// </summary>
        /// <param name="e"></param>
        public void PostShipEvent(SimpleActionExecuteEventArgs e)
        {
            string dt = System.DateTime.UtcNow.ToString("o");
            //  string shippinggtin = "";
            // string UnitGtin;

            //string input = System.DateTime.Now.ToString();
            //DateTime dt = DateTime.ParseExact(input, "yyyy-MM-dd'T'hh:mm:ss%K", System.Globalization.CultureInfo.InvariantCulture);
            DateTime centuryBegin = new DateTime(2018, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            string eventid = elapsedTicks.ToString();
            RepackLotSerialNo repacklot = (RepackLotSerialNo)e.CurrentObject;
            IObjectSpace objectSpace = this.application.CreateObjectSpace(typeof(RepackLotSerialNo));
            string repacklotid = repacklot.RepackLot.LotId;
            RepackLots rl = repacklot.RepackLot;
            CriteriaOperator op;

            op = CriteriaOperator.Parse("RepackLot.LotId = ? AND AggPostedToVendor = ? AND LabelType = ? AND ShippmentPostedToVendor = ?", repacklotid, true, eLabelType.Pallet, false);
            IList palletList = objectSpace.GetObjects(typeof(RepackLotSerialNo), op);

            //op = Crite
            string urltemp = url2;

            //url = "https://unitdose.track-n-trace.net/rfxcelwss/services/IMessagingServiceSoapHttpPort";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urltemp);
            request.Headers.Add(@"SOAP:Action");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Method = "POST";
            //      XmlDocument soapEnvelope = new XmlDocument();
            string oRequest = "";
            oRequest = oRequest + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            oRequest = oRequest + Environment.NewLine + "<SOAP-ENV:Envelope xmlns:ns3=\"http://xmlns.rfxcel.com/traceability/3\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:ns0=\"http://xmlns.rfxcel.com/traceability/api/3\" xmlns:ns1=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns2=\"http://xmlns.rfxcel.com/traceability/messagingService/3\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\">";
            oRequest = oRequest + Environment.NewLine + "	<SOAP-ENV:Header xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\" xsi:schemaLocation=\"http://schemas.xmlsoap.org/ws/2004/08/addressing ../SOAP-Security/addressing.xsd\">";
            oRequest = oRequest + Environment.NewLine + "		<wsse:Security mustUnderstand=\"true\">";
            oRequest = oRequest + Environment.NewLine + "			<wsse:UsernameToken>";
            oRequest = oRequest + Environment.NewLine + "				<wsse:Username>" + rfxUserName + "</wsse:Username>";
            oRequest = oRequest + Environment.NewLine + "				<wsse:Password>" + rfxPassWord + "</wsse:Password>";
            oRequest = oRequest + Environment.NewLine + "				<!--optional";
            oRequest = oRequest + Environment.NewLine + "				<wsu:Created>" + System.DateTime.UtcNow.ToString("o") + "</wsu:Created>-->";
            oRequest = oRequest + Environment.NewLine + "			</wsse:UsernameToken>";
            oRequest = oRequest + Environment.NewLine + "		</wsse:Security>";
            oRequest = oRequest + Environment.NewLine + "	</SOAP-ENV:Header>";
            oRequest = oRequest + Environment.NewLine + "	<ns1:Body>";
            oRequest = oRequest + Environment.NewLine + "		<ns2:processMessages contentStructVer=\"3.1.3\" createDateTime=\"2015-12-15T22:56:02Z\" requestId=\"Ship-" + eventid + "\">";
            oRequest = oRequest + Environment.NewLine + "			<ns2:msgEnvelopeList>";
            oRequest = oRequest + Environment.NewLine + "				<ns0:envelope>";
            oRequest = oRequest + Environment.NewLine + "					<ns0:header>";
            oRequest = oRequest + Environment.NewLine + "						<ns0:msgInfo>";
            oRequest = oRequest + Environment.NewLine + "	    					<ns0:sysDeploymentId xsi:type=\"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\">" + rfxUserName + "</ns0:sysDeploymentId>";
            oRequest = oRequest + Environment.NewLine + "		    				<ns0:senderInstId xsi:type=\"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\">" + rfxUserName + "</ns0:senderInstId>";
            oRequest = oRequest + Environment.NewLine + "                           <ns0:senderId xsi:type=\"ns3:TypedQualifiedIdType\" qlfr=\"ORG_DEF\" type=\"ORG_ID\">"+ repacklot.RepackLot.RepackItem.SenderOwnerId.Trim() + "</ns0:senderId>";
            oRequest = oRequest + Environment.NewLine + "			    			<ns0:receiverInstId xsi:type=\"ns3:QualifiedIdType\" qlfr=\"SYS_DEF\">rfxcel</ns0:receiverInstId>";
            oRequest = oRequest + Environment.NewLine + "				    		<ns0:receiverId xsi:type=\"ns3:TypedQualifiedIdType\" qlfr=\"ORG_DEF\" type=\"ORG_ID\">1</ns0:receiverId>";
            oRequest = oRequest + Environment.NewLine + "					    	<ns0:msgFormat xsi:type=\"ns3:OptionallyVersionedEnumType\">XML</ns0:msgFormat>";
            oRequest = oRequest + Environment.NewLine + "						    <ns0:msgType xsi:type=\"ns3:OptionallyVersionedEnumType\" ver=\"1.1\">SYS_EVENTS_ENV</ns0:msgType>";
            oRequest = oRequest + Environment.NewLine + "							<ns0:msgId/>";
            oRequest = oRequest + Environment.NewLine + "							<ns0:corrMsgId/>";
            oRequest = oRequest + Environment.NewLine + "						</ns0:msgInfo>";
            oRequest = oRequest + Environment.NewLine + "					</ns0:header>";
            oRequest = oRequest + Environment.NewLine + "					<ns0:body>";
            oRequest = oRequest + Environment.NewLine + "						<XML_SYS_EVENTS_ENV>";
            oRequest = oRequest + Environment.NewLine + "							<epcis:EPCISDocument xmlns:epcis=\"urn:epcglobal:epcis:xsd:1\" xmlns:gs1ushc=\"http://epcis.gs1us.org/hc/ns\" creationDate=\"2014-05-30T15:14:27.574-04:00\" schemaVersion=\"1.1\"";
            oRequest = oRequest + Environment.NewLine + "	xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"urn:epcglobal:epcis:xsd:1 EPCglobal-epcis-1_1.xsd\">";
            oRequest = oRequest + Environment.NewLine + "								<EPCISBody>";
            oRequest = oRequest + Environment.NewLine + "									<EventList>";
            oRequest = oRequest + Environment.NewLine + "										<!-- Shipment -->";
            oRequest = oRequest + Environment.NewLine + "										";
            oRequest = oRequest + Environment.NewLine + "										<ObjectEvent>";
            oRequest = oRequest + Environment.NewLine + "				<eventTime>" + System.DateTime.UtcNow.ToString("o") + "</eventTime>";
            oRequest = oRequest + Environment.NewLine + "				<eventTimeZoneOffset>-05:00</eventTimeZoneOffset>";
            oRequest = oRequest + Environment.NewLine + "				<epcList>";

            foreach (RepackLotSerialNo ic in palletList)
            {
                oRequest = oRequest + Environment.NewLine + "            <epc>urn:epc:id:sscc:" + ic.sGTIN + "</epc>";
                ic.ShippmentPostedToVendor = true;
                ic.Save();
                ic.Session.Save(ic);
                ic.Session.CommitTransaction();

            }
            //  oRequest = oRequest + Environment.NewLine + "					<epc>urn:epc:id:sgtin:0324338.520012.000004410512</epc>";

            oRequest = oRequest + Environment.NewLine + "				</epcList>";
            oRequest = oRequest + Environment.NewLine + "				<action>OBSERVE</action>";
            oRequest = oRequest + Environment.NewLine + "				<bizStep>urn:epcglobal:cbv:bizstep:shipping</bizStep>";
            oRequest = oRequest + Environment.NewLine + "				<disposition>urn:epcglobal:cbv:disp:in_transit</disposition>";
            oRequest = oRequest + Environment.NewLine + "				<readPoint>";
            oRequest = oRequest + Environment.NewLine + "					<id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>";
            oRequest = oRequest + Environment.NewLine + "				</readPoint>";
            oRequest = oRequest + Environment.NewLine + "            <bizLocation>";
            oRequest = oRequest + Environment.NewLine + "               <id>" + repacklot.RepackLot.RepackItem.SenderLocationSGIN + "</id>"; ;
            oRequest = oRequest + Environment.NewLine + "            </bizLocation>";
            oRequest = oRequest + Environment.NewLine + "				<bizTransactionList>";
            oRequest = oRequest + Environment.NewLine + "	     	        <bizTransaction type=\"urn:epcglobal:cbv:btt:po\">urn:epcglobal:cbv:bt:" + repacklot.RepackLot.CustomerId.CustomerGLN + ":" + repacklot.RepackLot.CustomerPO + "</bizTransaction>";
            oRequest = oRequest + Environment.NewLine + "	     	        <bizTransaction type=\"urn:epcglobal:cbv:btt:desadv\">urn:epcglobal:cbv:bt:" + repacklot.RepackLot.CustomerId.CustomerGLN + ":" + repacklot.RepackLot.CustomerPO + repacklot.RepackLot.LastDeliveryNumber++.ToString() + "</bizTransaction>";
            oRequest = oRequest + Environment.NewLine + "				</bizTransactionList>";
            oRequest = oRequest + Environment.NewLine + "				<extension>";
            oRequest = oRequest + Environment.NewLine + "					<sourceList>";
            oRequest = oRequest + Environment.NewLine + "						<source type=\"urn:epcglobal:cbv:sdt:owning_party\">" + repacklot.RepackLot.RepackItem.ReceiverOwnerId.Trim() + "</source>";
            oRequest = oRequest + Environment.NewLine + "						<source type=\"urn:epcglobal:cbv:sdt:location\">" + repacklot.RepackLot.RepackItem.DestinationLocation.Trim() + "</source>";
            oRequest = oRequest + Environment.NewLine + "					</sourceList>";
            oRequest = oRequest + Environment.NewLine + "					<destinationList>";
            oRequest = oRequest + Environment.NewLine + "						<destination type=\"urn:epcglobal:cbv:sdt:owning_party\">" + repacklot.RepackLot.RepackItem.ReceiverOwnerId.Trim() + "</destination>";
            oRequest = oRequest + Environment.NewLine + "						<destination type=\"urn:epcglobal:cbv:sdt:location\">" + repacklot.RepackLot.RepackItem.ReceiverLocation.Trim() + "</destination>";
            oRequest = oRequest + Environment.NewLine + "					</destinationList>";
            oRequest = oRequest + Environment.NewLine + "				</extension>";
            oRequest = oRequest + Environment.NewLine + "				<gs1ushc:eventID>GS1_Ship_" + eventid + "</gs1ushc:eventID>";
            oRequest = oRequest + Environment.NewLine + "			</ObjectEvent>";
            oRequest = oRequest + Environment.NewLine + "									</EventList>";
            oRequest = oRequest + Environment.NewLine + "								</EPCISBody>";
            oRequest = oRequest + Environment.NewLine + "							</epcis:EPCISDocument>";
            oRequest = oRequest + Environment.NewLine + "						</XML_SYS_EVENTS_ENV>";
            oRequest = oRequest + Environment.NewLine + "					</ns0:body>";
            oRequest = oRequest + Environment.NewLine + "				</ns0:envelope>";
            oRequest = oRequest + Environment.NewLine + "			</ns2:msgEnvelopeList>";
            oRequest = oRequest + Environment.NewLine + "		</ns2:processMessages>";
            oRequest = oRequest + Environment.NewLine + "	</ns1:Body>";
            oRequest = oRequest + Environment.NewLine + "</SOAP-ENV:Envelope>";

            //******************************************
            using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\soloSHIPEVENT.xml"))
            {
                stmw2.Write(oRequest);
            }
            //******************************************
            try
            {
                request.Timeout = 100000;
                request.ContentLength = oRequest.Length;
                request.ContentType = "text/xml;charset=utf-8";
                byte[] bytes = Encoding.UTF8.GetBytes(oRequest);
                request.Headers.Add("SOAP:Action");

                // for testing only
                using (StreamWriter stmw2 = new StreamWriter("c:\\temp\\soloShipEvent.xml"))
                {
                    stmw2.Write(oRequest);
                }
                if (rl.SendFile)
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Flush();
                        requestStream.Close();

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                            throw new ApplicationException(message);
                        }

                        StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                        ResponseXML = responseReader.ReadToEnd();
                        // for testing only *********************************
                        using (StreamWriter stmw3 = new StreamWriter("c:\\temp\\shipResponse.xml"))
                        {
                            stmw3.Write(ResponseXML);
                        }
                        // **************************************************
                    }
                }
                else
                {
                    string message = String.Format("Repack Lot send File Checkmark is set to {0}", rl.SendFile.ToString());
                    throw new ApplicationException(message);


                }

            }
            catch (SystemException ex)
            {

                LastError = ex.Message + "  ";
                throw new System.ArgumentException(ex.Message);
            }

        }




        class SerialNo
        {
            public List<SerialNo> SerialNos = new List<SerialNo>();

            public string Sid { get; set; }
            public string sGTIN { get; set; }
            public SerialNo()
            {
                SerialNos = new List<SerialNo>();
            }

        }

    }
}
