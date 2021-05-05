<?php

include 'database.php';


 $data = $_POST;

if (
    empty($data['password']) ||
    empty($data['email']))
    {
    
    die(' ﻝﻮﻘﺤﻟﺍ ﻊﻴﻤﺟ ﻪﺌﺒﻌﺗ ﺀﺎﺟﺮﻟﺍ');
    }

if ($data['password'] !== $data['password_confirm']) 
{
   die('Password and Confirm password should match!');   
}

$password= $_POST["password"];
$email= $_POST["email"];
 if (!$connect) 
    {
        die ("connection failed: " . mysqli_connect_error());
    }
     else 
    {

    $quu1 = mysqli_query($connect," UPDATE `child` SET 	`password`='$password'   WHERE `email` ='$email'");
	echo "Success";
    }
		
 
				
?>
