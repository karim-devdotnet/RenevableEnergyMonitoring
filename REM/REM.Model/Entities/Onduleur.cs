using System;

namespace REM.Model.Entities
{
    public class Onduleur
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string  Designation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal VL_Vac { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal VL_Fac { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal VL_Pac { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal VL_Vdc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Total { get; set; }

        public virtual Meteo Meteo { get; set; }
    }
}
