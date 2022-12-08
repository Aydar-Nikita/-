-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: real_estate_agency
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `real_estate`
--

DROP TABLE IF EXISTS `real_estate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `real_estate` (
  `real_estate_id` int NOT NULL AUTO_INCREMENT,
  `address` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `cost` int NOT NULL,
  `floor` int NOT NULL,
  `number_of_rooms` int NOT NULL,
  `status_id` int NOT NULL,
  `comment` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `seller_id` int NOT NULL,
  PRIMARY KEY (`real_estate_id`),
  KEY `estate_status_idx` (`status_id`),
  KEY `estate_seller_idx` (`seller_id`),
  CONSTRAINT `estate_seller` FOREIGN KEY (`seller_id`) REFERENCES `seller` (`seler_id`),
  CONSTRAINT `estate_status` FOREIGN KEY (`status_id`) REFERENCES `real_estate_status` (`status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `real_estate`
--

LOCK TABLES `real_estate` WRITE;
/*!40000 ALTER TABLE `real_estate` DISABLE KEYS */;
INSERT INTO `real_estate` VALUES (1,' г. Уфа ул. Бульвар Славы, 12, Подъезд №1, кв.10',2000000,4,3,1,'ааа',1),(2,' г. Уфа ул. 50 лет СССР, 45, Подъезд №3, кв.101',2500000,3,3,1,'ббб',1),(3,' г. Уфа ул.Проспект Октября, 46, Подъезд №4, кв.54',1800000,5,3,1,'ггг',2),(4,' г. Уфа ул. Первомайская, 16, Подъезд №2, кв.33',22000,5,2,2,'ддд',2);
/*!40000 ALTER TABLE `real_estate` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-08 10:24:41
