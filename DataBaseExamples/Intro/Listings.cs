using System;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.OleDb;
using System.Data.OracleClient;

namespace DataBaseExamples.Intro
{
    #region SimpleConnection
    class SqlServerProvider
    {
        
        public static void SimpleConnectionAndQuery()
        {
            // Set up connection string
            string connString = @"
            server = (local)\MYSERVER;
            integrated security = true;
            database = northwind
         ";

            // Set up query string
            string sql = @"
            select
               *
            from
               employees
         ";

            // Declare connection and data reader variables
            SqlConnection conn = null;
            SqlDataReader reader = null;

            try
            {
                // Open connection
                conn = new SqlConnection(connString);
                conn.Open();

                // Execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                // Display output header
                Console.WriteLine(
                   "This program demonstrates the use of "
                 + "the SQL Server Data Provider."
                );
                Console.WriteLine(
                   "Querying database {0} with query {1}\n"
                 , conn.Database
                 , cmd.CommandText
                );
                Console.WriteLine("First Name\tLast Name\n");

                // Process the result set
                while (reader.Read())
                {
                    Console.WriteLine(
                       "{0} | {1}"
                     , reader["FirstName"].ToString().PadLeft(10)
                     , reader[1].ToString().PadLeft(10)
                    );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // Close connection
                reader.Close();
                conn.Close();
            }
        }

    }
    #endregion

    #region ODBCProvider
    class OdbcProvider
    {
        public static void ODBCConnection()
        {
            // Set up connection string
            string connString = @"dsn=Northwind";

            // Set up query string
            string sql = @"
            select
               *
            from
               employees
         ";

            // Declare connection and data reader variables
            OdbcConnection conn = null;
            OdbcDataReader reader = null;

            try
            {
                // Open connection
                conn = new OdbcConnection(connString);
                conn.Open();

                // Execute the query
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                reader = cmd.ExecuteReader();

                // Display output header
                Console.WriteLine(
                   "This program demonstrates the use of "
                 + "the ODBC Data Provider."
                );
                Console.WriteLine(
                   "Querying database {0} with query {1}\n"
                 , conn.Database
                 , cmd.CommandText
                );
                Console.WriteLine("First Name\tLast Name\n");

                // Process the result set
                while (reader.Read())
                {
                    Console.WriteLine(
                       "{0} | {1}"
                     , reader["FirstName"].ToString().PadLeft(10)
                     , reader[1].ToString().PadLeft(10)
                    );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // Close connection
                reader.Close();
                conn.Close();
            }
        }
    }
    #endregion

    #region ConnectionDisplay
    class ConnectionDisplay
    {
        public static void DisplayConnectionProperties()
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"
            server = (local)\MYSERVER;
            integrated security = true;
         ");

