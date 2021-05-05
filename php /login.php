<?php

include 'database.php';
	if(isset($_POST["User"]))
	{
		$errors = array();

		$email    = $_POST["User"];
		       
              //Connect to database
		//require dirname(__FILE__) . '/database.php';


		$quu1 = mysqli_query($connect, "SELECT * FROM child WHERE email = '$email' LIMIT 1");


		$resultcheck = mysqli_num_rows($quu1);

		if ($resultcheck >= 1)
		 {

			if($row = mysqli_fetch_assoc($quu1))
			{


				
					 	echo "Success" . "|" . $row['username'] . "|" .  $email . "|" .$row['chaildID'] ."|" .$row['Ch_Total_Score'];

			
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

		if(count($errors) > 0)
		{
			echo $errors[0];
		}

		
	}
	else
	{
		echo "Missing data";
	}
?>
