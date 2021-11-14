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
        // a implémenter
        private decimal ToDecimal(string rowData)
        {
            return 0;
        }
        static void Main(string[] args)
        {

            var dataTable = GetDataTable(@"C:\Users\Montassar\source\repos\RenevableEnergyMonitoring\REM\REM.Konsole\CSV\Daily_STEG_09_2011_06_12.csv", ';');

            using (var db = new REMContext())
            {
                List<Meteo> meteos = new List<Meteo>();

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime timestamp = DateTime.Parse(row["Timestamp"].ToString());
                    var meteo = new Meteo();
                    meteo.Timestamp = timestamp;
                    meteo.Irradiance = Convert.ToDecimal(row["irradianza"].ToString(), new CultureInfo("en-US"));
                    meteo.TemperatureOfModule = Convert.ToDecimal(row["t_modulo"].ToString(), new CultureInfo("en-US"));
                    meteo.TemperatureAmbiante = Convert.ToDecimal(row["t_ambiente"].ToString(), new CultureInfo("en-US"));
                    meteo.Humidity = Convert.ToDecimal(row["umidita"].ToString(), new CultureInfo("en-US"));
                    meteo.SpeedOfWind = Convert.ToDecimal(row["Velocita_vento"].ToString(), new CultureInfo("en-US"));
                    meteo.Onduleurs = new List<Onduleur>();

                    //Ond1;
                    var onduleur1 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur1",
                        VL_Vac = Convert.ToDecimal(row["VL_Vac01"].ToString(), new CultureInfo("en-US")),
                        VL_Fac = Convert.ToDecimal(row["VL_Fac01"].ToString(), new CultureInfo("en-US")),
                        VL_Pac = Convert.ToDecimal(row["VL_Pac01"].ToString(), new CultureInfo("en-US")),
                        VL_Vdc = Convert.ToDecimal(row["VL_Vdc01_01"].ToString(), new CultureInfo("en-US")),
                        VL_Iac = Convert.ToDecimal(row["VL_Iac01"].ToString(), new CultureInfo("en-US")),
                        Total = Convert.ToDecimal(row["VL_ETotal01"].ToString(), new CultureInfo("en-US")),

                    };
                    meteo.Onduleurs.Add(onduleur1);

                    //Ond2;
                    var onduleur2 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur2",
                        VL_Vac = Convert.ToDecimal(row["VL_Vac02"].ToString(), new CultureInfo("en-US")),
                        VL_Fac = Convert.ToDecimal(row["VL_Fac02"].ToString(), new CultureInfo("en-US")),
                        VL_Pac = Convert.ToDecimal(row["VL_Pac02"].ToString(), new CultureInfo("en-US")),
                        VL_Vdc = Convert.ToDecimal(row["VL_Vdc02_01"].ToString(), new CultureInfo("en-US")),
                        VL_Iac = Convert.ToDecimal(row["VL_Iac02"].ToString(), new CultureInfo("en-US")),
                        Total = Convert.ToDecimal(row["VL_ETotal02"].ToString(), new CultureInfo("en-US")),
                    };
                    meteo.Onduleurs.Add(onduleur2);

                    //Ond3;
                    var onduleur3 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur3",
                        VL_Vac = Convert.ToDecimal(row["VL_Vac03"].ToString(), new CultureInfo("en-US")),
                        VL_Fac = Convert.ToDecimal(row["VL_Fac03"].ToString(), new CultureInfo("en-US")),
                        VL_Pac = Convert.ToDecimal(row["VL_Pac03"].ToString(), new CultureInfo("en-US")),
                        VL_Vdc = Convert.ToDecimal(row["VL_Vdc03_01"].ToString(), new CultureInfo("en-US")),
                        VL_Iac = Convert.ToDecimal(row["VL_Iac03"].ToString(), new CultureInfo("en-US")),
                        Total = Convert.ToDecimal(row["VL_ETotal03"].ToString(), new CultureInfo("en-US")),
                    };
                    meteo.Onduleurs.Add(onduleur3);

                    //Ond4;
                    var onduleur4 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur4",
                        VL_Vac = Convert.ToDecimal(row["VL_Vac04"].ToString(), new CultureInfo("en-US")),
                        VL_Fac = Convert.ToDecimal(row["VL_Fac04"].ToString(), new CultureInfo("en-US")),
                        VL_Pac = Convert.ToDecimal(row["VL_Pac04"].ToString(), new CultureInfo("en-US")),
                        VL_Vdc = Convert.ToDecimal(row["VL_Vdc04_01"].ToString(), new CultureInfo("en-US")),
                        VL_Iac = Convert.ToDecimal(row["VL_Iac04"].ToString(), new CultureInfo("en-US")),
                        Total = Convert.ToDecimal(row["VL_ETotal04"].ToString(), new CultureInfo("en-US")),
                    };
                    meteo.Onduleurs.Add(onduleur4);

                    //Ond5;
                    var onduleur5 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur5",
                        VL_Vac = Convert.ToDecimal(row["VL_Vac05"].ToString(), new CultureInfo("en-US")),
                        VL_Fac = Convert.ToDecimal(row["VL_Fac05"].ToString(), new CultureInfo("en-US")),
                        VL_Pac = Convert.ToDecimal(row["VL_Pac05"].ToString(), new CultureInfo("en-US")),
                        VL_Vdc = Convert.ToDecimal(row["VL_Vdc05_01"].ToString(), new CultureInfo("en-US")),
                        VL_Iac = Convert.ToDecimal(row["VL_Iac05"].ToString(), new CultureInfo("en-US")),
                        Total = Convert.ToDecimal(row["VL_ETotal05"].ToString(), new CultureInfo("en-US")),
                    };
                    meteo.Onduleurs.Add(onduleur5);

                    //Ond6;
                    var onduleur6 = new Onduleur
                    {
                        Timestamp = timestamp,
                        Designation = "Onduleur6",
                        VL_Vac = Convert.ToDecimal(row["VL_Vac06"].ToString(), new CultureInfo("en-US")),
                        VL_Fac = Convert.ToDecimal(row["VL_Fac06"].ToString(), new CultureInfo("en-US")),
                        VL_Pac = Convert.ToDecimal(row["VL_Pac06"].ToString(), new CultureInfo("en-US")),
                        VL_Vdc = Convert.ToDecimal(row["VL_Vdc06_01"].ToString(), new CultureInfo("en-US")),
                        VL_Iac = Convert.ToDecimal(row["VL_Iac06"].ToString(), new CultureInfo("en-US")),
                        Total = Convert.ToDecimal(row["VL_ETotal06"].ToString(), new CultureInfo("en-US")),
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
