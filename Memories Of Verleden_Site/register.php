<?php

include('header.html');


	//Capture the user inputs from the form
    $first_name=$_POST['first_name']; 
    $last_name=$_POST['last_name']; 
    $phone=$_POST['phone'];
    $email=$_POST['email']; 
    $password=$_POST['password']; 
    $repassword=$_POST['repassword']; 
  
 
	//Validate user inputs
    if (($first_name == "") or ($last_name == "") or ($email == "")or ($password == ""))
    {
		
		echo"<p>Required Field(s) missing..>!!!!! Go back and try again.....!!!!.</p>";
    }
    elseif  (!(strstr($email, "@")) or !(strstr($email, ".")))
    {
       
		echo"<p>Invalid Email....!!!! Go back and try again <a href='register.php'> Register </a> </p> ";
		
    }
    elseif ($password != $repassword)
    {
		
		echo"<p> Invalid Password ....!!! Go back and try again </p>";
    }
    else
    {
    //Connect to the server and add a new record 
	require_once('init.php');
	//Define the insert query
	//$password=md5($password);
    $query = "INSERT INTO Users VALUES
	('$first_name',
	'$last_name',
	'$phone',
	'$password',
	'$email')";
	
	//close the connection
	echo "<section class='HS'>";
    mysqli_query($link, $query) or die( "Unable to insert the record");
    mysqli_close($link);
    
    echo "<p> <b>Record Added Successfully......!!!! </p>";
    echo"<p> <a href=login.html>Click Here to Login to the Member Page </a> </b></p>";
	echo "</section>";
    include('footer.php');
    }
	
?>
