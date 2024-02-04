\c postgres

DROP DATABASE prevision_coupure;

CREATE DATABASE prevision_coupure;

\c prevision_coupure



--------------------------------------------  CREATE  ---------------------------------------------------



CREATE TABLE Source(
    idSource serial primary key,
    capacitePanneau double precision,
    capaciteBatterie double precision,
    coupureBatterie double precision
);

CREATE TABLE Salle(
    idSalle serial primary key,
    nomSalle varchar,
    idSource int,

    foreign key(idSource) references Source(idSource)
);

CREATE TABLE Pointage(
    idPointage serial primary key,
    datePointage date,
    nbEtudiant int,
    partieJournee int,              -- 0:matin  10:apres midi
    idSalle int,

    foreign key(idSalle) references Salle(idSalle) 
);

CREATE TABLE Journee(
    idJournee serial primary key,
    dateJournee date
);

CREATE TABLE DetailsJournee(
    idDetails serial primary key,
    heure time,
    luminosite double precision,
    idJournee int,

    foreign key(idJournee) references Journee(idJournee) 
);

CREATE TABLE Coupure(
    idCoupure serial primary key,
    idSource int,
    heureCoupure timestamp,

    foreign key(idSource) references Source(idSource) 
);



----------------------------------------------- INSERT ----------------------------------------------------



-- INSERT INTO Source VALUES   (default, 12000, 9200),
--                             (default, 12000, 9200),
--                             (default, 15000, 11500);


-- INSERT INTO Salle VALUES(default, 'S1 Info', 1),
--                         --(default, 'S1 Design', 1),
--                         (default, 'S3 Info', 2),
--                         --(default, 'S3 Design', 2),
--                         (default, 'S5 Info', 3);
--                         --(default, 'S5 Design', 3);


-- INSERT INTO Pointage VALUES (default, '2023-12-08', 110, 0, 1),                 -- zoma
--                             (default, '2023-12-08', 92, 10, 1),

--                             (default, '2023-12-07', 75, 0, 1),
--                             (default, '2023-12-07', 96, 10, 1),

--                             (default, '2023-12-01', 68, 0, 1),                 -- zoma
--                             (default, '2023-12-01', 42, 10, 1);


-- INSERT INTO Journee VALUES  (default, '2023-12-08'),
--                             (default, '2023-12-07'),
--                             (default, '2023-12-01');


-- INSERT INTO DetailsJournee VALUES   (default, '08:00', 6, 1),
--                                     (default, '09:00', 7, 1),
--                                     (default, '10:00', 9, 1),
--                                     (default, '11:00', 9, 1),
--                                     (default, '14:00', 10, 1),
--                                     (default, '15:00', 7, 1),
--                                     (default, '16:00', 5, 1),
--                                     (default, '17:00', 4, 1),

--                                     (default, '08:00', 8, 2),
--                                     (default, '09:00', 7, 2),
--                                     (default, '10:00', 4, 2),
--                                     (default, '11:00', 9, 2),
--                                     (default, '14:00', 6, 2),
--                                     (default, '15:00', 4, 2),
--                                     (default, '16:00', 1, 2),
--                                     (default, '17:00', 2, 2), 

--                                     (default, '08:00', 7, 3),
--                                     (default, '09:00', 7, 3),
--                                     (default, '10:00', 7, 3),
--                                     (default, '11:00', 9, 3),
--                                     (default, '14:00', 8, 3),
--                                     (default, '15:00', 5, 3),
--                                     (default, '16:00', 5, 3),
--                                     (default, '17:00', 7, 3);


-- INSERT INTO Coupure VALUES  (default, 1, '2023-12-08 14:15'),   
--                             (default, 2, '2023-12-07 15:05'), 
--                             (default, 3, '2023-12-01 10:43');



----------------------------- Donnee Zoky Tojo Mandresy -------------------------------------------


-- INSERT INTO Source VALUES   (default, 25000, 5000, 50);


