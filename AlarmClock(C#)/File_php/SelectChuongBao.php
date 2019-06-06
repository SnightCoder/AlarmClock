<?php
 require "connect.php";
  class ChuongBao{
      function ChuongBao($id,$name,$path,$status,$run){
          $this->id=$id;
            $this->name=$name;
              $this->path=$path;
                $this->status=$status;
                 $this->run=$run;
      }
  }
  $maTK=$_GET["maTK"];
  $mang=array();
  $data=mysqli_query($con,"select *from chuongbao where maTK='$maTK'");
  while($row=mysqli_fetch_assoc($data)){
      array_push($mang,new ChuongBao($row['id'],$row['name'],$row['path'],$row['status'],$row['run']));
  }
   $a = json_encode($mang);
   if ($a=='[]')echo "0";
   else echo $a;
?>