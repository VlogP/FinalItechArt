﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
   public class PatientTableViewDTO
    {
       
        public int PatientId { get; set; }
        public string PatientFirstname { get; set; }
        public string PatientLastname { get; set; }
        public string ClinicName { get; set; }
        public string ClinicId { get; set; }
        public string BirthDate { get; set; }      
        public string VisitLast { get; set; }
        public string UsedDrugs { get; set; }
        public string Status { get; set; }

    }
}
