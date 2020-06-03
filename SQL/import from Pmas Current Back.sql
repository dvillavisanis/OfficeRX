use [OfficeRX_abc4]
declare @CompanyId varchar(3)
set @CompanyId= '001';
EXEC master.dbo.sp_dropserver @server=N'[xsql2]', @droplogins='droplogins'
-

--Drop Existing LinkedS erver [CARME]:
EXEC sp_dropserver @server=N'xsql2', @droplogins='droplogins'
--GO
eXEC sp_addlinkedserver @server = N'xsql2', 
  @srvproduct=N'',  
        @provider=N'SQLNCLI10',
    @datasrc=N'orx',
                            @provstr=N'DRIVER={SQL Server};SERVER=xsql2;UID=orx;PWD=12admin90!'
GO
EXEC sp_addlinkedsrvlogin @rmtsrvname=N'xsql2', 
                         @useself=N'False', 
                         @locallogin=NULL, 
                         @rmtuser='orx', 
                         @rmtpassword='12admin90!'
GO

select * from [xsql2].atlanticbio.dbo.[ABC_COMPANIES]

--EXEC sp_MSset_oledb_prop N'it-storage', N'AllowInProcess', 1
--EXEC master.dbo.sp_dropserver @server=N'it-storage', @droplogins='droplogins'
GO
 

--select * from openquery ([xsql2], 'select @@servername a' );

------- ******* Customer **********
--------************update do not do this [xsql2].atlanticbio.dbo.customer set state =null where (select count(*) from  [xsql2].atlanticbio.dbo.states states where states.statecd = customer.state) = 0
--delete from [dbo].[VendorContact]
--go
--delete from [dbo].[VendorNote]
--go
--delete from Vendor;
--go
--delete from [dbo].[DistributionCenterWhse]
--go 
--delete from [dbo].[DistributionCenter]
--delete from dbo.CustomerContact
--go 
--delete from dbo.Customernote
--go

--delete from [dbo].[Customer]
--GO
--delete from salesorder-
--go
--delete from repacklotOperations
--go
--delete from repacklots
--go 
--delete from [dbo].[CustomerParentSystem]
--go
--delete from vendorcontact
--go
--delete from vendornote
--go 
--delete from vendor
--go




UPDATE       [xsql2].[atlanticbio].[dbo].ClientUsers
SET                OID = NEWID() where oid is null
go



insert dbo.party (oid)
(select oid 
from 
[xsql2].[atlanticbio].[dbo].[ClientUsers] cu
where 
 upper(cu.userid) not in (select [UserName]from [dbo].[Employee]) and cu.active = 'Y' and Company_id = '001')        





Print 'Person'
go 
insert   dbo.Person ( Oid, FirstName, LastName,  Email)
(select OID ,cu.first_name,cu.last_name,cu.useremail
from 
[xsql2].[atlanticbio].[dbo].[ClientUsers] cu
where 
 upper(cu.userid) not in (select [UserName]from [dbo].[Employee]) and cu.active = 'Y' and Company_id = '001')        
go 

print 'Employee'
go 
insert [dbo].[Employee]([OID],[UserName],[IsActive],[ChangePasswordOnFirstLogon])
(select oid,USERID ,1,1
from 
[xsql2].[atlanticbio].[dbo].[ClientUsers]  cu 
where [Company_id] = '001' and
[active] = 'Y' and upper(userid) not in (select [UserName]from [dbo].[Employee]) )
go 
  



Print 'Security Roles'
--go
insert into   [dbo].[EmployeeRoleEmployeeRoles_EmployeeEmployees] (Employees,EmployeeRoles,OID)
(SELECT cu.oid,  (SELECT        TOP (1) Oid FROM        [dbo].[PermissionPolicyRole]   
WHERE        (Name = 'Lookup')),newID()
FROM            [xsql2].atlanticbio.dbo.security_groupings sg , [xsql2].atlanticbio.dbo.[ClientUsers] cu,
             [dbo].[Employee] ssu
WHERE      ssu.Oid =cu.oid and sg.user_name = cu.userid and  (group_name = 'Salesmodule') and cu.active = 'Y' )

Go

insert into   [dbo].[EmployeeRoleEmployeeRoles_EmployeeEmployees] (Employees,EmployeeRoles,OID)
(SELECT cu.oid,  (SELECT        TOP (1) Oid FROM        [dbo].[PermissionPolicyRole]   
WHERE        (Name = 'Sales')),newID()
FROM            [xsql2].atlanticbio.dbo.security_groupings sg , [xsql2].atlanticbio.dbo.[ClientUsers] cu,
             [dbo].[Employee] ssu
WHERE      ssu.Oid =cu.oid and sg.user_name = cu.userid and  (group_name = 'Salesmodule') and cu.active = 'Y' )





Print 'Shipping Type'
Go
insert into    dbo.ShippingType (ShippingTypeCode, ShippingDescription)
SELECT       ShipCode, Description FROM  [xsql2].mas_001.dbo.SO8_ShippingRate

go



print 'ParentSystem'
Go
	insert [dbo].[CustomerParentSystem] ([OID],[ParentSystemName])
	select [Parentsystemid],[Parentsystemdesc] from  [xsql2].[atlanticbio].[dbo].[Customer_parentsystem]
Go 

--delete from [dbo].[SalesRep];


go
print 'Sales Rep'
go
	insert [dbo].[SalesRep] (SalesRepCode,LastName,FirstName,[SalesrepAccountingCode],IsActive,Repstartdate)
		select Distinct upper(C.[Record_Manager]), case LEN(IsNULL(last_name,'')) 
		when 0  then substring(upper(C.[Record_Manager]),2,len(Record_Manager))
		
		else Last_name end,

		Case 	LEN(IsNULL(first_name,'')) 
		when 0 then substring(upper(C.[Record_Manager]),1,1)
		else First_name end,
		[MAS_salesPerson],
		case upper(cu.active)
		when 'Y' then 1
		else 0
		end 
		,cu.StartDate
		from [xsql2].atlanticbio.[dbo].[Company_customers] c
			left outer Join [xsql2].atlanticbio.dbo.clientusers  cu on cu.userid = c.Record_Manager 
		WHERE c.Record_Manager IS NOT NULL  and  c.company_id = '001'
go 
insert [dbo].[SalesRepGoals]( [Oid]
      ,[SalesRep],[GoalYear],[GoalMonth] ,[GoalAmt] ,[UdSaleTotalGoalDollars]
      ,[UdSolidUnits]  ,[UdLiquidUnits]   ,[UdPowderUnits]  ,[UdSyringUnits]
      ,[UdNarcUnits]    ,[UdOintmentUnits]  ,[UDCiiUnits]   ,[UdUntdUnits]
      ,[UdSolidDollars]    ,[UdLiquidDollars]    ,[UdPowderDollars]  ,[UdSyringDollars]
      ,[UdNarcDollars]      ,[UdOintmentDollars]      ,[UDCiiDollars]      ,[UdUntdDollars])
  
