<?php
include_once 'myDB.php';
    $login = $_GET["login"];
    $query = mysqli_query($db, "SELECT `inventory`.`name`, `userinfo`.`inventcount` FROM `inventory`,`userinfo` WHERE `userinfo`.`userid` = (SELECT `id` FROM `users` WHERE `login` = '$login') and `inventory`.`id`=`userinfo`.`inventid`;");
    while(($row = mysqli_fetch_array($query))){
        $rows[] = $row;
    }
    echo json_encode($rows);
?>