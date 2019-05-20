# SqlToXmlConverter

This is a helper WebForms site project that allows writing/reading *SQL tables* to *XML files* for easy use. It is applicable for simplifying complex projects and mocking the data layer for easy population of data.

The [App_Code/SqlDataTableToXmlHelper.cs](SqlToXmlConverter/App_Code/SqlDataTableToXmlHelper.cs) file contains the `SqlDataTableToXmlHelper` class that can be used to 
 - Get all Table names in a given DataBase
 - Populate an SQL table to a DataTable object
 - Export one or all DataTable objects to .XML file
 - Populate DataTable object from an existing .XML file
 

The attachment has all the Tables of the `Nortwhind` database already populated as XML files. 
 
The [Default.aspx](SqlToXmlConverter/SqlToXmlConverter/Default.aspx) page provides a UserInterface for easy configuration of the connection strings and an example how to load data from XML file and visualizing it via `asp:GridView` control.
