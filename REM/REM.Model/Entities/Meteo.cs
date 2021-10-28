using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REM.Model.Entities
{
    public class Meteo
    {
        [NotMapped]
        private long _Id;

        [Key]
        public long Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = Convert.ToInt64(Timestamp.ToString("yyyyMMddhhmm"));
            }
        }
        public DateTime Timestamp { get; set; }
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