(SELECT  Newid()
      ,UPPER(LTRIM([SalesRepid])) ,[goalyear],[goalmth]
      ,[Goal] ,[c17856SalesGoals]
      ,[c17856solid]      ,[c17856liquid]      ,[c17856powder]      ,[c17856Syringe]
      ,[c17856narc]      ,[c17856Ointments]      ,[c17856CII]     ,[c17856untd]   
	  ,[c17856solidDollars]      ,[c17856liquidDollars]      ,[c17856powderDollars]      ,[c17856SyringeDollars]
      ,[c17856NarcoticDollars]      ,[c17856OintmentsDollars]      ,[c17856CIIDollars]    ,[c17856untdDollars]
  FROM [xsql2].[ATLANTICBIO].[dbo].[ClientUserGoals] g,
[xsql2].[ATLANTICBIO].[dbo].[ClientUsers] cu
  WHERE g.salesrepid = cu.userid and cu.active = 'Y' and cu.[Company_id] = '001' and cu.salesagent = 'Y' and (SELECT COUNT(*) FROM SALESREP WHERE UPPER(LTRIM([SalesRepid])) = sALESREPID and [goalyear] > '2014' and [goalyear] > '2014') >0
  )

go 

--Delete from ManufacturerNote

--delete from Manufacturer

Go
print 'manufacture'
insert Manufacturer ( ManfacturerCode, ManufacturerName, Address,  City, State,
 ZipCode, Phone)
 (SELECT        ManfCode, ManufName,  Address, City, s.statecode, zipcode,  Phone
FROM            [xsql2].atlanticbio.dbo.manufactures m left outer join [dbo].[State] s
on m.state = s.StateCode
 where manfcode<>'')

print 'ManufacturerNote'
Go 

--delete from state
Go
print 'State' 
go
insert [dbo].[State] ([StateCode],[StateName])
select Distinct Statecd, state from [xsql2].atlanticbio.dbo.states 
go
delete from [dbo].[VendorType]
insert [dbo].[VendorType] ([VendorTypeCode],[VendorTypeDesc]) values ('MANU','Manufacturer')
insert [dbo].[VendorType] ([VendorTypeCode],[VendorTypeDesc]) values ('WSR','Wholesaler')
go
delete from Wholesaler 
Go
Print 'Wholesaler'
go
insert into [dbo].[Wholesaler] ([Name])
select distinct Wholesaler from  [xsql2].atlanticbio.dbo.Customer
go



Print 'Customer IDN'

insert into [dbo].[CustomerIDN]
([IDNName])
select [Custmer_idn]
from [xsql2].atlanticbio.[dbo].[Customer_IDN]
go 
  
Print 'Customer Classifications'
go
insert  CustomerClassification ( Classification)
(select         Customer_class_desc
FROM            [xsql2].atlanticbio.dbo.Customer_Code)

go
Print 'Customer GPO'
go
insert  [dbo].[CustomerGPO] ( [GPOName])
SELECT        Description
FROM            [xsql2].atlanticbio.dbo.Customer_GPO where company = '001'






Print 'Customer'
go
insert [dbo].[Customer]
([CustomerName],[CustomerNo],[BillingAddress],[BillingAddress2],[BillingAddress3],[BillingCity],
[BillingState],[BillingZip],[ShipAddress],[ShipAddress2],[ShipAddress3],[ShipCity],[Shipstate],
[ShipZip],[Phone],[Fax], [UnitCount] ,[WebSite],[DEANo],[DeaExpDate],[CreatedDate] ,  [CreatedBy] ,
[Oldid],[SalesRep],Wholesaler,
[Classification] ,[CustomerGPO],[CustomerParentSystem],IDN)
select Distinct c.[COMPANY],cc.[MAS_CUSTOMER_NO],c.[ADDRESS1],c.[ADDRESS2],c.[ADDRESS3],
c.[CITY],upper(c.[STATE]),c.[Zip],c.[SHIP_ADDRESS],c.[SHIP_ADDRESS2],c.[SHIP_ADDRESS3],c.[SHIP_CITY],upper(c.[SHIP_STATE]),
c.[SHIP_ZIP],SUBSTRING(c.phone,1,15),substring(c.[FAX],1,15),cast(c.[BEDS] as int),
c.[WEBSITE],c.[DEA_NO],c.[DeaEXPDate],c.[CREATE_DATE],
UPPER(c.[RECORD_CREATOR]),cc.[CUSTOMER_ID],
 ltrim(upper(cc.[RECORD_MANAGER])),(select top 1 oid from wholesaler where c.wholesaler = wholesaler.name),
(select top 1 oid from CustomerClassification cc1 where  cc1.Classification=  cclass.Customer_class_desc),
(select top 1 oid from [dbo].[CustomerGPO] cgp where  cgp.[GPOName] =  cgpo.Description),
(SELECT TOP 1 [OID] FROM [dbo].[CustomerParentSystem] where [ParentSystemName] = cps.[Parentsystemdesc]),
(SELECT TOP 1 [OID] FROM [dbo].[CustomerIDN] where [IDNName] = c.[idn])

From
[xsql2].atlanticbio.[dbo].[COMPANY_CUSTOMERS] cc,
[xsql2].atlanticbio.[dbo].[CUSTOMER] c left outer join [xsql2].atlanticbio.[dbo].Customer_Code cclass
on [c].code = cclass.[Customer_Code] left outer join [xsql2].atlanticbio.[dbo].Customer_GPO cgpo
on [c].gpo = cgpo.[CustomerGPO] 
left outer join [xsql2].atlanticbio.[dbo].[Customer_parentsystem] cps
on c.[ParentSystem] = cps.[Parentsystemid]
where 
c.customer_id =  cc.Customer_id and
cc.company_id = '001' and c.isdeleted is null and len(cc.record_manager) < 15

 go
 
 print  'Customer Contact'
 go
 Insert dbo.CustomerContact ([FirstName],[LastName],[Address],[Address2],[City],[State],
[ZipCode],[Phone],[Mobile],[Fax],[Email],[BirthDate],[FaceBook],[Notes],[SendMarketing],[Customers])
select [FIRST_NAME],[LAST_NAME],[ADDRESS1],[ADDRESS2],[CITY],upper(cc.[STATE])
,[ZIP],cc.[PHONE],[MOBILE],cc.[FAX],[E_MAIL],[Birthdate],[Facebook],cc.[Notes],[SendMarketing],c.oid

