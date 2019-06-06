<?php 
 require "connect.php";
 class Ten{
   function Ten($user,$pass,$MaTaiKhoan,$avatar,$passM){
       $this->user=$user;
       $this->pass=$pass;
       $this->MaTaiKhoan=$MaTaiKhoan;
       $this->avatar=$avatar;
       $this->passM=$passM;
   }
 }
 $user=$_GET['taikhoan'];
 $pass=$_GET['matkhau'];
 
$mang=array();
$data=mysqli_query($con,"select *from taikhoan where user='$user' and pass='$pass'");
while ($row=mysqli_fetch_assoc($data)) {
	array_push($mang, new Ten($row["user"],$row["pass"],$row["MaTaiKhoan"],$row["avatar"],$row["passM"]));
}
   $a = json_encode($mang);
   if ($a=='[]')echo "0";
   else echo $a;

?>