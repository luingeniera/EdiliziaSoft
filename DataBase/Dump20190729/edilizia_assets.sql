CREATE DATABASE  IF NOT EXISTS `edilizia` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `edilizia`;
-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: edilizia
-- ------------------------------------------------------
-- Server version	8.0.16

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
-- Table structure for table `assets`
--

DROP TABLE IF EXISTS `assets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `assets` (
  `idassets` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(6) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `category` varchar(45) DEFAULT NULL,
  `delivery_status` varchar(45) DEFAULT NULL,
  `delivery_date` datetime DEFAULT NULL,
  `return_status` varchar(45) DEFAULT NULL,
  `retrun_date` datetime DEFAULT NULL,
  `assetscol` varchar(45) DEFAULT NULL,
  `detour_reason` varchar(45) DEFAULT NULL,
  `observation` varchar(250) DEFAULT NULL,
  `asset_type` varchar(45) DEFAULT NULL,
  `id_room_by_user` int(11) DEFAULT NULL,
  `assetscol1` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idassets`),
  KEY `id_room_by_user_idx` (`id_room_by_user`),
  CONSTRAINT `id_room_by_user` FOREIGN KEY (`id_room_by_user`) REFERENCES `rooms_by_users` (`idrooms_by_users`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assets`
--

LOCK TABLES `assets` WRITE;
/*!40000 ALTER TABLE `assets` DISABLE KEYS */;
INSERT INTO `assets` VALUES (1,'ME001','Mesa ratona','Mesas','optima','2019-07-01 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL),(2,'ME002','Escritorio','Mesas','optima','2019-07-01 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL),(3,'PE001','Perchero','Perchero','medio','2019-07-10 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL),(4,'ME003','Mesa francesa','Mesas','medio','2019-01-15 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,2,NULL),(5,'MU001','Mueble 120 x 60 x 180','Muebles','optimo','2019-03-10 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,2,NULL);
/*!40000 ALTER TABLE `assets` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-07-29 19:17:55
