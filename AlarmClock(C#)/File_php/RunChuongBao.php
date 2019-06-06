<?php
  require "connect.php";
  $id=$_GET['id'];
  $maTK=$_GET['maTK'];
  $run=$_GET['run'];
  mysqli_query($con,"Update chuongbao set run='$run' where id='$id' and maTK='$maTK'");
  echo "Success";
?>