<?php 
 require "connect.php";
 $user=$_GET["user"];
 $pass=$_GET["pass"];
 $maTK=$_GET["maTK"];
mysqli_query($con,"INSERT INTO taikhoan VALUES ('$user','$pass','$maTK','https://','')");
echo "Success";
?>