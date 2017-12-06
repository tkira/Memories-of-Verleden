<?php
session_start();
include('header.html');


	//Capture the user inputs from the form
    
    $m_topic=$_POST['m_topic'];
	$m_body=$_POST['m_body']; 
    

  
 
	//Validate user inputs
    if (($m_body == "") or ($m_topic == "") )
    {
		echo"<section><div class='HS'>";
		echo"<p>Sorry it seems that you did not fill out the required fields please try again</p>";
     echo"<a href='createTopic.php'>Go Back</a>";
     echo"</div></section>";
	 include('footer.php');
	}
   
    else
    {
    //Connect to the server and add a new record 
	require_once('init.php');
	//Define the insert query
	//$password=md5($password);
    $query = "INSERT INTO messageBoard
	(
	m_topic,
	m_body
	)
	
	VALUES
	('$m_topic',
	'$m_body'
	)";
	
	//close the connection
	echo "<section class='HS'>";
    mysqli_query($link, $query) or die( "Unable to insert the record");
    mysqli_close($link);
    
    echo "<p> <b>Record Added Successfully......!!!! </p>";
    echo"<p> <a href=login.html>Click Here to Login to the Member Page </a> </b></p>";
	header("location: forum.php");
	echo "</section>";
    include('footer.php');
    }
	
?>