-- INSERT INTO Salle VALUES(default, 'S1', 1),
--                         (default, 'S2', 1);


-- INSERT INTO Pointage VALUES (default, '2023-12-08', 150, 0, 1),                 
--                             (default, '2023-12-08', 130, 10, 1),
--                             (default, '2023-12-08', 134, 0, 2),                 
--                             (default, '2023-12-08', 156, 10, 2);


-- INSERT INTO Journee VALUES  (default, '2023-12-08');


-- INSERT INTO DetailsJournee VALUES   (default, '08:00', 7, 1),
--                                     (default, '09:00', 6, 1),
--                                     (default, '10:00', 7, 1),
--                                     (default, '11:00', 8, 1),
--                                     (default, '14:00', 7, 1),
--                                     (default, '15:00', 6, 1),
--                                     (default, '16:00', 4, 1),
--                                     (default, '17:00', 5, 1);


-- INSERT INTO Coupure VALUES  (default, 1, '2023-12-08 16:12');



--------------------------------- donnée Mendrika --------------------------------



-- INSERT INTO Source VALUES   (default, 40000, 50000, 50),
--                             (default, 50000, 60000, 50);

                
-- INSERT INTO Salle VALUES(default, 'Salle 1', 1),
--                         (default, 'Salle 2', 1),
--                         (default, 'Amphi C', 2),
--                         (default, 'Salle design', 2);

    
-- INSERT INTO Pointage VALUES (default, '2023-12-12', 152, 0, 1),                 
--                             (default, '2023-12-12', 150, 10, 1),
--                             (default, '2023-12-12', 124, 0, 2),                 
--                             (default, '2023-12-12', 130, 10, 2),
--                             (default, '2023-12-05', 135, 0, 1),
--                             (default, '2023-12-05', 165, 10, 1),
--                             (default, '2023-12-05', 125, 0, 2),
--                             (default, '2023-12-05', 112, 10, 2),
--                             (default, '2023-11-28', 132, 0, 1),
--                             (default, '2023-11-28', 150, 10, 1),
--                             (default, '2023-11-28', 150, 0, 2),
--                             (default, '2023-11-28', 145, 10, 2);


-- INSERT INTO Journee VALUES  (default, '2023-12-12'),
--                             (default, '2023-12-05'),
--                             (default, '2023-11-28'),
--                             (default, '2023-12-19');


-- INSERT INTO DetailsJournee VALUES   (default, '08:00', 4, 1),
--                                     (default, '09:00', 5, 1),
--                                     (default, '10:00', 6, 1),
--                                     (default, '11:00', 7, 1),
--                                     (default, '12:00', 8, 1),
--                                     (default, '14:00', 6, 1),
--                                     (default, '15:00', 4, 1),
--                                     (default, '16:00', 3, 1),
--                                     (default, '17:00', 3, 1),

--                                     (default, '08:00', 4, 2),
--                                     (default, '09:00', 5, 2),
--                                     (default, '10:00', 6, 2),
--                                     (default, '11:00', 7, 2),
--                                     (default, '12:00', 8, 2),
--                                     (default, '14:00', 6, 2),
--                                     (default, '15:00', 4, 2),
--                                     (default, '16:00', 3, 2),
--                                     (default, '17:00', 3, 2),

--                                     (default, '08:00', 4, 3),
--                                     (default, '09:00', 5, 3),
--                                     (default, '10:00', 6, 3),
--                                     (default, '11:00', 7, 3),
--                                     (default, '12:00', 8, 3),
--                                     (default, '14:00', 6, 3),
--                                     (default, '15:00', 4, 3),
--                                     (default, '16:00', 3, 3),
--                                     (default, '17:00', 3, 3),

