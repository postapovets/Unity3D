<?php
    include_once 'myDB.php';
    if (isset($_POST['name']) && isset($_POST['level']) && isset($_POST['score'])) {
        $name = mysqli_real_escape_string($db, $_POST['name']);
        $level = (int) $_POST['level'];
        $score = (int) $_POST['score'];
        
        $result = mysqli_query($db, "SELECT `name` FROM `users` WHERE `name` = '$name';");
        $numRows = mysqli_num_rows($result);
        mysqli_free_result($result);
        if ( $numRows > 0) { //update record
            mysqli_query($db, "UPDATE `users` SET `name` = '$name', `level` = $level, `score` = $score WHERE `name` = '$name';");
        } else { // insert record
            mysqli_query($db, "INSERT INTO `users`(`name`, `level`, `score`) VALUES ('$name', $level, $score);");
        }
    } else {
        echo " Params not posted ";
    }
?>