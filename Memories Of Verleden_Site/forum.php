<?php
session_start();
require ("dbCreation.php");
$email = $_SESSION['email'];
include ("header.html");
?>



<body>
<section class="HS">
<table>
<tr>
<td><strong>ID</strong></td>
<td><strong>Topic</strong></td>
<td><strong>Body</strong></td>
</tr>

<?php

$conn = mysqli_connect("localhost","root","","Memories");
// Check connection
if (mysqli_connect_errno())
{
echo "<p>Failed to connect to MySQL: " . mysqli_connect_error() . "</p>";
}
else
{
function produceTable($result)
{
$result = mysqli_query($conn,"SELECT * FROM messageBoard ");
return $result;
}
$result = mysqli_query($conn,"SELECT * FROM messageBoard ");
while($row = mysqli_fetch_array($result)) {

echo "<td> <a class='dark' href=forumView.php?m_id=".$row['m_id'].">".$row['m_id']."</a></td>";
echo "<td align = 'center'>Topic: <br/> ".$row['m_topic']."</td>";
echo "<td>body:".$row['m_body']."</td>";
echo "<tr>";
}
}
?>

<td colspan="4"><a class='dark' href="createTopic.php">Leave a message </a></td>

</table>
</section>

<footer>
<p class='middle'> &copy; Memories Of Verleden </p>
</footer>
</div>
<div id="wrapper">

</div>
</body>
</html>