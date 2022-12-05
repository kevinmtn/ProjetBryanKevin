SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS Player;
DROP TABLE IF EXISTS User;
DROP TABLE IF EXISTS Booking;
DROP TABLE IF EXISTS VideoGame;
DROP TABLE IF EXISTS Copy;
DROP TABLE IF EXISTS Loan;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE Player (
    idPlayer INTEGER NOT NULL,
    pseudo VARCHAR(20) NOT NULL,
    registrationDate DATE NOT NULL,
    dateOfBirth DATE NOT NULL,
    idUser INTEGER NOT NULL,
    userName VARCHAR(20) NOT NULL,
    password VARCHAR(20) NOT NULL,
    isAdmin BOOLEAN NOT NULL,
    PRIMARY KEY (idPlayer)
);

CREATE TABLE User (
    idUser INTEGER NOT NULL,
    username VARCHAR(20) NOT NULL,
    password VARCHAR(20) NOT NULL,
    isAdmin BOOLEAN NOT NULL,
    PRIMARY KEY (idUser)
);

CREATE TABLE Booking (
    idPlayer INTEGER NOT NULL,
    idVideoGame INTEGER NOT NULL,
    bookingDate DATE NOT NULL,
    PRIMARY KEY (idPlayer, idVideoGame)
);

CREATE TABLE VideoGame (
    idVdeoGame INTEGER NOT NULL,
    name VARCHAR(50) NOT NULL,
    creditCost INTEGER NOT NULL,
    console VARCHAR(20) NOT NULL,
    PRIMARY KEY (idVdeoGame)
);

CREATE TABLE Copy (
    idCopy INTEGER NOT NULL,
    idVideoGame INTEGER NOT NULL,
    idPlayer INTEGER NOT NULL,
    PRIMARY KEY (idCopy)
);

CREATE TABLE Loan (
    idLoan INTEGER NOT NULL,
    startDate DATE NOT NULL,
    endDate DATE NOT NULL,
    ongoing BOOLEAN NOT NULL,
    idCopy INTEGER NOT NULL,
    idBorrower INTEGER NOT NULL,
    idLender INTEGER NOT NULL,
    PRIMARY KEY (idLoan)
);

ALTER TABLE Player ADD FOREIGN KEY (idUser) REFERENCES User(idUser);
ALTER TABLE Booking ADD FOREIGN KEY (idPlayer) REFERENCES Player(idPlayer);
ALTER TABLE Booking ADD FOREIGN KEY (idVideoGame) REFERENCES VideoGame(idVdeoGame);
ALTER TABLE Copy ADD FOREIGN KEY (idPlayer) REFERENCES Player(idPlayer);
ALTER TABLE Copy ADD FOREIGN KEY (idVideoGame) REFERENCES VideoGame(idVdeoGame);
ALTER TABLE Loan ADD FOREIGN KEY (idBorrower) REFERENCES Player(idPlayer);
ALTER TABLE Loan ADD FOREIGN KEY (idCopy) REFERENCES Copy(idCopy);
ALTER TABLE Loan ADD FOREIGN KEY (idLender) REFERENCES Player(idPlayer);