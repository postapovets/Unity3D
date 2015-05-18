<?php
include_once 'myDB.php';
if (isset($_POST['id']) && isset($_POST["amount"])) {
    $id = (int) $_POST['id'];
    $amount = (int) $_POST["amount"];
    $qryStr = "UPDATE `userinfo` SET `inventcount`=`inventcount`+$amount WHERE `id`=$id";
    if (mysqli_query($db, $qryStr))
        exit ("Ok");
    else
        exit ("Error");
}
?>