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
-- Table structure for table `rooms_by_users`
--

DROP TABLE IF EXISTS `rooms_by_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `rooms_by_users` (
  `idrooms_by_users` int(11) NOT NULL AUTO_INCREMENT,
  `start_date` datetime DEFAULT NULL,
  `end_date` datetime DEFAULT NULL,
  `id_user_resposible` int(11) DEFAULT NULL,
  `id_user_owner` int(11) DEFAULT NULL,
  `id_room` int(11) DEFAULT NULL,
  `rooms_by_userscol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idrooms_by_users`),
  KEY `id_user_resposible_idx` (`id_user_resposible`),
  KEY `id_user_owner_idx` (`id_user_owner`),
  KEY `id_room_idx` (`id_room`),
  CONSTRAINT `id_room` FOREIGN KEY (`id_room`) REFERENCES `rooms` (`idRooms`),
  CONSTRAINT `id_user_owner` FOREIGN KEY (`id_user_owner`) REFERENCES `users` (`idUsers`),
  CONSTRAINT `id_user_resposible` FOREIGN KEY (`id_user_resposible`) REFERENCES `users` (`idUsers`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms_by_users`
--

LOCK TABLES `rooms_by_users` WRITE;
/*!40000 ALTER TABLE `rooms_by_users` DISABLE KEYS */;
INSERT INTO `rooms_by_users` VALUES (1,'2019-07-01 00:00:00','2020-06-30 00:00:00',2,1,1,NULL),(2,'2019-01-01 00:00:00','2021-10-31 00:00:00',2,3,3,NULL),(3,'2019-05-01 00:00:00','2021-04-30 00:00:00',4,1,4,NULL);
/*!40000 ALTER TABLE `rooms_by_users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-07-29 19:17:57
