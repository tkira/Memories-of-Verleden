<?php 
$server ="localhost";
$user="root";
$pass = "";
$database = "Memories";


$link = mysqli_connect($server, $user, $pass, $database)
 or die ("Unable to connect to the database server ");
 ?>