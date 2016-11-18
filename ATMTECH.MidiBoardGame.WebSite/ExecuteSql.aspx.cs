using System;
using System.Data;
using System.Web.Services.Description;
using System.Web.UI;
using ATMTECH.MidiBoardGame.DAO;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public partial class ExecuteSql : Page
    {
        public string ReturnExecuteSql { set { lblResult.Text = value; } }

        protected void btnExecuteSqlClick(object sender, EventArgs e)
        {
            
            if (txtSql.Text.ToLower().IndexOf("select") >= 0)
            {
                DataSet dataSet = new BaseDao().ReturnDataSet(txtSql.Text);
                string html = string.Empty;
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    html = "<table border=0 style='font-size: 11px;' cellspacing='0' cellPadding='0'>";
                    html += "<tr>";
                    foreach (DataColumn dataColumn in dataSet.Tables[0].Columns)
                    {
                        html += "<td style='font-weight:bold;border-bottom:solid 2px black;'>" + dataColumn.ColumnName +
                                "&nbsp;&nbsp;</td>";
                    }
                    html += "</tr>";
                    int rowCount = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        rowCount += 1;
                        html += rowCount % 2 > 0 ? "<tr>" : "<tr style='background-color:lightgray;'>";
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            if (row.ItemArray[i].ToString().Length > 150)
                            {
                                html += "<td>" + row.ItemArray[i].ToString().Substring(1, 149) + "</td>";
                            }
                            else
                            {
                                html += "<td>" + row.ItemArray[i] + "</td>";
                            }

                        }
                        html += "</tr>";
                    }

                    html += "</table>";
                    lblResult.Text = html;
                }
            }
            else
            {
                {
                    {
                       lblResult.Text = new BaseDao().ExecuterSql(txtSql.Text);
                    }
                }
            }



            //Presenter.ExecuteSql(txtSql.Text);
            //ShowMessage(new Message { Description = string.Format("Opération exécuté"), MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
    }
}