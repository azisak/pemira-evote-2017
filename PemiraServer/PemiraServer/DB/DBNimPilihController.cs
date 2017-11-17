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
    public class DBNimPilihController
    {
        /* Atribut Kelas DB NIM yang Sudah Memilih Controller
         * Inisialisasi adapter, dataset, dan sqlcommand untuk method kelas
         */
        public static DBPemiraDataSetTableAdapters.NIM_PilihTableAdapter pilihTableAdapter = new DBPemiraDataSetTableAdapters.NIM_PilihTableAdapter();
        public static DBPemiraDataSet.NIM_PilihDataTable pilihDT = new DBPemiraDataSet.NIM_PilihDataTable();
        public static SqlCommand sqlCmd = new SqlCommand();

        /* Constructor
         */
        public DBNimPilihController()
        {
            try
            {
                sqlCmd.Connection = pilihTableAdapter.Connection;
                pilihTableAdapter.Fill(pilihDT);
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
        public bool addPilih(string nim)
        {
            string prodi = nim.Substring(0, 3);
            int result = pilihTableAdapter.Insert(nim, prodi);
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

        public bool checkBelumPilih(string nim)
        {
            string query = "nim = '" + nim + "'";
            DataRow[] found = pilihDT.Select(query);
            if (found.Length == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /* Method untuk melakukan pengecekan DB
         * 
         */
        public void printDB()
        {
            string printOut = "";
            pilihTableAdapter.Fill(pilihDT);
            foreach (DataRow dr in pilihDT.Rows)
            {
                foreach (DataColumn dc in pilihDT.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + pilihDT.Rows.Count;
            MessageBox.Show(printOut);
        }

        public bool exportCSV(string path)
        {
            var dtRaw = new DBPemiraDataSet.NIM_PilihDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                pilihTableAdapter.Fill(dtRaw);
                DataView dv = new DataView(dtRaw);
                dtExport = dv.ToTable(false, "NIM", "Program_studi");
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

            pilihTableAdapter.Fill(pilihDT);
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
