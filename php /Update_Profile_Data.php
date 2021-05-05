<?php

include 'database.php';


 $data = $_POST;

if (empty($data['Ch_ID']) ||
    empty($data['username']) ||
    empty($data['password']) ||
    empty($data['email']) ||
    empty($data['password_confirm']))
    {
    
    die('Please fill all required fields!');
    }


if ($data['password'] !== $data['password_confirm']) 
{
   die('Password and Confirm password should match!');   
}
$Ch_ID = $_POST["Ch_ID"];
$username= $_POST["username"];
$password= $_POST["password"];
$email= $_POST["email"];
 if (!$connect) 
    {
        die ("connection failed: " . mysqli_connect_error());
    }
     else 
    {

     $sql_u = "SELECT * FROM child WHERE username='$username'";
  	$sql_e = "SELECT * FROM child WHERE email='$email'";
  	
    $result_u = $connect->query($sql_u);
  	 $result_e = $connect->query($sql_e);
  	
  	 if ($result_u->num_rows > 0)
  	 {
  	 $Ch_ID_u;
  	    while($row = $result_u->fetch_assoc()) 
  	   {
               $Ch_ID_u = $row["chaildID"];
       }
        echo   $Ch_ID_u ;
        echo $_POST["Ch_ID"];
        
       if( $Ch_ID_u != $_POST["Ch_ID"] )
         {
            echo 'ﻞﻌﻔﻟﺎﺑ ﺫﻮﺧﺄﻣ ﻡﺪﺨﺘﺴﻤﻟﺍ ﻢﺳﺍ '; 	
         }
		  else
  	     {

               $quu1 = mysqli_query($connect," UPDATE `child` SET 	`username` = '$username' , `email` ='$email',`password`='$password'   WHERE `chaildID` = '$Ch_ID'");
	           echo "Success";
         }
  	 
   	 }
  	 else
  	 {

$quu1 = mysqli_query($connect," UPDATE `child` SET 	`username` = '$username' , `email` ='$email',`password`='$password'   WHERE `chaildID` = '$Ch_ID'");
	echo "Success";
    }
		
    }
				
?>