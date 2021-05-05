<?php

include 'database.php';
	if(isset($_POST["email"]))
	{
		$errors = array();

		$email    = $_POST["email"];
				

		
	    $quu1 = mysqli_query($connect, "SELECT * FROM child WHERE email = '$email' LIMIT 1");
             

		$resultcheck = mysqli_num_rows($quu1);

		if ($resultcheck >= 1)
		{

			if($row = mysqli_fetch_assoc($quu1))
			{

				/* store result */
				
					 	echo "Success";

				

			}
			else
			{
				$errors[] = "Something went wrong, please try again.2";
			}
		}
		else
		{
			$errors[] = "Something went wrong, please try again.1";
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
