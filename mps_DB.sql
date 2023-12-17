-- create leaderboard
CREATE DATABASE leaderboard;
USE leaderboard;
-- create tables
-- DROP TABLE gamer;
CREATE TABLE gamer (
    gamer_id      int NOT NULL IDENTITY(1,1),
    gamer_name    varchar(50) NOT NULL,
    password      varchar(255),
    CONSTRAINT gamer_pk PRIMARY KEY (gamer_id),
    CONSTRAINT gamer_nk UNIQUE (gamer_name)
);

CREATE TABLE score (
    score_id  int NOT NULL IDENTITY(1,1),
    gamer_id  int NOT NULL,
    date_time  datetime NOT NULL,
    score     int NOT NULL,
    CONSTRAINT score_pk PRIMARY KEY (score_id),
    CONSTRAINT score_fk FOREIGN KEY (gamer_id)
    REFERENCES gamer(gamer_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);