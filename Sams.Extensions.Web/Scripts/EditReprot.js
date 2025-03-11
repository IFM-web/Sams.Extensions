$(document).ready(function () {
    $('#ImgFile').bind('change', function () {
        var fileExtension = ['png', 'img', 'jpg','jfif'];
        var filename1 = $('#ImgFile').val();
        var extension = filename1.replace(/^.*\./, '');
        if ($.inArray(extension, fileExtension) == -1) {
            alert("Please select only PNG/IMG/JPG/JFIF files.");
            $(this).val('');
            return true;

        }
        var a = (this.files[0].size);
        //alert(a);
        //if (a > 100000) {
        //    alert('Please Upload Photo1 Less Than 100kb');
        //    $(this).val('');
        //};
    });
  
});


function EditReport(checklistId, imgAutoId) {
    document.getElementById("checklisid").value = checklistId;
    $("#imageid").val(imgAutoId);

    $('#exampleModalmodel').modal('show');
}

function closeModal() {
    $('#exampleModalmodel').modal('hide');
}

function Validation() {
    let ImgFile = $("#ImgFile").val();
    let remark = $("#remark").val();
    let mes = ''
    if (ImgFile == '') {
        mes += 'Image Is Required !';
    }
    if (remark == '') {
        mes += 'Remark Is Required !'
    }
    return mes;
}
function Update() {
    let ImageId = $("#imageid").val();
    let checklisid = $("#checklisid").val();
    let remark = $("#remark").val();
    var fileInput = $("#ImgFile")[0];


    if (window.FormData !== undefined) {
        $("#preload").show();
        $("#btnclose").prop("disabled", true);

        var fdata = new FormData();
        fdata.append("ImageId", ImageId);
        fdata.append("checklisid", checklisid);
        fdata.append("remark", remark);


        if (fileInput.files.length > 0) {
            fdata.append("ImgFile", fileInput.files[0]);
        } 

        $.ajax({
            url: '/BranchNew/Update',
            type: "POST",
            data: fdata,
            contentType: false,
            processData: false,
            success: function (data) {
                closeModal();
                alert(data);
                $("#remark").val('');
                $("#ImgFile").val('');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });

    }

}


