<?php 
 require "connect.php";
 $id=$_GET['id'];
 $ON_OFF=$_GET['ON_OFF'];
 $MaTaiKhoan=$_GET['MaTaiKhoan'];
 if($MaTaiKhoan!=NULL)
mysqli_query($con,"update danhtrong set ON_OFF='$ON_OFF' where id='$id' and MaTaiKhoan='$MaTaiKhoan'");
echo "Success";
?>