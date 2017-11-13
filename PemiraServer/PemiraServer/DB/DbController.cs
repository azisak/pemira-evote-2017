using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace PemiraServer
{
    /*public class dbDfault
    {
        public static DatasetTableAdapter passwordsTableAdapter = new PemiraDBDataSetTableAdapters.KunciPasswordsTableAdapter();
        public static DataTable dt;
        public static SqlCommand cmd = new SqlCommand();
    }*/

    public class dbKunciPasswordsController
    {
        public static PemiraDBDataSetTableAdapters.KunciPasswordsTableAdapter passwordsTableAdapter = new PemiraDBDataSetTableAdapters.KunciPasswordsTableAdapter();
        public static PemiraDBDataSet.KunciPasswordsDataTable dt = new PemiraDBDataSet.KunciPasswordsDataTable();
        public static SqlCommand cmd = new SqlCommand();

        public dbKunciPasswordsController()
        {
            try
            {
                cmd.Connection = passwordsTableAdapter.Connection;
                passwordsTableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public string getPassword(int id)
        {
            string find = "id = '" + id + "'";
            DataRow[] foundRows = dt.Select(find);
            return foundRows[0]["password"].ToString();
        }

        public int getDataCount()
        {
            return dt.Count;
        }
        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        public void addPassword(string pass)
        {
            passwordsTableAdapter.Insert(pass);
            passwordsTableAdapter.Fill(dt);
        }

        public void printDB()
        {
            string printOut = "";
            passwordsTableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }

        public void flush()
        {
            string query = @"TUNCATE TABLE KunciPasswords";
            this.execute(query);
        }
    }

    public class dbImportStatusController
    {
        public static PemiraDBDataSetTableAdapters.ImportStatusTableAdapter importTableAdapter = new PemiraDBDataSetTableAdapters.ImportStatusTableAdapter();
        public static PemiraDBDataSet.ImportStatusDataTable dt = new PemiraDBDataSet.ImportStatusDataTable();
        public static SqlCommand cmd = new SqlCommand();
        public static Label importStatusLabel;

        public void writeStatusOnLabel()
        {
            importStatusLabel.ForeColor = System.Drawing.Color.Green;
            string newStatus = "Database Has Been Imported\n";
            newStatus += "From: " + dt.Rows[dt.Count - 1]["Path"] + "\n";
            //newStatus += "On: " + dt.Rows[dt.Count - 1]["LastUpdated"].ToString() + "\n";
            newStatus += "By: " + dt.Rows[dt.Count - 1]["MachineName"];
            importStatusLabel.Text = newStatus;
        }

        public void setImportStatusLabel(Label _importStatusLabel)
        {
            importStatusLabel = _importStatusLabel;
        }

        public void updateImportStatusLabel()
        {
            importTableAdapter.Fill(dt);
            if (dt.Count > 0)
            {
                this.writeStatusOnLabel();
            }
            else
            {
                importStatusLabel.ForeColor = System.Drawing.Color.Red;
                importStatusLabel.Text = "No DPT Database imported";
            }
        }

        public dbImportStatusController()
        {
            try
            {
                cmd.Connection = importTableAdapter.Connection;
                importTableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public void addNewImportStatus(string path, string machineName)
        {
            string query =
                @"INSERT INTO dbo.ImportStatus (Path, MachineName) VALUES ('" + path + "','" + machineName + "')";
            cmd.CommandText = query;
            this.execute(query);
            importTableAdapter.Fill(dt);
            this.writeStatusOnLabel();
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }
        public void flush()
        {
            string query = @"TUNCATE TABLE KunciPasswords";
            this.execute(query);
        }
    }
    public class dbQBilik2Controller
    {
        public static PemiraDBDataSetTableAdapters.QBilik2TableAdapter QBilik2TableAdapter = new PemiraDBDataSetTableAdapters.QBilik2TableAdapter();
        public static PemiraDBDataSet.QBilik2DataTable dt = new PemiraDBDataSet.QBilik2DataTable();
        public static SqlCommand cmd = new SqlCommand();

        public DataRowCollection getAllRows()
        {
            return dt.Rows;

            //CARA ITERASI:
            /*
                MISAL: dr = getAllNim();

                foreach(DataRow row in dr) {
                    string singleNim = row["nim"].ToString();
                }
            */
        }

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            return false;
        }

        public dbQBilik2Controller()
        {
            try
            {
                cmd.Connection = QBilik2TableAdapter.Connection;
                QBilik2TableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public void addNim(string nim)
        {
            string query = "INSERT INTO QBilik2 (nim) VALUES (" + nim + ")";
            this.execute(query);
            QBilik2TableAdapter.Fill(dt);
        }

        public void delNim(string nim)
        {
            string query = "DELETE FROM QBilik2 WHERE nim = '" + nim + "'";
            this.execute(query);
            QBilik2TableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            QBilik2TableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }
        public void flush()
        {
            string query = @"TUNCATE TABLE KunciPasswords";
            this.execute(query);
        }
    }

    public class dbQBilik1Controller
    {
        public static PemiraDBDataSetTableAdapters.QBilik1TableAdapter QBilik1TableAdapter = new PemiraDBDataSetTableAdapters.QBilik1TableAdapter();
        public static PemiraDBDataSet.QBilik1DataTable dt = new PemiraDBDataSet.QBilik1DataTable();
        public static SqlCommand cmd = new SqlCommand();

        public DataRowCollection getAllRows()
        {
            return dt.Rows;

            //CARA ITERASI:
            /*
                MISAL: dr = getAllNim();

                foreach(DataRow row in dr) {
                    string singleNim = row["nim"].ToString();
                }
            */
        }

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            return false;
        }

        public dbQBilik1Controller()
        {
            try
            {
                cmd.Connection = QBilik1TableAdapter.Connection;
                QBilik1TableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public void addNim(string nim)
        {
            string query = "INSERT INTO QBilik1 (nim) VALUES (" + nim + ")";
            this.execute(query);
            QBilik1TableAdapter.Fill(dt);
        }

        public void delNim(string nim)
        {
            string query = "DELETE FROM QBilik1 WHERE nim = '" + nim + "'";
            this.execute(query);
            QBilik1TableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            QBilik1TableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }
        public void flush()
        {
            string query = @"TUNCATE TABLE KunciPasswords";
            this.execute(query);
        }
    }



    public class dbWaitingListController
    {
        public static PemiraDBDataSetTableAdapters.WaitingListTableAdapter waitingListTableAdapter = new PemiraDBDataSetTableAdapters.WaitingListTableAdapter();
        public static PemiraDBDataSet.WaitingListDataTable dt = new PemiraDBDataSet.WaitingListDataTable();
        public static SqlCommand cmd = new SqlCommand();

        public DataRowCollection getAllRows()
        {
            return dt.Rows;

            //CARA ITERASI:
            /*
                MISAL: dr = getAllNim();

                foreach(DataRow row in dr) {
                    string singleNim = row["nim"].ToString();
                }
            */
        }

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            return false;
        }

        public dbWaitingListController()
        {
            try
            {
                cmd.Connection = waitingListTableAdapter.Connection;
                waitingListTableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public void addNim(string nim)
        {
            string query = "INSERT INTO WaitingList (nim) VALUES (" + nim + ")";
            this.execute(query);
            waitingListTableAdapter.Fill(dt);
        }

        public void delNim(string nim)
        {
            string query = "DELETE FROM WaitingList WHERE nim = '" + nim + "'";
            this.execute(query);
            waitingListTableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error"  + "\n\nSource:" + e.Source);
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            waitingListTableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }
        public void flush()
        {
            string query = @"TUNCATE TABLE KunciPasswords";
            this.execute(query);
        }
    }

    public class dbDPTController
    {
        public static PemiraDBDataSetTableAdapters.DPTTableAdapter dptTableAdapter = new PemiraDBDataSetTableAdapters.DPTTableAdapter();
        //public static SqlConnection conn = new SqlConnection(dptTableAdapter.Connection.ConnectionString);
        public static PemiraDBDataSet.DPTDataTable dt = new PemiraDBDataSet.DPTDataTable();
        public static SqlCommand cmd = new SqlCommand();

        public dbDPTController()
        {
            try
            {
                //conn.Open();
                cmd.Connection = dptTableAdapter.Connection;
                dptTableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public bool exportCSVdpt(string path)
        {
            var dtRaw = new PemiraDBDataSet.DPTDataTable();
            bool isSuccess = true;
            DataTable dtUnfiltered = new DataTable();
            DataTable dtExport = new DataTable();
            try
            {
                dptTableAdapter.FillByDPT(dtRaw);
                DataView dv = new DataView(dtRaw);
                dtExport = dv.ToTable(false, "nama", "nim", "sudahPilih");
                try
                {
                    WriteToFile(dtExport, path, false, ",");
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Export Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
            }

            dptTableAdapter.Fill(dt);
            return isSuccess;
        }

        public bool exportCSVdp(string path)
        {
            var dtRaw = new PemiraDBDataSet.DPTDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                dptTableAdapter.Fill(dtRaw);
                DataView dv = new DataView(dtRaw);
                dtExport = dv.ToTable(false, "nama", "nim", "sudahPilih");
                try
                {
                    WriteToFile(dtExport, path, false, ",");
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Export Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
            }

            dptTableAdapter.Fill(dt);
            return isSuccess;
        }

        public bool exportCSVkm(string path)
        {
            var dtRandom = new PemiraDBDataSet.DPTDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                dptTableAdapter.FillRandomKM(dtRandom);
                DataView dv = new DataView(dtRandom);
                //DATA LENGKAP:
                //dtExport = dv.ToTable(false, "nim", "nama", "nomorPilihanKM");
                //DATA HANYA PILIHAN:
                dtExport = dv.ToTable(false, "nomorPilihanKM");
                try
                {
                    WriteToFile(dtExport, path, false, ",");
                    MessageBox.Show("Export KM results Successful");//\nNumber of rows: " + dtExport.Rows.Count);
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Export Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
            }

            dptTableAdapter.Fill(dt);
            return isSuccess;
        }

        public bool exportCSVmwawm(string path)
        {
            var dtRandom = new PemiraDBDataSet.DPTDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                dptTableAdapter.FillRandomMWAWM(dtRandom);
                DataView dv = new DataView(dtRandom);
                //DATA LENGKAP:
                //dtExport = dv.ToTable(false, "nim", "nama", "nomorPilihanMWAWM");
                //DATA HANYA PILIHAN:
                dtExport = dv.ToTable(false, "nomorPilihanMWAWM");
                try
                {
                    WriteToFile(dtExport, path, false, ",");
                    MessageBox.Show("Export MWAWM results Successful");//\nNumber of rows: " + dtExport.Rows.Count);
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Export Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error" + "\n\nSource: " + e.Source);
            }

            dptTableAdapter.Fill(dt);
            return isSuccess;
        }

        public bool importCSV(string path)
        {
            bool isSuccess = true;
            string query = "TRUNCATE TABLE DPT_staging";
            isSuccess &= this.execute(query);

            query =
                @"BULK INSERT DPT_staging
                    FROM '" + path + @"'
                    WITH
                        (
                            FIRSTROW = 0,
                            FIELDTERMINATOR = ',',
                            ROWTERMINATOR = '\n',
                            TABLOCK
                        )";

            if (this.execute(query))
            {
                query = @"TRUNCATE TABLE DPT";
                isSuccess &= this.execute(query);

                query = @"INSERT INTO DPT(nama, nim) 
                           SELECT nama, nim
                           FROM DPT_staging
                        ";
                isSuccess &= this.execute(query);
                dptTableAdapter.Fill(dt);
                MessageBox.Show("Import Successful\nNumber of rows: " + dt.Count);
                return isSuccess;
            }
            else
            {
                MessageBox.Show("Import from " + path + " aborted\nPlease Check .csv File Format => nama,nim");
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            dptTableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            return false;
        }

        public bool isAlreadyPickedKM(string nim)
        {
            //nim harus sudah ada dalam db
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            return (foundRows[0].Field<int>("nomorPilihanKM").ToString() != "999");
        }

        public bool isAlreadyPickedMWAWM(string nim)
        {
            //nim harus sudah ada dalam db
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);

            return (foundRows[0].Field<int>("nomorPilihanMWAWM").ToString() != "999");
        }

        public void setSudahPilih(string nim, bool isAlreadyPicked)
        {
            string sAlreadyPicked;
            if (isAlreadyPicked)
            {
                sAlreadyPicked = "1";
            }
            else
            {
                sAlreadyPicked = "0";
            }
            string query = @"UPDATE DPT SET SudahPilih = " + sAlreadyPicked + " WHERE nim = '" + nim + "'";
            this.execute(query);
            dptTableAdapter.Fill(dt);
        }

        public bool getSudahPilih(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            //Debug.WriteLine(foundRows[0]["sudahpilih"].ToString());
            if (foundRows[0]["sudahPilih"].ToString() == "False")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setChoiceKM(string nim, string nomorPilihanKM)
        {
            string query = @"UPDATE DPT SET nomorPilihanKM = '" + nomorPilihanKM + "' WHERE nim = '" + nim + "'";
            this.execute(query);
            dptTableAdapter.Fill(dt);
        }

        public void setChoiceMWAWM(string nim, string nomorPilihanKM)
        {
            string query = @"UPDATE DPT SET nomorPilihanMWAWM = '" + nomorPilihanKM + "' WHERE nim = '" + nim + "'";
            this.execute(query);
            dptTableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error" + "\n\nSource: " + e.Source);
                return false;
            }
        }

        //FUNGSI UNTUK EXPORT DOANG
        public void WriteToFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader = false, string seperator = ";")
        {
            var sw = new StreamWriter(fileOutputPath, false);
            int icolcount = dataSource.Columns.Count;
            if (!firstRowIsColumnHeader)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    sw.Write(dataSource.Columns[i].ToString().ToUpper());
                    if (i < icolcount - 1)
                        sw.Write(seperator);
                }

                sw.Write(sw.NewLine);
            }
            foreach (DataRow drow in dataSource.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]) && (drow[i].ToString().ToUpper() != "FALSE"))
                        if(drow[i].ToString().ToUpper() == "TRUE")
                        {
                            sw.Write("1");
                        }
                        else
                        {
                            sw.Write(drow[i].ToString());
                        }
                    if (i < icolcount - 1)
                        sw.Write(seperator);
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public void flush()
        {
            string query = @"TUNCATE TABLE KunciPasswords";
            this.execute(query);
        }
    }
}
