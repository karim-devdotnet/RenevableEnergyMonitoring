using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REM.Model.Entities
{
    public class CsvImportHistory
    {
        public CsvImportHistory()
            {
                Id = Guid.NewGuid();
            }
    
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string NameFile { get; set; }
        public int NbrLine { get; set; }
        
    }
    
}
