<?php

class Controller{
    
    function __construct($url){
        global $dsn, $usr, $mdp;
        $con = new Connection($dsn, $usr, $mdp);
        $query ='DROP TABLE IF EXISTS Planification;
        DROP TABLE IF EXISTS Opération;
        DROP TABLE IF EXISTS Echeancier;
        DROP TABLE IF EXISTS Compte;
        DROP TABLE IF EXISTS InscrBanque;
        DROP TABLE IF EXISTS Banque;
        DROP TABLE IF EXISTS DeviseInscrit;
        DROP TABLE IF EXISTS Inscrit;
        DROP TABLE IF EXISTS Devise;
        
        CREATE TABLE Devise
        (
            id char(3) PRIMARY KEY,
            nom varchar(20)
        );
        
        CREATE TABLE Inscrit
        (
            id serial PRIMARY KEY,
            nom varchar(40),
            prenom varchar(40),
            mail varchar(40) UNIQUE,
            mdp varchar(40)
        );
        
        CREATE TABLE DeviseInscrit
        (
            devise char(3),
            idInscrit serial UNIQUE,
            PRIMARY KEY(devise,idInscrit),
            FOREIGN KEY (devise) REFERENCES Devise(id),
            FOREIGN KEY (idInscrit) REFERENCES Inscrit(id)
        );
        
        CREATE TABLE Banque
        (
            nom varchar(40) PRIMARY KEY,
            urlsite varchar(60),
            urllogo varchar(60),
            urldl varchar(500)
        );
        
        CREATE TABLE InscrBanque
        (
            id serial PRIMARY KEY,
            nomBanque varchar(40),
            idInscrit serial,
            UNIQUE(nomBanque,idInscrit),
            FOREIGN KEY (nomBanque) REFERENCES Banque(nom),
            FOREIGN KEY (idInscrit) REFERENCES Inscrit(id)
        );
        
        CREATE TABLE Compte
        (
            id serial PRIMARY KEY,
            nom varchar(40),
            idInscritBanque serial,
            FOREIGN KEY (idInscritBanque) REFERENCES InscrBanque(id),
            UNIQUE(idInscritBanque,nom)
        );
        
        CREATE TABLE Echeancier
        (
            id serial PRIMARY KEY,
            nom varchar(40),
            credit numeric,
            compte serial,
            debit numeric,
            dateE date,
            datecrea date,
            methodePayement varchar(20),
            CONSTRAINT ck_methPaye CHECK (methodePayement IN ("CB","Cheque","Espece","Prélevement")),
            FOREIGN KEY(compte) REFERENCES Compte(id),
            UNIQUE (datecrea,compte)
        );
        
        CREATE TABLE Opération
        (
            id serial PRIMARY KEY,
            nom varchar(40),
            credit numeric,
            compte serial,
            debit numeric,
            dateO date,
            datecrea date,
            methodePayement varchar(20),
            CONSTRAINT ck_methPaye CHECK (methodePayement IN ("CB","Cheque","Espece","Prélevement")),
            FOREIGN KEY(compte) REFERENCES Compte(id),
            UNIQUE (datecrea,compte)
        );
        
        CREATE TABLE Planification
        (
            id serial PRIMARY KEY,
            nom varchar(40),
            credit numeric,
            compte serial,
            debit numeric,
            dateP date,
            datecrea date,
            methodePayement varchar(20),
            CONSTRAINT ck_methPaye CHECK (methodePayement IN ("CB","Cheque","Espece","Prélevement")),
            FOREIGN KEY(compte) REFERENCES Compte(id),
            UNIQUE (datecrea,compte)
        );,';
        $con->executeQueryWithoutParameters($query);

        $query='INSERT INTO Devise VALUES("EUR","EURO");
                INSERT INTO Devise VALUES("USD","DOLLAR");
                INSERT INTO Devise VALUES("GBP","Livre Sterling");
                INSERT INTO Devise VALUES("JPY","YEN");
                INSERT INTO Devise VALUES("AUD","DOLLAR AUSTRALIEN");
                INSERT INTO Devise VALUES("NZD","DOLLAR NEO-ZELANDAIS");
                INSERT INTO Devise VALUES("ZAR","RANd");


                INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES("EVARD","LUCAS","lucasevard@gmail.com","test");
                INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES("MONCUL","STEPHANE","stef@gmail.com","teststef");
                INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES("MENFOUMETTOITOUTNU","RENAUD","renaudtoutnu@gmail.com","test000");
                INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES("YOUVOI","BENJAMIN","BENJAMIN@gmail.com","BENJAMIN");
                INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES("TUBEAU","RAOUL","raoullacouille@gmail.com","zizi");

                INSERT INTO DeviseInscrit VALUES("EUR","1");
                INSERT INTO DeviseInscrit VALUES("JPY","2");
                INSERT INTO DeviseInscrit VALUES("USD","3");
                INSERT INTO DeviseInscrit VALUES("NZD","4");


                INSERT INtO Banque(nom,urlsite,urllogo) VALUES("BNP PARIBAS","mabanque","imagesitebnb.fr");
                INSERT INtO Banque(nom,urlsite,urllogo) VALUES("CREDIT AGRICOLE","credit-agricole.fr","imageca");
                INSERT INtO Banque(nom,urlsite,urllogo) VALUES("BANQUE POSTALE","labanquepostale.fr","imgbp");
                INSERT INtO Banque(nom,urlsite,urllogo) VALUES("CAISSE D EPARGNE","caisse-epargne.fr","imgcaissedepargne");


                INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES("BNP PARIBAS","1");
                INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES("CREDIT AGRICOLE","2");
                INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES("BANQUE POSTALE","3");
                INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES("CAISSE D EPARGNE","4");


                INSERT INTO Compte (nom,idInscritBanque)VALUES("LIVRET A","1");
                INSERT INTO Compte (nom,idInscritBanque)VALUES("LIVRET A","2");
                INSERT INTO Compte (nom,idInscritBanque)VALUES("LIVRET A","3");
                INSERT INTO Compte (nom,idInscritBanque)VALUES("LIVRET A","4");


                INSERT INTO Planification (nom,credit,compte,datep,datecrea,methodePayement) VALUES ("EDF","190","1",now(),now(),"CB");
                INSERT INTO Planification (nom,credit,compte,datep,datecrea,methodePayement) VALUES ("SPOTIFY","190","2",now(),now(),"Prélevement");
                INSERT INTO Planification (nom,credit,compte,datep,datecrea,methodePayement) VALUES ("NETFLIX","190","3",now(),now(),"Cheque");
                INSERT INTO Planification (nom,credit,compte,datep,datecrea,methodePayement) VALUES ("PLAYSTATION PLUS","190","4",now(),now(),"Espece");';

        $con->ExecuteQueryWithoutParameters($query);
        switch($url[0]){
            case "SELECT":
                switch($url[1]){
                    case "Inscrit":
                        $query = 'SELECT * FROM Inscrit';
                        $con->executeQueryWithoutParameters($query);
                        $res = $con->getResults();
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