DROP TABLE Planification;
DROP TABLE Opération;
DROP TABLE Echeancier;
DROP TABLE Compte;
DROP TABLE Banque;
DROP TABLE DeviseInscrit;
DROP TABLE Inscrit;
DROP TABLE Devise;


CREATE TABLE Devise
(
    id char(3) PRIMARY KEY,
    nom varchar(20)
);

CREATE TABLE Inscrit
(
    id char(5) PRIMARY KEY,
    nom varchar(40),
    prenom varchar(40),
    mail varchar(40),
    mdp varchar(40)
);

CREATE TABLE DeviseInscrit
(
    devise char(3),
    idInscrit char(5) UNIQUE,
    PRIMARY KEY(devise,idInscrit),
    FOREIGN KEY (devise) REFERENCES Devise(id),
    FOREIGN KEY (idInscrit) REFERENCES Inscrit(id)
);

CREATE TABLE Banque
(
    nom varchar(40) PRIMARY KEY,
    urlsite varchar(60),
    urllogo varchar(60)
);

CREATE TABLE Compte
(
    id char (5) PRIMARY KEY,
    nomBanque varchar(40),
    nom varchar(40),
    idInscrit char(5),
    FOREIGN KEY (nomBanque) REFERENCES Banque(nom),
    FOREIGN KEY (idInscrit) REFERENCES Inscrit(id),
    UNIQUE(nomBanque,nom,idInscrit)
);

CREATE TABLE Echeancier
(
    id char(5) PRIMARY KEY,
    nom varchar(40),
    credit numeric,
    compte char(5),
    debit numeric,
    dateE date,
    datecrea date,
    methodePayement varchar(20),
    CONSTRAINT ck_methPaye CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
    FOREIGN KEY(compte) REFERENCES Compte(id),
    UNIQUE (datecrea,compte)
);

CREATE TABLE Opération
(
    id char(5) PRIMARY KEY,
    nom varchar(40),
    credit numeric,
    compte char(5),
    debit numeric,
    dateO date,
    datecrea date,
    methodePayement varchar(20),
    CONSTRAINT ck_methPaye CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
    FOREIGN KEY(compte) REFERENCES Compte(id),
    UNIQUE (datecrea,compte)
);

CREATE TABLE Planification
(
    id char(5) PRIMARY KEY,
    nom varchar(40),
    credit numeric,
    compte char(5),
    debit numeric,
    dateP date,
    datecrea date,
    methodePayement varchar(20),
    CONSTRAINT ck_methPaye CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
    FOREIGN KEY(compte) REFERENCES Compte(id),
    UNIQUE (datecrea,compte)
);