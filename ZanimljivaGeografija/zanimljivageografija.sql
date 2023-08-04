CREATE TABLE IF NOT EXISTS tipkorisnika(
    id INT UNSIGNED AUTO_INCREMENT,
    naziv VARCHAR(50) NOT NULL,
    PRIMARY KEY(id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS korisnik(
    id INT UNSIGNED AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(250) NOT NULL,
    tip_id  INT UNSIGNED NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(tip_id) REFERENCES tipkorisnika(id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS profil(
    id INT UNSIGNED AUTO_INCREMENT,
    ime VARCHAR(50) NOT NULL,
    prezime VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    telefon INT(13) NOT NULL,
    korisnik_id INT UNSIGNED NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(korisnik_id) REFERENCES korisnik(id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS oblast(
    id INT UNSIGNED AUTO_INCREMENT,
    naziv VARCHAR(30) NOT NULL,
    PRIMARY KEY(id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS slovo(
    id INT UNSIGNED AUTO_INCREMENT,
    naziv VARCHAR(1) NOT NULL,
    PRIMARY KEY(id)
)ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS pitanje(
    id INT UNSIGNED AUTO_INCREMENT,
    tekst VARCHAR(500) NOT NULL,
    odgovor VARCHAR(255) NOT NULL,
    oblast_id INT UNSIGNED NOT NULL,
    slovo_id INT UNSIGNED NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(oblast_id) REFERENCES oblast(id),
    FOREIGN KEY(slovo_id) REFERENCES slovo(id)
) ENGINE=InnoDB;

INSERT INTO `tipkorisnika`(`naziv`) VALUES('igrac');

INSERT INTO `korisnik`(`username`,`password`,`tip_id`) VALUES ('marija', 'jovic',1);
INSERT INTO `profil`(`ime`, `prezime`, `email`, `telefon`, `korisnik_id`) VALUES ('Marija','Jovic','email1','123456', 1);

INSERT INTO `oblast`(`naziv`) VALUES ('drzava');
INSERT INTO `oblast`(`naziv`) VALUES ('grad');
INSERT INTO `oblast`(`naziv`) VALUES ('reka');
INSERT INTO `oblast`(`naziv`) VALUES ('zivotinja');
INSERT INTO `oblast`(`naziv`) VALUES ('biljka');

INSERT INTO `slovo`(`naziv`) VALUES ('A');
INSERT INTO `slovo`(`naziv`) VALUES ('B');
INSERT INTO `slovo`(`naziv`) VALUES ('C');
INSERT INTO `slovo`(`naziv`) VALUES ('D');
INSERT INTO `slovo`(`naziv`) VALUES ('E');

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Koja drzava je najvece ostrvo i najmanji kontinent na svetu?','Australija',1,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Grad koji je prestonica Grcke je?','Atina',2,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Koja reka nema nijedan most?','Amazon',3,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Jedna od najvecih zmija na svetu je?','Anakonda',4,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Za internacionalni simbor dobrodoslice smatra se?','Ananas',5,1);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Drzava koja ima najvise vrsta piva na svetu i najvise pivara po glavi stanovnika je?','Belgija',1,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad Srbije je?','Beograd',2,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Reka ciji naziv je srpsko zensko ime, a nalazi se na granici Crne Gore i Albanije je?','Bojana',3,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Drugi naziv za pavijana je?','Babun',4,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Postoje cetiri vrste ove biljke. Koristi se kao zacin, ali i kao lek.','Biber',5,2);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova drzava se granici sa Srbijom i lezi na istocnoj obali Jadranskog mora.','Crna Gora',1,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najveci grad Svajcarske je?','Cirih',2,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Kako se zove reka koja protice kroz Hrvatsku, a njen najveci vodopad je Velika Gubavica?','Cetina',3,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Krilati insekt koji uz pomoc aparata ispusta cvrkut koji mozemo cuti je?','Cvrcak',4,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova biljka je 95% vode, dobar je izvor vitamina K i sadrzi androsteron, hormon za koji se smatra da privlaci zene','Celer',5,3);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Drzava u kojoj svaki drugi dan pada kisa ili sneg i koja je 2009. godine imala 184 dana padavina je?','Danska',1,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad americke savezne drzave Kolorado je?','Denver',2,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova reka prolazi kroz Beograd.','Dunav',3,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Vodeni sisar koji je poznat po svom prijateljskom odnosu prema ljudima je?','Delfin',4,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Listovi ove biljke se koriste za pusenje.','Duvan',5,4);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Drzava u kojoj se nalazi Sfinga i Velike piramide je?','Egipat',1,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad Skotske je?','Edinburg',2,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Reka koje protice kroz Mesopotaniju i njen naziv potice iz persijskog jezika, a u prevodu znaci "jednostavna za prelaz" je? ','Eufrat',3,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Druga po velicini savremena ptica koja naseljava Australiju je?','Emu',4,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Biljka koja sadrži eukaliptol koji se koristi u mnogim lekovima protiv kašlja i prehlade je?','Eukaliptus',5,5);









