<?php
include_once 'myDB.php';
    $query = mysqli_query($db, "SELECT `name`, `posX`, `posY`, `posZ` FROM `sceneSaveTest`;");
    while(($row = mysqli_fetch_array($query))){
        $rows[] = $row;
    }
    
    echo json_encode($rows);
?>