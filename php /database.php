
<?php


    //database configuration
    $host       ="localhost";
    $user       ="id16572382_root";
    $pass       ="QWER1234qwer#";
    $database   ="id16572382_raqmanah";

    $connect = new mysqli($host, $user, $pass, $database);

    if (!$connect) {
        die ("connection failed: " . mysqli_connect_error());
    } else {
        $connect->set_charset('utf8');
    }

	$GLOBALS['config'] = $connect;


    $ENABLE_RTL_MODE = 'false';

?>
