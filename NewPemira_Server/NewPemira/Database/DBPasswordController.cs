using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPemira
{
    class DBPasswordController
    {
        /* Atribut Kelas DB NIM yang Sudah Memilih Controller
         * Inisialisasi adapter, dataset, dan sqlcommand untuk method kelas
         */
        public static DBPemiraDataSetTableAdapters.PasswordTableAdapter passwordTableAdapter = new DBPemiraDataSetTableAdapters.PasswordTableAdapter();
        public static DBPemiraDataSet.PasswordDataTable passwordDT = new DBPemiraDataSet.PasswordDataTable();
        public static SqlCommand sqlCmd = new SqlCommand();

        /* Constructor
         */
        public DBPasswordController()
        {
            try
            {
                sqlCmd.Connection = passwordTableAdapter.Connection;
                passwordTableAdapter.Fill(passwordDT);
                Console.WriteLine("Koneksi Data Yang Sudah Memilih Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
                Console.WriteLine("Koneksi Data Yang Sudah Memilih Gagal");
            }
        }

        public bool addPassword(string pass1, string pass2, string pass3, string pass4, string pass5)
        {
            int result = passwordTableAdapter.Insert(pass1, pass2, pass3, pass4, pass5);
            if (result == 1)
            {
                MessageBox.Show("Add Password Berhasil");
                return true;
            }
            else
            {
                MessageBox.Show("Add Password Gagal");
                return false;
            }
        }

        public bool addPassword(List<string> password)
        {
            int result = passwordTableAdapter.Insert(password[0], password[1], password[2], password[3], password[4]);
            if (result == 1)
            {
                MessageBox.Show("Add Password Berhasil");
                return true;
            }
            else
            {
                MessageBox.Show("Add Password Gagal");
                return false;
            }
        }

        public bool isTableEmpty()
        {
            if (passwordDT.Count == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool checkPassword(List<string> password)
        {
            bool check = true;
            string find = "password_1 = '" + password[0] + "'";
            DataRow[] found = passwordDT.Select(find);
            if (found.Length == 1)
            {
                int i = 1;
                while (i < 5 && check)
                {
                    string col = "password_" + (i + 1);
                    if (!password.Contains(found[0][col].ToString()))
                    {
                        check = false;
                    }
                    i++;
                }
            }
            else
            {
                check = false;
            }
            return check;
        }

        /* Export CSV
         */
        public bool exportCSV(string path)
        {
            var dtRandom = new DBPemiraDataSet.PasswordDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                passwordTableAdapter.Fill(dtRandom);
                DataView dv = new DataView(dtRandom);
                dtExport = dv.ToTable(false, "Password1", "Password2", "Password3", "Password4", "Password5");
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
            passwordTableAdapter.Fill(passwordDT);
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
