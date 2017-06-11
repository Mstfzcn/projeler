# Host: 185.87.123.67  (Version 5.6.26)
# Date: 2017-05-26 11:42:37
# Generator: MySQL-Front 6.0  (Build 1.48)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "serabilgi"
#

DROP TABLE IF EXISTS `serabilgi`;
CREATE TABLE `serabilgi` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `seraAd` varchar(255) NOT NULL DEFAULT '',
  `seraSicaklik` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "serabilgi"
#

INSERT INTO `serabilgi` VALUES (1,'AnaSera','20');
