<?php
include_once 'myDB.php';
    $query = mysqli_query($db, "SELECT `login` FROM `users`;");
    while(($row = mysqli_fetch_array($query))){
        $rows[] = $row;
    }
    echo json_encode($rows);
?>