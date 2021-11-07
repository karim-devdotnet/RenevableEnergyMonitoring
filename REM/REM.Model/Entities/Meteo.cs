using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REM.Model.Entities
{
    public class Meteo
    {
        

        [Key]
        public string Id { get; set; } 

        [NotMapped]
        private DateTime _Timestamp;
        public DateTime Timestamp
        {
            get
            {
                return _Timestamp;
            }
            set
            {
                _Timestamp = value;
                Id =  _Timestamp.ToString("yyyyMMddhhmmss");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Irradiance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TemperatureOfModule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TemperatureAmbiante { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Humidity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal SpeedOfWind { get; set; }

        public virtual ICollection<Onduleur> Onduleurs{ get; set; }
    }
}