from [xsql2].atlanticbio.dbo.Customer_Contacts cc,
dbo.Customer c where c.oldid = cc.Customer_id and cc.company_id = '001'
 and (CC.First_Name is not NULL or cc.LaST_NAME is not NULL)  and
  (len(rtrim(cc.[STATE])) = 2 or cc.state is null)  and
   (len(rtrim(cc.[PHONE])) <= 15 or cc.phone is null)  and 
  (len(mobile) <= 10  or cc.mobile is null) and
  (len(cc.fax) <= 10 or cc.fax is null)

 go
 print  'Customer License verifications'
 go
 Insert [dbo].[CustomerLicenseVerifications] ([LicenseNumber],[Customer],[LicenseExpirationDate],[verifiedBy],[VerificationDate])
 select  DEANumber,(select top 1 oid from [dbo].[Customer] where [Oldid] = CustomerId),Deadt,upper(varifiedby),VarifiedDt
 from [xsql2].atlanticbio.[dbo].[Customer_DeaVarifications]  l,
   [xsql2].atlanticbio.[dbo].[CUSTOMER] c,
[xsql2].atlanticbio.[dbo].[COMPANY_CUSTOMERS] cc
where 
(l.customerid = c.customer_id and
l.mas_companyid = '001') and
c.customer_id =  cc.Customer_id and
cc.company_id = '001' and isdeleted is null

 

Go
Print 'WebUsers'

Go

insert  WebUsers      (WebUserName, UserPassword, WebUserEmail)
SELECT distinct [WebUsername]  ,[WebPassword]  ,[Email]
  FROM [xsql2].[ATLANTICBIO].[dbo].[Customer_WebUsers] cw where Company_id = '001' and 
  (select count(*) from WebUsers w  where w.WebUserName = cw.[WebUsername]) = 0 

go
print 'CustomerWebUsers'
go

insert CustomerWebUsers        (oid,Customers, WebUser)

select newid(), (select oid from customer where oldid =  ccw.customer_id) ,cw.[WebUsername] from 
[xsql2].atlanticbio.[dbo].[Company_Customers_Webusers] ccw,
[xsql2].atlanticbio.[dbo].[Customer_WebUsers] cw
where cw.[Webuserid]= ccw.[Webuserid] and   (select count(*) from WebUsers w  where w.WebUserName = cw.[WebUsername]) = 1 



go
Print 'Vendors' 
go
insert dbo.Vendor([VendorName],[AccountingVendorNumber],[Address],[Address2],[Address3],[City],[State],[ZipCode],[phone]
,Fax,Website,[oldvendorid])
(select distinct
      ap1.[VendorName],ap1.[VendorNumber] ,[AddressLine1]   ,[AddressLine2],[AddressLine3]   ,[City] ,[State]  ,[ZipCode]
      ,[PhoneNumber]  ,[Fax],[URLAddress]      ,ap1.[VendorNumber]
	  from 

[xsql2].[mas_001].[dbo].[IM5_TransactionDetail] im5,
[xsql2].mas_001.[dbo].[AP1_VendorMaster] ap1
where im5.[VendorCustomerNumber] = ap1.[VendorNumber]and
im5.[TransactionCode] = 'PO'
)

go
update  vendor set lastdatePurchasedFrom =lastdate
from 
vendor v,
(select [VendorCustomerNumber],max([TransactionDate]) as lastdate 
 from [xsql2].[mas_001].[dbo].[IM5_TransactionDetail] im5 where im5.[TransactionCode] = 'PO' 
 group by [VendorCustomerNumber]) im5
where  
ltrim([VendorCustomerNumber]) = V.[oldvendorid]
go


update  vendor set IsActive = 1 from Vendor where LastDatePurchasedFrom >= '1/1/2014'
go 

--delete from [dbo].[DistributionCenterWhse]
--delete from [dbo].[DistributionCenter] 
Go
Print 'Distribution Centers'
Insert into [dbo].[DistributionCenter] ([DCName],[Address],[Address2],[City],[State],
[ZipCode],[DeaLicense],[DEAExpirationDt],[StateLicense],[StateExpirationDt],[OldFacilityId])
Select [FacilityName],[FacilityAddress1],[FacilityAddress2],[FacilityCity],upper([FacilityState]),[FacilityZip],
[DEAlicense],[DeaExpiration],[StateLicense],[stateexpiration],[FacilityId]
From 
[xsql2].atlanticbio.[dbo].[Facilities] 
where Companyid = '001' and len(rtrim([FacilityState])) = 2  
Go


--delete from [dbo].[DistributionCenterWhse]
--go
Print 'Distribution Centers whse'
go 

insert into [dbo].[DistributionCenterWhse] ([WhseCode],[Name],[Retail],[Partial],[DistributionCenter])
select Distinct fw.[Whseid],fw.[Whseid],[Webwarehouse],[ispartial],dc.[Oid]
from [xsql2].atlanticbio.[dbo].[Facilities_whse] fw ,
[dbo].[DistributionCenter] DC

where 
(DC.OldFacilityID = fw.FacilityId and fw.Companyid = '001') order by fw.whseid

update [dbo].[DistributionCenterWhse] set name = (select [WhseDescription] from [xsql2].mas_001.[dbo].[IMC_WarehouseCode] imc where 
imc.whsecode = [dbo].[DistributionCenterWhse].whseCode)
Go

print 'WhseBins'
Go

insert          DistributionCenterWhseBins 
(Warehouse, BinBarcode, BinRack, BinLevel)
(select [WhseCode],'000','000','000' from [dbo].[DistributionCenterWhse])
Go

print ' item product line'
--delete from [ItemProductLine] 

go 
 Insert into  [ItemProductLine] ( [ProductLineCode]
      ,[Description] ,[Valuation] ,[StandardUnitOfMeasure]     ,[PurchaseUnitOfMeasure]
      ,[SalesUnitOfMeasure]       )
select distinct upper([PRODUCT_LINEcd]),[PRODUCT_DESC],5,'EA','EA','EA'
from [xsql2].atlanticbio.[dbo].[PRODUCT_LINE] where [CompanyCd] = '001'
go

print 'Items'
Go
Insert into [dbo].Items ([ItemNumber],[ItemDescription],ItemType,[BarCode],[ProductName],GenericKey,
AccountingNumber,[FormCode],[Strength],[PackageSize],
[DeaClass],[OriginalNDC],[IsRefrigerated],[RefrigerateAfterOpening],[CreatedBy],[CreatedDate],productline,StdPrice,MinPrice,ReorderPoint)
select [NDC_CODE],[Mas_longDesc],0,[UPC_Barcode],[PRODUCT_NAME],GCN,rb.mas_itemnumber,[FORM_CODE],[STRENGTH_DESC],[PACKAGE_SIZE],
[DEA_CLASS_CODE],[OriginalNDC],Case When upper([Refridgerated])='Y' then 1
 Else 0 end,Case When upper([Refridgerated])='Y' then 1 else 0 end,[Createdby],[Createddt],