--                                     (default, '08:00', 4, 4),
--                                     (default, '09:00', 5, 4),
--                                     (default, '10:00', 6, 4),
--                                     (default, '11:00', 7, 4),
--                                     (default, '12:00', 8, 4),
--                                     (default, '14:00', 6, 4),
--                                     (default, '15:00', 4, 4),
--                                     (default, '16:00', 3, 4),
--                                     (default, '17:00', 3, 4);

                        
-- INSERT INTO Coupure VALUES  (default, 1, '2023-12-12 16:00'),
--                             (default, 1, '2023-12-05 15:00'),
--                             (default, 1, '2023-11-28 14:00');


    
--------------------------------------- Donnee Koto ------------------------------------


INSERT INTO Source VALUES   (default, 25000, 19200, 50);

INSERT INTO Salle VALUES(default, 'Salle 1', 1);

INSERT INTO Pointage VALUES (default, '2023-11-01', 300, 0, 1),                 
                            (default, '2023-11-01', 280, 10, 1),
                            (default, '2023-11-02', 250, 0, 1),                 
                            (default, '2023-11-02', 240, 10, 1),
                            (default, '2023-11-03', 220, 0, 1),
                            (default, '2023-11-03', 210, 10, 1),
                            
                            (default, '2023-11-06', 320, 0, 1),
                            (default, '2023-11-06', 330, 10, 1),
                            (default, '2023-11-07', 300, 0, 1),
                            (default, '2023-11-07', 290, 10, 1),
                            (default, '2023-11-08', 300, 0, 1),
                            (default, '2023-11-08', 280, 10, 1),
                            (default, '2023-11-09', 250, 0, 1),
                            (default, '2023-11-09', 240, 10, 1),
                            (default, '2023-11-10', 220, 0, 1),
                            (default, '2023-11-10', 210, 10, 1),

                            (default, '2023-11-13', 320, 0, 1),
                            (default, '2023-11-13', 330, 10, 1),
                            (default, '2023-11-14', 300, 0, 1),
                            (default, '2023-11-14', 290, 10, 1),
                            (default, '2023-11-15', 300, 0, 1),
                            (default, '2023-11-15', 280, 10, 1),
                            (default, '2023-11-16', 250, 0, 1),
                            (default, '2023-11-16', 240, 10, 1),
                            (default, '2023-11-17', 220, 0, 1),
                            (default, '2023-11-17', 210, 10, 1),

                            (default, '2023-11-20', 320, 0, 1),
                            (default, '2023-11-20', 330, 10, 1),
                            (default, '2023-11-21', 300, 0, 1),
                            (default, '2023-11-21', 290, 10, 1),
                            (default, '2023-11-22', 300, 0, 1),
                            (default, '2023-11-22', 280, 10, 1),
                            (default, '2023-11-23', 250, 0, 1),
                            (default, '2023-11-23', 240, 10, 1),
                            (default, '2023-11-24', 220, 0, 1),
                            (default, '2023-11-24', 210, 10, 1),

                            (default, '2023-11-27', 320, 0, 1),
                            (default, '2023-11-27', 330, 10, 1),
                            (default, '2023-11-28', 300, 0, 1),
                            (default, '2023-11-28', 290, 10, 1),
                            (default, '2023-11-29', 300, 0, 1),
                            (default, '2023-11-29', 280, 10, 1),
                            (default, '2023-11-30', 250, 0, 1),
                            (default, '2023-11-30', 240, 10, 1),
                            (default, '2023-12-01', 220, 0, 1),
                            (default, '2023-12-01', 210, 10, 1),

                            (default, '2023-12-04', 320, 0, 1),
                            (default, '2023-12-04', 330, 10, 1),
                            (default, '2023-12-05', 300, 0, 1),
                            (default, '2023-12-05', 290, 10, 1),
                            (default, '2023-12-06', 300, 0, 1),
                            (default, '2023-12-06', 280, 10, 1),
                            (default, '2023-12-07', 250, 0, 1),
                            (default, '2023-12-07', 240, 10, 1),
                            (default, '2023-12-08', 220, 0, 1),
                            (default, '2023-12-08', 210, 10, 1),

                            (default, '2023-12-11', 320, 0, 1),
                            (default, '2023-12-11', 330, 10, 1),
                            (default, '2023-12-12', 300, 0, 1),
                            (default, '2023-12-12', 290, 10, 1),
                            (default, '2023-12-13', 300, 0, 1),
                            (default, '2023-12-13', 280, 10, 1);



