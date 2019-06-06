<?php 
 require "connect.php";
 $user=$_GET["user"];
 $pass=$_GET["pass"];
 $maTK=$_GET["maTK"];
 $passM=$_GET["passM"];
mysqli_query($con,"UPDATE taikhoan set user='$user',pass='$pass',passM='$passM' where MaTaiKhoan='$maTK'");
echo "Success";
?>