(select top 1 oid from [dbo].[ItemProductLine] where [ProductLineCode]= upper(im1.ProductLine)),
case [StdPrice]
 when 0 then im1.lastcost *1.33
 else [stdprice] 
 end ,

case (select [MinPrice] from [xsql2].atlanticbio.[dbo].[ItemMinPrice] where company_cd = '001' and itemnumber = im1.itemnumber) 
 When  0 then Im1.[LastCost] * 1.22
else 
(select [MinPrice] from [xsql2].atlanticbio.[dbo].[ItemMinPrice] where company_cd = '001' and itemnumber = im1.itemnumber)

end, rb.Reorderpoint
From [xsql2].atlanticbio.[dbo].[ZRB_RED_BOOK] rb,
     [xsql2].mas_001.[dbo].[IM1_InventoryMasterfile] im1

where 
rb.mas_itemnumber = im1.itemnumber and

active = 1 and len(ndc_code) >10 and len(rtrim([Mas_longDesc])) >5
Go
print 'correcting Item descriptions'
update items set ItemDescription = LN , 
AccountingNumber = SUBSTRING(NDC,1,5) +  '-'+ SUBSTRING(NDC,6,4) + '-'+SUBSTRING(NDC,10,2),
BarCode = ndc,ProductName=LN60  , BrandName= BN, 
GNC_Sequence= GCN_SEQNO , GNC=  GCN_SEQNO,  AdditionalDescription = AD,
 Strength = cast(HCFA_PS as nvarchar) + ' ' + HCFA_UNIT, 
 PackageDescription = PD, PackageSize = PS,  DeaClass = DEA,
 FormCode = HCFA_UNIT
From Items,
FirstData.dbo.RNDC14_NDC_MSTR fd
where itemnumber = ndc  

Print 'Items from FirstData'
Go

insert Into Items (ItemNumber, ItemDescription, ItemType, AccountingNumber, BarCode, ProductName, BrandName, 
GNC_Sequence, GNC,  AdditionalDescription, Strength, PackageDescription, PackageSize,  DeaClass, FormCode )
SELECT       fd.NDC, LN, 0, SUBSTRING(NDC,1,5) +  '-'+ SUBSTRING(NDC,6,4) + '-'+SUBSTRING(NDC,10,2), NDC,LN60,BN,
  GCN_SEQNO,GCN_SEQNO, AD,   cast(HCFA_PS as nvarchar) + ' '+ HCFA_UNIT ,PD,PS, dea,  HCFA_UNIT
FROM            FirstData.dbo.RNDC14_NDC_MSTR fd
where  (select count(*) from items where itemnumber = ndc) = 0




Print 'Item Groups'
go
insert into dbo.ItemPricingGroup (ItemgroupCd,ItemGroupDescription)

SELECT       Item_Group, Item_Group_Desc
FROM           [xsql2].atlanticbio.[dbo].Company_Items_Groups where Company_id = '001'


Go
delete from dbo.ItemPricingGroupList
go 
insert into dbo.ItemPricingGroupList (ItemPricingGroup,Item,GroupPrice,
 ContractAcquisitionCost)
  
SELECT   (select Top 1 oid from[dbo].[ItemPricingGroup]where  [ItemGroupCd] = Item_Group), ndc_code, Std_Groupprice ,
                         ContractAcquisitionCost
FROM            [xsql2].atlanticbio.dbo.Company_Items ci
where ci.ndc_code in (select itemnumber from Items) and company_id = '001'

go

Print 'itemInventory'
 Go
 insert  [dbo].[ItemInventory] ([ItemNumber]   ,[Warehouse]      ,[ItemLot]      
      ,[ExpirtationDate]      ,[QtyOnHand]      
      ,[UnitCost]     )
   
   select rb.ndc_code,
 (select  [WhseCode] from [dbo].[DistributionCenterWhse] dcw where  dcw.[WhseCode] = im3.[WhseCode])
  ,lotserialnumber,
  (SELECT [Expirationdt] FROM [xsql2].[ATLANTICBIO].[dbo].[ItemLotExp]
  where itemnumber = im3.itemnumber and lot = im3.lotserialnumber),
   QtyOnHand ,unitcost
  
  from  [xsql2].[mas_001].[dbo].[IM3_ItemCosting] im3,
 [xsql2].atlanticbio.dbo.[ZRB_RED_BOOK] rb
 where im3.itemnumber = rb.mas_itemnumber and QtyOnhand >0 and
 rb.ndc_code in  (select itemnumber from 
[dbo].items)
GO

print 'ItemPTB'
Go

  insert dbo.ItemPTB
(   OID, ItemNumber, StartDate, EndDate, EnterDate, PTB)

SELECT newid(),[NDC_CODE]
      ,[StartDate]
      ,[Enddate]
      ,[entered]
	  ,[ptb]
           
  FROM [xsql2].[ATLANTICBIO].[dbo].[NDC_PTB] 
  where (select count(*) from items where Itemnumber = NDC_Code) >0
  go
  print 'updating currentptbItemPTB'
  update items set CurrentPTB = ptb
   from items,itemPTB 
   where itemptb.itemnumber = items.ItemNumber
Print 'Purchase orders'
Go
insert dbo.ItemPurchaseOrder
(Vendor, PoStatus, PurchaseOrderNumber, PODate, VendorAddress, VendorAddress2, VendorAddress3, VendorCity, 
VendorState, VendorZipCode, ShipToName, ShipToAddress, ShipToAddress2, 
ShipToCity, ShipToState, ShipZipCode, FreightAmt, 
IsPrinted, OnHold, Comment,  VendorName,
DistributionCenter, Warehouse, [AccountingPORefNumber])
select  (select [OID] from dbo.vendor where [oldvendorid] = po1.VendorNumber),1,
 PurchaseOrderNumber, PurchaseOrderDate, VendorAddress1, VendorAddress2, VendorAddress3,VendorCity, VendorState,
					 VendorZipCode, 
                         ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZipCode, 
						  FreightAmount,0,0,Comment,VendorName,
						  (SELECT   DistributionCenter FROM     dbo.DistributionCenterWhse where WhseCode= WarehouseCode),
						 (SELECT     WhseCode FROM   dbo.DistributionCenterWhse where WhseCode= WarehouseCode),
						 PurchaseOrderNumber
					FROM          [xsql2].mas_001.dbo.PO1_PurchaseOrderEntryHeader po1
					WHERE        (OrderStatus IN ('O', 'B', 'N')) AND (PurchaseOrderDate >= '3/1/2017')
Go





print 'Purchase order Lines'
Go



