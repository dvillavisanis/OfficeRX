;#DropDB RX2_OfficeEasyTest

#Application RX2_Office.Win
#Application RX2_Office.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef RX2_Office.Win

*Action About...
 
*Action OK

#EndIf

#IfDef RX2_Office.Web

*Action Choose Theme(Black Glass)

#EndIf
