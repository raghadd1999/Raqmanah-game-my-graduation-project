<?php

include 'database.php';

$sql = "SELECT * FROM child ORDER BY  Ch_Total_Score  DESC LIMIT 10 ";
if($result = mysqli_query($connect, $sql)){
    if(mysqli_num_rows($result) > 0){
            echo "Success" ."|" ;
               while($row = mysqli_fetch_array($result)){
             echo $row['username']."|".$row['Ch_Total_Score']."|";

          
                          
        }
       // Free result set
        mysqli_free_result($result);
    } else{
        echo "No records matching your query were found.";
    }
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
		
		?>
