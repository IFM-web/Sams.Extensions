using Sams.Extensions.Model;
using Sams.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Sams.Extensions.Web.Models
{
    public class VEIWMODEL
    {
        public List<MaxAuditReport> maxaudit { get; set; }
        public MIDHEAD midhead { get; set; }
        public List<SUBHEADER> subheader { get; set; }

        public List<MaxAuditReport1> maxaudit1 { get; set; }
        public MIDHEAD1 midhead1 { get; set; }
        public List<SUBHEADER1> subheader1 { get; set; }
    }

    public class MaxAuditReport
    {
        public int ChecklistAutoID { get; set; }
        public int CHECKLIST_ID { get; set; }
        public string  MAINHEADER{ get; set; }
        public string SUBHEADER{ get; set; }
        public int NEWCHECKLISTID { get; set; }
        public int NEWCHECKLISTFORORDERBY { get; set; }
        public string CHECKLISTTYPE { get; set; }
        public string BRANCHCODE { get; set; }
        public string TEXT { get; set; }
        public string REMARKS { get; set; }
        public int ROWCOUNT { get; set; }
        public int HEADERINDEX { get; set; }
        public int IMGAUTO_ID { get; set; }
        public int LocationAutoId { get; set; }

    }
    public class MaxAuditReport1
    {
        public int ChecklistAutoID { get; set; }
        public int CHECKLIST_ID { get; set; }
        public string MAINHEADER { get; set; }
        public string SUBHEADER { get; set; }
        public int NEWCHECKLISTID { get; set; }
        public int NEWCHECKLISTFORORDERBY { get; set; }
        public string CHECKLISTTYPE { get; set; }
        public string BRANCHCODE { get; set; }
        public string TEXT { get; set; }
        public string REMARKS { get; set; }
        public int ROWCOUNT { get; set; }
        public int HEADERINDEX { get; set; }
        public int IMGAUTO_ID { get; set; }
        public int LocationAutoId { get; set; }

    }

    public class MIDHEAD
    {
       public string BRANCHCODE { get; set; }
       public string  BRANCHNAME { get; set; }
       public string FONAME { get; set; }
       public string AUDITTIME { get; set; }
       public string SPOCNAME { get; set; }
       public string SPOCNUMBER { get; set; }
       public string CHECKLISTYPE { get; set; }
    }
    public class MIDHEAD1
    {
        public string BRANCHCODE { get; set; }
        public string BRANCHNAME { get; set; }
        public string FONAME { get; set; }
        public string AUDITTIME { get; set; }
        public string SPOCNAME { get; set; }
        public string SPOCNUMBER { get; set; }
        public string CHECKLISTYPE { get; set; }
    }
    public class  SUBHEADER
    {
        public string MAINHEADER { get; set; }  
    }
    public class SUBHEADER1
    {
        public string MAINHEADER { get; set; }
        public int CHECKLISTID { get; set; }
    }
}