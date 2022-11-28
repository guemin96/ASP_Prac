
//    var _FormData = new FormData();
//    var _FILE_MAX_SIZE = 10;

//    window.onload = function () {
//        var fileArea = document.getElementById('dragDropArea');
//        var fileInput = document.getElementById('fileInput');

//        fileArea.addEventListener('dragover', function (evt) {
//            evt.preventDefault();
//        fileArea.classList.add('dragover');
//            });
//        fileArea.addEventListener('dragleave', function (evt) {
//            evt.preventDefault();
//        fileArea.classList.remove('dragover');
//            });
//        fileArea.addEventListener('drop', function (evt) {
//            evt.preventDefault();
//        fileArea.classList.remove('dragenter');
//        var files = evt.dataTransfer.files;
//        fileInput.files = files;
//        fnSelectFile();
//            });
//    }

//    function fnSelectFile() {

//        var maxsize = _FILE_MAX_SIZE * 1024 * 1024;
//    // 첨부파일 Input태그 호출
//    var input = document.getElementById('fileInput');
//    // Input 태그에서 선택된 파일 개수 만큼 반복
//    for (var i = 0; i < input.files.length; ++i) {
//            var name = input.files.item(i).name; // 파일명
//    var size = input.files.item(i).size; // 파일 사이즈

//            // 파일 사이즈 체크
//            if (size > maxsize) {
//        alert("파일은 " + _FILE_MAX_SIZE + "Byte 이하만 가능합니다.");
//            }
//    else {
//        // 폼 데이터에 파일 정보 보존
//        _FormData.append("files", input.files[i]);
//            }
//        }

//    // 선택 파일을 화면에 표시
//    fnDisplayFileList();
//}

//    function fnCancelFile(name, size) {
//        filelist = _FormData.getAll("files");
//        _FormData.delete("files");
//        for (var file of filelist) {
//                if (file.name == name && file.size == size) {
//                    continue;
//                }
//        _FormData.append("files", file);
//            }
//        fnDisplayFileList();
//}

//        function fnDisplayFileList() {
//            var children = "";
//            var output = document.getElementById("fileList");
//            var filelist = _FormData.getAll("files");
//            for(var file of filelist) {
//                var name = file.name;
//                var size = file.size;
//            children += '&nbsp;&nbsp;&nbsp;' + name + ' ';
//            children += "<span style='cursor:pointer;color:red;' onclick='javascript:fnCancelFile(\"" + name + "\"," + size + ");'>X</span><Br />";
//                }
//            output.innerHTML = children;
//        }

//    function fnSendFile() {
//        $.ajax({
//            url: '/Board/CreateBoard',
//            type: "POST",
//            contentType: false,
//            processData: false,
//            data: _FormData,
//            async: false,
//            success: function (data) {
//                if (data.result == 0) {
//                    alert("파일 업로드 완료!");
//                    window.location.href = '/Board';
//                }
//                else {
//                    alert("파일 업로드 실패");
//                }
//            },
//            error: function (err) {
//                alert(err.statusText);
//            }
//        });
//}
//uploadButton
$(function () {
    $("#uploadButton").click(function () {
        if ($("#uploadFile").val() === "") {
            alert("File is empty.");
            return;
        }
        var formData = new FormData();
        $.each(document.querySelector("#uploadFile").files, function (i, item) {
            formData.append("files", item);
        });
        $.ajax({
            type: "POST",
            url: "Board/UploadFiles",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data === "Success") $("#uploadFile").val("");
                else alert(data);
            }
        })
    });
});