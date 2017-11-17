using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace PemiraServer.DB
{
    public class DBDPTController
    {
        /* Atribut Kelas DB DPT (Daftar Pemilih Tetap) Controller
         * Inisialisasi adapter, dataset, dan sqlcommand untuk method kelas
         */
        public static DBPemiraDataSetTableAdapters.DPTTableAdapter dptTableAdapter = new DBPemiraDataSetTableAdapters.DPTTableAdapter();
        public static DBPemiraDataSet.DPTDataTable dptDT = new DBPemiraDataSet.DPTDataTable();
        public static SqlCommand sqlCmd = new SqlCommand();

        /* Constructor
         */
        public DBDPTController()
        {
            try
            {
                sqlCmd.Connection = dptTableAdapter.Connection;
                dptTableAdapter.Fill(dptDT);
                Console.WriteLine("Koneksi Data DPT Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
                Console.WriteLine("Koneksi Data DPT Gagal");
            }
        }

        public bool execute(string query)
        {
            sqlCmd.CommandText = query;
            try
            {
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        public bool getDPT(string nim)
        {
            string query = "nim = '" + nim + "'";
            DataRow[] found = dptDT.Select(query);
            if (found.Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Method Import CSV DPT
         * 
         */
        public bool importCSV(string path)
        {
            bool isSuccess = true;
            string query = "TRUNCATE TABLE DPT";
            isSuccess &= this.execute(query);

            query =
                @"BULK INSERT DPT
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
                MessageBox.Show("Import Successful\nNumber of rows: " + dptDT.Count);
                return isSuccess;
            }
            else
            {
                MessageBox.Show("Import from " + path + " aborted\nPlease Check .csv File Format => nama,nim");
                return false;
            }
        }

        /* Method Export CSV DPT
         * 
         */
        public bool exportCSV(string path)
        {
            var dptDTexport = new DBPemiraDataSet.DPTDataTable();
            bool isSuccess = true;
            DataTable dtUnfiltered = new DataTable();
            DataTable dtExport = new DataTable();
            try
            {
                dptTableAdapter.Fill(dptDTexport);
                DataView dv = new DataView(dptDTexport);
                dtExport = dv.ToTable(false, "NIM", "Nama");
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

            dptTableAdapter.Fill(dptDT);
            return isSuccess;
        }

        /*  Method untuk Export table ke sebuah File
         * 
         */
        public void WriteToFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader = false, string separator = ";")
        {
            var sw = new StreamWriter(fileOutputPath, false);
            int icolcount = dataSource.Columns.Count;
            if (!firstRowIsColumnHeader)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    sw.Write(dataSource.Columns[i].ToString().ToUpper());
                    if (i < icolcount - 1)
                        sw.Write(separator);
                }

                sw.Write(sw.NewLine);
            }
            foreach (DataRow drow in dataSource.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]) && (drow[i].ToString().ToUpper() != "FALSE"))
                        if (drow[i].ToString().ToUpper() == "TRUE")
                        {
                            sw.Write("1");
                        }
                        else
                        {
                            sw.Write(drow[i].ToString());
                        }
                    if (i < icolcount - 1)
                        sw.Write(separator);
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
}
