<?php 
 require "connect.php";
 $ChiCheck;
 $date
 ;$Hou;
 $Like_Dis;
 $min;
 $Month;
 $NhacNgay;
 $NhacThoi;
 $ON_OFF;
 $sec;
 $TenBaoThuc;
 $Thu2;
 $Thu3;
 $Thu4;
 $Thu5;
 $Thu6;
 $Thu7;
 $Thu8;
 $VongLap;
 $year;
 $MaTaiKhoan=$_GET['MaTaiKhoan'];
 if($MaTaiKhoan!=NULL)
 for($i=1;$i<=20;$i++)
mysqli_query($con,"insert into danhtrong values('$i',2,3,4,5,6,7,8,9,10,11,'12',13,14,15,16,17,18,19,20,21,'$MaTaiKhoan')");
echo "Success";
?>