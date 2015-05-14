<?php
    include_once 'myDB.php';
    
    if (isset($_POST['login']) && isset($_POST['password'])) {
        $login = mysqli_real_escape_string($db, $_POST['login']);
        $password = mysqli_real_escape_string($db, $_POST['password']);
        $result = mysqli_query($db, "SELECT * FROM `users` WHERE `login` = '$login';");
        $numRows = mysqli_num_rows($result);
        mysqli_free_result($result);
        if ($numRows == 0) {
            if (mysqli_query($db, "INSERT INTO `users`(`login`, `password`, `isactive`) VALUES ('$login', '$password', 1);")) {
                exit('Ok');
            } else {
                exit ('Unknown error.');
            }
        } else {
            exit('Error. Login already exists.');
        }
    } else {
        exit('Error. Login and Password required.');
    }
?>