using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace InventoryApp.Reports.ReportView
{
    public partial class PriceSetupWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyDataSetTableAdapters.PriceSetupsTableAdapter ta = new MyDataSetTableAdapters.PriceSetupsTableAdapter();
                MyDataSet.PriceSetupsDataTable dt = new MyDataSet.PriceSetupsDataTable();
                ta.Fill(dt);
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = "Reports/Report/PriceSetupReport.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }

        }
    }
}