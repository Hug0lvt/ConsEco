<?php

class MdlInscrit{

    static function selectAll(){
        global $dsn, $usr, $mdp;

        $con = new Connection($dsn, $usr, $mdp);
        $gateway = new InscritGateway($con);
        return $gateway->selectAll();
    }
}

?>