<?php
 
 
 $data = $_POST;

if (empty($data['Ch_ID']) ||
    empty($data['Q_ID']))
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
        $Ch_ID    = $_POST["Ch_ID"];
         $Q_ID  = $_POST["Q_ID"];

  
          $stmt = $connect->prepare("INSERT INTO chiled_questions(	CH_ID, Q_ID) VALUES ( ?, ? )");
        $stmt->bind_param("ss", $Ch_ID, $Q_ID);

       $stmt->execute();

        $stmt->close();

       	 
	    $connect->close();
	    
    }