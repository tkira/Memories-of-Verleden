<?php
include ("header.html");
?>

<body>
<div class='container-fluid'>
<br/>
    <section>
	<div class="HS">
	
<?php
 if (isset($_SESSION['email']))
 {
	
	$first_name = $_SESSION['first_name'];
	$last_name = $_SESSION['last_name'];
	$phone = $_SESSION['phone'];
	$email = $_SESSION['email'];


	echo"<h3> Welcome  $first_name $last_name</h3><br/>";
	
	echo "<p> Hey Welcome.
	$first_name This is your member page where your account details can be viewed.
	that you have joined the community and hope that you
	enjoy the stay and games we provide.</p>";
	
	echo"<table>
	<tr>
	<td>
	<b>First Name:</b> $first_name </td>
	</tr>" ;
	
	echo"<tr>
	<td><b> Last Name:</b> $last_name </td>
	</tr>" ;
	
	echo"<tr>
	<td> <b>Email:</b> $email </td>
	</tr>" ;
	
	echo"<tr>
	<td> <b>Phone:</b> $phone </td>
	</tr>";
	
	echo"</table><br/><br/>";
 }
 else
 {
	echo "there is some error";
 }
	include("footer.php");
?>
</div>
</body>
</html>