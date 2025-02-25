﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sams.Extensions.Model
{
    public class  FsaReportHeader
    {
        [Display(Name = "MLI Location Name")]
        public string ClientDetails { get; set; }
        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }
        [Display(Name = "Year")]
        public string Year { get; set; }
        public string AuditDate { get; set; }
    }

    public class FsaReportDetails
    {
        [Display(Name ="S.No")]
        public string ShowID { get; set; }
        public string Category { get; set; }
        public string Audit { get; set; }
        [Display(Name = "Action")]
        public string RequiredAction { get; set; }
        [Display(Name = "Picture")]

        public string Pictures { get; set; }
    }

    public class FsaReportFooter
    {

        [Display(Name = "S.No")]
        public string ChecklistID { get; set; }
        public string Category { get; set; }
        public string Qty { get; set; }
        public string Pictures { get; set; }
        public string Audit { get; set; }
       
    }
    public class CustomReportDetails
    {
        public IEnumerable<string> HeaderRequiredFields { get; set; }
        public IEnumerable<string> HeaderCompareFields { get; set; }

        public IEnumerable<string> DetailRequiredFields { get; set; }
        public IEnumerable<string> DetailCompareFields { get; set; }

        public IEnumerable<string> FooterRequiredFields { get; set; }
        public IEnumerable<string> FooterCompareFields { get; set; }
    }
}
