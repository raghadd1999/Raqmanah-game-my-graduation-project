<?php

include 'database.php';
	if(isset($_POST["Ch_ID"]) && isset($_POST["L_ID"]))
	{
		$errors = array();

		$Ch_ID    = $_POST["Ch_ID"];
		$L_ID  = $_POST["L_ID"];
		

			echo $Ch_ID;

	echo $L_ID;

	    $quu1 = mysqli_query($connect, "SELECT * FROM level WHERE Ch_ID = '$Ch_ID' AND Chiled_game= '$L_ID' LIMIT 1");
              

		$resultcheck = mysqli_num_rows($quu1);

		if ($resultcheck >= 1)
		{

			if($row = mysqli_fetch_assoc($quu1))
			{

				/* store result */
				
					 	echo "Success" . "|" . $row['Chiled_game'] . "|" . $row['level_Score'];

				

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