insert into    ItemPurchaseOrderLine  

( PurchaseOrder, ItemNumber, ItemDescription, UnitCost, QtyOrdered, QtyReceived, QtyBackOrdered)

select ( select top 1 OID from [dbo].[ItemPurchaseOrder] where [AccountingPORefNumber] = po2.[PurchaseOrderNumber]),
 rb.ndc_code,rb.mas_longdesc, UnitCost,QtyOrdered,QtyReceived, QtyBckordrd
 
  FROM            [xsql2].mas_001.dbo.PO2_PurchaseOrderEntryLine po2,
                [xsql2].mas_001.[dbo].[PO1_PurchaseOrderEntryHeader] po1,
                [xsql2].[atlanticbio].[dbo].[ZRB_RED_BOOK] rb
				where 
				po2.[PurchaseOrderNumber]= po1.[PurchaseOrderNumber] and
				po2.itemnumber = rb.mas_itemnumber and 

               (OrderStatus IN ('O', 'B', 'N')) AND (PurchaseOrderDate >= '3/1/2017')and
			   (select Count(*) from Items where items.itemnumber = rb.ndc_code) > 0

go
Print 'Updating Qtys'
go
update items set QtyOnPurchaseOrder = (select sum(QtyOrdered) from [dbo].[ItemPurchaseOrderLine] pol,
[dbo].[ItemPurchaseOrder]po where
po.oid = POL.[PurchaseOrder] and pol.Itemnumber= items.itemnumber and po.PoStatus = 1)

go 
Print 'Customer Item Pricing'
go
insert CustomerItemPricing ( Oid, Customer, Item, CustomerPrice,LastUpdatedBy,LastUpdated)

SELECT    newid(), (select oid From Customer c where c.oldid = Customer_id ),
 NDC_CODE, Pricing,   lastupdatedby,Lastupdated
FROM            [xsql2].atlanticbio.dbo.Customer_ItemPricing
where  company_id = '001' and  (select count(*) from items where ItemNumber = ndc_code) = 1 and Pricing > 0
Go 



--update [dbo].[Items] set [QtyOnHand] = (select sum([QtyOnHand]) from [dbo].[ItemInventory] where
--[dbo].[Items].[ItemNumber] = [dbo].[ItemInventory].itemnumber)

--go 








go
print 'Repackagers'
go

Insert into RepackPackager (PackagerName, HoldingWhse, address1, Address2, City, 
State, Zip, AccountingVendorId,StateLicense, DeaLicense, 
RepackLicense, RepackNotificationEmail, OldPackagerid)
SELECT [Packager_Name] ,[HoldingWH]  ,[Shippingaddress1]  ,[ShippingAddress2] ,[ShippingCity]
      ,[ShippingState]      ,[ShippingZip]      ,[ABCMasVendorID],[StateLicense]   ,[DEAlicense]
      ,[RepackLicense]     ,[PkgGroupEmail],UDpackager
  FROM [xsql2].[ATLANTICBIO].[dbo].[UD_Packager]

print 'RepackMachinestypes'
go
insert into [dbo].[RepackMachineTypes] ([MachineName],[MachineDescription],[isActive])
SELECT  [MachineName]
      ,[MachineDescription]
      ,[Active]
      
  FROM [xsql2].[ATLANTICBIO].[dbo].[uds_MachineTypes]
go
print 'RepackMachines'
go



insert into [dbo].[RepackMachines] ([EquipmentId],[EquipmentDescription],[Model],[SerialNumber],[InventoryId],[Owner],[Ctr],[Location],[DateInservice],[Comment],[IsActive],[IsProcessMachine])
SELECT         EquipId,  Equipment, Model, SerialNumber, InventoryID, Owner, Ctr, Location, DateInService, Comments, case Inuseflag
when 'Y' then 1
when 'N' then 0
else 0 end , 
                         case ProccessMachineflag
						 when 'Y' then 1
when 'N' then 0
else 0 end 


FROM            [xsql2].atlanticbio.dbo.UDS_machines

go
--print 'delete Repack lots'
--go

--delete from [dbo].[RepackLotOperations] 
--go
--delete from [dbo].[RepackLots]
go 
print 'Repacklots'
go

insert into [dbo].[RepackLots] ([Lotid],CustomerId,
      [RepackLotStatus],[CustomerPO],[LotDescription],[unitQty]
      ,[Packagetype] ,[PackageQty],[NDC] ,[UPC] ,[Barcode]  ,[MgfNDC] ,[MGFLot]
      ,[MGFLotExpirationDt] ,[TradeName],[GenericName] ,[Strength]  ,[ReceivedDt]
      ,[LotExpirationDt] ,[BeyondUseDt] ,[DateInDoor] ,[QCCount]   ,[RetentionQty]
      ,[QCIncompleteQty]   ,[QCLostQty] ,[QcStartDate] ,[QcEndDate]  ,[PharmChkDt]
      ,[isRefrigerated]  ,[RefrigerateAfterOpen]  ,[InTakeDt]  ,[ExpectedCompletionDt]
      ,[BulkReturnQty]  ,[BulkRtnComment]  ,oldid  )
     
  SELECT  cast([lotid] as nvarchar(15)),(Select Oid from Customer where OldID = [Customer_Id]) ,
  [WFLevel] ,[CustomerPO] ,[LotDesc] ,[UnitQty]  
      ,[packagetype]   ,[PackageQty],rtrim([ndc]),rtrim([UPC]) ,rtrim([Barcode]),rtrim(ndc) ,rtrim([MGFLot])
	   ,[MGFExpirationDt],[TradeName],rtrim([GenericName])   ,rtrim([Strength])  ,[RecievedDt]
,[RepackExpirationdt]     ,[BeyondUseDt]  ,[Dateindoor],[QCCount]   ,[QCRetentionQty]
     ,[QCIncompleteQty] ,[QCLostqty] ,[QCStartDt],[QCEndDate]  ,[pharmckdt]
 ,case  when upper( [Refridgerated]) = 'Y' THEN 1
   Else 0
	  end
    ,case when upper([RefrigAfterOpen]) = 'Y' then 1 else 0 end      ,[IntakeQCdt]   ,[ExpectedCompletionDt]
  ,[Return_qty]     ,rtrim([Return_comment])  ,[lotid]   
  FROM [xsql2].[ATLANTICBIO].[dbo].[uds_LOTS] Where  Barcode like '17856%' and  ([WFLevel] >0 and[WFLevel]< 11)
  go
  print 'Repack Operations'
  go

