<?php
  require "connect.php";
  $id=$_GET['id'];
  $maTK=$_GET['maTK'];
  mysqli_query($con,"delete from chuongbao where id='$id' and maTK='$maTK'");
  echo "Success";
?>