using System;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var path = Server.MapPath(tbPath.Text);
        var sqlToXmlHelper = new SqlDataTableToXmlHelper(tbDataBaseName.Text, tbConnectionString.Text, path);
        sqlToXmlHelper.ExportAllTablesToXml();
        Label1.Text = string.Format("The records were successfully exported to '{0}'", path);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        var path = Server.MapPath(tbPath.Text);
        var sqlToXmlHelper = new SqlDataTableToXmlHelper(tbDataBaseName.Text, tbConnectionString.Text, path);
        var datatable = sqlToXmlHelper.XmlToDataTable(tbTableNameImport.Text);

        GridView1.Visible = true;
        GridView1.DataSource = datatable;
        GridView1.DataBind();
        
        Label1.Text = string.Format("The records from '{0}' data table were successfully imported", tbTableNameImport.Text);
    }
}