INSERT INTO Journee VALUES  (default,'2023-11-01'), 
                            (default,'2023-11-02'), 
                            (default,'2023-11-03'),
                            (default,'2023-11-06'),
                            (default,'2023-11-07'),
                            (default,'2023-11-08'),
                            (default,'2023-11-09'),
                            (default,'2023-11-10'),
                            (default,'2023-11-13'),
                            (default,'2023-11-14'),
                            (default,'2023-11-15'),
                            (default,'2023-11-16'),
                            (default,'2023-11-17'),
                            (default,'2023-11-20'),
                            (default,'2023-11-21'),
                            (default,'2023-11-22'),
                            (default,'2023-11-23'),
                            (default,'2023-11-24'),
                            (default,'2023-11-27'),
                            (default,'2023-11-28'),
                            (default,'2023-11-29'),
                            (default,'2023-11-30'),
                            (default,'2023-12-01'),
                            (default,'2023-12-04'),
                            (default,'2023-12-05'),
                            (default,'2023-12-06'),
                            (default,'2023-12-07'),
                            (default,'2023-12-08'),
                            (default,'2023-12-11'),
                            (default,'2023-12-12'),
                            (default,'2023-12-13');



INSERT INTO DetailsJournee VALUES   (default, '08:00', 8, 1),
                                    (default, '09:00', 7, 1),
                                    (default, '10:00', 9, 1),
                                    (default, '11:00', 9, 1),
                                    (default, '14:00', 8, 1),
                                    (default, '15:00', 7, 1),
                                    (default, '16:00', 6, 1),
                                    (default, '17:00', 4, 1),

                                    (default, '08:00', 8, 2),
                                    (default, '09:00', 7, 2),
                                    (default, '10:00', 9, 2),
                                    (default, '11:00', 9, 2),
                                    (default, '14:00', 8, 2),
                                    (default, '15:00', 7, 2),
                                    (default, '16:00', 6, 2),
                                    (default, '17:00', 4, 2),
                                    
                                    (default, '08:00', 8, 3),
                                    (default, '09:00', 7, 3),
                                    (default, '10:00', 9, 3),
                                    (default, '11:00', 9, 3),
                                    (default, '14:00', 8, 3),
                                    (default, '15:00', 7, 3),
                                    (default, '16:00', 6, 3),
                                    (default, '17:00', 4, 3),

                                    (default, '08:00', 8, 4),
                                    (default, '09:00', 7, 4),
                                    (default, '10:00', 9, 4),
                                    (default, '11:00', 9, 4),
                                    (default, '14:00', 8, 4),
                                    (default, '15:00', 7, 4),
                                    (default, '16:00', 6, 4),
                                    (default, '17:00', 4, 4),

                                    (default, '08:00', 8, 5),
                                    (default, '09:00', 7, 5),
                                    (default, '10:00', 9, 5),
                                    (default, '11:00', 9, 5),
                                    (default, '14:00', 8, 5),
                                    (default, '15:00', 7, 5),
                                    (default, '16:00', 6, 5),
                                    (default, '17:00', 4, 5),

                                    (default, '08:00', 8, 6),
                                    (default, '09:00', 7, 6),
                                    (default, '10:00', 9, 6),
                                    (default, '11:00', 9, 6),
                                    (default, '14:00', 8, 6),
                                    (default, '15:00', 7, 6),
                                    (default, '16:00', 6, 6),
                                    (default, '17:00', 4, 6),

                                    (default, '08:00', 8, 7),
                                    (default, '09:00', 7, 7),
                                    (default, '10:00', 9, 7),
                                    (default, '11:00', 9, 7),
                                    (default, '14:00', 8, 7),
                                    (default, '15:00', 7, 7),
                                    (default, '16:00', 6, 7),
                                    (default, '17:00', 4, 7),

                                    (default, '08:00', 8, 8),
                                    (default, '09:00', 7, 8),
                                    (default, '10:00', 9, 8),
                                    (default, '11:00', 9, 8),
                                    (default, '14:00', 8, 8),
                                    (default, '15:00', 7, 8),
                                    (default, '16:00', 6, 8),
                                    (default, '17:00', 4, 8),

                                    (default, '08:00', 8, 9),
                                    (default, '09:00', 7, 9),
                                    (default, '10:00', 9, 9),
                                    (default, '11:00', 9, 9),
                                    (default, '14:00', 8, 9),
                                    (default, '15:00', 7, 9),
                                    (default, '16:00', 6, 9),
                                    (default, '17:00', 4, 9),

                                    (default, '08:00', 8, 10),
                                    (default, '09:00', 7, 10),
                                    (default, '10:00', 9, 10),
                                    (default, '11:00', 9, 10),
                                    (default, '14:00', 8, 10),
                                    (default, '15:00', 7, 10),
                                    (default, '16:00', 6, 10),
                                    (default, '17:00', 4, 10),

                                    (default, '08:00', 8, 11),
                                    (default, '09:00', 7, 11),
                                    (default, '10:00', 9, 11),
                                    (default, '11:00', 9, 11),
                                    (default, '14:00', 8, 11),
                                    (default, '15:00', 7, 11),
                                    (default, '16:00', 6, 11),
                                    (default, '17:00', 4, 11),

                                    (default, '08:00', 8, 12),
                                    (default, '09:00', 7, 12),
                                    (default, '10:00', 9, 12),
                                    (default, '11:00', 9, 12),
                                    (default, '14:00', 8, 12),
                                    (default, '15:00', 7, 12),
                                    (default, '16:00', 6, 12),
                                    (default, '17:00', 4, 12),

                                    (default, '08:00', 8, 13),
                                    (default, '09:00', 7, 13),
                                    (default, '10:00', 9, 13),
                                    (default, '11:00', 9, 13),
                                    (default, '14:00', 8, 13),
                                    (default, '15:00', 7, 13),
                                    (default, '16:00', 6, 13),
                                    (default, '17:00', 4, 13),

                                    (default, '08:00', 8, 14),
                                    (default, '09:00', 7, 14),
                                    (default, '10:00', 9, 14),
                                    (default, '11:00', 9, 14),
                                    (default, '14:00', 8, 14),
                                    (default, '15:00', 7, 14),
                                    (default, '16:00', 6, 14),
                                    (default, '17:00', 4, 14),

                                    (default, '08:00', 8, 15),
                                    (default, '09:00', 7, 15),
                                    (default, '10:00', 9, 15),
                                    (default, '11:00', 9, 15),
                                    (default, '14:00', 8, 15),
                                    (default, '15:00', 7, 15),
                                    (default, '16:00', 6, 15),
                                    (default, '17:00', 4, 15),

                                    (default, '08:00', 8, 16),
                                    (default, '09:00', 7, 16),
                                    (default, '10:00', 9, 16),
                                    (default, '11:00', 9, 16),
                                    (default, '14:00', 8, 16),
                                    (default, '15:00', 7, 16),
                                    (default, '16:00', 6, 16),
                                    (default, '17:00', 4, 16),

                                    (default, '08:00', 8, 17),
                                    (default, '09:00', 7, 17),
                                    (default, '10:00', 9, 17),
                                    (default, '11:00', 9, 17),
                                    (default, '14:00', 8, 17),
                                    (default, '15:00', 7, 17),
                                    (default, '16:00', 6, 17),
                                    (default, '17:00', 4, 17),

                                    (default, '08:00', 8, 18),
                                    (default, '09:00', 7, 18),
                                    (default, '10:00', 9, 18),
                                    (default, '11:00', 9, 18),
                                    (default, '14:00', 8, 18),
                                    (default, '15:00', 7, 18),
                                    (default, '16:00', 6, 18),
                                    (default, '17:00', 4, 18),

                                    (default, '08:00', 8, 19),
                                    (default, '09:00', 7, 19),
                                    (default, '10:00', 9, 19),
                                    (default, '11:00', 9, 19),
                                    (default, '14:00', 8, 19),
                                    (default, '15:00', 7, 19),
                                    (default, '16:00', 6, 19),
                                    (default, '17:00', 4, 19),

                                    (default, '08:00', 8, 20),
                                    (default, '09:00', 7, 20),
                                    (default, '10:00', 9, 20),
                                    (default, '11:00', 9, 20),
                                    (default, '14:00', 8, 20),
                                    (default, '15:00', 7, 20),
                                    (default, '16:00', 6, 20),
                                    (default, '17:00', 4, 20),

                                    (default, '08:00', 8, 21),
                                    (default, '09:00', 7, 21),
                                    (default, '10:00', 9, 21),
                                    (default, '11:00', 9, 21),
                                    (default, '14:00', 8, 21),
                                    (default, '15:00', 7, 21),
                                    (default, '16:00', 6, 21),
                                    (default, '17:00', 4, 21),

                                    (default, '08:00', 8, 22),
                                    (default, '09:00', 7, 22),
                                    (default, '10:00', 9, 22),
                                    (default, '11:00', 9, 22),
                                    (default, '14:00', 8, 22),
                                    (default, '15:00', 7, 22),
                                    (default, '16:00', 6, 22),
                                    (default, '17:00', 4, 22),

                                    (default, '08:00', 8, 23),
                                    (default, '09:00', 7, 23),
                                    (default, '10:00', 9, 23),
                                    (default, '11:00', 9, 23),
                                    (default, '14:00', 8, 23),
                                    (default, '15:00', 7, 23),
                                    (default, '16:00', 6, 23),
                                    (default, '17:00', 4, 23),

                                    (default, '08:00', 8, 24),
                                    (default, '09:00', 7, 24),
                                    (default, '10:00', 9, 24),
                                    (default, '11:00', 9, 24),
                                    (default, '14:00', 8, 24),
                                    (default, '15:00', 7, 24),
                                    (default, '16:00', 6, 24),
                                    (default, '17:00', 4, 24),

                                    (default, '08:00', 8, 25),
                                    (default, '09:00', 7, 25),
                                    (default, '10:00', 9, 25),
                                    (default, '11:00', 9, 25),
                                    (default, '14:00', 8, 25),
                                    (default, '15:00', 7, 25),
                                    (default, '16:00', 6, 25),
                                    (default, '17:00', 4, 25),

                                    (default, '08:00', 8, 26),
                                    (default, '09:00', 7, 26),
                                    (default, '10:00', 9, 26),
                                    (default, '11:00', 9, 26),
                                    (default, '14:00', 8, 26),
                                    (default, '15:00', 7, 26),
                                    (default, '16:00', 6, 26),
                                    (default, '17:00', 4, 26),

                                    (default, '08:00', 8, 27),
                                    (default, '09:00', 7, 27),
                                    (default, '10:00', 9, 27),
                                    (default, '11:00', 9, 27),
                                    (default, '14:00', 8, 27),
                                    (default, '15:00', 7, 27),
                                    (default, '16:00', 6, 27),
                                    (default, '17:00', 4, 27),

                                    (default, '08:00', 8, 28),
                                    (default, '09:00', 7, 28),
                                    (default, '10:00', 9, 28),
                                    (default, '11:00', 9, 28),
                                    (default, '14:00', 8, 28),
                                    (default, '15:00', 7, 28),
                                    (default, '16:00', 6, 28),
                                    (default, '17:00', 4, 28),

                                    (default, '08:00', 8, 29),
                                    (default, '09:00', 7, 29),
                                    (default, '10:00', 9, 29),
                                    (default, '11:00', 9, 29),
                                    (default, '14:00', 8, 29),
                                    (default, '15:00', 7, 29),
                                    (default, '16:00', 6, 29),
                                    (default, '17:00', 4, 29),

                                    (default, '08:00', 8, 30),
                                    (default, '09:00', 7, 30),
                                    (default, '10:00', 9, 30),
                                    (default, '11:00', 9, 30),
                                    (default, '14:00', 8, 30),
                                    (default, '15:00', 7, 30),
                                    (default, '16:00', 6, 30),
                                    (default, '17:00', 4, 30),

                                    (default, '08:00', 8, 31),
                                    (default, '09:00', 7, 31),
                                    (default, '10:00', 9, 31),
                                    (default, '11:00', 9, 31),
                                    (default, '14:00', 8, 31),
                                    (default, '15:00', 7, 31),
                                    (default, '16:00', 6, 31),
                                    (default, '17:00', 4, 31);




