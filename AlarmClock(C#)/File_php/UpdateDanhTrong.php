<?php 
 require "connect.php";
 $id=$_GET['id'];
 $ChiCheck=$_GET['ChiCheck'];
 $date=$_GET['date'];
 $Hou=$_GET['Hou'];
 $Like_Dis=$_GET['Like_Dis'];
 $min=$_GET['min'];
 $Month=$_GET['Month'];
 $NhacNgay=$_GET['NhacNgay'];
 $NhacThoi=$_GET['NhacThoi'];
 $ON_OFF=$_GET['ON_OFF'];
 $sec=$_GET['sec'];
 $TenBaoThuc=$_GET['TenBaoThuc'];
 $Thu2=$_GET['Thu2'];
 $Thu3=$_GET['Thu3'];
 $Thu4=$_GET['Thu4'];
 $Thu5=$_GET['Thu5'];
 $Thu6=$_GET['Thu6'];
 $Thu7=$_GET['Thu7'];
 $Thu8=$_GET['Thu8'];
 $VongLap=$_GET['VongLap'];
 $year=$_GET['year'];
 $MaTaiKhoan=$_GET['MaTaiKhoan'];
 if($MaTaiKhoan!=NULL)
 for($i=1;$i<=20;$i++)
mysqli_query($con,"update danhtrong set ChiCheck='$ChiCheck',date='$date',Hou='$Hou',Like_Dis='$Like_Dis',min='$min',Month='$Month',NhacThoi='$NhacThoi',NhacNgay='$NhacNgay',ON_OFF='$ON_OFF',sec='$sec',TenBaoThuc='$TenBaoThuc',Thu2='$Thu2',Thu3='$Thu3',Thu4='$Thu4',Thu5='$Thu5',Thu6='$Thu6',Thu7='$Thu7',Thu8='$Thu8',VongLap='$VongLap',year='$year' where id='$id' and MaTaiKhoan='$MaTaiKhoan'");
echo "Success";
?>