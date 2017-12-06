<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "Memories";
$conn = @mysqli_connect("localhost","root","");



if (!$conn) {
die ("The connection has failed: " . mysqli_error($conn));
}
else {
//echo "Successfully connected to mySQL!";
}
$dbName = "Memories";
$query = "CREATE DATABASE IF NOT EXISTS  " . $dbName;
if (!mysqli_query($conn,$query)) {
if (mysqli_select_db($conn,$dbName)) {
//echo "<p>Database selection successful</p>";


}
else {

echo "<p>Could not open the database " . mysqli_error($conn) . "</p>" ;
}
}
else {
//echo @"<p>Database successfully created</p>";
//Only need to do this if it's the database has just been created
if (mysqli_select_db($conn,$dbName)) {
//echo "<p>Database selection successful</p>";

}
else {
echo "<p>Could not open the database " . mysqli_error($conn) . "</p>" ;
}
}

$userTable = "CREATE TABLE IF NOT EXISTS Users (
first_name VARCHAR ( 20) NOT NULL ,
last_name VARCHAR ( 30) NOT NULL ,
phone VARCHAR ( 10) NOT NULL ,
password VARCHAR ( 64) NOT NULL ,
email VARCHAR ( 40) NOT NULL ,
PRIMARY KEY (email)
)";

$forumThreads2 = "CREATE TABLE IF NOT EXISTS messageBoard (
m_id int ( 10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
m_topic VARCHAR ( 30) NOT NULL ,
m_body varchar (300) not null
)";

if (mysqli_query($conn, $forumThreads2)) {
    //echo "Table Users created successfully";
} else {
    echo "Error creating table: " . mysqli_error($conn);
}


if (mysqli_query($conn, $userTable)) {
    //echo "Table Users created successfully";
} else {
    echo "Error creating table: " . mysqli_error($conn);
}


mysqli_close($conn);
?>