insert into [dbo].[RepackLotOperations] ([RepackLotOid]
        ,[OperationDesc]      ,[UnitDoseQty]     
      ,[EstimatedQty]      ,[QtyProcessed]      ,[QtyLost]      ,[RetentionQty]
      ,[QtyShipped]          ,[OldID])
   SELECT (select top 1 OID from  [dbo].[RepackLots] where oldid = [LotId])
          ,[OperationDesc]   ,[unitdosesize]      ,[EstQty] ,[QTYShipped]
      ,[QtyProccessed]      ,[Qtylost],[QtyRetention],lotoperationid 
      
  FROM [xsql2].[ATLANTICBIO].[dbo].[uds_lot_operations]

  print 'WorkOrders'
go


 insert into WorkOrders (WoStatus, OriginalNDC, OriginalLot, 
 --DcWhse, FinishProductWhse, 
 NewNdc, OriginalQty, EstimatedFullCaseCount, OriginalNDCSize, OrinalNdcCost, OriginalQtyReturned, OriginalReturnReason, 
 NewNDCSize, NewNDCLot, PackageQty, ExpectedDate, 
 Repackager, 
 NumberOfFullCases, PartialCaseQty, NoPartialCost, FullCaseCost,PartialCost,UnitCost, SubmittedBy, SubmittedDate,Comment, 
 ShipToTracking, ShipDate, ShipBy, QcBy,  QcDate, RecvBy, RecvDate, InvoiceNumber, 
 InvoiceAmt, CreatedBy, CreatedDate, DeletedBy, DeltedDate, DeletedReason,  OldWorkorderId)

select [Status],ic.[OriginalNDC],[OriginalLot],
[NewNDC],[QtytoConvert],[EstimateWillProduce],[OriginalNDCSize],[OriginalCost],[Qty_returned],[Returned_reason],
[NewNDCSize],[UDPackagingLot],[RecvFullCaseQty],[ExpectedCompletionDt],
(select [OID] from [dbo].[RepackPackager] where [OldPackagerid]= ic.[UDPackager]),
[RecvFullCasecount],[RecvINPartialcount],[NopartialCost],[FullCaseCost] , [PartialCaseCost] ,UnitCost,  [Submittedby],[Submitteddt],[Comments],
[Shiptotracking],[ShipToDate],[ShiptoBy],[QualityCheckBy],[QualityCheckDt],[Receivedby],[Receivedt],[Invoicenumber],
[InvoiceAmt],ic.[createdby],[createddt],[DeletedBY],[DeletedDt],[DeletedReason],[Workorderid]

From [xsql2].[ATLANTICBIO].[dbo].[ItemConversions] ic,
dbo.items i,
dbo.items i2
where [Company_cd] = '001'
and i.itemnumber = ic.originalndc and
i2.itemnumber = ic.newndc
go 
update dbo.items  set QtyOnWo = (select sum([OriginalQty])From WorkOrders where [OriginalNDC] = itemnumber and workorders.[WoStatus] <70)
go 
update dbo.items  set QtyOnWo = (select sum([OriginalQty])From WorkOrders where [NewNDC] = itemnumber and workorders.[WoStatus] <70)
Go 

--delete  from dbo.DistributionCenterLicenses
go
print 'DC Licenses'
go 
 insert into    DistributionCenterLicenses   (DistributionCenterId, LicenseTypeCode, State,
  LicenseNumber, ExpirationDate, LicenseFile)
SELECT         (SELECT        TOP (1) DistributionCenter
FROM            DistributionCenterWhse where WhseCode =whse_cd) 
, upper(License_type), State, License_no, Expiration_dt, Licensecopy
FROM            [xsql2].atlanticbio.dbo.Company_Whse_State_License where company_cd = '001' and (License_type  is not null and 
RTRIM(license_type) <>'')

go
print 'Invoice History'
go
insert   CustomerInvoiceHistory (InvoiceNumber, InvoiceDate,  
CustomerID,
 CustomerName,
 SalesRep, 
 CustomerPoNumber,  InvoiceDueDate, DiscountDueDate, TransactionDate, SalesOrderNumber, 
                         FrieghtAmount, BillToName, BillToAddress1, BillToAdress2, BillToAdress3, 
						 BillToCity, BillToState, BillToZip, ShipToAddress1, ShipToAddress2,  ShipToCity,
						  ShipToState,ShipToZip, ShipDate, WhseCode,   OldInvoiceNumber)
 select [InvoiceNumber],[InvoiceDate], 
(select top 1 oid from customer where Customerno = [CustomerNumber] ),[CustomerNameSort],
(select top 1 Salesrepcode from Salesrep where salesrepAccountingCode = [SOSlspersonCode]),
[CustomerPOSort],[InvoiceDueDate],[DiscountDueDate],[TransDate],[SOSalesOrderNumber],
[SOFrghtAmount],[SOBillToName],[SOBillToAddress1],[SOBillToAddress2],[SOBillToAddress3],
[SOBillToCity],[SOBillToState],[SOBillToZipCode],[SOShipToAddress1],[SOShipToAddress2],[SOShipToCity],
[SOShipToState],[SOShipToZipCode],[SOShipDate],
(select top 1 [WhseCode] from DistributionCenterWhse where WhseCode  = [WarehouseCode]),
[InvoiceNumber] 
from [xsql2].mas_001.[dbo].[ARN_InvHistoryHeader] where headerseqnumber = '000'
go
print 'Customer Invoice History Detail'
go

insert into  [CustomerInvoiceHistoryDetails] ([InvoiceNumber] ,[SortOrder] ,[ItemNumber]
      ,[ItemDescription] ,[WareHouseId]  ,[UnitOfMessure]   ,[QtyOrdered]
      ,[QtyShipped]  ,[QtyBackOrdered]    ,[UnitPrice]      ,[UnitCost]
      ,[ProductLine]  ,[ItemLot])

SELECT  (select top 1 oid from [dbo].[CustomerInvoiceHistory] where aro.invoicenumber =  [InvoiceNumber]), [DetailSeqNumber],
(SELECT TOP 1 [ItemNumber] FROM [dbo].[Items] WHERE [AccountingNumber] = SOITEMNUMBER ),
 [SODescription],[SOWhse],[SOUnitOfMeasure],
[SOQtyOrdered],[QtyShipped],[SOQtyBackordered],[SOUnitPrice],[SOUnitCost],
(select tOP 1 oid from [dbo].[ItemProductLine] where [ProductLineCode]= [SOProductLine]),LotSerialNumber
FROM            [xsql2].mas_001.dbo.ARO_InvHistoryDetail aro,
 [xsql2].mas_001.[dbo].[SOE_SOLotSerialHistDetail] soe
where (soe.invoicenumber = aro.invoicenumber and soe.itemnumber = aro.soitemnumber) and headerseqnumber = '000' AND SOITEMNUMBER IS NOT NULL and
(select count(*) from  [dbo].[DistributionCenterWhse] where [WhseCode] = [SOWhse]) >0
go


 update CustomerInvoiceHistory set invoicetotal = (select sum([QtyShipped] * [UnitPrice]) from
  [CustomerInvoiceHistoryDetails]  
  where [CustomerInvoiceHistoryDetails].[InvoiceNumber]  = [CustomerInvoiceHistory].[OId])

