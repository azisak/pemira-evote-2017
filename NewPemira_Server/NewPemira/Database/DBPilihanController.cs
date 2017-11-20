﻿using System;
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
                Console.WriteLine("Koneksi Data Pilihan Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
                Console.WriteLine("Koneksi Data Pilihan Gagal");
            }
        }

        /*
         */
        public bool tambahPilihanKM(string prodi, string pilihan1, string pilihan2)
        {
            int result = pilihanTableAdapter.Insert(prodi, pilihan1, pilihan2);
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

        /* Export CSV tanpa prodi
         */
        public bool exportCSVPilihanKM(string path)
        {
            DBPemiraDataSet.PilihanDataTable dtPilihan = new DBPemiraDataSet.PilihanDataTable();
            EnumerableRowCollection<DBPemiraDataSet.PilihanRow> pilihanQuery =
                from pilihan in dtPilihan.AsEnumerable()
                select pilihan;
            bool isSuccess = true;
            DataTable pilihanExport = new DataTable();
            try
            {
                pilihanTableAdapter.Fill(dtPilihan);
                DataView dv = pilihanQuery.AsDataView();
                pilihanExport = dv.ToTable(false, "prodi", "pilihan_1", "pilihan_2");
                try
                {
                    WriteFile(pilihanExport, path, false, ",");
                    MessageBox.Show("Export Pilihan KM results Successful");
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

        /* Export CSV dengan prodi
         */
        public bool exportCSVPilihanKMPilihan1(string path, string prodi)
        {
            DBPemiraDataSet.PilihanDataTable dtPilihanProdi = new DBPemiraDataSet.PilihanDataTable();

            EnumerableRowCollection<DBPemiraDataSet.PilihanRow> pilihanProdiQuery =
                from pilihanProdi in dtPilihanProdi.AsEnumerable()
                where pilihanProdi.Field<string>(columnName: "pilihan_1") == "1"
                select pilihanProdi;
            bool isSuccess = true;
            DataTable pilihanProdiExport = new DataTable();
            try
            {
                pilihanTableAdapter.Fill(dtPilihanProdi);
                DataView dv = pilihanProdiQuery.AsDataView();
                pilihanProdiExport = dv.ToTable(false, "prodi", "pilihan_1", "pilihan_2");
                try
                {
                    
                    WriteFile(pilihanProdiExport, path, false, ",");
                    MessageBox.Show("Export Pilihan KM results Successful");
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
        public void WriteFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader = false, string separator = ",")
        {
            var writer = new StreamWriter(fileOutputPath, false);
            writer.Flush();
            int icolcount = dataSource.Columns.Count;
            if (!firstRowIsColumnHeader)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    writer.Write(dataSource.Columns[i].ToString().ToUpper());
                    if (i < icolcount - 1)
                        writer.Write(separator);
                }

                writer.Write(writer.NewLine);
            }
            foreach (DataRow drow in dataSource.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]) && (drow[i].ToString().ToUpper() != "FALSE"))
                        if (drow[i].ToString().ToUpper() == "TRUE")
                        {
                            writer.Write("1");
                        }
                        else
                        {
                            writer.Write(drow[i].ToString());
                        }
                    if (i < icolcount - 1)
                        writer.Write(separator);
                }
                writer.Write(writer.NewLine);
            }
            writer.Close();
        }
    }
}