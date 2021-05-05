<?php

include 'database.php';
	if(isset($_POST["Ch_ID"]) && isset($_POST["Q_ID"]))
	{
		$errors = array();

		$Ch_ID    = $_POST["Ch_ID"];
		$Q_ID  = $_POST["Q_ID"];
		

			echo $Ch_ID;

	echo $Q_ID;

	    $quu1 = mysqli_query($connect, "SELECT * FROM chiled_questions WHERE CH_ID = '$Ch_ID' AND Q_ID= '$Q_ID' LIMIT 1");
             

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
