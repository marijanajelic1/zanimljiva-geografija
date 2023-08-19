CREATE TABLE IF NOT EXISTS tipkorisnika(
    id INT UNSIGNED AUTO_INCREMENT,
    tip VARCHAR(50) NOT NULL,
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

CREATE TABLE IF NOT EXISTS odgovori(
    id INT UNSIGNED AUTO_INCREMENT,
    igrac_id INT UNSIGNED NOT NULL,
    brojtacnih INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY(igrac_id) REFERENCES korisnik(id)
)ENGINE=InnoDB;

INSERT INTO `tipkorisnika`(`tip`) VALUES('igrac');
INSERT INTO `tipkorisnika`(`tip`) VALUES('administrator');

INSERT INTO `korisnik`(`username`,`password`,`tip_id`) VALUES ('marija', 'jovic',1);
INSERT INTO `korisnik`(`username`,`password`,`tip_id`) VALUES ('administrator', 'administrator',2);
INSERT INTO `profil`(`ime`, `prezime`, `email`, `telefon`, `korisnik_id`) VALUES ('Marija','Jovic','email1','123456', 1);
INSERT INTO `profil`(`ime`, `prezime`, `email`, `telefon`, `korisnik_id`) VALUES ('Marijana','Jelic','email2','123457', 2);

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
INSERT INTO `slovo`(`naziv`) VALUES ('F');
INSERT INTO `slovo`(`naziv`) VALUES ('G');
INSERT INTO `slovo`(`naziv`) VALUES ('H');
INSERT INTO `slovo`(`naziv`) VALUES ('I');
INSERT INTO `slovo`(`naziv`) VALUES ('J');
INSERT INTO `slovo`(`naziv`) VALUES ('K');
INSERT INTO `slovo`(`naziv`) VALUES ('L');
INSERT INTO `slovo`(`naziv`) VALUES ('M');
INSERT INTO `slovo`(`naziv`) VALUES ('N');

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Koja država je najveće ostrvo i najmanji kontinent na svetu?','Australija',1,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Prestonica Grčke je?','Atina',2,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Koja reka nema nijedan most?','Amazon',3,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Jedna od najvećih zmija na svetu.','Anakonda',4,1);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Za internacionalni simbol dobrodošlice smatra se?','Ananas',5,1);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Koja država ima najviše vrsta piva na svetu i najviše pivara po glavi stanovnika?','Belgija',1,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad Srbije.','Beograd',2,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Reka čiji naziv je srpsko žensko ime, a nalazi se na granici Crne Gore i Albanije je?','Bojana',3,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Drugi naziv za pavijana.','Babun',4,2);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Postoje četiri vrste ove biljke. Koristi se kao začin, ali i kao lek.','Biber',5,2);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova država se graniči sa Srbijom i leži na istočnoj obali Jadranskog mora.','Crna Gora',1,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najveći grad Švajcarske.','Cirih',2,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Kako se zove reka koja protiče kroz Hrvatsku, a njen najveći vodopad je Velika Gubavica?','Cetina',3,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Krilati insekt koji uz pomoć aparata ispušta cvrkut koji možemo čuti je?','Cvrcak',4,3);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova biljka je 95% vode, dobar je izvor vitamina K i sadrži androsteron, hormon za koji se smatra da privlaci žene','Celer',5,3);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Država u kojoj svaki drugi dan pada kiša ili sneg i koja je 2009. godine imala 184 dana padavina.','Danska',1,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad američke savezne države Kolorado je?','Denver',2,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova reka prolazi kroz Beograd.','Dunav',3,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Vodeni sisar koji je poznat po svom prijateljskom odnosu prema ljudima.','Delfin',4,4);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Listovi ove biljke se koriste za pušenje.','Duvan',5,4);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Država u kojoj se nalazi Sfinga i Velike piramide.','Egipat',1,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad Škotske.','Edinburg',2,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Reka koje protiče kroz Mesopotaniju i njen naziv potiče iz persijskog jezika, a u prevodu znaci "jednostavna za prelaz" je? ','Eufrat',3,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Druga po veličini savremena ptica koja naseljava Australiju.','Emu',4,5);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Biljka koja sadrži eukaliptol koji se koristi u mnogim lekovima protiv kašlja i prehlade.','Eukaliptus',5,5);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Građani ove države u proseku popiju 85 litara piva godišnje.','Finska',1,6);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Naziv grada u kome se nalazi Fontana del Porcellino.','Firenca',2,6);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najduža reka u nemačkoj državi Hesen duga 220,7 km. ','Fulda',3,6);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova životinja čini jednu od četiri grupe sisara koje su nekada živele na kopnu.','Foka',4,6);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Popularna sobna drvenasta biljka, laka za održavanje.','Fikus',5,6);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova država proizvodi vino već 8.000 godina i smatra se rodnim mestom vinarstva.','Gruzija',1,7);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad Čečenske Republike je?','Grozni',2,7);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Reka u centralnoj Srbiji. ','Gruza',3,7);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ugrožena vrsta iz porodice mačaka i najbrža kopnena životinja je?','Gepard',4,7);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Smatra se za jednu od najlekovitijih biljaka na svetu, posebno delotvornom za srce.','Glog',5,7);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Država na Karibima čije ime potiče od reči ajiti, što znači zemlja visokih planina.','Haiti',1,8);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Drugi po veličini grad u Nemačkoj.','Hamburg',2,8);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova reka protiče kroz Njujork.','Hadson',3,8);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Popularan kućni ljubimac, omiljen među decom.','Hrcak',4,8);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Nacionalno drvo SAD-a, Engleske i Nemačke je?.','Hrast',5,8);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Država sa tri aktivna vulkana: Vezuv, Etnu i Stromboli je?','Italija',1,9);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad Pakistana.','Islamabad',2,9);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Brza planinska reka koja izvire na severnoj strani planine Hajla.','Ibar',3,9);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('U Finskoj ova životinja tradicionalno vuče sanke.','Irvas',4,9);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Lekovita biljka koja takođe može biti i parazit koji napada drveće.','Imela',5,9);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('U ovoj državi je pismenost gotovo 100%.','Japan',1,10);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najsvetiji grad Judaizma i duhovni centar Jevrejskog naroda.','Jerusalim',2,10);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Reka u opštini Loznica u zapadnoj Srbiji.','Jadar',3,10);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Može biti i kućni ljubimac, telo mu prekrivaju bodlje.','Jez',4,10);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('List ove biljke je simbol Kanade i nalazi se na njenoj zastavi.','Javor',5,10);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Domaćin Svetskog prvenstva u fudbalu 2022. godine.','Katar',1,11);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najveći i glavni grad Egipta.','Kairo',2,11);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Reka koja nastaje od Obnice i Jablanice u Valjevu duga 123 km je?','Kolubara',3,11);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najmanje ptice selice na svetu i jedine koje mogu da lete unazad.','Kolibri',4,11);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Plod ove biljke je proglašen za nacionalno voće u Kini.','Kivi',5,11);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Država na zapadu Evrope sa istoimenim glavnim gradom.','Luksemburg',1,12);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najpoznatiji i najveći sat na svetu Big Ben se nalazi u ovom gradu.','London',2,12);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Na ovoj reci su podignute dve hidroelektrane Potpeć i Bistrica.','Lim',3,12);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Jedan horoskopski znak nosi naziv ove životinje..','Lav',4,12);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Popularno letnje povrće, spolja zelene, a unutra crvene boje.','Lubenica',5,12);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Zastava ove države je crvene boje sa zelenim pentagramom u sredini.','Maroko',1,13);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad Mozambika.','Maputo',2,13);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najduža reka Severne Amerike, a sa Misurijem je četvrta po dužini u svetu.','Misisipi',3,13);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Naziv hibrida nastalog ukrštanjem magarice sa pastuvom?','Mazga',4,13);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Voće od koga se pravi ulje, a može biti zelene, crne, ljubičaste, tamno braon i roze boje.','Maslina',5,13);

INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Glavni grad ove Evropske države je Berlin.','Nemacka',1,14);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Treći grad po veličini u Srbiji.','Nis',2,14);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Najhladnija reka na svetu.','Neretva',3,14);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Ova zivotinja je dobila ime po rogu na svojoj njušci.','Nosorog',4,14);
INSERT INTO `pitanje`(`tekst`,`odgovor`,`oblast_id`,`slovo_id`) VALUES ('Biljka nastala ukrštanjem pomela i mandarine.','Narandza',5,14);








