using REM.Data;
using REM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;

namespace REM.Konsole
{
    class Program
    {
             
        static void Main(string[] args)
        {
            decimal ToDec(string rowData)
            {
                if (rowData == "")
                {
                    return 0;
                }
                return Convert.ToDecimal(rowData, new CultureInfo("en-US"));
            }
            var dataTable = GetDataTable(@"C:\Users\Montassar\source\repos\RenevableEnergyMonitoring\REM\REM.Konsole\CSV\Daily_STEG_09_2011_06_12.csv", ';');

            using (var db = new REMContext())
            {
                List<Meteo> meteos = new List<Meteo>();

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime timestamp = DateTime.Parse(row["Timestamp"].ToString());
                    var meteo = new Meteo();
                    meteo.Timestamp = timestamp;
                    meteo.Irradiance = ToDec(row["irradianza"].ToString());
                    meteo.TemperatureOfModule = ToDec(row["t_modulo"].ToString());
                    meteo.TemperatureAmbiante = ToDec(row["t_ambiente"].ToString());
                    meteo.Humidity = ToDec(row["umidita"].ToString());
                    meteo.SpeedOfWind = ToDec(row["Velocita_vento"].ToString());
                    meteo.Onduleurs = new List<Onduleur>();

                    //Ond1;
                    var onduleur1 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur1",
                        VL_Vac = ToDec(row["VL_Vac01"].ToString()),
                        VL_Fac = ToDec(row["VL_Fac01"].ToString()),
                        VL_Pac = ToDec(row["VL_Pac01"].ToString()),
                        VL_Vdc = ToDec(row["VL_Vdc01_01"].ToString()),
                        VL_Iac = ToDec(row["VL_Iac01"].ToString()),
                        Total = ToDec(row["VL_ETotal01"].ToString()),

                    };
                    meteo.Onduleurs.Add(onduleur1);

                    //Ond2;
                    var onduleur2 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur2",
                        VL_Vac = ToDec(row["VL_Vac02"].ToString()),
                        VL_Fac = ToDec(row["VL_Fac02"].ToString()),
                        VL_Pac = ToDec(row["VL_Pac02"].ToString()),
                        VL_Vdc = ToDec(row["VL_Vdc02_01"].ToString()),
                        VL_Iac = ToDec(row["VL_Iac02"].ToString()),
                        Total = ToDec(row["VL_ETotal02"].ToString()),
                    };
                    meteo.Onduleurs.Add(onduleur2);

                    //Ond3;
                    var onduleur3 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur3",
                        VL_Vac = ToDec(row["VL_Vac03"].ToString()),
                        VL_Fac = ToDec(row["VL_Fac03"].ToString()),
                        VL_Pac = ToDec(row["VL_Pac03"].ToString()),
                        VL_Vdc = ToDec(row["VL_Vdc03_01"].ToString()),
                        VL_Iac = ToDec(row["VL_Iac03"].ToString()),
                        Total = ToDec(row["VL_ETotal03"].ToString()),
                    };
                    meteo.Onduleurs.Add(onduleur3);

                    //Ond4;
                    var onduleur4 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur4",
                        VL_Vac = ToDec(row["VL_Vac04"].ToString()),
                        VL_Fac = ToDec(row["VL_Fac04"].ToString()),
                        VL_Pac = ToDec(row["VL_Pac04"].ToString()),
                        VL_Vdc = ToDec(row["VL_Vdc04_01"].ToString()),
                        VL_Iac = ToDec(row["VL_Iac04"].ToString()),
                        Total = ToDec(row["VL_ETotal04"].ToString()),
                    };
                    meteo.Onduleurs.Add(onduleur4);

                    //Ond5;
                    var onduleur5 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur5",
                        VL_Vac = ToDec(row["VL_Vac05"].ToString()),
                        VL_Fac = ToDec(row["VL_Fac05"].ToString()),
                        VL_Pac = ToDec(row["VL_Pac05"].ToString()),
                        VL_Vdc = ToDec(row["VL_Vdc05_01"].ToString()),
                        VL_Iac = ToDec(row["VL_Iac05"].ToString()),
                        Total = ToDec(row["VL_ETotal05"].ToString()),
                    };
                    meteo.Onduleurs.Add(onduleur5);

                    //Ond6;
                    var onduleur6 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur6",
                        VL_Vac = ToDec(row["VL_Vac06"].ToString()),
                        VL_Fac = ToDec(row["VL_Fac06"].ToString()),
                        VL_Pac = ToDec(row["VL_Pac06"].ToString()),
                        VL_Vdc = ToDec(row["VL_Vdc06_01"].ToString()),
                        VL_Iac = ToDec(row["VL_Iac06"].ToString()),
                        Total = ToDec(row["VL_ETotal06"].ToString()),
                    };
                    meteo.Onduleurs.Add(onduleur6);

                    //db.Meteos.Add(meteo);
                    //db.SaveChanges();

                    meteos.Add(meteo);
                }

                db.Meteos.AddRange(meteos);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Gibt den Inhalt einer CSV Datei in einer DataTable zurück
        /// </summary>
        /// <param name="path">Pfad der CSV Datei</param>
        /// <param name="seperator">Zeichen mit dem die Spalten getrennt werden. Meist ';' oder ','</param>
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
    }
}
