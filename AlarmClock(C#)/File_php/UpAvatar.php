<?php 
 require "connect.php";
 $avatar=$_GET["avatar"];
 $maTK=$_GET["maTK"];
mysqli_query($con,"update taikhoan set avatar='$avatar' where MaTaiKhoan='$maTK'");
echo "Success";
?>