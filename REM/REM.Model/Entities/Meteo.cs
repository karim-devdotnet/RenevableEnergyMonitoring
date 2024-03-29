﻿using System;
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

        [Display(Name ="Temps")]
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
        [Display(Name ="Temperature du module")]
        public decimal TemperatureOfModule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name ="Temperature ambiante")]
        public decimal TemperatureAmbiante { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name ="Humidite")]
        public decimal Humidity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name ="Vitesse du vent")]
        public decimal SpeedOfWind { get; set; }

        public virtual ICollection<Onduleur> Onduleurs{ get; set; }

        public override string ToString()
        {
            return $"ID:{Id}";
        }
    }
}
