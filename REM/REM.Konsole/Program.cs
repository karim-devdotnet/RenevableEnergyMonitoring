using REM.Data;
using REM.Model.Entities;
using System;
using System.Collections.Generic;

namespace REM.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new REMContext())
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
                db.SaveChanges();

            }
        }
    }
}