go
Update Customer set LastInvoiceDate = (Select Max(Invoicedate) from CustomerInvoiceHistory where Customer.OID = CustomerInvoiceHistory.CustomerID)

go
/****** Script for SelectTopNRows command from SSMS  ******/
print ' customers InvoicePayments'
--delete  from dbo.CustomerInvoicePayments
--go
Insert     dbo.CustomerInvoicePayments   (Oid, TransactionDate, CheckNumber, PyamentType, PaymentReferance, CardHoldername,
 CCExpMonth, ccExpYear, EncryptedCardNumber, ccNumberLastfour, CCcvv2Number,  CreditCardTransactionId,
  TransactionAmount,[CustomerOID], InvoiceNumber)

SELECT newid(),[TransDate],[PymntReferenceCheckNumber] ,0  ,[PymntReferenceCheckNumber] ,[CardholderName]
   ,[ExpirationDateMonth]  ,[ExpirationDateYear] ,Null	,[Last4UnencryptedCreditCardNos],[CreditCardCVV2Number] ,[CreditCardTransactionID]
     ,[TransPymntAmount],
	 (select top 1 OID from dbo.Customer where [CustomerNo] = [CustomerNumber]),
      (select top 1 OID from CustomerInvoiceHistory where [OldInvoiceNumber] = ar6.[InvoiceNumber])
  FROM xsql2.[MAS_001].[dbo].[AR6_TransPaymentHistory] ar6
  where  transactionType = 'P'

go 




print ' customers request'
go 


insert [dbo].[ItemRequest]
( [Oid],[ItemNumber],[RequestStatus],[RequestBy],[RequestDt]
 ,[GoodUntilDt],[RequestQty]   ,[UnitPrice] ,[CustomerPO]
 ,[ItemRequestType] ,[SubsOkay] ,[OnEDL]  ,[BuyPrice]   ,[SearchUntil]
      ,[PedBackToType],[Completed] ,[Completedby] ,[CompletedDate]  ,[Comment]
      ,[RequestSalesOrderDate]  ,[RequestSOEnteredBy] ,[AllOrNothing]    ,[TotalAllocated]
      ,[DrugRequestSwitchReson],oldid ,[Customer])

SELECT        newid(),NDC,REQUESTSTATUS,REQUEST_BY, REQUEST_DATE,
GoodUntildt, REQUEST_QTY, UNIT_PRICE,  PO_NUMBER,
Requesttype, case upper(substituteok) when 'Y' then 1 else 0 end ,  case upper(OnEDL) when 'Y' then 1 else 0 end,   BuyPrice, Searchuntil,
 case upper(Pedback) when 'A' then 0 else 1 end, case upper(Completed) when 'Y' then 1 else 0 end,  CompletedBy,  completedDate, comment,
 Salesorderdt, Salesorderby, case upper(IS_ALLORNOTHING) when 'Y' then 1 else 0 end
 ,TotalAllocated,
   Switchreasoncd, DRUG_REQUEST_ID,
(select top 1 OID from Customer where Oldid = Customer_id)

                      
FROM            xsql2.atlanticbio.dbo.NDC_Requests 
where (select count(*) from items where itemnumber = NDC) > 0

go 


Print 'CustomerCDR'
Go
delete from CustomerCDR
go

insert[dbo].[CustomerCDR](Oid,
      [CallDate] ,[Clid] ,[Src] ,[dst],[dcontext]
      ,[Channel] ,[dstChannel]  ,[LastApp] ,[LastData]   ,[Duration]
      ,[BillSeconds]     ,[Disposition]   ,[AccountCode] ,[Uniqueid]  ,[UserField]
      ,[Mssql_trans]    ,[Customer]    ,[SalesRep])
      SELECT   Newid(),
	  [calldate]  ,[clid]   ,[src]   ,[dst]  ,[dcontext]
      ,[channel]      ,[dstchannel]      ,[lastapp]      ,[lastdata]      ,[duration]
      ,[billsec]      ,[disposition] ,[AccountCode] ,[Uniqueid] ,      [userfield] 
	       ,[MSSQL_Trans]      , (select top 1 oid from customer where OldId = [Customer_id] )    ,
		   (select top 1 Salesrepcode from Salesrep where [SalesRepCode] = [Record_manager])
  FROM [xsql2].[Asterisk].[dbo].[cdr] where calldate >= '1/1/2016'
  
  go
  
  Print ' Recalc last Call date'
  go

  update customer set lastCallDate = (select max(Calldate) from CustomerCDR where Customer.oid = CustomerCDR.Customer)
  go
  update customer set [DEALastVerifiedDate] = (select max(VerificationDate) from 
[dbo].[CustomerLicenseVerifications] where  [dbo].[CustomerLicenseVerifications].customer= customer.oid)
Go 

print 'ItemTraNSACTIONS'
GO
print ' Item Trans it - wo'
Go
insert     ItemTransaction(
 Oid, TransactionType, TransactionDate, ItemNumber,
  Lot,  Warehouse,  Qty, UnitCost,
   UnitPrice)
select newid(),4,[TransactionDate],rb.NDC_code,LotSerialLifoFifoNo,[WarehouseCode],[TransactionQty],[UnitCost],[UnitPrice]

from [xsql2].mas_001.[dbo].[IM5_TransactionDetail] im5,
[xsql2].[Atlanticbio].[dbo].[ZRB_RED_BOOK]rb
where (IM5.[TransactionCode] =  'WO' 
and transactiondate >= '1/1/2015') and ( rb.mas_itemNumber= im5.itemnumber) and (select count(itemnumber) from Items where itemnumber = rb.ndc_code) >0 
and ([WarehouseCode] is not null or ltrim([WarehouseCode]) != '')
go

print ' Item Trans So'
Go

insert     ItemTransaction(
 Oid, TransactionType, TransactionDate, ItemNumber,
  Lot,  Warehouse,  Qty, UnitCost,
   UnitPrice, Customer)
select newid(),3,[TransactionDate],rb.NDC_code,LotSerialLifoFifoNo,[WarehouseCode],[TransactionQty],[UnitCost],[UnitPrice]
,oid
from [xsql2].mas_001.[dbo].[IM5_TransactionDetail] im5,
[xsql2].[Atlanticbio].[dbo].[ZRB_RED_BOOK]rb,
(select OID,customerno from Customer ) c
where (c.customerno = im5.[VendorCustomerNumber]) and
(IM5.[TransactionCode] =  'SO' 
and transactiondate >= '1/1/2015') and ( rb.mas_itemNumber= im5.itemnumber) and (select count(itemnumber) from Items where itemnumber = rb.ndc_code) >0 
go


