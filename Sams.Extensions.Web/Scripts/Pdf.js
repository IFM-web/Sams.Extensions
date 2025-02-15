var mystyle = `
<title> Fsa Report</title>
<style>

   @media print {


            body {
                -webkit-print-color-adjust: exact;
                  page-break-after: always;
            background-color: none;
         
            }
             header,
            footer {
                display: none;
            }

            .no-print {
                display: none;
            }


            table {
    border-collapse: collapse;
    width: 100%;
    }
}


            @page {
                size: A4 portrait;

                -webkit-print-color-adjust: exact;
              font-family: 'Times New Roman', Times, serif, sans-serif;
                  page-break-after: always;

                   
                header,
                footer {
                    display: none;
                }



            }

          

        



table{
    border-collapse: collapse;
}
#btnpdf{
    display:none;
}

#btnback{
    display:none;
}
</style>
`
var btn = '<input type="submit" style="display:none" onclick="window.print()" class="btn btn-primary" id="btnreprint" value="Export to PDF" />'

document.getElementById("btnpdf").addEventListener("click", () => {

    var datadiv = document.getElementById("pdfexport").innerHTML;

    var datadiv = document.getElementById("pdfexport");

    var popupwin = window.open('', '_blank', 'width=200', 'height=200', 'left:100', 'top:100');

    popupwin.document.open();
    popupwin.document.write(mystyle +datadiv.innerHTML);
 
    var imgUrl = document.getElementById('imgUrl').value;
    setTimeout(function () {
        popupwin.print();
    }, 1000);
    var pdf = new jsPDF();
    pdf.addImage(imgUrl, 'JPEG', 15, 15, 150, 125);

    popupwin.focus();
    popupwin.close();
    return true;
});