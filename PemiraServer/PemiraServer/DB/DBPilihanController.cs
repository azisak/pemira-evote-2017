using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraServer.DB
{
    class DBPilihanController
    {
        /* Atribut Kelas DB NIM yang Sudah Memilih Controller
         * Inisialisasi adapter, dataset, dan sqlcommand untuk method kelas
         */
        public static DBPemiraDataSetTableAdapters.PilihanTableAdapter pilihanTableAdapter = new DBPemiraDataSetTableAdapters.PilihanTableAdapter();
        public static DBPemiraDataSet.PilihanDataTable pilihanDT = new DBPemiraDataSet.PilihanDataTable();
        public static SqlCommand sqlCmd = new SqlCommand();

        /* Constructor
         */
        public DBPilihanController()
        {
            try
            {
                sqlCmd.Connection = pilihanTableAdapter.Connection;
                pilihanTableAdapter.Fill(pilihanDT);
                Console.WriteLine("Koneksi Data Yang Sudah Memilih Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
                Console.WriteLine("Koneksi Data Yang Sudah Memilih Gagal");
            }
        }

        /*
         */
        public bool tambahPilihanKM(string pilihan1, string pilihan2)
        {
            int result = pilihanTableAdapter.Insert(pilihan1, pilihan2);
            if (result == 1)
            {
                MessageBox.Show("Add Data yang Sudah Memilih Berhasil");
                return true;
            }
            else
            {
                MessageBox.Show("Add Data yang Sudah Memilih Gagal");
                return false;
            }
        }

        /* Export CSV
         */
        public bool exportCSV(string path)
        {
            var dtRandom = new DBPemiraDataSet.PilihanDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                pilihanTableAdapter.Fill(dtRandom);
                DataView dv = new DataView(dtRandom);
                dtExport = dv.ToTable(false, "Preferensi_1", "Preferensi_2");
                try
                {
                    WriteToFile(dtExport, path, false, ",");
                    MessageBox.Show("Export KM results Successful");
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
            pilihanTableAdapter.Fill(pilihanDT);
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
