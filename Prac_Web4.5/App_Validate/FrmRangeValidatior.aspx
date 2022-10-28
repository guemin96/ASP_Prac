<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRangeValidatior.aspx.cs" Inherits="App_Validate.FrmRangeValidatior" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>JavaScript로 범위 확인하기</title>
    <script>
        function CheckLogin() {
            //값을 받아서 정수형으로 변환
            var test = document.getElementById().value
            var varAge = parseInt(document.getElementById("txtAge").v);
            if (varAge < 1 || varAge > 150) {
                alert("나이는 1~150까지 입력하시오.");
                document.getElementById("txtAge").focus();  //포커스
                return false;
            }
            return true;
             
        }
    </script>
</head>
<body>
    <form id="frmLogin" action="#" method="post" onsubmit="return CheckLogin();">
        나이 : <input type="text" id="txtAge" name="txtAge" value="0"/>(1~150)<br />
        <input type="submit" value="체크" />
    </form>
</body>
</html>
