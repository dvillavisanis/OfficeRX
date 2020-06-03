;#DropDB RX_OfficeEasyTest

#Application RX_Office.Win
#Application RX_Office.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef RX_Office.Win

*Action About...
 
*Action OK

#EndIf

#IfDef RX_Office.Web

*Action Choose Theme(Black Glass)

#EndIf
