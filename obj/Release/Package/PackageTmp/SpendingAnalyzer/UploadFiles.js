$(document).ready(function () {
    $("#btnUploadFiles").click(function (evt) {        
        var fileUpload = $("#FileUpload1").get(0);
        var files = fileUpload.files;
        var validFileExtension = ["csv"];
        
        var data = new FormData();

        if (files.length > 0) {
            for (var i = 0; i < files.length; i++) {
                var fileName = files[i].name;
                var fileNameExtension = fileName.substring(fileName.lastIndexOf('.') + 1);
                
                if ($.inArray(fileNameExtension, validFileExtension) == -1)
                {
                    alert("Invalid file type");
                    return false;
                }
                else{
                    data.append(fileName, files[i]);
                }
            }

            var options = {};
            options.url = "FileUploadHandler.ashx";
            options.type = "POST";
            options.data = data;
            options.contentType = false;
            options.processData = false;
            options.success = function (result) { alert(result); };
            options.error = function (err) { alert(err.statusText); };

            $("#uploadModal").modal("hide");
            
            $.ajax(options);
        }
        else
        {
            alert("No file selected.");
            return false;
        }
        evt.preventDefault();
    });
});