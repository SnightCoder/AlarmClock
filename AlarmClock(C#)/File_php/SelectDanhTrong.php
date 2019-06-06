<?php 
 require "connect.php";
 class Ten{
   function Ten($id,$ChiCheck,$date,$Hou,$Like_Dis,$min,$Month,$NhacNgay,$NhacThoi,$ON_OFF,$sec,$TenBaoThuc,$Thu2,$Thu3,$Thu4,$Thu5,$Thu6,$Thu7,$Thu8,$VongLap,$year,$MaTaiKhoan){
       $this->id=$id;
       $this->ChiCheck=$ChiCheck;
       $this->date=$date;
       $this->Hou=$Hou;
       $this->Like_Dis=$Like_Dis;
       $this->min=$min;
       $this->Month=$Month;
       $this->NhacNgay=$NhacNgay;
       $this->NhacThoi=$NhacThoi;
       $this->ON_OFF=$ON_OFF;
       $this->sec=$sec;
       $this->TenBaoThuc=$TenBaoThuc;
       $this->Thu2=$Thu2;
       $this->Thu3=$Thu3;
       $this->Thu4=$Thu4;
       $this->Thu5=$Thu5;
       $this->Thu6=$Thu6;
       $this->Thu7=$Thu7;
       $this->Thu8=$Thu8;
       $this->VongLap=$VongLap;
       $this->year=$year;
       $this->MaTaiKhoan=$MaTaiKhoan;
   }
 }
 $maTK=$_GET["maTK"];
$mang=array();
$data=mysqli_query($con,"select *from danhtrong where MaTaiKhoan='$maTK'");
while ($row=mysqli_fetch_assoc($data)) {
	array_push($mang, new Ten($row["id"],$row["ChiCheck"],$row["date"],$row["Hou"],$row["Like_Dis"],$row["min"],$row["Month"],$row["NhacNgay"],$row["NhacThoi"],$row["ON_OFF"],$row["sec"],$row["TenBaoThuc"],$row["Thu2"],$row["Thu3"],$row["Thu4"],$row["Thu5"],$row["Thu6"],$row["Thu7"],$row["Thu8"],$row["VongLap"],$row["year"],$row["MaTaiKhoan"]));
}
   echo json_encode($mang);
?>