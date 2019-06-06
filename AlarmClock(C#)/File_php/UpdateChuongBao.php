<?php
  require "connect.php";
  $id=$_GET['id'];
  $maTK=$_GET['maTK'];
  $name=$_GET['name'];
  $path=$_GET['path'];
  
  mysqli_query($con,"Update chuongbao set name='$name', path='$path' where id='$id' and maTK='$maTK'");
  echo "Success";
?>