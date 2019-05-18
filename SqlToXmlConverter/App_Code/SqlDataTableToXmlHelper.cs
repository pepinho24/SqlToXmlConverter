using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for SqlDataTableToXmlHelper
/// </summary>
public class SqlDataTableToXmlHelper
{
    public string DataBaseName { get; set; }
    public string ConnectionString { get; set; }
    public string XmlFolderPath { get; set; }

    public SqlDataTableToXmlHelper(string dbName, string connectionString, string path)
    {
        this.DataBaseName = dbName;
        this.ConnectionString = connectionString;
        this.XmlFolderPath = path;
    }

    public DataTable XmlToDataTable(string tableName, string sourcePath = null)
    {
        if (sourcePath == null)
        {
            sourcePath = Path.Combine(XmlFolderPath, tableName + "DataTable.xml");
        }

        DataTable data = new DataTable() { TableName = tableName };
        data.ReadXml(sourcePath);
        return data;
    }

    public void DataTableToXml(string tableName)
    {
        var path = Path.Combine(this.XmlFolderPath, tableName + "DataTable.xml");
       
        var dt = SqlToDataTable(tableName);
        dt.WriteXml(path, XmlWriteMode.WriteSchema, true);
    }

    public IList<string> ListTables()
    {
        List<string> tables = new List<string>();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[this.ConnectionString].ConnectionString);

        connection.Open();
        try
        {
            //https://stackoverflow.com/questions/3005095/can-i-get-name-of-all-tables-of-sql-server-database-in-c-sharp-application/3005157
            if (connection.State == ConnectionState.Open)
            {
                DataTable dt = connection.GetSchema("Tables");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string) row[2];
                    if ((string) row[3] == "BASE TABLE")
                    {
                        tables.Add(tablename);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }

        return tables;
    }

    public void ExportAllTablesToXml()
    {
        var allTables = ListTables();
        foreach (var tablename in allTables)
        {
            DataTableToXml(tablename);
        }
    }

    public DataTable SqlToDataTable(string tableName)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[this.ConnectionString].ConnectionString);
        SqlCommand command = new SqlCommand(string.Format("SELECT * from [{0}]", tableName));
        command.Connection = connection;
        SqlDataAdapter adapter = new SqlDataAdapter(command);

        DataTable data = new DataTable() { TableName = tableName };
        adapter.Fill(data);

        return data;
    }
}