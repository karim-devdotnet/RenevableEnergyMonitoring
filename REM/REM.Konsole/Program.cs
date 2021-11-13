using REM.Data;
using REM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace REM.Konsole
{
    class Program
    {
       public class  Met
        {
            public DateTime d;
            public Decimal irr;
            public int tMod;
            public int tAmb;
            public decimal hum;
            public decimal wind;
                      
        }


        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\Users\Montassar\Desktop\steg.csv"))
            {
                reader.ReadLine();

                var line = reader.ReadLine();
                var values = line.Split(';');
                //List<Met> listM = new List<Met>();
                Console.WriteLine(values[1]);

                var m = new Met();
                m.d = DateTime.Parse(values[0]);
                m.irr = Convert.ToDecimal(values[1]);
                //m.tMod = int.Parse(values[2]);
                //m.irr = 1;
               m.tMod = 0;
                m.tAmb = 0; m.hum = 0;
                m.wind = 0;
                // m.tAmb = Int32.Parse(values[3]);
                // m.hum = Convert.ToDecimal(values[4]);
                //m.wind = Decimal.Parse(values[40]);


                using (var db = new REMContext())
                {
                    var meteo = new Meteo
                    {
                        Timestamp = m.d,
                        Irradiance=m.irr,
                        TemperatureOfModule=m.tMod,
                        TemperatureAmbiante=m.tAmb,
                        Humidity=m.hum,
                        SpeedOfWind=m.wind,

                    };
                    db.Meteos.Add(meteo);
                    db.SaveChanges();
                }
            }
        }
     }

 }


                    





                    /*using (var db = new REMContext())
                     {
                         var meteo = new Meteo
                         {
                             //Timestamp = DateTime.Parse(values[0]),
                             Timestamp = DateTime.Now,
                             Irradiance = Convert.ToDecimal(values[1]),
                             TemperatureOfModule= Int32.Parse(values[2]),
                             TemperatureAmbiante=Int32.Parse(values[3]),
                             Humidity=Convert.ToDecimal(values[4]),
                             SpeedOfWind= Convert.ToDecimal(values[40]),


                         };
                         db.Meteos.Add(meteo);
                         db.SaveChanges();

                     }
                 }
             }

             /*using (var db = new REMContext())
             {
                 var meteo = new Meteo
                 {
                     Timestamp = DateTime.Now,
                     TemperatureOfModule = 100,
                     TemperatureAmbiante=40,
                     Onduleurs = new List<Onduleur>
                     {
                         new Onduleur{Id=1,Timestamp=DateTime.Now,Designation ="Ond1", VL_Fac=12,VL_Vac=4,VL_Pac=6, VL_Vdc=8},
                         new Onduleur{Id=2,Timestamp=DateTime.Now,Designation ="Ond2", VL_Fac=12,VL_Vac=4,VL_Pac=6, VL_Vdc=8},
                         new Onduleur{Id=3,Timestamp=DateTime.Now,Designation ="Ond3", VL_Fac=12,VL_Vac=4,VL_Pac=6, VL_Vdc=8}
                     }
                 };

                 db.Meteos.Add(meteo);
                 db.SaveChanges();*/


             
         
     

