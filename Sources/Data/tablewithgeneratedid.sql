DROP TABLE Planification;
DROP TABLE Opération;
DROP TABLE Echeancier;
DROP TABLE Compte;
DROP TABLE InscrBanque;
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
    CONSTRAINT ck_methPaye CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
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
    CONSTRAINT ck_methPaye CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
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
    CONSTRAINT ck_methPaye CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
    FOREIGN KEY(compte) REFERENCES Compte(id),
    UNIQUE (datecrea,compte)
);,