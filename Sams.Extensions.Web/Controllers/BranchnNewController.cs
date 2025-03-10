using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Sams.Extensions.Business;
using Sams.Extensions.Dal;
using Sams.Extensions.Logger;
using Sams.Extensions.Model;
using Sams.Extensions.Web.Models;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.util;
using System.Web;
using System.Web.Mvc;
using PdfSharp.Pdf;
using System.Drawing;
using System.Drawing.Imaging;

using TheArtOfDev.HtmlRenderer.PdfSharp;


using PageSize = PdfSharpCore.PageSize;
using DocumentFormat.OpenXml.Spreadsheet;
using PdfSharp;
using SelectPdf;
using PdfDocument = SelectPdf.PdfDocument;
using System.Net.Http;
using System.Threading.Tasks;
using IronSoftware.Forms;
using System.Drawing.Imaging;
using System.Security.Policy;
using System.Windows.Interop;
using System.Net.NetworkInformation;
using System.Web.Hosting;



namespace Sams.Extensions.Web.Controllers
{
    //[CustomAuthorizeAttribute]
    public class BranchNewController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private readonly IMasterBusiness _master;
        private readonly ILoggerManager _loggerManager;
        private readonly IBranchCodeData _dataAccesLayer;
        private readonly PdfSharp.PageSize pageSize;

