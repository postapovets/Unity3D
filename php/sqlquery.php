<?php
include_once 'myDB.php';
//$result = mysqli_query($db, "create table users (id INT NOT NULL AUTO_INCREMENT, login varchar(16), password varchar(256), email varchar(256), isactive int, PRIMARY KEY (id) );");
//$result = mysqli_query($db, "drop table users;");
//$result = mysqli_query($db, "select * from users;");
//
//$result = mysqli_query($db, "drop table userinfo;");
//$result = mysqli_query($db, "create table userinfo (id INT NOT NULL AUTO_INCREMENT, userid int NOT NULL REFERENCES users(id), inventid int NOT NULL REFERENCES inventory(id), inventcount int, PRIMARY KEY (id) );");
//$result = mysqli_query($db, "create table inventory (id INT NOT NULL AUTO_INCREMENT, name varchar(32) not null, decription varchar(256), PRIMARY KEY (id) );");
var_dump($result);
?>
