<?php
 
 
 $data = $_POST;

if (empty($data['username']) ||
    empty($data['password']) ||
    empty($data['email']))
    {
    
    die('Please fill all required fields!');
    }

    $host       ="localhost";
    $user       ="id16572382_root";
    $pass       ="QWER1234qwer#";
    $database   ="id16572382_raqmanah";

    $connect = new mysqli($host, $user, $pass, $database);

    if (!$connect) 
    {
        die ("connection failed: " . mysqli_connect_error());
    }
     else 
    {
        $connect->set_charset('utf8');
        $username= $_POST["username"];
        $password= $_POST["password"];
        $email= $_POST["email"];
        $sharingPermission= "1";

  
$sql_u = "SELECT * FROM child WHERE username='$username'";
  	$sql_e = "SELECT * FROM child WHERE email='$email'";
  	$res_u = mysqli_query($connect, $sql_u);
  	$res_e = mysqli_query($connect, $sql_e);

  	if (mysqli_num_rows($res_u) > 0)
  	 {
  	  echo 'ﺎﻘﺑﺎﺳ ﺩﻮﺟﻮﻣ ﻡﺪﺨﺘﺴﻤﻟﺍ ﻢﺳﺍ'; 	
   	 }
  	else if(mysqli_num_rows($res_e) > 0)
  	 {
  	  echo  'ﻡﺪﺨﺘﺴﻣ ﻲﻧﻭﺮﺘﻜﻟﻹﺍ ﺪﻳﺮﺒﻟﺍ'; 	
  	 }
  	 else
  	 {
          $stmt = $connect->prepare("INSERT INTO child (	username, password, email,sharingPermission) VALUES ( ?, ? ,? , ? )");
        $stmt->bind_param("ssss",$username, $password, $email, $sharingPermission);

       $stmt->execute();

        $stmt->close();

       $sql = "SELECT * FROM child ORDER BY chaildID DESC LIMIT 0, 1";
       $result = $connect->query($sql);
       
      if ($result->num_rows > 0) {
        // output data of each row
       while($row = $result->fetch_assoc()) {
               $Ch_ID = $row["chaildID"];
       }
       } 
       else 
       {
          echo "0 results";
        }
        $stmt1 = $connect->prepare("INSERT INTO level(Ch_ID, Chiled_game, level_Score) VALUES ( ?, 1 ,0 )");
        $stmt1->bind_param("s",$Ch_ID);

       $stmt1->execute();

        $stmt1->close();
        $stmt1 = $connect->prepare("INSERT INTO level(Ch_ID, Chiled_game, level_Score) VALUES ( ?, 2 ,0 )");
        $stmt1->bind_param("s",$Ch_ID);

       $stmt1->execute();

        $stmt1->close();

$stmt1 = $connect->prepare("INSERT INTO level(Ch_ID, Chiled_game, level_Score) VALUES ( ?, 3 ,0 )");
        $stmt1->bind_param("s",$Ch_ID);

       $stmt1->execute();

        $stmt1->close();

$stmt1 = $connect->prepare("INSERT INTO level(Ch_ID, Chiled_game,level_Score) VALUES ( ?, 4 ,0 )");
        $stmt1->bind_param("s",$Ch_ID);

       $stmt1->execute();

        $stmt1->close();

$stmt1 = $connect->prepare("INSERT INTO level(Ch_ID, Chiled_game, level_Score) VALUES ( ?, 5 ,0 )");
        $stmt1->bind_param("s",$Ch_ID);

       $stmt1->execute();

        $stmt1->close();

        echo $Ch_ID;
             
	 }
	    $connect->close();
	    
    }