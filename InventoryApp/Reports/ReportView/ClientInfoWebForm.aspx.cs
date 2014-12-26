using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace InventoryApp.Reports.ReportView
{
    public partial class ClientInfoWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyDataSetTableAdapters.ClientInformationsTableAdapter ta = new MyDataSetTableAdapters.ClientInformationsTableAdapter();
                MyDataSet.ClientInformationsDataTable dt = new MyDataSet.ClientInformationsDataTable();
                ta.Fill(dt);
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = "Reports/Report/ClientInfo.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}