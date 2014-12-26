<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierInfoWebForm.aspx.cs" Inherits="InventoryApp.Reports.ReportView.SupplierInfoWebForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>




<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Title of the document</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="float: right">
            <a href="/SupplierInformation/Index">Close</a>
        </div>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1345px">
                <LocalReport ReportEmbeddedResource="InventoryApp.Reports.Report.SupplierInfoReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="InventoryApp.Reports.MyDataSetTableAdapters.SupplierInformationsTableAdapter"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>


