-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: productsdb
-- ------------------------------------------------------
-- Server version	5.7.44

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
-- Table structure for table `basketproductcards`
--

DROP TABLE IF EXISTS `basketproductcards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `basketproductcards` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Price` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `HistoryId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basketproductcards`
--

LOCK TABLES `basketproductcards` WRITE;
/*!40000 ALTER TABLE `basketproductcards` DISABLE KEYS */;
INSERT INTO `basketproductcards` VALUES (1,10,1,2,0),(2,0,1,3,1),(3,0,1,1,3),(4,10,1,1,4),(5,10,1,1,5),(6,40,1,4,5),(7,0,1,3,6),(8,10,1,4,10),(9,30,1,10,10),(10,10,31,12,10),(11,85,1,9,11);
/*!40000 ALTER TABLE `basketproductcards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `histories`
--

DROP TABLE IF EXISTS `histories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `histories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime(6) NOT NULL,
  `TotalAmount` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `histories`
--

LOCK TABLES `histories` WRITE;
/*!40000 ALTER TABLE `histories` DISABLE KEYS */;
INSERT INTO `histories` VALUES (1,'2024-07-03 16:25:59.515849',10),(2,'2024-07-03 16:26:45.017523',10),(3,'2024-07-03 16:27:43.520162',0),(4,'2024-07-03 16:35:24.936827',10),(5,'2024-07-03 16:43:12.130450',10),(6,'2024-07-03 16:45:30.997493',0),(7,'2024-07-04 00:00:00.000000',0),(8,'2024-07-04 00:00:00.000000',0),(9,'2024-07-04 00:00:00.000000',0),(10,'2024-07-04 00:00:00.000000',350),(11,'2024-07-04 00:00:00.000000',85);
/*!40000 ALTER TABLE `histories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Price` int(11) NOT NULL,
  `InStock` tinyint(1) NOT NULL,
  `Name` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,0,1,'Молоко'),(2,0,1,'Хлеб'),(3,0,1,'Сахар'),(4,0,1,'Мясо'),(5,0,1,'Соль'),(6,0,1,'Вода'),(7,0,1,'Курица'),(8,0,1,'Печенье'),(9,0,1,'Вода'),(10,0,1,'Вода'),(11,0,1,'Арбуз'),(12,0,1,'Нектарин'),(13,0,1,'Дыня');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-07-04  2:19:06
