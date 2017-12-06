<?php
session_start();
	include("header.html");
	include("init.php");
	$item_id = $_GET["m_id"];
	$query = "SELECT * FROM messageBoard where (m_id='$item_id')";
	$result = mysqli_query($link, $query);
?>


<?php
	while ($row = mysqli_fetch_array($result, MYSQLI_ASSOC))
{   
	echo "<br/> <section><div class='HS'>";
	echo "<h1>".'<p>reply id</p>'.$row['m_id']."</h1>";
	echo "<p>topic: ".$row['m_topic']."</p>";
	echo "<p>Body: ".$row['m_body']."</p>";
	echo "<a href='forum.php'>Go Back to forum view</a></section></div>";
}
?>


<?php
require ("dbCreation.php");
$email = $_SESSION['email'];
?>


<?php
	include("footer.php");
?>