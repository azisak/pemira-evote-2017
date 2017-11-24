using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace NewPemira
{
    public class DBDPTController
    {
        /* 
         * Atribut Kelas DB DPT (Daftar Pemilih Tetap) Controller
         * Inisialisasi adapter, dataset, dan sqlcommand untuk method kelas
         */
        public static DBPemiraDataSetTableAdapters.DPTTableAdapter dptTableAdapter = new DBPemiraDataSetTableAdapters.DPTTableAdapter();
        public static DBPemiraDataSet.DPTDataTable dptDT = new DBPemiraDataSet.DPTDataTable();
        public static SqlCommand sqlCmd = new SqlCommand();

        /* 
         * Constructor Controller Tabel Data Pemilih
         */
        public DBDPTController()
        {
            try
            {
                sqlCmd.Connection = dptTableAdapter.Connection;
                dptTableAdapter.Fill(dptDT);
                //Console.WriteLine("Koneksi Data DPT Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
                //Console.WriteLine("Koneksi Data DPT Gagal");
            }
        }

        /*
         * Fungsi execute untuk melakukan pengeksekusian query
         */
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

        public bool isEmptyDPT()
        {
            if (dptDT.Count == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

       /*
        * Fungsi getDPT untuk mengecek apakah nim yang dimasukkan dapat memilih atau tidak
        */
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

        public bool checkBelumPilih(string nim)
        {
            string query = "nim = '" + nim + "' and sudahpilih = '0'";
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

        /*
        * Fungsi getDPT untuk mengecek apakah nim yang dimasukkan dapat memilih atau tidak
        */
        public bool setSudahPilih(string nim)
        {
            string query = "nim = '" + nim + "'";
            DataRow[] found = dptDT.Select(query);
            if (found.Length == 1)
            {
                query = "UPDATE DPT SET sudahpilih = '1' WHERE nim = '" + nim + "'";
                bool check = this.execute(query);
                dptTableAdapter.Fill(dptDT);
                return check;
            }
            else
            {
                return false;
            }
        }

        /* 
         * Method Import CSV DPT
         */
        public bool importCSV(string path)
        {
            bool isSuccess = true;
            string query = "TRUNCATE TABLE DPT_Template";
            isSuccess &= this.execute(query);

            query =
                @"BULK INSERT DPT_Template
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

                query = @"INSERT INTO DPT(nim, nama) 
                           SELECT nim, nama
                           FROM DPT_Template
                        ";
                isSuccess &= this.execute(query);
                dptTableAdapter.Fill(dptDT);
                MessageBox.Show("Import Successful\nNumber of rows: " + dptDT.Count);
                return isSuccess;
            }
            else
            {
                MessageBox.Show("Import from " + path + " aborted\nPlease Check .csv File Format => nama,nim");
                return false;
            }
        }

        /* 
         * Method Export CSV DPT
         */
        public bool exportCSVDP(string path)
        {
            DBPemiraDataSet.DPTDataTable dptDTexport = new DBPemiraDataSet.DPTDataTable();
            EnumerableRowCollection<DBPemiraDataSet.DPTRow> DPQuery =
                from dpt in dptDTexport.AsEnumerable()
                where dpt.Field<string>("sudahpilih") == "1"
                select dpt;
            bool isSuccess = true;
            DataTable dptExport = new DataTable();
            try
            {
                dptTableAdapter.Fill(dptDTexport);
                DataView dv = DPQuery.AsDataView();
                dptExport = dv.ToTable(false, "nim", "nama", "sudahpilih");
                try
                {
                    WriteToFile(dptExport, path, false, ",");
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

        /* 
         * Method untuk Export table ke sebuah File
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
