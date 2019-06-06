<?php
  require "connect.php";
  $name=$_GET['name'];
  $path=$_GET['path'];
  $status=$_GET['status'];
  $maTK=$_GET['maTK'];
  $run=$_GET['run'];
  mysqli_query($con,"Insert into chuongbao values (null,'$name','$path','$status','$maTK','$run')");
  echo "Success";
?>