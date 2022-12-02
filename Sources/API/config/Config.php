<?php
//prefixe
$rep=__DIR__.'/../';

$dsn='mysql:host='.getenv("DB_SERVER").';dbname='.getenv("MARIADB_DATABASE");
$dbname=getenv("MARIADB_DATABASE");
$usr=getenv("MARIADB_USER");
$mdp=getenv("MARIADB_PASSWORD");
?>