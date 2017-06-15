# Host: 185.87.123.67  (Version 5.6.26)
# Date: 2017-05-26 11:40:42
# Generator: MySQL-Front 6.0  (Build 1.48)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "personel"
#

DROP TABLE IF EXISTS `personel`;
CREATE TABLE `personel` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `kAdi` varchar(255) DEFAULT NULL,
  `sifre` varchar(255) DEFAULT NULL,
  `soyad` varchar(255) DEFAULT NULL,
  `unvan` varchar(255) DEFAULT NULL,
  `gorev` varchar(255) DEFAULT NULL,
  `sonTarih` date DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "personel"
#

INSERT INTO `personel` VALUES (1,'mustafa','123','özcan','CEO','Proje Planlama','2017-03-30');