            try
            {
                // Open connection
                conn.Open();
                Console.WriteLine("Connection opened.");

                // Display connection properties
                Console.WriteLine("Connection Properties:");
                Console.WriteLine(
                   "\tConnection String: {0}",
                   conn.ConnectionString);
                Console.WriteLine(
                   "\tDatabase: {0}",
                   conn.Database);
                Console.WriteLine(
                   "\tDataSource: {0}",
                   conn.DataSource);
                Console.WriteLine(
                   "\tServerVersion: {0}",
                   conn.ServerVersion);
                Console.WriteLine(
                   "\tState: {0}",
                   conn.State);
                Console.WriteLine(
                   "\tWorkstationId: {0}",
                   conn.WorkstationId);
            }
            catch (SqlException e)
            {
                // Display error
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // Close connection
                conn.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
    #endregion

    #region CommandUsage
    class CommandUsage
    {
        #region CommandDefaultConstructor
         public static void CommandDefaultConstructor()
         {
             // create connection
             SqlConnection conn = new SqlConnection(@"
                server = (local)\MYSERVER;
                integrated security = true;
                database = northwind
             ");

             // create command
             SqlCommand cmd = new SqlCommand();
             Console.WriteLine("Command created with default constructor.");

             try
             {
                // open connection
                conn.Open();
             }
             catch (SqlException ex)
             {
                Console.WriteLine(ex.ToString());
             }
             finally
             {
                conn.Close();
                Console.WriteLine("Connection Closed.");
             }
        }
        #endregion       

        #region CommandWithTextAndConnectionExecutesScalar
        public static void CommandWithTextAndConnectionExecutesScalar()
        {
            // create connection
            SqlConnection conn = new SqlConnection(@"
            server = (local)\MYSERVER;
            integrated security = true;
            database = northwind
         ");

            // create command (with both text and connection)
            string sql = @"
            select
               count(*)
            from
               employees
         ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            Console.WriteLine("Command created and connected.");

            try
            {
                // open connection
                conn.Open();

                // execute query
                Console.WriteLine(
                   "Number of Employees is {0}"
                 , cmd.ExecuteScalar()
                );
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed.");
            }
        }
        #endregion

        #region SimpleReader
        public static void SimpleReader()
        {
            // create connection
            SqlConnection conn = new SqlConnection(@"
            server = (local)\MYSERVER;
            integrated security = true;
            database = northwind
         ");

            // create command (with both text and connection)
            string sql = @"
            select
               firstname,
               lastname
            from
               employees
         ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            Console.WriteLine("Command created and connected.");

            try
            {
                // open connection
                conn.Open();

                // execute query
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("Employee name: {0} {1}",
                       rdr.GetValue(0),
                       rdr.GetValue(1)
                    );
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed.");
            }
        }
        #endregion

        #region ExecuteNonQuery
        public static void ExecuteNonQuery()
        {
            // create connection
            SqlConnection conn = new SqlConnection(@"
            server = (local)\MYSERVER;
            integrated security = true;
            database = northwind
         ");

            // define scalar query
            string sqlqry = @"
            select
               count(*)
            from
               employees
         ";

            // define insert statement
            string sqlins = @"
            insert into employees
            (
               firstname,
               lastname
            )
            values('Zachariah', 'Zinn')
         ";

            // define delete statement
            string sqldel = @"
            delete from employees
            where
               firstname = 'Zachariah'
               and
               lastname = 'Zinn'
         ";

            // create commands
            SqlCommand cmdqry = new SqlCommand(sqlqry, conn);
            SqlCommand cmdnon = new SqlCommand(sqlins, conn);

            try
            {
                // open connection
                conn.Open();

                // execute query to get number of employees
                Console.WriteLine(
                   "Before INSERT: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );

                // execute nonquery to insert an employee
                Console.WriteLine(
                   "Executing statement {0}"
                 , cmdnon.CommandText
                );
                cmdnon.ExecuteNonQuery();
                Console.WriteLine(
                   "After INSERT: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );

                // execute nonquery to delete an employee
                cmdnon.CommandText = sqldel;
                Console.WriteLine(
                   "Executing statement {0}"
                 , cmdnon.CommandText
                );
                cmdnon.ExecuteNonQuery();
                Console.WriteLine(
                   "After DELETE: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed.");
            }
        }
        #endregion

        #region CommandParameters
        public static void CommandParameters()
        {
             // set up rudimentary data
             string fname = "Zachariah";
             string lname = "Zinn";

             // create connection
             SqlConnection conn = new SqlConnection(@"
                server = (local)\MYSERVER;
                integrated security = true;
                database = northwind
             ");

             // define scalar query
             string sqlqry = @"
                select
                   count(*)
                from
                   employees
             ";

             // define insert statement
             string sqlins = @"
                insert into employees
                (
                   firstname,
                   lastname
                )
                values(@fname, @lname)
             ";

             // define delete statement
             string sqldel = @"
                delete from employees
                where
                   firstname = @fname
                   and
                   lastname = @lname
             ";

             // create commands
             SqlCommand cmdqry = new SqlCommand(sqlqry, conn);
             SqlCommand cmdnon = new SqlCommand(sqlins, conn);

             // add parameters to the command for statements
             cmdnon.Parameters.Add("@fname", SqlDbType.NVarChar, 10);
             cmdnon.Parameters.Add("@lname", SqlDbType.NVarChar, 20);

             try
             {
                // open connection
                conn.Open();

                 Console.WriteLine("Executing parameterized queries");
                // execute query to get number of employees
                Console.WriteLine(
                   "Before INSERT: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );

                // execute nonquery to insert an employee
                cmdnon.Parameters["@fname"].Value = fname;
                cmdnon.Parameters["@lname"].Value = lname;
                Console.WriteLine(
                   "Executing statement {0}"
                 , cmdnon.CommandText
                );
                cmdnon.ExecuteNonQuery();
                Console.WriteLine(
                   "After INSERT: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );

                // execute nonquery to delete an employee
                cmdnon.CommandText = sqldel;
                Console.WriteLine(
                   "Executing statement {0}"
                 , cmdnon.CommandText
                );
                cmdnon.ExecuteNonQuery();
                Console.WriteLine(
                   "After DELETE: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );
             }
             catch (SqlException ex)
             {
                Console.WriteLine(ex.ToString());
             }
             finally
             {
                conn.Close();
                Console.WriteLine("Connection Closed.");
             }
        }
        #endregion
    }   
    #endregion

    #region ReaderUsage
    class ReaderUsage
    {
        #region Looper
        public static void Looper()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               contactname
            from
               customers
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // open connection
                conn.Open();

                // create command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // create data reader
                SqlDataReader rdr = cmd.ExecuteReader();

                // loop through result set
                while (rdr.Read())
                {
                    // print one row at a time
                    Console.WriteLine("{0}", rdr[0]);
                }

                // close data reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                //close connection
                conn.Close();
            }
        }
        #endregion

        #region OrdinalIndexer
        public static void OrdinalIndexer()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               companyname,
               contactname
            from
               customers
            where
               contactname like 'M%'
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // Open connection
                conn.Open();

                // create command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // create data reader
                SqlDataReader rdr = cmd.ExecuteReader();

                // print headings
                Console.WriteLine("\t{0}   {1}",
                   "Company Name".PadRight(25),
                   "Contact Name".PadRight(20));

                Console.WriteLine("\t{0}   {1}",
                   "============".PadRight(25),
                   "============".PadRight(20));

                // loop through result set
                while (rdr.Read())
                {
                    Console.WriteLine(" {0} | {1}",
                       rdr[0].ToString().PadLeft(25),
                       rdr[1].ToString().PadLeft(20));
                }

                // close reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region TypedAccessors
        public static void TypedAccessors()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               productname,
               unitprice,
               unitsinstock,
               discontinued
            from
               products
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // open connection
                conn.Open();

                // create command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // create data reader
                SqlDataReader rdr = cmd.ExecuteReader();

                // fetch data
                while (rdr.Read())
                {
                    Console.WriteLine(
                       "{0}\t {1}\t\t {2}\t {3}",
                        // nvarchar
                       rdr.GetString(0).PadRight(30),
                        // money
                       rdr.GetDecimal(1),
                        // smallint
                       rdr.GetInt16(2),
                        // bit
                       rdr.GetBoolean(3));
                }

                // close data reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region DataReaderInfo
        public static void DataReaderInfo()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               contactname,
               contacttitle
            from
               customers
            where
               contactname like 'M%'
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader rdr = cmd.ExecuteReader();

                // get column names
                Console.WriteLine(
                   "Column Name:\t{0} {1}",
                   rdr.GetName(0).PadRight(25),
                   rdr.GetName(1));

                // get column data types
                Console.WriteLine(
                   "Data Type:\t{0} {1}",
                   rdr.GetDataTypeName(0).PadRight(25),
                   rdr.GetDataTypeName(1));

                Console.WriteLine();

                while (rdr.Read())
                {
                    // get column values for all rows
                    Console.WriteLine(
                       "\t\t{0} {1}",
                       rdr.GetString(0).ToString().PadRight(25),
                       rdr.GetString(1));
                }

                // get number of columns
                Console.WriteLine();
                Console.WriteLine(
                   "Number of columns in a row: {0}",
                   rdr.FieldCount);

                // get info about each column 
                Console.WriteLine(
                   "'{0}' is at index {1} " +
                   "and its type is: {2}",
                   rdr.GetName(0),
                   rdr.GetOrdinal("contactname"),
                   rdr.GetFieldType(0));

                Console.WriteLine(
                   "'{0}' is at index {1} " +
                   "and its type is: {2}",
                   rdr.GetName(1),
                   rdr.GetOrdinal("contacttitle"),
                   rdr.GetFieldType(1));

                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region SchemaTable
        public static void SchemaTable()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query 
            string sql = @"
            select
               *
            from
               employees
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                // store Employees schema in a data table
                DataTable schema = rdr.GetSchemaTable();

                // display info from each row in the data table.
                // each row describes a column in the database table.
                foreach (DataRow row in schema.Rows)
                {
                    foreach (DataColumn col in schema.Columns)
                        Console.WriteLine(col.ColumnName + " = " + row[col]);
                    Console.WriteLine("----------------");
                }

                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region MultiPleResults
        public static void MultiPleResults()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query 1
            string sql1 = @"
            select
               companyname,
               contactname
            from
               customers
            where
               companyname like 'A%'
         ";

            // query 2
            string sql2 = @"
            select
               firstname,
               lastname
            from
               employees
         ";

            // combine queries
            string sql = sql1 + sql2;

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // open connection
                conn.Open();

                // create command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // create data reader
                SqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine("Multiple queries, same reader ".PadLeft(60, '='));
                // loop through result sets
                do
                {
                    while (rdr.Read())
                    {
                        // Print one row at a time
                        Console.WriteLine("{0} : {1}", rdr[0], rdr[1]);
                    }
                    Console.WriteLine("".PadLeft(60, '='));
                }
                while (rdr.NextResult());

                // close data reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                // Close connection
                conn.Close();
            }
        }
        #endregion

    }
    #endregion

    #region DataSetUsage
    class DatasetUsage
    {
        #region PopulateDataSet
        public static void PopulateDataSet()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               productname,
               unitprice
            from
               products
            where
               unitprice < 20
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // open connection
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                // create dataset
                DataSet ds = new DataSet();

                // fill dataset
                da.Fill(ds, "products");

                // get data table
                DataTable dt = ds.Tables["products"];

                // display data
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                        Console.WriteLine(row[col]);
                    Console.WriteLine("".PadLeft(20, '='));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region FilterSort
        public static void FilterSort()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";
            

            // query 1
            string sql1 = @"
            select
               *
            from
               customers
         ";

            // query 2
            string sql2 = @"
            select
               *
            from
               products
            where
               unitprice < 10
         ";

            // combine queries
            string sql = sql1 + sql2;

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, conn);

                // create and fill data set
                DataSet ds = new DataSet();
                da.Fill(ds, "customers");

                // get the data tables collection
                DataTableCollection dtc = ds.Tables;

                // display data from first data table
                //
                // display output header
                Console.WriteLine("FilterSort Example");
                Console.WriteLine("Results from Customers table:");
                Console.WriteLine(
                   "CompanyName".PadRight(20) +
                   "ContactName".PadLeft(23) + "\n");

                // set display filter
                string fl = "country = 'Germany'";

                // set sort
                string srt = "companyname asc";

                // display filtered and sorted data
                foreach (DataRow row in dtc["customers"].Select(fl, srt))
                {
                    Console.WriteLine(
                       "{0}\t{1}",
                       row["CompanyName"].ToString().PadRight(25),
                       row["ContactName"]);
                }

                // display data from second data table
                //
                // display output header
                Console.WriteLine("\n----------------------------");
                Console.WriteLine("Results from Products table:");
                Console.WriteLine(
                   "ProductName".PadRight(20) +
                   "UnitPrice".PadLeft(21) + "\n");

                // display data
                foreach (DataRow row in dtc[1].Rows)
                {
                    Console.WriteLine("{0}\t{1}",
                       row["productname"].ToString().PadRight(25),
                       row["unitprice"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region DataViewUsage
        public static void DataViewUsage()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               contactname,
               country
            from
               customers
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // Create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, conn);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "customers");

                // get data table reference
                DataTable dt = ds.Tables["customers"];

                // create data view
                DataView dv = new DataView(
                   dt,
                   "country = 'Germany'",
                   "country",
                   DataViewRowState.CurrentRows
                );
                Console.WriteLine("Example using DataView".PadLeft(40, '*').PadRight(60, '*'));
                // display data from data view
                foreach (DataRowView drv in dv)
                {
                    for (int i = 0; i < dv.Table.Columns.Count; i++)
                        Console.Write(drv[i] + "\t");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region PersistDataSetUpdates
        public static void PersistDataSetUpdates()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string qry = @"
            select
               *
            from
               employees
            where
               country = 'UK'
         ";

            // SQL to update employees
            string upd = @"
            update employees   
            set
               city = @city
            where
                employeeid = @employeeid
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {

                Console.WriteLine("Persisting DataSet Chances Example".PadLeft(50, '*').PadRight(70, '*'));
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "employees");

                // get data table reference
                DataTable dt = ds.Tables["employees"];


                // List contents
                Console.WriteLine("Before DataSet Update");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                     "{0} {1} {2}",
                     row["firstname"].ToString().PadRight(15),
                     row["lastname"].ToString().PadLeft(25),
                     row["city"]);
                  
                }
                


                // modify city in first row
                string orig = (string)dt.Rows[0]["city"];
                if (orig == "Wilmington")
                    orig = "Not Wilmington";
                else 
                    orig = "Wilmington";
                dt.Rows[0]["city"] = orig;



                Console.WriteLine("After DataSet Update");
                // display rows
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                       "{0} {1} {2}",
                       row["firstname"].ToString().PadRight(15),
                       row["lastname"].ToString().PadLeft(25),
                       row["city"]);
                }

                // update Employees
                //
                // create command
                SqlCommand cmd = new SqlCommand(upd, conn);
                //
                // map parameters
                //
                // City
                cmd.Parameters.Add(
                   "@city",
                   SqlDbType.NVarChar,
                   15,
                   "city");
                //
                // EmployeeID
                SqlParameter parm =
                   cmd.Parameters.Add(
                      "@employeeid",
                      SqlDbType.Int,
                      4,
                      "employeeid");
                parm.SourceVersion = DataRowVersion.Original;
                //
                // Update database
                da.UpdateCommand = cmd;
                da.Update(ds, "employees");


                // now read again from DB, just to make sure
                // create and fill dataset
                ds = new DataSet();
                da.Fill(ds, "employees");

                // get data table reference
                dt = ds.Tables["employees"];


                // List contents
                Console.WriteLine("Read again from DB");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                     "{0} {1} {2}",
                     row["firstname"].ToString().PadRight(15),
                     row["lastname"].ToString().PadLeft(25),
                     row["city"]);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region PersistInserts
        public static void PersistInserts()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string qry = @"
            select
               *
            from
               employees
            where
               country = 'UK'
         ";

            // SQL to insert employees
            string ins = @"
            insert into employees
            (
               firstname,
               lastname,
               titleofcourtesy,
               city,
               country
            )
            values
            (
               @firstname,
               @lastname,
               @titleofcourtesy,
               @city,
               @country
            )
         ";

            // Create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Persisting DataSet Inserts Example".PadLeft(50, '*').PadRight(70, '*'));
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "employees");

                // get data table reference
                DataTable dt = ds.Tables["employees"];

                // add a row
                DataRow newRow = dt.NewRow();
                newRow["firstname"] = "Roy";
                newRow["lastname"] = "Beatty";
                newRow["titleofcourtesy"] = "Sir";
                newRow["city"] = "Birmingham";
                newRow["country"] = "UK";
                dt.Rows.Add(newRow);

                // display rows
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                       "{0} {1} {2}",
                       row["firstname"].ToString().PadRight(15),
                       row["lastname"].ToString().PadLeft(25),
                       row["city"]);
                }

                // insert employees
                //
                // create command
                SqlCommand cmd = new SqlCommand(ins, conn);
                //
                // map parameters
                cmd.Parameters.Add(
                   "@firstname",
                   SqlDbType.NVarChar,
                   10,
                   "firstname");
                cmd.Parameters.Add(
                   "@lastname",
                   SqlDbType.NVarChar,
                   20,
                   "lastname");
                cmd.Parameters.Add(
                   "@titleofcourtesy",
                   SqlDbType.NVarChar,
                   25,
                   "titleofcourtesy");
                cmd.Parameters.Add(
                   "@city",
                   SqlDbType.NVarChar,
                   15,
                   "city");
                cmd.Parameters.Add(
                   "@country",
                   SqlDbType.NVarChar,
                   15,
                   "country");
                //
                // insert employees
                da.InsertCommand = cmd;
                da.Update(ds, "employees");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region PersistDeletes
        public static void PersistDeletes()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string qry = @"
            select
               *
            from
               employees
            where
               country = 'UK'
         ";

            // SQL to delete employees
            string del = @"
            delete from employees
            where
               employeeid = @employeeid
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Persisting DataSet Deletes Example".PadLeft(50, '*').PadRight(70, '*'));
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "employees");

                // get data table reference
                DataTable dt = ds.Tables["employees"];

                // delete employees
                //
                // create command
                SqlCommand cmd = new SqlCommand(del, conn);
                //
                // map parameters
                cmd.Parameters.Add(
                   "@employeeid",
                   SqlDbType.Int,
                   4,
                   "employeeid");
                //
                // select employees
                string filt = @"
                  firstname = 'Roy'
                  and
                  lastname = 'Beatty'
            ";
                //
                // delete employees
                foreach (DataRow row in dt.Select(filt))
                {
                    row.Delete();
                }
                da.DeleteCommand = cmd;
                da.Update(ds, "employees");

                // display rows
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                       "{0} {1} {2}",
                       row["firstname"].ToString().PadRight(15),
                       row["lastname"].ToString().PadLeft(25),
                       row["city"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region PersistAddWithBuilder
        public static void PersistAddWithBuilder()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string qry = @"
            select
               *
            from
               employees
            where
               country = 'UK'
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Persisting DataSet Inserts with Builder Example".PadLeft(50, '*').PadRight(70, '*'));
               
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // create command builder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "employees");

                // get data table reference
                DataTable dt = ds.Tables["employees"];

                // add a row
                DataRow newRow = dt.NewRow();
                newRow["firstname"] = "Roy";
                newRow["lastname"] = "Beatty";
                newRow["titleofcourtesy"] = "Sir";
                newRow["city"] = "Birmingham";
                newRow["country"] = "UK";
                dt.Rows.Add(newRow);

                // display rows
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                       "{0} {1} {2}",
                       row["firstname"].ToString().PadRight(15),
                       row["lastname"].ToString().PadLeft(25),
                       row["city"]);
                }

                // insert employees
                da.Update(ds, "employees");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region WriteXML
        public static void WriteXML()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string qry = @"
            select
               productname,
               unitprice
            from
               products
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // open connection
                conn.Open();

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "products");

