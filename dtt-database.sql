-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: dtt
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20200630173408_ArticleAndUserModel','3.1.5'),('20200705190013_StringLength','3.1.5'),('20200705190249_RemovedStringLength','3.1.5');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `article`
--

DROP TABLE IF EXISTS `article`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `article` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Summary` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PublishDate` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `article`
--

LOCK TABLES `article` WRITE;
/*!40000 ALTER TABLE `article` DISABLE KEYS */;
INSERT INTO `article` VALUES (2,'DTT Test','Test user authentication','fg','2020-06-19 00:00:00.000000'),(3,'Test CMSuser change','Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis vitae augue id erat euismod pulvinar sed ac lectus. Mauris egestas quam sed diam fermentum condimentum.','Testen voor DTT','2020-06-19 00:00:00.000000'),(4,'Stage ASP.NET Core DTT','Stage vacaturen ASP.NET Core developer DTT','Belangrijke eigenschappen','2020-06-24 00:00:00.000000'),(5,'Meerdere testen','Meerdere teste om te checken of alles nog werkt','Test voor werking','2020-06-28 00:00:00.000000'),(6,'Hallo regex yuri Test 4','Test Test\nTest\n3 Test','Hallo ik ben Yuri Lamijo en ben 21 jaar','2020-06-18 00:00:00.000000'),(8,'Laatste Test','Laatste Test Yuri','Laatste Test DTT','2020-06-23 00:00:00.000000'),(9,'Yuri DTT Test validation','Yuri Lamijo Regex testen\nVia regex website','Hallo ik ben Yuri 21 jaar','2020-07-01 00:00:00.000000'),(12,'Lorem ipsum dolor sit amet, consectetur adipiscing elit.','Lorem ipsum dolor sit amet, consectetur adipiscing elit.','Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis vitae augue id erat euismod pulvinar sed ac lectus. Mauris egestas quam sed diam fermentum condimentum. Nullam vehicula odio eros, eu malesuada erat interdum ac. Donec sed ipsum eget ex mattis sollicitudin. Nulla sodales libero porta fringilla auctor. Nam sed libero eu ante vestibulum dignissim. Vivamus eu diam ultrices, feugiat libero et, consequat mauris. Maecenas in leo ut nulla tempus efficitur. Aliquam vestibulum augue condimentum lectus vestibulum, non congue ex malesuada. Vivamus et neque enim. Donec a libero erat. Nulla congue in erat vel elementum. Nullam vitae turpis ut neque tempus placerat in sit amet massa. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vel erat luctus, semper est sed, facilisis quam. Sed hendrerit sit amet tellus non lobortis. ','2020-07-03 00:00:00.000000');
/*!40000 ALTER TABLE `article` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Username` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Role` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PasswordHash` longblob NOT NULL,
  `PasswordSalt` longblob NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Yuri','YuriLamijo','Admin',_binary '¢:}mE\ß\âÖ§}\ßXt\Ím½R=­£\Ûs².‰†	d\ØW\ã„\Ñ\ê\ÓFùzf‡5W\ÎÛœ‚³ğ|\Óiû\âuû',_binary '‡XX\"r\\0k\Ö\r\åi\Û.\ãZMû‡\0\à!\Ğ\\dl\É6¶»\ÄZpƒŒ#õ…—»İ«à¥œ+/Cr\\\"Ï”y^fš\É£Yu;\\M²K)¼¿\İşV­ \Z…ògN\ÇMü2,\ÕO o\Ü_Gõ{4\îd\\Ÿ¦\Ü#\ì\è\Ö\áK¿H±X;'),(2,'CMSuser','CMSuser','User',_binary 'd+L‘]\ß\Ñ8\Îxiö7£L¡#\ê\ê}¥˜\Û&W¥c¯õOAÍ³ı„\äH$(9´hu\'şböU\"ù\Â\Å6±:',_binary '\Ä\è‹A„\îÁ )gL5@vùq91¯n÷\ëE¯\îÊ–`/\n\ß\íö»®’q	¤ n¿‘3s7å¯ŠUÍ©\Ş;·Ù8zl.\í:–6ö\İ~m\Ñ*\ïUª8\Ë\Ón9÷h\É=¢»>±½\ÑÙß\Ûc\æ2i\çPFó\ÕGo\Ì1‘z'),(3,'Tester','TestUser','User',_binary '\0\æ9LMd)<G>²Œ¥g€\ï6 B\\\Z_øô¥”U££C®†Â—²÷¥\ÕĞ˜gĞ®·hSZR	Ë¾`Y\ÉU',_binary '¾…Š—ò\Ù\ì@†:ºd\Öø®ƒ>%\å5\Öö?©\Ëp§¹¬\ÚYN„\Ô\n:]\ßNÖ¹ÀwĞ©9‘]†x|ºaº\Øü\ËÆ™\Ã\è\Â\İC\\ªš®M­GN‚\ÕKs¶Û®WF\ÏB‹}¸ß«6ø{\ÍZÖ¡Ô©\ÄDy3\ä†\rúu<	ğï§—\Ó;\Ò');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-07-05 21:30:34
