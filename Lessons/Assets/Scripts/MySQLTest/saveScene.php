<?php
    include_once 'myDB.php';
    if (isset($_POST['name']) && isset($_POST['posX']) && isset($_POST['posY']) && isset($_POST['posZ'])) {
        $name = mysqli_real_escape_string($db, $_POST['name']);
        $posX = (float) $_POST['posX'];
        $posY = (float) $_POST['posY'];
        $posZ = (float) $_POST['posZ'];
        echo "name=$name PosX=$posX PosY=$posY PosZ=$posZ";
        $result = mysqli_query($db, "SELECT `name` FROM `sceneSaveTest` WHERE `name` = '$name';");
        $numRows = mysqli_num_rows($result);
        mysqli_free_result($result);
        if ( $numRows > 0) { //update record
            mysqli_query($db, "UPDATE `sceneSaveTest` SET `name` = '$name', `posX` = '$posX', `posY` = '$posY', `posZ` = '$posZ' WHERE `name` = '$name';");
        } else { // insert record
            $str = "INSERT INTO `sceneSaveTest`(`name`, `posX`, `posY`, `posZ`) VALUES ('$name', '$posX', '$posY', '$posZ');";
            mysqli_query($db, $str);
        }
    } else {
        echo " Params not posted ";
    }
?>