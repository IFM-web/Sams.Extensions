//function ShowImageList(CheckListId, AuditDate, BranchCode, Location) {
//    window.open("http://localhost:50292/Branch/ViewMore", '_blank');

//}

//var styles = `<!DOCTYPE html>
   
//        <head>
//            <meta charset="utf-8" />
//            <meta name="viewport" content="width=device-width, initial-scale=1.0" />
//            <title>Audit Details</title>
//            <style>
//  @media print {
       

//            body {
//                -webkit-print-color-adjust: exact;             
//                  page-break-after: always;        
//            background-color: none;
//            padding: 20px;
//            }

//            .no-print {
//                display: none;
//            }
//            table {
//    border-collapse: collapse;
//    width: 100%; 
//}


//            @page {
//                size: A4 portrait;
               
//                -webkit-print-color-adjust: exact;
//              font-family: 'Times New Roman', Times, serif, sans-serif;
//                  page-break-after: always;

//                    border:2px solid black;
//                header,
//                footer {
//                    display: none;
//                }



//            }

//            header,
//            footer {
//                display: none;
//            }

//        }


//        body {
//             -webkit-print-color-adjust: exact;
//            font-family: 'Times New Roman', Times, serif, sans-serif;
//            background-color: none;
//            padding: 20px;
       
//            margin: 20px;
           

//        }
        

//            </style>

//        </head>`

//document.getElementById("btnpdf").addEventListener("click", () => {

//    var datadiv = document.getElementById("pdfexport");
//    //const hideFrame = document.createElement("iframe");
//    //var popupwin = window.open('', '_blank', 'width=200', 'height=200', 'left:100', 'top:100');

//    popupwin.document.open();
//    popupwin.document.write(styles + datadiv.innerHTML);

//    var imgUrl = document.getElementById('imgUrl').value;
//    setTimeout(function () {
//        popupwin.print();


//    }, 2000);
//    var pdf = new jsPDF();
//    pdf.addImage(imgUrl, 'JPEG', 15, 15, 150, 125);

//    popupwin.focus();
//    popupwin.close();
//    return true;
//});

