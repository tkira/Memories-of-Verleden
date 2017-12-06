<?php
session_start();
require ("dbCreation.php");
include ("header.html");
	  $email = $_SESSION['email'];
?>

<!DOCTYPE HTML> 

<section class="HS">
<form action="fourmProcess.php" method="post" name="form1" >
   <table >
   <td colspan="3" bgcolor="#E6E6E6"><strong>Create New Topic</strong> </td>
   
    <tr>
      <td><strong>Topic</strong></td>
      <td><textarea name="m_topic" type="text" id="m_topic" size="120" maxlength="120"></textarea></td>
    </tr>  
	<tr>
      <td><strong>Body</strong></td>
      <td><textarea name="m_body" type="text" id="m_body" size="120" maxlength="120"></textarea></td>
    </tr>

    <tr>
	<td class="Button" ><strong><a href="Register.html">Dont have an account ?</a></strong></label>
    <td class="Button" ><input type="submit" name="Submit" value="Create"></td>
</td>
    </tr>
  </table>
  

</form>

<?php
include ("footer.php");