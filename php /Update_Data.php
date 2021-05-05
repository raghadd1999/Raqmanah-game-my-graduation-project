<?php

include 'database.php';
	if(isset($_POST["Ch_ID"]) && isset($_POST["L_ID"]))
	{
		$errors = array();

		$Ch_ID    = $_POST["Ch_ID"];
		$L_ID  = $_POST["L_ID"];
		

			echo $Ch_ID;

	echo $L_ID;
    $quu1 = mysqli_query($connect," UPDATE level SET level_Score = level_Score + 5 WHERE Ch_ID = '$Ch_ID' AND Chiled_game = '$L_ID'");
 //update score 5 marks in level

    $quu = mysqli_query($connect," UPDATE child SET Ch_Total_Score = Ch_Total_Score + 5 WHERE chaildID = '$Ch_ID'");
		// update score 5 marks in total
		
		
	}
	else
	{
		echo "Missing Data!";
	}
?>
