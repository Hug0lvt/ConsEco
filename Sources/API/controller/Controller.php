<?php

class Controller{
    
    function __construct($url){
        switch($url[0]){
            case "SELECT":
                switch($url[1]){
                    case "Inscrit":
                        $res=MdlInscrit::selectAll();
                        print(json_encode($res));
                        break;
                }
                break;
            default:
                echo "ERREUR";
        }
    }
}

?>