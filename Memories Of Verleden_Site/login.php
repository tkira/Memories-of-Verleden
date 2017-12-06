<?php


//start the new session
session_start();
include('header.html');
//Read the email and the password
$email = $_POST['email'];
$password=$_POST['password'];
?>


<?php
if (($email=="") || ($password=="")) {
   //Redirect user back to the login page
   echo "sit tight ";
echo "Your username or password was not recognised by the server please try again";
   header("Refresh:2; url=login.html");
   $message1 = "Please enter your login and password";
echo "<script type='text/javascript'>alert('$message1');</script>";
   exit();
}
else
	{   
	//connect to server and select database
	require_once('init.php');
   
	//Create a select query to select user details using the email and the password
	$query = "SELECT *
	FROM Users WHERE (email = '$email') AND (password = '$password')";
	$result = mysqli_query($link, $query) or die( "Invalid Customer ID or Password");
//echo $query;

	//get the number of rows in the result set; should be 1 if a match
	if (mysqli_num_rows($result) == 1) {
   		//if authorized, get the values of firstname lastname, phone and email
    	$row = $result -> fetch_array();
		$first_name = $row['first_name'];
		$last_name = $row['last_name'];
		$phone = $row['phone'];
		$email = $row['email'];
		mysqli_close($link);
		//save the values in session variables
		$_SESSION['first_name']= $first_name;
		$_SESSION['last_name'] = $last_name;
		$_SESSION['phone'] = $phone; 
		$_SESSION['email'] = $email;
		echo"<section>";
		echo"<h2> Authentication Succeed !!! </h2>";
		echo"<br/> <a href=forum.php> Click Here to go to Member Page </a>"; 
		echo "</section>";
    include('footer.php');
	}
	else
		{
			//Redirect user back to the login page
echo "sit tight ";
echo "Your username or password was not recognised by the server please try again";
				header("Refresh:2; url=login.html");
				$message = "Invalid data, Please enter your criedentials again";
echo "<script type='text/javascript'>alert('$message');</script>";
			
	
		}
}
?>

