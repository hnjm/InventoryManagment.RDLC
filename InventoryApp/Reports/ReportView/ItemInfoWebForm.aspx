<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemInfoWebForm.aspx.cs" Inherits="InventoryApp.Reports.ReportView.ItemInfoWebForm" %>

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
            <a href="/ItemInformation/Index">Close</a>
        </div>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1345px">
                <LocalReport ReportEmbeddedResource="InventoryApp.Reports.Report.ItemInfoReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="MyDataSetTableAdapters.ItemInformationsTableAdapter"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
