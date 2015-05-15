<?php
include_once 'myDB.php';
if (isset($_POST['login'])) {
    $login = mysqli_real_escape_string($db, $_POST['login']);
    $query = mysqli_query($db, "SELECT `inventory`.`name`, `userinfo`.`inventcount` FROM `userinfo`, `inventory` WHERE `userinfo`.`userid`= (select `id` from `users` where `login` = '$login') and `userinfo`.`inventid` = `inventory`.`id`;");
    while (($row = mysqli_fetch_array($query))) {
        $rows[] = $row;
    }
    echo json_encode($rows);
}
?>