        public BranchNewController(IMasterBusiness master, ILoggerManager loggerManager, IBranchCodeData dataAccesLayer)
        {
            _master = master;
            _loggerManager = loggerManager;
            _dataAccesLayer = dataAccesLayer;
        }
        public ActionResult MaxAudit(string Branch, string AuditDate, string Location, string ChecklistType)
        {



            VEIWMODEL vm = new VEIWMODEL();
            List<MaxAuditReport> mar = new List<MaxAuditReport>();
            List<MaxAuditReport1> mar1 = new List<MaxAuditReport1>();
            MIDHEAD mh = new MIDHEAD();
            MIDHEAD1 mh1 = new MIDHEAD1();
            List<SUBHEADER> sh = new List<SUBHEADER>();
            List<SUBHEADER1> sh1 = new List<SUBHEADER1>();

            //var data = _dataAccesLayer.GetReportValuesV2(Location, Branch, AuditDate, ChecklistType);
            SqlCommand cmd = new SqlCommand("udp_GetMaxReportValuesUpdatedV2_New", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clientcode", Branch);
            cmd.Parameters.AddWithValue("@LocationautoId", Location);
            cmd.Parameters.AddWithValue("@FromDate", AuditDate);
            //cmd.Parameters.AddWithValue("@ChecklistType", ChecklistType);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataSet dset = new DataSet();

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {



                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    mar.Add(new MaxAuditReport
                    {
                        CHECKLIST_ID = Convert.ToInt32(dr["ChecklistId"]),
                        MAINHEADER = Convert.ToString(dr["MainHeader"]),
                        SUBHEADER = Convert.ToString(dr["SubHeader"]),
                        NEWCHECKLISTID = Convert.ToInt32(dr["NewChecklistId"]),
                        NEWCHECKLISTFORORDERBY = Convert.ToInt32(dr["NewChecklistIdForOrderBy"]),
                        CHECKLISTTYPE = Convert.ToString(dr["ChecklistType"]),
                        BRANCHCODE = Convert.ToString(dr["BranchCode"]),
                        TEXT = Convert.ToString(dr["Text"]),
                        REMARKS = Convert.ToString(dr["Remarks"]),
                        ROWCOUNT = Convert.ToInt32(dr["row_count"]),
                        HEADERINDEX = Convert.ToInt32(dr["HeaderIndex"]),
                        IMGAUTO_ID = Convert.ToInt32(dr["ImageAutoId"]),
                        LocationAutoId = Convert.ToInt32(dr["LocationAutoId"]),
                    });
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {


                foreach (DataRow dr in ds.Tables[1].Rows)
                {

                    mh.BRANCHCODE = Convert.ToString(dr["BranchCode"]);
                    mh.BRANCHNAME = Convert.ToString(dr["BranchName"]);
                    mh.FONAME = Convert.ToString(dr["FOName"]);
                    mh.AUDITTIME = Convert.ToString(dr["AuditTime"]);
                    mh.SPOCNAME = Convert.ToString(dr["SpocName"]);
                    mh.SPOCNUMBER = Convert.ToString(dr["SpocNumber"]);
                    mh.CHECKLISTYPE = Convert.ToString(dr["ChecklistType"]);
                    //dset = Fill("select * from MaxLifeChecklistImageMaster where ChecklistType=N'securityGuard' and BranchCode='" + dr["BranchCode"] + "' and USERID='" + dr["FOName"] + "' and  ChecklistId in (31, 37)");
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sh.Add(new SUBHEADER
                    {
                        MAINHEADER = Convert.ToString(dr["MainHeader"]),

                    });
                    sh.Distinct().OrderBy(x => x.MAINHEADER).ToList();
                }

            }
            if (ds.Tables[2].Rows.Count > 0)
            {


                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    mar1.Add(new MaxAuditReport1
                    {
                        CHECKLIST_ID = Convert.ToInt32(dr["ChecklistId"]),
                        MAINHEADER = Convert.ToString(dr["MainHeader"]),
                        SUBHEADER = Convert.ToString(dr["SubHeader"]),
                        NEWCHECKLISTID = Convert.ToInt32(dr["NewChecklistId"]),
                        NEWCHECKLISTFORORDERBY = Convert.ToInt32(dr["NewChecklistIdForOrderBy"]),
                        CHECKLISTTYPE = Convert.ToString(dr["ChecklistType"]),
                        BRANCHCODE = Convert.ToString(dr["BranchCode"]),
                        TEXT = Convert.ToString(dr["Text"]),
                        REMARKS = Convert.ToString(dr["Remarks"]),
                        ROWCOUNT = Convert.ToInt32(dr["row_count"]),
                        HEADERINDEX = Convert.ToInt32(dr["HeaderIndex"]),
                        IMGAUTO_ID = Convert.ToInt32(dr["ImageAutoId"]),
                        LocationAutoId = Convert.ToInt32(dr["LocationAutoId"]),
                    });
                }
            }
            if (ds.Tables[3].Rows.Count > 0)
            {


                foreach (DataRow dr in ds.Tables[3].Rows)
                {


                    mh1.BRANCHCODE = Convert.ToString(dr["BranchCode"]);
                    mh1.BRANCHNAME = Convert.ToString(dr["BranchName"]);
                    mh1.FONAME = Convert.ToString(dr["FOName"]);
                    mh1.AUDITTIME = Convert.ToString(dr["AuditTime"]);
                    mh1.SPOCNAME = Convert.ToString(dr["SpocName"]);
                    mh1.SPOCNUMBER = Convert.ToString(dr["SpocNumber"]);
                    mh1.CHECKLISTYPE = Convert.ToString(dr["ChecklistType"]);

                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {


                dset = Fill("select * from MaxLifeChecklistImageMaster where ChecklistType=N'securityGuard' and BranchCode='" + Branch + "' and USERID='" + ds.Tables[1].Rows[0]["FOName"] + "' and  ChecklistId in (31, 37) and (convert(varchar,cast(datetime as date),106)) ='" + AuditDate + "' ");

            }


            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                sh1.Add(new SUBHEADER1
                {
                    MAINHEADER = Convert.ToString(dr["MainHeader"]),
                    CHECKLISTID = Convert.ToInt32(dr["CHECKLISTID"]),

                });
                //sh1.Distinct().OrderBy(x => x.MAINHEADER).ToList();
            }
            vm.maxaudit = mar;
            vm.midhead = mh;
            vm.subheader = sh;
            vm.maxaudit1 = mar1;
            vm.midhead1 = mh1;
            vm.subheader1 = sh1;
            ViewBag.checklisttype = ChecklistType;

            if (dset.Tables[0].Rows.Count > 0)
            {
                byte[] byteData = (byte[])dset.Tables[0].Rows[0]["image"];
                string imreBase64Data = Convert.ToBase64String(byteData);
                string imgDataURL = string.Format("data:image/jpeg;base64,{0}", imreBase64Data);
                //Passing image data in viewbag to view
                ViewBag.Image1 = imgDataURL;
                if (dset.Tables[0].Rows.Count > 1)
                {
                    byte[] byteData1 = (byte[])dset.Tables[0].Rows[1]["image"];
                    string imreBase64Data1 = Convert.ToBase64String(byteData1);
                    string imgDataURL1 = string.Format("data:image/jpeg;base64,{0}", imreBase64Data1);
                    //ViewBag.Image1 = dset.Tables[0].Rows[0]["image"];
                    ViewBag.Image2 = imgDataURL1;
                }
            }
            //var data = _dataAccesLayer.GetReportValuesV2(Location, Branch, AuditDate, ChecklistType);
            return View(vm);




        }
        #region MaxAuditPDF 
        public ActionResult MaxAuditPDF(string Branch, string AuditDate, string Location, string ChecklistType)
        //public ActionResult MaxAuditPDF()
        {

            //string url = "http://localhost:50292/BranchNew/MaxAudit?Branch=APKT1&AuditDate=17%20Feb%202025&Location=206&ChecklistType=Housekeeping";



            // Fetch HTML from the URL
            var client = new WebClient();

            //string htmlCode = client.DownloadString(url);
            //           PdfDocument pdf = PdfGenerator.GeneratePdf(htmlCode,PdfSharp.PageSize.A4);
            //           pdf.Save("url_to_pdf.pdf");



            //SelectPdf.PdfDocument doc = converter.ConvertUrl("http://localhost:50292/BranchNew/MaxAudit?Branch=APKT1&AuditDate=17%20Feb%202025&Location=206&ChecklistType=Housekeeping");
            //SelectPdf.PdfDocument doc = converter.ConvertHtmlString(HTMLContent.ToString());
            //doc.Save("test.pdf");

            //MemoryStream stream = new MemoryStream();

            //doc.Save(stream)
            //;

            //return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Receipt.pdf");
            //  doc.Save("RECEIPT.pdf");
            //return "RECEIPT.pdf";

            //VEIWMODEL vm = new VEIWMODEL();
            //List<MaxAuditReport> mar = new List<MaxAuditReport>();
            //List<MaxAuditReport1> mar1 = new List<MaxAuditReport1>();
            //MIDHEAD mh = new MIDHEAD();
            //MIDHEAD1 mh1 = new MIDHEAD1();
            //List<SUBHEADER> sh = new List<SUBHEADER>();
            //List<SUBHEADER1> sh1 = new List<SUBHEADER1>();

            //var data = _dataAccesLayer.GetReportValuesV2(Location, Branch, AuditDate, ChecklistType);
            SqlCommand cmd = new SqlCommand("udp_GetMaxReportValuesUpdatedV2_New", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clientcode", Branch);
            cmd.Parameters.AddWithValue("@LocationautoId", Location);
            cmd.Parameters.AddWithValue("@FromDate", AuditDate);
            //cmd.Parameters.AddWithValue("@ChecklistType", ChecklistType);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataSet dset = new DataSet();
            da.Fill(ds);



            var td2 = ds.Tables[2]; // HOurseKeeping 

            var td3 = ds.Tables[3]; // HOurseKeeping header

            var td0 = ds.Tables[0]; // SecurityGuard

            var td1 = ds.Tables[1]; //SecurityGuard header
            StringBuilder sb = new StringBuilder();

            string htmldesign = $@"
     <!DOCTYPE html>
     <html lang=""en"">
     <head>
         <meta charset=""UTF-8"">
         <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

     </head>
     <body style=""font-family: Arial, sans-serif; margin: 40px; padding: 0;"">
         <!-- Logo and Header -->

 <style>
 <style>
 body
 {{

    margin-bottom: 10px;
 }}
     table {{
         width: 100%;
         border-collapse: collapse;
     }}
     td, th {{
         border: 1px solid black;
         padding: 8px;
         text-align: center;
     }}
     tr {{
         page-break-inside: avoid; 
     }}
  th {{
         page-break-inside: avoid; 
     }}
     img {{
         max-width: 150px;
         max-height: 125px;
         display: block;
         margin: auto;
     }}
 </style>

 </style>

   <div id=""FinalReport"" style=""padding: 10px; text-align: center;"">
             <img style=""width: 120px; padding-bottom: 8px; margin-left: 804px;"" src=""~/Images/logo.png"" /><br />
         </div>
       <table class=""table-bordered"" style=""
                width: 100%; text-align:center; border-spacing:0px;
                "">
                 <thead>
                     <tr style=""margin-bottom:10px;"">
                         <th colspan=""5"" style=""background-color: #EB8317; color: white; font-family: Arial; font-size: 11px; font-weight: bold; border: 1px solid #000000 !important; padding: 10px; font-size: 20px; margin-bottom: 10px;"">
                             AXIS MAX LIFE BRANCH SUPERVISOR VISIT REPORT
                         </th>

                     </tr>

                     <tr style=""color:black;font-family:Arial;font-size:11px;font-weight:bold;"">
                         <th style=""border: 1px solid #000000 !important;padding: 10px;"">Branch Code</th>
                         <th style=""border: 1px solid #000000 !important;padding: 10px;"">Branch Name</th>
                         <th style=""border: 1px solid #000000 !important;padding: 10px;"">APS Representative</th>
                         <th style=""border: 1px solid #000000 !important;padding: 10px;"">Visit date</th>

                     </tr>
                 </thead>
  <tbody>";

            sb.Append(htmldesign);

            foreach (DataRow dr in td3.Rows)

            {
                htmldesign = $@"<tr>
                                 <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">{Convert.ToString(dr["BranchCode"])}</td>
                              <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">{Convert.ToString(dr["BranchName"])}</td>
                              <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">{Convert.ToString(dr["FOName"])}</td>
                              <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">{Convert.ToString(dr["AuditTime"])}</td>
                              </tr>
                             </tbody>
                             </table>
                             ";
            }
            sb.Append(htmldesign);


            htmldesign = @"
         <table style=""width: 100%; border-collapse: collapse; margin-top: 20px""> <thead>
                 <tr  id=""row1"" style=""background-color: #EB8317; color: White; font-family: Arial; font-size: 11px; font-weight: bold; "">
                   <th style=""border: 1px solid #000000 !important;padding: 10px;width:9.7%"""" class=""""Column1 text-center"""">
                             S.No.
         </th>
               <th style = ""border: 1px solid #000000 !important;padding: 10px;width:20%"""" class=""""Column2 text-center"""">
                             Question
                         </ th >
                         <th style = ""border: 1px solid #000000 !important; padding: 10px;width:19%"" class=""Column3 text-center"">
                             Response
                         </ th >
                         <th style = ""border: 1px solid #000000 !important; padding: 10px;width:27%"" class=""Column4 text-center"">
                             Photo
                         </ th >
                         <th style = ""border: 1px solid #000000 !important;padding: 10px;width:25%"" class=""Column5 text-center"">
                             Comments
                         </ th >     
                 </tr>
             </thead>
             <tbody>";

            sb.Append(htmldesign);
            //  foreach (DataRow dr in td2.Rows)

            //{
            string mainHeader = Convert.ToString(td2.Rows[0]["MainHeader"]);
            string CHECKLISTYPE = Convert.ToString(td3.Rows[0]["ChecklistType"]);

            var distinctHeaders = td2.AsEnumerable()
                    .Select(row => row["MAINHEADER"].ToString())
                    .Distinct();
            htmldesign = $@"
                      <table class=""table-bordered"" style=""width: 100%;border-spacing:0px;"">
                                     <thead>

                                         <tr>
                                             <th colspan=""5"" style=""background-color: silver;color:black;font-family:Arial;font-size:11px;font-weight:bold;text-align:center;padding:5px;width: 1px;border: 1px solid #000000 !important;padding: 10px;"">
                                                 {CHECKLISTYPE}
                                             </th>
                                         </tr>
                                     </thead>
                                 </table>";
            sb.Append(htmldesign);
            foreach (var item in distinctHeaders)
            {



                htmldesign = $@" 

     <table id=""table2"" class=""table-bordered"" style=""width: 100%;border-spacing:0px;"">
         <thead>
             <tr>
                 <th colspan=""5"" style=""background-color: silver;color:black;font-family:Arial;font-size:11px;font-weight:bold;text-align:center;padding:5px;width: 1px;border: 1px solid #000000 !important;"">
                     {item}
                 </th>
             </tr>
         </thead>
         <tbody>";

                sb.Append(htmldesign);
                foreach (DataRow dr1 in td2.Rows)
                {


                    if (dr1["MAINHEADER"].ToString() == item)

                        htmldesign = $@"
                         <tr>
                             <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                 {Convert.ToString(dr1["row_count"])}
                             </td>
                             <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                 {Convert.ToString(dr1["SubHeader"])}
                             </td>
                             <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                 {Convert.ToString(dr1["Text"])}
                             </td>
                             <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                 <img style=""width:150px; height:125px; margin: 0 auto;""
                                      src=""https://ifm360.in/ApsReportingPortal/BranchNew/RetrieveImage?ImageId={Convert.ToString(dr1["ImageAutoId"])}""/>
                             </td>
                             <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                 {Convert.ToString(dr1["Remarks"])}
                             </td>
                         </tr>";

                    sb.Append(htmldesign);
                }
            }
            //}

            //---- SecurityGuard start here-------------------------------

            string CHECKLISTYPE2 = Convert.ToString(td1.Rows[0]["ChecklistType"]);

            htmldesign += $@"  <table class=""""table-bordered"""" style=""""
                 width: 100%; text-align:center; border-spacing:0px;
                 """">
                  <thead>

                   <tr><th>{CHECKLISTYPE2}</th>
  </tr>
                      <tr style=""""color:black;font-family:Arial;font-size:11px;font-weight:bold;"""">
                          <th style=""""border: 1px solid #000000 !important;padding: 10px;"""">Branch Code</th>
                          <th style=""""border: 1px solid #000000 !important;padding: 10px;"""">Branch Name</th>
                          <th style=""""border: 1px solid #000000 !important;padding: 10px;"""">APS Representative</th>
                          <th style=""""border: 1px solid #000000 !important;padding: 10px;"""">Visit date</th>

                      </tr>
                  </thead>
   <tbody>";

            string mainHeader2 = Convert.ToString(td0.Rows[0]["MAINHEADER"]);


            var distinctHeaders2 = td0.AsEnumerable()
                    .Select(row => row["MainHeader"].ToString())
                    .Distinct();

            foreach (var item in distinctHeaders2)
            {

                htmldesign += $@" 

        <table id=""table2"" class=""table-bordered"" style=""width: 100%;border-spacing:0px;"">
            <thead>
                <tr>
                    <th colspan=""5"" style=""background-color: silver;color:black;font-family:Arial;font-size:11px;font-weight:bold;text-align:center;padding:5px;width: 1px;border: 1px solid #000000 !important;"">
                        {item}
                    </th>
                </tr>
            </thead>
            <tbody>";

                foreach (DataRow dr1 in td0.Rows)
                {

                    if (dr1["MAINHEADER"].ToString() == item)

                        htmldesign += $@"
                            <tr>
                                <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                    {Convert.ToString(dr1["NewChecklistIdForOrderBy"])}
                                </td>
                                <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                    {Convert.ToString(dr1["SubHeader"])}
                                </td>
                                <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                    {Convert.ToString(dr1["Text"])}
                                </td>
                                <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                    <img style=""width:150px; height:125px; margin: 0 auto;""
                                         src=""https://ifm360.in/ApsReportingPortal/BranchNew/RetrieveImage?ImageId={Convert.ToString(dr1["ImageAutoId"])}""/>
                                </td>
                                <td style=""border: 1px solid #000; padding: 8px; text-align: center;"">
                                    {Convert.ToString(dr1["Remarks"])}
                                </td>
                            </tr>";


                }
            }




            // Initialize the HTML to PDF converter
            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.JpegCompressionLevel = 70;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginTop = 20;
            converter.Options.MarginBottom = 20;
            converter.Options.MarginLeft = 10;




            converter.Options.KeepImagesTogether = true;
            converter.Options.KeepTextsTogether = true;

            converter.Options.JavaScriptEnabled = true;

            //converter.Options.ManualPdfCreationDelay = 2000; // 2 seconds

            converter.Options.MaxPageLoadTime = 60000;



            string url = "http://localhost:50292/BranchNew/MaxAudit?Branch=AAMB1&AuditDate=07%20Mar%202025&Location=206&ChecklistType=SecurityGuard";


            //SelectPdf.PdfDocument doc = converter.ConvertUrl("http://localhost:50292/BranchNew/MaxAudit?Branch=AAMB1&AuditDate=07%20Mar%202025&Location=206&ChecklistType=SecurityGuard");

            using (WebClient webClient = new WebClient())
            using (Stream htmlStream = webClient.OpenRead(url)) // ✅ Corrected method
            using (StreamReader reader = new StreamReader(htmlStream))
            {
                string html = reader.ReadToEnd();

                // ✅ Convert to PDF

                PdfDocument doc1 = converter.ConvertHtmlString(html);

                // ✅ Save the PDF
                // doc1.Save("Downloads/file.pdf");
                //doc1.Close();

                using (MemoryStream memoryStream = new MemoryStream())
                {

                    try
                    {
                        doc1.Save(memoryStream);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    doc1.Close();


                    DateTime date = DateTime.Now;
                    var namedate = date.ToString("dd-MM-yyyy-HH-mm-ss-fff");
                    string fileName = $"{namedate}.pdf";


                    return File(memoryStream.ToArray(), "application/octet-stream", fileName);
                }





            }







            return View();
        }




        #endregion




        public ActionResult EditMaxAudit(string Branch, string AuditDate, string Location, string ChecklistType)
        {



            VEIWMODEL vm = new VEIWMODEL();
            List<MaxAuditReport> mar = new List<MaxAuditReport>();
            List<MaxAuditReport1> mar1 = new List<MaxAuditReport1>();
            MIDHEAD mh = new MIDHEAD();
            MIDHEAD1 mh1 = new MIDHEAD1();
            List<SUBHEADER> sh = new List<SUBHEADER>();
            List<SUBHEADER1> sh1 = new List<SUBHEADER1>();

            //var data = _dataAccesLayer.GetReportValuesV2(Location, Branch, AuditDate, ChecklistType);
            SqlCommand cmd = new SqlCommand("udp_GetMaxReportValuesUpdatedV2_New", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clientcode", Branch);
            cmd.Parameters.AddWithValue("@LocationautoId", Location);
            cmd.Parameters.AddWithValue("@FromDate", AuditDate);
            //cmd.Parameters.AddWithValue("@ChecklistType", ChecklistType);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataSet dset = new DataSet();

            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mar.Add(new MaxAuditReport
                {
                    ChecklistAutoID = Convert.ToInt32(dr["ChecklistAutoID"]),
                    CHECKLIST_ID = Convert.ToInt32(dr["ChecklistId"]),
                    MAINHEADER = Convert.ToString(dr["MainHeader"]),
                    SUBHEADER = Convert.ToString(dr["SubHeader"]),
                    NEWCHECKLISTID = Convert.ToInt32(dr["NewChecklistId"]),
                    NEWCHECKLISTFORORDERBY = Convert.ToInt32(dr["NewChecklistIdForOrderBy"]),
                    CHECKLISTTYPE = Convert.ToString(dr["ChecklistType"]),
                    BRANCHCODE = Convert.ToString(dr["BranchCode"]),
                    TEXT = Convert.ToString(dr["Text"]),
                    REMARKS = Convert.ToString(dr["Remarks"]),
                    ROWCOUNT = Convert.ToInt32(dr["row_count"]),
                    HEADERINDEX = Convert.ToInt32(dr["HeaderIndex"]),
                    IMGAUTO_ID = Convert.ToInt32(dr["ImageAutoId"]),
                    LocationAutoId = Convert.ToInt32(dr["LocationAutoId"]),
                });
            }
            foreach (DataRow dr in ds.Tables[1].Rows)
            {

                mh.BRANCHCODE = Convert.ToString(dr["BranchCode"]);
                mh.BRANCHNAME = Convert.ToString(dr["BranchName"]);
                mh.FONAME = Convert.ToString(dr["FOName"]);
                mh.AUDITTIME = Convert.ToString(dr["AuditTime"]);
                mh.SPOCNAME = Convert.ToString(dr["SpocName"]);
                mh.SPOCNUMBER = Convert.ToString(dr["SpocNumber"]);
                mh.CHECKLISTYPE = Convert.ToString(dr["ChecklistType"]);
                //dset = Fill("select * from MaxLifeChecklistImageMaster where ChecklistType=N'securityGuard' and BranchCode='" + dr["BranchCode"] + "' and USERID='" + dr["FOName"] + "' and  ChecklistId in (31, 37)");
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sh.Add(new SUBHEADER
                {
                    MAINHEADER = Convert.ToString(dr["MainHeader"]),

                });
                sh.Distinct().OrderBy(x => x.MAINHEADER).ToList();
            }
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                mar1.Add(new MaxAuditReport1
                {
                    ChecklistAutoID = Convert.ToInt32(dr["ChecklistAutoID"]),
                    CHECKLIST_ID = Convert.ToInt32(dr["ChecklistId"]),
                    MAINHEADER = Convert.ToString(dr["MainHeader"]),
                    SUBHEADER = Convert.ToString(dr["SubHeader"]),
                    NEWCHECKLISTID = Convert.ToInt32(dr["NewChecklistId"]),
                    NEWCHECKLISTFORORDERBY = Convert.ToInt32(dr["NewChecklistIdForOrderBy"]),
                    CHECKLISTTYPE = Convert.ToString(dr["ChecklistType"]),
                    BRANCHCODE = Convert.ToString(dr["BranchCode"]),
                    TEXT = Convert.ToString(dr["Text"]),
                    REMARKS = Convert.ToString(dr["Remarks"]),
                    ROWCOUNT = Convert.ToInt32(dr["row_count"]),
                    HEADERINDEX = Convert.ToInt32(dr["HeaderIndex"]),
                    IMGAUTO_ID = Convert.ToInt32(dr["ImageAutoId"]),
                    LocationAutoId = Convert.ToInt32(dr["LocationAutoId"]),
                });
            }
            foreach (DataRow dr in ds.Tables[3].Rows)
            {


                mh1.BRANCHCODE = Convert.ToString(dr["BranchCode"]);
                mh1.BRANCHNAME = Convert.ToString(dr["BranchName"]);
                mh1.FONAME = Convert.ToString(dr["FOName"]);
                mh1.AUDITTIME = Convert.ToString(dr["AuditTime"]);
                mh1.SPOCNAME = Convert.ToString(dr["SpocName"]);
                mh1.SPOCNUMBER = Convert.ToString(dr["SpocNumber"]);
                mh1.CHECKLISTYPE = Convert.ToString(dr["ChecklistType"]);

            }
            dset = Fill("select * from MaxLifeChecklistImageMaster where ChecklistType=N'securityGuard' and BranchCode='" + Branch + "' and USERID='" + ds.Tables[1].Rows[0]["FOName"] + "' and  ChecklistId in (31, 37) and (convert(varchar,cast(datetime as date),106)) ='" + AuditDate + "' ");
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                sh1.Add(new SUBHEADER1
                {
                    MAINHEADER = Convert.ToString(dr["MainHeader"]),
                    CHECKLISTID = Convert.ToInt32(dr["CHECKLISTID"]),

                });
                //sh1.Distinct().OrderBy(x => x.MAINHEADER).ToList();
            }
            vm.maxaudit = mar;
            vm.midhead = mh;
            vm.subheader = sh;
            vm.maxaudit1 = mar1;
            vm.midhead1 = mh1;
            vm.subheader1 = sh1;
            ViewBag.checklisttype = ChecklistType;
            if (dset.Tables[0].Rows.Count > 0)
            {
                byte[] byteData = (byte[])dset.Tables[0].Rows[0]["image"];
                string imreBase64Data = Convert.ToBase64String(byteData);
                string imgDataURL = string.Format("data:image/jpeg;base64,{0}", imreBase64Data);
                //Passing image data in viewbag to view
                ViewBag.Image1 = imgDataURL;
                if (dset.Tables[0].Rows.Count > 1)
                {
                    byte[] byteData1 = (byte[])dset.Tables[0].Rows[1]["image"];
                    string imreBase64Data1 = Convert.ToBase64String(byteData1);
                    string imgDataURL1 = string.Format("data:image/jpeg;base64,{0}", imreBase64Data1);
                    //ViewBag.Image1 = dset.Tables[0].Rows[0]["image"];
                    ViewBag.Image2 = imgDataURL1;
                }
            }
            //var data = _dataAccesLayer.GetReportValuesV2(Location, Branch, AuditDate, ChecklistType);
            return View(vm);




        }




        public DataSet Fill(string sql)
        {
            DataSet ds = new DataSet();

            using (SqlConnection sqcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    SqlCommand sqcmd = new SqlCommand(sql, sqcon);
                    sqcmd.CommandTimeout = 0;
                    SqlDataAdapter SqlDa = new SqlDataAdapter(sqcmd);
                    SqlDa.Fill(ds);

                }
                catch (Exception exce)
                {
                    throw exce;
                }
            }
            return ds;
        }

        public string ExecQuery(string query)
        {
            using (SqlConnection sqcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlTransaction SqlTran = null;
                DataTable dt = new DataTable();
                try
                {
                    if (sqcon.State == ConnectionState.Open)
                    { sqcon.Close(); }
                    sqcon.Open();
                    SqlTran = sqcon.BeginTransaction();
                    SqlCommand sqcmd = new SqlCommand(query, sqcon, SqlTran);
                    sqcmd.CommandTimeout = 0;

                    SqlDataAdapter SqlDa = new SqlDataAdapter(sqcmd);
                    SqlDa.Fill(dt);

                    SqlTran.Commit();
                    if (dt.Rows.Count > 0)
                    {
                        query = dt.Rows[0]["Message"].ToString();
                    }
                    else
                    {
                        query = "Successfull";
                    }
                }
                catch (Exception exce)
                {
                    throw exce;
                }
                finally
                {
                    sqcon.Close();
                }
            }
            return query;
        }
        // GET: Branch
        public ActionResult Index()
        {
            _loggerManager.LogError($"Logging Test");

            try
            {
                var vm = MaxAuditViewModel.DefaultInstance;
                if (TempData["MaxData"] != null)
                {
                    vm = (MaxAuditViewModel)TempData["MaxData"];
                }
                var companies = _master.FetchCompanyDetails();
                vm.Companies = companies.ToSelectList("CompanyCode", "CompanyDesc");
                //vm.CurrentCompany = (Session["UserInfo"] as Account).Company;
                if (!string.IsNullOrEmpty(vm.CurrentCompany))
                {
                    var locations = _master.FetchLocations(vm.CurrentCompany, "All");
                    vm.Locations = locations.ToSelectList("LocationAutoId", "Locationdesc");
                }
                var checkListTypes = _dataAccesLayer.FetchChecklistTypes();
                vm.ChecklistTypes = checkListTypes.ToSelectList("Id", "DisplayLabel");
                var selectedCheckList = checkListTypes.SingleOrDefault(chk => chk.Id.ToString() == vm.SelectedChecklistType);
                var data = _dataAccesLayer.FetchClientCodeV2(vm.CurrentLocation, vm.FromDate.ToString("dd-MMM-yyyy"), vm.ToDate.ToString("dd-MMM-yyyy"), selectedCheckList != null ? selectedCheckList.CheckListType : "");
                vm.BranchDetails = data;
                return View(vm);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Exception in Index {ex}");
                throw;
            }
        }
        [HttpPost]
        public ActionResult Search()
        {
            var vm = MaxAuditViewModel.DefaultInstance;
            //vm.SelectedChecklistType = Request.Form["SelectedChecklistType"].ToString();
            vm.CurrentLocation = Request.Form["CurrentLocation"].ToString();
            vm.FromDate = Convert.ToDateTime(Request.Form["Fromdate"]);
            vm.ToDate = Convert.ToDateTime(Request.Form["ToDate"]);
            TempData["MaxData"] = vm;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult FetchLocations(string CompanyCode, string RegionCode)
        {
            var locations = _master.FetchLocations(CompanyCode, RegionCode);
            var locationList = locations.ToSelectList("LocationAutoId", "Locationdesc");
            return Json(locationList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult FetchRegions(string CompanyCode)
        {
            var locations = _master.FetchRegions(CompanyCode);
            var locationList = locations.ToSelectList("RegionName", "RegiRegionDescriptiononName");
            return Json(locationList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(string Branch, string AuditDate, string Location, string ChecklistType)
        {
            var data = _dataAccesLayer.GetReportValuesV2(Location, Branch, AuditDate, ChecklistType);
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Export()
        {
            try
            {
                //string location = Request.Form["Location"].ToString();
                //string branch = Request.Form["Branch"].ToString();
                //string auditdate = Request.Form["AuditDate"].ToString();
                //string checkListType = Request.Form["CheckListType"].ToString();
                //var viewMoreUrl = ConfigurationManager.AppSettings["MaxReportImageEndpoint"].ToString();
                //viewMoreUrl += $"?AuditDate={auditdate}&Location={location}&Branch={branch}";
                //var data = _dataAccesLayer.GetReportValuesV2(location, branch, auditdate, checkListType);
                //Document pdfDoc = new Document(PageSize.A4, 0, 0, 0, 0);
                //PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //PdfReportBuilder builder = new PdfReportBuilder(pdfDoc, _dataAccesLayer);
                //builder.CreateHeader(data.Header);
                //builder.CreateDetails(data.MasterdetailList, viewMoreUrl,checkListType);
                //pdfWriter.CloseStream = false;
                //pdfDoc.Close();
                //Response.Buffer = true;
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", $"attachment;filename={data.Header.BranchName.Trim()}.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Write(pdfDoc);
                //Response.End();

            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult RetrieveImage(int ImageId)
        {
            byte[] cover = _dataAccesLayer.GetImageById(ImageId, true);
            if (cover == null)
            {
                string path = Server.MapPath("~/Images/NoImagesFound.jpg");
                cover = System.IO.File.ReadAllBytes(path);
            }


            byte[] compressedImage = CompressImage(cover, 20);

            return File(compressedImage, "image/jpeg");
            //byte[] cover = _dataAccesLayer.GetImageById(ImageId, true);
            //if (cover != null)
            //{
            //    return File(cover, "image/jpg");
            //}
            //else
            //{
            //    string path = Server.MapPath("~/Images/NoImagesFound.jpg");

            //    //Read the File data into Byte Array.
            //    byte[] bytes = System.IO.File.ReadAllBytes(path);

            //    //Send the File to Download.
            //    return File(bytes, "image/jpg");
            //}
        }

        private byte[] CompressImage(byte[] imageBytes, long quality)
        {
            using (MemoryStream inputStream = new MemoryStream(imageBytes))
            {
                using (Image image = Image.FromStream(inputStream))
                {
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        EncoderParameters encoderParams = new EncoderParameters(1);
                        encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);


                        image.Save(outputStream, jpgEncoder, encoderParams);
                        return outputStream.ToArray();
                    }
                }
            }
        }

        public byte[] ImageToBinary(string imagePath)
        {
            //string absolutePath = HostingEnvironment.MapPath(imagePath);


            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            //fileStream.Close();
            return buffer;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders()
                   .FirstOrDefault(codec => codec.FormatID == format.Guid);
        }
        [AllowAnonymous]
        public ActionResult ViewMore(string CheckListId, string AuditDate, string Location, string Branch, string CheckListType)
        {
            var images = _dataAccesLayer.FetchCheckListImageList(Location, Branch, AuditDate, CheckListId, true, CheckListType);
            return View(images);
        }

        public ActionResult SetImage(byte[] image)
        {
            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                string path = Server.MapPath("~/Images/NoImagesFound.jpg");

                //Read the File data into Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);

                //Send the File to Download.
                return File(bytes, "image/jpg");
            }
        }

        [HttpPost]

        public JsonResult Delete(string clientCode, string auditdate)
        {
            string msg = "";

            try
            {


                string query = $@"delete from MaxLifeChecklistMaster where BranchCode='{clientCode}' and (convert(varchar,cast(ChecklistTime as date),106)) = '{auditdate}'; delete from MaxLifeChecklistImageMaster where BranchCode='{clientCode}' and (convert(varchar,cast(datetime as date),106)) = '{auditdate}'";

                msg = ExecQuery(query);


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(msg);
        }

        public JsonResult Update(HttpPostedFileBase ImgFile, string ImageId, string checklisid, string remark)
        {
            string _FileName = Path.GetFileName(ImgFile.FileName);
            string msg = "";

            try
            {
                string base64String = null;

                if (_FileName != null && ImgFile.ContentLength > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        ImgFile.InputStream.CopyTo(ms);
                        byte[] imageBytes = ms.ToArray();


                        base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                        byte[] imageBytes3 = Convert.FromBase64String(base64String);
                        var ds = new DataSet();

                        using (var scn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                        {
                            SqlCommand command;
                            command = new SqlCommand("Udp_UpdateImageandRamark", scn);
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add("@ImageAutoId", SqlDbType.Int).Value = ImageId;
                            if (imageBytes3 != null && imageBytes3.Length > 0)
                            {
                                command.Parameters.Add("@Image", SqlDbType.Image).Value = (object)imageBytes3 ?? DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Image", SqlDbType.Image).Value = (object)imageBytes3 ?? DBNull.Value;
                            }
                            scn.Open();
                            var adapter = new SqlDataAdapter(command);
                            adapter.Fill(ds);

                        }


                        string query = $@"UPDATE MaxLifeChecklistMaster SET Remarks='{remark}' WHERE ChecklistAutoID='{checklisid}'";
                        msg = ExecQuery(query);
                    }


                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return Json(msg);
        }

    }

}