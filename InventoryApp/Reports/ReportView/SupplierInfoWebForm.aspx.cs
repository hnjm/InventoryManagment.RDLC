using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryApp.Reports.MyDataSetTableAdapters;
using Microsoft.Reporting.WebForms;

namespace InventoryApp.Reports.ReportView
{
    public partial class SupplierInfoWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            
                SupplierInformationsTableAdapter ta =new SupplierInformationsTableAdapter();
                MyDataSet.SupplierInformationsDataTable dt = new MyDataSet.SupplierInformationsDataTable();
                ta.Fill(dt);
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = "Reports/Report/SupplierInfoReport.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}