                // extract dataset to XML file
                ds.WriteXml("productstable.xml"
                );
                Console.WriteLine("Write xml to productstable.xml".PadLeft(50, '*').PadRight(70, '*'));
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

        #region PopulateDataTable
        public static void PopulateDataTable()
        {
            // connection string
            string connString = @"
            server = (local)\myserver;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               productname,
               unitprice
            from
               products
            where
               unitprice < 20
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Populate DataTable Example".PadLeft(50, '*').PadRight(70, '*'));
       
                // open connection
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                // create data table
                DataTable dt = new DataTable();

                // fill data table
                da.Fill(dt);

                // display data
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                        Console.WriteLine(row[col]);
                    Console.WriteLine("".PadLeft(20, '='));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }
        #endregion

    }
    #endregion

    #region StoredProcedures
    class StoredProcedures
    {
        #region sp_Select_All_Employees
        /**  create procedure sp_Select_All_Employees
            *     as
            *   select
            *     employeeid,
            *     firstname,
            *     lastname
            *   from
            *     employees
            **/
        #endregion

        #region Call_sp_Select_All_Employees
        public static void Call_sp_Select_All_Employees()
        {

            // create connection
            SqlConnection conn = new SqlConnection(@"
                server = (local)\myserver;
                integrated security = true;
                database = northwind
             ");

            try
            {
                Console.WriteLine("calling stored procedure sp_Select_All_Employees".PadLeft(50, '*').PadRight(70, '*'));
           
                // open connection
                conn.Open();

                // create command
                SqlCommand cmd = conn.CreateCommand();

                // specify stored procedure to execute
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_select_all_employees";

                // execute command
                SqlDataReader rdr = cmd.ExecuteReader();

                // Process the result set
                while (rdr.Read())
                {
                    Console.WriteLine(
                       "{0} {1} {2}"
                     , rdr[0].ToString().PadRight(5)
                     , rdr[1].ToString()
                     , rdr[2].ToString()
                    );
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region procedure sp_Orders_By_EmployeeId
        /**  create procedure sp_Orders_By_EmployeeId
         *    @employeeid int
         *    as
         *    select
         *       orderid,
         *        customerid
         *    from
         *        orders
         *    where
         *    employeeid = @employeeid
         * */
        #endregion

        #region Call_procedure sp_Orders_By_EmployeeId
        public static void Call_procedure_sp_Orders_By_EmployeeId()
        {

             // create connection
             SqlConnection conn = new SqlConnection(@"
                server = (local)\myserver;
                integrated security = true;
                database = northwind
             ");

             try
             {
                 Console.WriteLine("calling stored procedure sp_Orders_By_EmployeeId".PadLeft(50, '*').PadRight(70, '*'));
           
                // open connection
                conn.Open();

                // create command
                SqlCommand cmd = conn.CreateCommand();

                // specify stored procedure to execute
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_orders_by_employeeid";

                // create input parameter
                SqlParameter inparm = cmd.Parameters.Add(
                   "@employeeid"
                 , SqlDbType.Int
                );
                inparm.Direction = ParameterDirection.Input;
                inparm.Value = 2;

                // create output parameter
                SqlParameter ouparm = cmd.Parameters.Add(
                   "@ordercount"
                 , SqlDbType.Int
                );
                ouparm.Direction = ParameterDirection.Output;

                // create return value parameter
                SqlParameter retval = cmd.Parameters.Add(
                   "return_value"
                 , SqlDbType.Int
                );
                retval.Direction = ParameterDirection.ReturnValue;

                // execute command
                SqlDataReader rdr = cmd.ExecuteReader();

                // Process the result set
                while (rdr.Read())
                {
                   Console.WriteLine(
                      "{0} {1}"
                    , rdr[0].ToString().PadRight(5)
                    , rdr[1].ToString()
                   );
                }
                rdr.Close();

                // display output parameter value
                Console.WriteLine(
                   "The output parameter value is {0}"
                 , cmd.Parameters["@ordercount"].Value
                );

                // display return value
                Console.WriteLine(
                   "The return value is {0}"
                 , cmd.Parameters["return_value"].Value
                );
             }
             catch (SqlException ex)
             {
                Console.WriteLine(ex.ToString());
             }
             finally
             {
                conn.Close();
             }
          }
          #endregion

    }
    #endregion

    #region ConnectionFactory

        #region SimpleFactory
        enum DataProvider
        { SqlServer, OleDb, Odbc, Oracle }

         class ConnectionFactory
        {
            public static void ConnectionFactoryTest()
            {
                Console.WriteLine("********************************************************");
                Console.WriteLine("***** This App does not do anything really useful. *****");
                Console.WriteLine("***** However it illustrates how one might build a *****");
                Console.WriteLine("*****     custom ADO.NET data provider factory     *****");
                Console.WriteLine("********************************************************\n");

                // Read the DataProvider key.
                string dpStr = ConfigurationManager.AppSettings["provider"];
                DataProvider dp = (DataProvider)Enum.Parse(typeof(DataProvider), dpStr);

                // Read the connection string.
                string cnStr = ConfigurationManager.AppSettings["cnStr"];

                // Get a specific connection.
                IDbConnection myCn = GetConnection(dp);
                myCn.ConnectionString = cnStr;

                // Now open it via our helper function.
                OpenConnection(myCn);

                Console.WriteLine("Connection created");

                // Use it and close when finished.
                myCn.Close();
                Console.WriteLine("Connection closed");
            }

            #region Helper methods
            static IDbConnection GetConnection(DataProvider dp)
            {
                IDbConnection conn = null;
                switch (dp)
                {
                    case DataProvider.SqlServer:
                        conn = new SqlConnection();
                        break;
                    case DataProvider.OleDb:
                        conn = new OleDbConnection();
                        break;
                    case DataProvider.Odbc:
                        conn = new OdbcConnection();
                        break;
                    case DataProvider.Oracle:
                        conn = new OracleConnection();
                        break;
                }
                return conn;
            }

            public static void OpenConnection(IDbConnection cn)
            {
                // Open the incoming connection for the caller.
                cn.Open();
            }
            #endregion
        }

        #endregion

        #region DataProviderFactory
        class DataProviderFactory
        {
            public static void DataProviderFactoryTest()
            {
                #region OleDBProvider
                Console.WriteLine("***** Data Provider Factories: using OleDB *****\n");
                // Get Connection string / provider from *.config.
                string oleDp =
                  ConfigurationManager.AppSettings["fullOLEProvider"];
                string oleCnStr =
                  ConfigurationManager.ConnectionStrings["OleDbProviderNorthwind"].ConnectionString;
                
                // Make the factory provider.
                DbProviderFactory df = DbProviderFactories.GetFactory(oleDp);

                // Now make connection object.
                DbConnection cn = df.CreateConnection();
                Console.WriteLine("Your connection object is a: {0}", cn.GetType().FullName);
                cn.ConnectionString = oleCnStr;
                cn.Open();

                // Make command object.
                DbCommand cmd = df.CreateCommand();
                Console.WriteLine("Your command object is a: {0}", cmd.GetType().FullName);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Employees";

                // Print out data with data reader.
                DbDataReader dr =
                  cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Console.WriteLine("Your data reader object is a: {0}", dr.GetType().FullName);

                Console.WriteLine("\n***** Employees *****");

                while (dr.Read())
                    Console.WriteLine("-> {0}, {1}", dr[0], dr[1]);
                dr.Close();
                #endregion

                #region SQLDataProvider

                Console.WriteLine("***** Data Provider Factories: using SQL Client *****\n");
                // Get Connection string / provider from *.config.
                string sqlDp =
                  ConfigurationManager.AppSettings["fullSqlProvider"];
                string sqlCnStr =
                  ConfigurationManager.ConnectionStrings["SqlDBProviderNorthwind"].ConnectionString;

                // Make the factory provider.
                df = DbProviderFactories.GetFactory(sqlDp);

                // Now make connection object.
                cn = df.CreateConnection();
                Console.WriteLine("Your connection object is a: {0}", cn.GetType().FullName);
                cn.ConnectionString = sqlCnStr;
                cn.Open();

                // Make command object.
                cmd = df.CreateCommand();
                Console.WriteLine("Your command object is a: {0}", cmd.GetType().FullName);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Employees";

                // Print out data with data reader.
                dr =
                  cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Console.WriteLine("Your data reader object is a: {0}", dr.GetType().FullName);

                Console.WriteLine("\n***** Employees *****");

                while (dr.Read())
                    Console.WriteLine("-> {0}, {1}", dr[0], dr[1]);
                dr.Close();

                #endregion
            }
        }



        #endregion

    #endregion


        class Test
    {
        static void Main()
        {
             SqlServerProvider.SimpleConnectionAndQuery();
             OdbcProvider.ODBCConnection();
             ConnectionDisplay.DisplayConnectionProperties();
             CommandUsage.CommandDefaultConstructor();
             CommandUsage.CommandWithTextAndConnectionExecutesScalar();
             CommandUsage.SimpleReader();
             CommandUsage.ExecuteNonQuery();
             CommandUsage.CommandParameters();
             ReaderUsage.Looper();
             ReaderUsage.OrdinalIndexer();
             ReaderUsage.TypedAccessors();
             ReaderUsage.DataReaderInfo();
             ReaderUsage.SchemaTable();
             ReaderUsage.MultiPleResults();
             DatasetUsage.PopulateDataSet();
             DatasetUsage.FilterSort();
             DatasetUsage.DataViewUsage();
             DatasetUsage.PersistDataSetUpdates();
             DatasetUsage.PersistInserts();
             DatasetUsage.PersistDeletes();
             DatasetUsage.PersistAddWithBuilder();
             DatasetUsage.WriteXML();
             DatasetUsage.PopulateDataTable();
             StoredProcedures.Call_sp_Select_All_Employees();
             StoredProcedures.Call_procedure_sp_Orders_By_EmployeeId();
             ConnectionFactory.ConnectionFactoryTest(); 
             DataProviderFactory.DataProviderFactoryTest();


        }
    }


}