print ' Item Trans Po'
Go
insert     ItemTransaction(
 Oid, TransactionType, TransactionDate, ItemNumber,
  Lot,  Warehouse,  Qty, UnitCost,
   UnitPrice, Customer)
select newid(),2,[TransactionDate],rb.NDC_code,LotSerialLifoFifoNo,[WarehouseCode],[TransactionQty],[UnitCost],[UnitPrice]
,oid
from [xsql2].mas_001.[dbo].[IM5_TransactionDetail] im5,
[xsql2].[Atlanticbio].[dbo].[ZRB_RED_BOOK]rb,
(select OID,customerno from Customer ) c
where (c.customerno = im5.[VendorCustomerNumber]) and
(IM5.[TransactionCode] =  'PO' 
and transactiondate >= '1/1/2015') and ( rb.mas_itemNumber= im5.itemnumber) and 
(select count(itemnumber) from Items where itemnumber = rb.ndc_code) >0 
go

insert     ItemTransaction( Oid, TransactionType, TransactionDate, ItemNumber, Lot,  Warehouse, 
 Qty, UnitCost, UnitPrice, Vendor)
select newid(),2,
[TransactionDate],rb.NDC_code,LotSerialLifoFifoNo,[WarehouseCode],[TransactionQty],[UnitCost],[UnitPrice],
oid
from [xsql2].mas_001.[dbo].[IM5_TransactionDetail] im5,
[xsql2].[Atlanticbio].[dbo].[ZRB_RED_BOOK]rb,
(select OID,[oldvendorid] from Vendor ) V

where (v.[oldvendorid] = im5.[VendorCustomerNumber]) 
and (IM5.[TransactionCode] =  'PO' and transactiondate >= '1/1/2015')
and  rb.mas_itemNumber =im5.itemnumber  and 
(select count(itemnumber) from Items where itemnumber = rb.ndc_code) >0 
go


--insert     ItemTransaction( Oid, TransactionType, TransactionDate, ItemNumber, Lot,  Warehouse,  Qty, UnitCost, UnitPrice, Vendor, Customer)
--select newid(),
--case [TransactionCode]
--when 'IT' then 1
--when 'SO' then 3
--When 'WO' then 4
--When 'IA' then 0
--When 'PO' then 2
--end,
--[TransactionDate],rb.NDC_code,LotSerialLifoFifoNo,[WarehouseCode],[TransactionQty],[UnitCost],[UnitPrice],
--case [TransactionCode]
--when 'PO' then (select top 1 OID from vendor where oldvendorid = [VendorCustomerNumber])
--else Null
--end,
---case [TransactionCode]
--when 'SO' then (select Top 1 OID from Customer where customerno = [VendorCustomerNumber])
--else Null
---end
--from [xsql2].mas_001.[dbo].[IM5_TransactionDetail] im5,
--[xsql2].[Atlanticbio].[dbo].[ZRB_RED_BOOK]rb
--where im5.itemnumber = rb.mas_itemNumber and IM5.[TransactionCode] in ('WO','SO','IT','PO','IA') and len(itemnumber) > 10 
--and transactiondate >= '1/1/2014'
go 
Print 'App Options'
Go

insert into [dbo].ApplicationOptions 
      ([CompanyName] ,[Address1] ,[address2]   ,[city]
      ,[State],[ZIP]  ,[IsActive] ,[IsSAP] 
      ,[IsQuickbooks] ,[NextPONumber],[NextSONumber],Ref,ThrityDayCustomerSnatchLimit,
	  DefaultSalesCreditLimit ,defaultShippingCd,defaultDistributionWH)
values (
'Atlantic Biologicals Corps/National Apothecary Solutions','10202 Ne 16 Street','','Miami' ,
'Fl','33179',1,0,
0,(SELECT  CAST(MAX(NextPurchaseOrderNumber) as int)+ 1000 FROM        [xsql2].mas_001.dbo.PO0_ParameterFile ) ,1000,1,5,
20000.00,'FEDGR','001')
go 
delete  from SOdetail
go
delete  from SOHeader
go

print  'Open Sales Orders'
go 

insert into      SOHeader (SalesOrderNumber, AccountingSONumber, SalesOrderDate, PoNumber, SOStatus,
 CustomerNumber, DistributionCenterWhse, BillToName, BillToAddress1, BillToAddress2, BillToAddress3,
  BillToCity, BillToState, BillToZip, 
  ShipToName, ShipToAddress, ShipToAddress2, ShipToAddress3, ShipToCity, ShipToState, ShipToZip,
  SalesOrderComments, PickingsheetPrinted, ShippingType,  
                         ImportID)


 select SalesOrderNumber, SalesOrderNumber,SalesOrderDate, CustomerPONumber,1, 
(select top 1 oid from [dbo].[Customer] where [CustomerNo] = CustomerNumber), WhseCode,BillToName, BillToAddress1, BillToAddress2,BillToAddress3, 
 BillToCity, BillToState, BillToZipCode,
 ShipToName, ShipToAddress1, ShipToAddress2, ShipToAddress3, ShipToCity, ShipToState, ShipToZipCode,
 Comment,0,'FEDGR',
SalesOrderNumber
                        
FROM            xsql2.mas_001.dbo.SO1_SOEntryHeader
go
print 'so details'
go 
insert into SODetails ( SalesOrder, Item, UnitPrice, QtyOrdered)
SELECT  (select top 1 oid from soheader where importid = salesordernumber), (select top 1 itemnumber from Items where [AccountingNumber]= itemnumber),
UnitPrice,QtyOrdered

FROM            xsql2.mas_001.dbo.SO2_SOEntryDetailLine 
WHERE        (SalesOrderNumber IS NOT NULL)

go 

       
print  'Repack Items'

go 
insert           RepackItems(NDC, OriginalNDC, Active)
(select ndc_code,OriginalNDC,1
FROM [xsql2].[Atlanticbio].[dbo].ZRB_RED_BOOK rb
WHERE 
(rb.NDC_CODE LIKE '17856%') and RB.active = 1 and RB.showontab = 1  and 
(select Count(*) from Items where items.ItemNumber = rb.NDC_CODE) = 1)


Print 'CustomerNotes'
 go
insert dbo.Customernote (Author,NoteDate,Text,Customers)
select upper(cn.[EMPLOYEE]),cn.[NOTE_DATE],cn.[NOTE],c.oid from [xsql2].atlanticbio.dbo.Customer_notes cn,
dbo.Customer c where c.oldid = cn.Customer_id and cn.company_id = '001' and Note_Date >= '1/1/2015'
 go
Print 'Done'

