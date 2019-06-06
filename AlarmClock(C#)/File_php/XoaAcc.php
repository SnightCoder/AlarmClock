<?php
require "connect.php";
$matk=$_GET['maTK'];
mysqli_query($con,"DELETE FROM `taikhoan` WHERE MaTaiKhoan='$matk';DELETE FROM danhtrong WHERE MaTaiKhoan='$matk'")
?>