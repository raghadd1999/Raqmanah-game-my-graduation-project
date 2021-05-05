<?php

include 'database.php';
	if(isset($_POST["User"]))
	{
		$errors = array();

		$email    = $_POST["User"];
		       
          


		$quu1 = mysqli_query($connect, "SELECT * FROM child WHERE email = '$email' LIMIT 1");


		$resultcheck = mysqli_num_rows($quu1);

		if ($resultcheck >= 1) 
		{
            if($row = mysqli_fetch_assoc($quu1))
			{

			
					 	echo  $row['password'];

			}

         }
		else
		{
			$errors[] = "wrong";
		}

		if(count($errors) > 0){
			echo $errors[0];
		}

		
	}
	else
	{
		echo "Missing data";
	}
?>
