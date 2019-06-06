<?php 
 require "connect.php";
 class Ten{
   function Ten($user,$pass,$MaTaiKhoan){
       $this->user=$user;
       $this->pass=$pass;
       $this->MaTaiKhoan=$MaTaiKhoan;
   }
 }
 $user=$_GET['taikhoan'];
 $pass=$_GET['matkhau'];
 
$mang=array();
$data=mysqli_query($con,"select *from taikhoan where user='$user'");
while ($row=mysqli_fetch_assoc($data)) {
	array_push($mang, new Ten($row["user"],$row["pass"],$row["MaTaiKhoan"]));
}
   $a = json_encode($mang);
   if ($a=='[]')echo "0";
   else echo "Exists";

?>