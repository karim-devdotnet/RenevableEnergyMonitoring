using REM.Data;
using REM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.Sql;

namespace REM.Konsole
{
    class Program
    {
             
        static void Main(string[] args)
        {
            string NomFichier = "Daily_STEG_09_2011_06_12.csv";
            string pathFile= ConfigurationManager.AppSettings.Get("csvFolder")+"\\"+ NomFichier;

            

            var dataTable = GetDataTable(pathFile, ';');

            using (var db = new REMContext())
            {
                List<Meteo> meteos = new List<Meteo>();

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime timestamp = DateTime.Parse(row["Timestamp"].ToString());
                    var meteo = new Meteo();
                    meteo.Timestamp = timestamp;
                    meteo.Irradiance = ToDecimal(row["irradianza"].ToString());
                    meteo.TemperatureOfModule = ToDecimal(row["t_modulo"].ToString());
                    meteo.TemperatureAmbiante = ToDecimal(row["t_ambiente"].ToString());
                    meteo.Humidity = ToDecimal(row["umidita"].ToString());
                    meteo.SpeedOfWind = ToDecimal(row["Velocita_vento"].ToString());
                    meteo.Onduleurs = new List<Onduleur>();

                    //Ond1;
                    var onduleur1 = GetOnduleur(row, timestamp, 1);
                    meteo.Onduleurs.Add(onduleur1);

                    //Ond2;
                    var onduleur2 = GetOnduleur(row, timestamp, 2);
                    meteo.Onduleurs.Add(onduleur2);

                    //Ond3;
                    var onduleur3 = GetOnduleur(row, timestamp, 3);
                    meteo.Onduleurs.Add(onduleur3);

                    //Ond4;
                    var onduleur4 = GetOnduleur(row, timestamp, 4);
                    meteo.Onduleurs.Add(onduleur4);

                    //Ond5;
                    var onduleur5 = GetOnduleur(row, timestamp, 5);
                    meteo.Onduleurs.Add(onduleur5);

                    //Ond6;
                    var onduleur6 = GetOnduleur(row, timestamp, 6);
                    meteo.Onduleurs.Add(onduleur6);
                    
                    meteos.Add(meteo);
                }

                var CsvImport = new CsvImportHistory
                {
                    Timestamp = DateTime.Now,
                    NameFile = NomFichier,
                    CountImportedRecords = meteos.Count,
                };

                db.Meteos.AddRange(meteos);
                db.CsvHistory.Add(CsvImport);
                db.SaveChanges();
                 
            }
        }

        /// <summary>
        /// Renvoie le contenu d'un fichier CSV dans un DataTable
        /// </summary>
        /// <param name="path">Chemin du fichier CSV</param>
        /// <param name="seperator">Caractère utilisé pour séparer les colonnes. La plupart du temps ';' ou ','</param>
        /// <returns></returns>
        private static DataTable GetDataTable(string path, char seperator)
        {       
            DataTable dt = new DataTable();
            FileStream aFile = new FileStream(path, FileMode.Open);
            using (StreamReader sr = new StreamReader(aFile, System.Text.Encoding.Default))
            {
                string strLine = sr.ReadLine();
                string[] strArray = strLine.Split(seperator);

                foreach (string value in strArray)
                    dt.Columns.Add(value.Trim());

                DataRow dr = dt.NewRow();

                while (sr.Peek() > -1)
                {
                    strLine = sr.ReadLine();
                    strArray = strLine.Split(seperator);
                    dt.Rows.Add(strArray);
                }
            }
            return dt;
        }

        private static decimal ToDecimal(string rowData)
        {
            try
            {
                if (rowData == "")
                {
                    return 0;
                }
                return Convert.ToDecimal(rowData, new CultureInfo("en-US"));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static Onduleur GetOnduleur(DataRow row,DateTime timestamp, int index)
        {
            return new Onduleur
            {
                Timestamp = timestamp,
                Designation = $"Onduleur{index}",
                VL_Vac = ToDecimal(row[$"VL_Vac0{index}"].ToString()),
                VL_Fac = ToDecimal(row[$"VL_Fac0{index}"].ToString()),
                VL_Pac = ToDecimal(row[$"VL_Pac0{index}"].ToString()),
                VL_Vdc = ToDecimal(row[$"VL_Vdc0{index}_01"].ToString()),
                VL_Iac = ToDecimal(row[$"VL_Iac0{index}"].ToString()),
                Total = ToDecimal(row[$"VL_ETotal0{index}"].ToString()),

            };
        }
    }
}
