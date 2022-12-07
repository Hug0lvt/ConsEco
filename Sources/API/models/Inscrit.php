<?php

    class Inscrit{
        private $conn;
        private $table = 'Inscrit';

        public $id;
        public $nom;
        public $prenom;
        public $mail;
        public $mdp;

        public function __construct($db){
            $this->conn = $db;
        }
    
        public function read(){
            $query = 'SELECT 
                    i.id as id,
                    i.nom as nom,
                    i.prenom as prenom,
                    i.mail as mail,
                    i.mdp as mdp
                FROM 
                    '.$this->table.' i
                ORDER BY
                    i.id';

            $stmt = $this->conn->prepare($query);
            $stmt->execute();
            return $stmt;
        }

        public function readMdpFromMail($mail){
            $query = 'SELECT 
                    i.mdp as mdp
                FROM
                    '.$this->table.' i
                WHERE
                    i.mail=:mail
                ';
            $stmt = $this->conn->prepare($query);
            $stmt->bindValue(':mail',$mail, PDO::PARAM_STR);
            $stmt->execute();
            return $stmt;
        }
    }

?>