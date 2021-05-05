<?php

include 'database.php';
	if(isset($_POST["Ch_ID"]))
	{
		$errors = array();

		$Ch_ID    = $_POST["Ch_ID"];
		       
              
 
          $quu1 = mysqli_query($connect, "Delete FROM chiled_questions WHERE CH_ID = '$Ch_ID' ");
 

		  $quu1 = mysqli_query($connect, "Delete FROM level WHERE Ch_ID = '$Ch_ID' ");

          $quu1 = mysqli_query($connect, "Delete FROM child WHERE chaildID = '$Ch_ID' ");

         echo "Success";

	}
	else
	{
		echo "Missing data";
	}
?>
