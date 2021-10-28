using REM.Data;
using REM.Model.Entities;
using System;

namespace REM.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new REMContext())
            {
                var meteao = new Meteo
                {
                    Timestamp = DateTime.Now
                };

                db.Meteos.Add(meteao);
                db.SaveChanges();

            }
        }
    }
}
