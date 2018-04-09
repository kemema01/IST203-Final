-- MySQL dump 10.13  Distrib 5.7.21, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: decider
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `attendance_line_t`
--

DROP TABLE IF EXISTS `attendance_line_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance_line_t` (
  `PerID` int(11) NOT NULL,
  `EntryID` int(11) NOT NULL,
  PRIMARY KEY (`PerID`,`EntryID`),
  KEY `EntryID` (`EntryID`),
  CONSTRAINT `attendance_line_t_ibfk_1` FOREIGN KEY (`PerID`) REFERENCES `person_t` (`PerID`),
  CONSTRAINT `attendance_line_t_ibfk_2` FOREIGN KEY (`EntryID`) REFERENCES `history_entry_t` (`EntryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_line_t`
--

LOCK TABLES `attendance_line_t` WRITE;
/*!40000 ALTER TABLE `attendance_line_t` DISABLE KEYS */;
/*!40000 ALTER TABLE `attendance_line_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dislike_line_t`
--

DROP TABLE IF EXISTS `dislike_line_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dislike_line_t` (
  `PerID` int(11) NOT NULL,
  `TagID` int(11) NOT NULL,
  PRIMARY KEY (`PerID`,`TagID`),
  KEY `TagID` (`TagID`),
  CONSTRAINT `dislike_line_t_ibfk_1` FOREIGN KEY (`PerID`) REFERENCES `person_t` (`PerID`),
  CONSTRAINT `dislike_line_t_ibfk_2` FOREIGN KEY (`TagID`) REFERENCES `tags_t` (`TagID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dislike_line_t`
--

LOCK TABLES `dislike_line_t` WRITE;
/*!40000 ALTER TABLE `dislike_line_t` DISABLE KEYS */;
/*!40000 ALTER TABLE `dislike_line_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history_entry_t`
--

DROP TABLE IF EXISTS `history_entry_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `history_entry_t` (
  `EntryID` int(11) NOT NULL AUTO_INCREMENT,
  `EntryDate` datetime NOT NULL,
  `RestID` int(11) NOT NULL,
  PRIMARY KEY (`EntryID`),
  KEY `RestID` (`RestID`),
  CONSTRAINT `history_entry_t_ibfk_1` FOREIGN KEY (`RestID`) REFERENCES `restaurant_t` (`RestID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history_entry_t`
--

LOCK TABLES `history_entry_t` WRITE;
/*!40000 ALTER TABLE `history_entry_t` DISABLE KEYS */;
/*!40000 ALTER TABLE `history_entry_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `like_line_t`
--

DROP TABLE IF EXISTS `like_line_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `like_line_t` (
  `PerID` int(11) NOT NULL,
  `TagID` int(11) NOT NULL,
  PRIMARY KEY (`PerID`,`TagID`),
  KEY `TagID` (`TagID`),
  CONSTRAINT `like_line_t_ibfk_1` FOREIGN KEY (`PerID`) REFERENCES `person_t` (`PerID`),
  CONSTRAINT `like_line_t_ibfk_2` FOREIGN KEY (`TagID`) REFERENCES `tags_t` (`TagID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `like_line_t`
--

LOCK TABLES `like_line_t` WRITE;
/*!40000 ALTER TABLE `like_line_t` DISABLE KEYS */;
/*!40000 ALTER TABLE `like_line_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person_t`
--

DROP TABLE IF EXISTS `person_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `person_t` (
  `PerID` int(11) NOT NULL AUTO_INCREMENT,
  `PerName` varchar(25) NOT NULL,
  PRIMARY KEY (`PerID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person_t`
--

LOCK TABLES `person_t` WRITE;
/*!40000 ALTER TABLE `person_t` DISABLE KEYS */;
INSERT INTO `person_t` VALUES (1,'Trey'),(2,'Sara'),(3,'Lysa'),(4,'Greg'),(5,'Jamie'),(6,'Jason'),(7,'Matt');
/*!40000 ALTER TABLE `person_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `restaurant_t`
--

DROP TABLE IF EXISTS `restaurant_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `restaurant_t` (
  `RestID` int(11) NOT NULL AUTO_INCREMENT,
  `RestName` varchar(25) NOT NULL,
  `RestPrice` int(11) NOT NULL,
  PRIMARY KEY (`RestID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `restaurant_t`
--

LOCK TABLES `restaurant_t` WRITE;
/*!40000 ALTER TABLE `restaurant_t` DISABLE KEYS */;
/*!40000 ALTER TABLE `restaurant_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tag_line_t`
--

DROP TABLE IF EXISTS `tag_line_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tag_line_t` (
  `RestID` int(11) NOT NULL,
  `TagID` int(11) NOT NULL,
  PRIMARY KEY (`RestID`,`TagID`),
  KEY `TagID` (`TagID`),
  CONSTRAINT `tag_line_t_ibfk_1` FOREIGN KEY (`RestID`) REFERENCES `restaurant_t` (`RestID`),
  CONSTRAINT `tag_line_t_ibfk_2` FOREIGN KEY (`TagID`) REFERENCES `tags_t` (`TagID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tag_line_t`
--

LOCK TABLES `tag_line_t` WRITE;
/*!40000 ALTER TABLE `tag_line_t` DISABLE KEYS */;
/*!40000 ALTER TABLE `tag_line_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tags_t`
--

DROP TABLE IF EXISTS `tags_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tags_t` (
  `TagID` int(11) NOT NULL AUTO_INCREMENT,
  `TagValue` varchar(15) NOT NULL,
  PRIMARY KEY (`TagID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tags_t`
--

LOCK TABLES `tags_t` WRITE;
/*!40000 ALTER TABLE `tags_t` DISABLE KEYS */;
INSERT INTO `tags_t` VALUES (1,'Burger'),(2,'BBQ'),(3,'Chicken'),(4,'Asian'),(5,'TexMex'),(6,'Pizza'),(7,'Italian'),(8,'Sandwich'),(9,'Diner'),(10,'Breakfast'),(11,'Seafood'),(12,'Great Sides'),(13,'Dessert'),(14,'Ice Cream'),(15,'Hot Dog'),(16,'Bar Food'),(17,'Healthy'),(18,'Veg Option'),(19,'Salad'),(20,'Mediterranean'),(21,'Steakhouse'),(22,'Sushi');
/*!40000 ALTER TABLE `tags_t` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-08 23:01:56
