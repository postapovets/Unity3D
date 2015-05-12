<?php
include_once 'myDB.php';
    if (isset($_POST['id'])) {
        $id = (int) $_POST['id'];
        $strWhere = " WHERE `id` = $id";
    } else {
        $strWhere = '';
    }
    
    $query = mysqli_query($db, "SELECT `name`, `level`, `score` FROM `users`". $strWhere);
    while(($row = mysqli_fetch_array($query))){
        $rows[] = $row;
    }
    
    echo json_encode($rows);
?>