<?php
    include_once 'myDB.php';
    
    if (isset($_POST['login']) && isset($_POST['password'])) {
        $login = mysqli_real_escape_string($db, $_POST['login']);
        $password = mysqli_real_escape_string($db, $_POST['password']);
        $result = mysqli_query($db, "SELECT * FROM `users` WHERE `login` = '$login' and `password` = '$password';");
        $numRows = mysqli_num_rows($result);
        mysqli_free_result($result);
        if ($numRows > 0) {
            exit('Ok');
        } else {
            exit ('Not Ok');
        }
    } else {
        exit ('Error. Login and Password required.');
    }
?>