INSERT INTO Coupure VALUES  (default, 1, '2023-11-01 15:45'), 
                            (default, 1, '2023-11-02 16:30'), 
                            (default, 1, '2023-11-03 17:00'),
                            (default, 1, '2023-11-06 15:00'),
                            (default, 1, '2023-11-07 15:40'),
                            (default, 1, '2023-11-08 15:45'),
                            (default, 1, '2023-11-09 16:29'),
                            (default, 1, '2023-11-10 17:01'),
                            (default, 1, '2023-11-13 15:02'),
                            (default, 1, '2023-11-14 15:42'),
                            (default, 1, '2023-11-15 15:43'),
                            (default, 1, '2023-11-16 16:32'),
                            (default, 1, '2023-11-17 17:03'),
                            (default, 1, '2023-11-20 14:55'),
                            (default, 1, '2023-11-21 15:35'),
                            (default, 1, '2023-11-22 15:40'),
                            (default, 1, '2023-11-23 16:24'),
                            (default, 1, '2023-11-24 16:55'),
                            (default, 1, '2023-11-27 15:04'),
                            (default, 1, '2023-11-28 15:44'),
                            (default, 1, '2023-11-29 15:49'),
                            (default, 1, '2023-11-30 16:33'),
                            (default, 1, '2023-12-01 17:06'),
                            (default, 1, '2023-12-04 14:59'),
                            (default, 1, '2023-12-05 15:39'),
                            (default, 1, '2023-12-06 15:44'),
                            (default, 1, '2023-12-07 16:28'),
                            (default, 1, '2023-12-08 17:00'),
                            (default, 1, '2023-12-11 15:46'),
                            (default, 1, '2023-12-12 16:32'),
                            (default, 1, '2023-12-13 17:01');



-- insert into Journee values(default, '2023-12-25');

-- insert into DetailsJournee values (default, '08:00', 8, 32),
--                                 (default, '09:00', 7, 32),
--                                 (default, '10:00', 9, 32),
--                                 (default, '11:00', 9, 32),
--                                 (default, '14:00', 8, 32),
--                                 (default, '15:00', 7, 32),
--                                 (default, '16:00', 6, 32),
--                                 (default, '17:00', 4, 32);

-- insert into pointage values (default, '2023-12-25', 320, 0, 1),
--                             (default, '2023-12-25', 330, 10, 1);



insert into Journee values(default, '2024-01-03');

insert into DetailsJournee values (default, '08:00', 9, 32),
                                (default, '09:00', 9, 32),
                                (default, '10:00', 9, 32),
                                (default, '11:00', 9, 32),
                                (default, '14:00', 8, 32),
                                (default, '15:00', 8, 32),
                                (default, '16:00', 8, 32),
                                (default, '17:00', 9, 32);