using PagedList;
using REM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REM.Web.Models
{
    public class MeteosListViewModel
    {
        public IPagedList<Meteo> MeteoPagedList { get; set; }
    }
}