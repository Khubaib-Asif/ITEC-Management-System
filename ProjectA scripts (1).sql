-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: projecta
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `committee_members`
--

DROP TABLE IF EXISTS `committee_members`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `committee_members` (
  `member_id` int NOT NULL AUTO_INCREMENT,
  `committee_id` int DEFAULT NULL,
  `name` varchar(255) NOT NULL,
  `role_id` int DEFAULT NULL,
  PRIMARY KEY (`member_id`),
  KEY `committee_id` (`committee_id`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `committee_members_ibfk_1` FOREIGN KEY (`committee_id`) REFERENCES `committees` (`committee_id`) ON DELETE CASCADE,
  CONSTRAINT `committee_members_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `lookup` (`lookup_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `committee_members`
--

LOCK TABLES `committee_members` WRITE;
/*!40000 ALTER TABLE `committee_members` DISABLE KEYS */;
/*!40000 ALTER TABLE `committee_members` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `committees`
--

DROP TABLE IF EXISTS `committees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `committees` (
  `committee_id` int NOT NULL AUTO_INCREMENT,
  `itec_id` int DEFAULT NULL,
  `committee_name` varchar(255) NOT NULL,
  PRIMARY KEY (`committee_id`),
  KEY `itec_id` (`itec_id`),
  CONSTRAINT `committees_ibfk_1` FOREIGN KEY (`itec_id`) REFERENCES `itec_editions` (`itec_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `committees`
--

LOCK TABLES `committees` WRITE;
/*!40000 ALTER TABLE `committees` DISABLE KEYS */;
/*!40000 ALTER TABLE `committees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `duties`
--

DROP TABLE IF EXISTS `duties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `duties` (
  `duty_id` int NOT NULL AUTO_INCREMENT,
  `committee_id` int DEFAULT NULL,
  `assigned_to` varchar(255) NOT NULL,
  `task_description` text,
  `deadline` date DEFAULT NULL,
  `status_id` int DEFAULT NULL,
  PRIMARY KEY (`duty_id`),
  KEY `committee_id` (`committee_id`),
  KEY `status_id` (`status_id`),
  CONSTRAINT `duties_ibfk_1` FOREIGN KEY (`committee_id`) REFERENCES `committees` (`committee_id`) ON DELETE CASCADE,
  CONSTRAINT `duties_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `lookup` (`lookup_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `duties`
--

LOCK TABLES `duties` WRITE;
/*!40000 ALTER TABLE `duties` DISABLE KEYS */;
/*!40000 ALTER TABLE `duties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_categories`
--

DROP TABLE IF EXISTS `event_categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event_categories` (
  `event_category_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(100) NOT NULL,
  PRIMARY KEY (`event_category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_categories`
--

LOCK TABLES `event_categories` WRITE;
/*!40000 ALTER TABLE `event_categories` DISABLE KEYS */;
/*!40000 ALTER TABLE `event_categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_participants`
--

DROP TABLE IF EXISTS `event_participants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event_participants` (
  `registration_id` int NOT NULL AUTO_INCREMENT,
  `event_id` int DEFAULT NULL,
  `participant_id` int DEFAULT NULL,
  `payment_status_id` int DEFAULT NULL,
  `fee_amount` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`registration_id`),
  KEY `event_id` (`event_id`),
  KEY `participant_id` (`participant_id`),
  KEY `payment_status_id` (`payment_status_id`),
  CONSTRAINT `event_participants_ibfk_1` FOREIGN KEY (`event_id`) REFERENCES `itec_events` (`event_id`) ON DELETE CASCADE,
  CONSTRAINT `event_participants_ibfk_2` FOREIGN KEY (`participant_id`) REFERENCES `participants` (`participant_id`) ON DELETE CASCADE,
  CONSTRAINT `event_participants_ibfk_3` FOREIGN KEY (`payment_status_id`) REFERENCES `lookup` (`lookup_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_participants`
--

LOCK TABLES `event_participants` WRITE;
/*!40000 ALTER TABLE `event_participants` DISABLE KEYS */;
/*!40000 ALTER TABLE `event_participants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_results`
--

DROP TABLE IF EXISTS `event_results`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event_results` (
  `result_id` int NOT NULL AUTO_INCREMENT,
  `event_id` int DEFAULT NULL,
  `participant_id` int DEFAULT NULL,
  `team_id` int DEFAULT NULL,
  `position` int DEFAULT NULL,
  `score` decimal(5,2) DEFAULT NULL,
  `remarks` text,
  PRIMARY KEY (`result_id`),
  KEY `event_id` (`event_id`),
  KEY `participant_id` (`participant_id`),
  KEY `team_id` (`team_id`),
  CONSTRAINT `event_results_ibfk_1` FOREIGN KEY (`event_id`) REFERENCES `itec_events` (`event_id`) ON DELETE CASCADE,
  CONSTRAINT `event_results_ibfk_2` FOREIGN KEY (`participant_id`) REFERENCES `participants` (`participant_id`) ON DELETE SET NULL,
  CONSTRAINT `event_results_ibfk_3` FOREIGN KEY (`team_id`) REFERENCES `teams` (`team_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_results`
--

LOCK TABLES `event_results` WRITE;
/*!40000 ALTER TABLE `event_results` DISABLE KEYS */;
/*!40000 ALTER TABLE `event_results` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `finances`
--

DROP TABLE IF EXISTS `finances`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `finances` (
  `transaction_id` int NOT NULL AUTO_INCREMENT,
  `itec_id` int DEFAULT NULL,
  `event_id` int DEFAULT NULL,
  `type_id` int DEFAULT NULL,
  `amount` decimal(10,2) NOT NULL,
  `from_entity_type` enum('User','Sponsor','Committee','Vendor') NOT NULL,
  `from_entity_id` int NOT NULL,
  `to_entity_type` enum('User','Sponsor','Committee','Vendor') NOT NULL,
  `to_entity_id` int NOT NULL,
  `description` text,
  `date_recorded` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`transaction_id`),
  KEY `itec_id` (`itec_id`),
  KEY `event_id` (`event_id`),
  KEY `type_id` (`type_id`),
  CONSTRAINT `finances_ibfk_1` FOREIGN KEY (`itec_id`) REFERENCES `itec_editions` (`itec_id`) ON DELETE CASCADE,
  CONSTRAINT `finances_ibfk_2` FOREIGN KEY (`event_id`) REFERENCES `itec_events` (`event_id`) ON DELETE SET NULL,
  CONSTRAINT `finances_ibfk_3` FOREIGN KEY (`type_id`) REFERENCES `lookup` (`lookup_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `finances`
--

LOCK TABLES `finances` WRITE;
/*!40000 ALTER TABLE `finances` DISABLE KEYS */;
/*!40000 ALTER TABLE `finances` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itec_editions`
--

DROP TABLE IF EXISTS `itec_editions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itec_editions` (
  `itec_id` int NOT NULL AUTO_INCREMENT,
  `year` int NOT NULL,
  `theme` varchar(255) DEFAULT NULL,
  `description` text,
  PRIMARY KEY (`itec_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itec_editions`
--

LOCK TABLES `itec_editions` WRITE;
/*!40000 ALTER TABLE `itec_editions` DISABLE KEYS */;
/*!40000 ALTER TABLE `itec_editions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itec_events`
--

DROP TABLE IF EXISTS `itec_events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itec_events` (
  `event_id` int NOT NULL AUTO_INCREMENT,
  `itec_id` int DEFAULT NULL,
  `event_name` varchar(255) NOT NULL,
  `event_category_id` int DEFAULT NULL,
  `description` text,
  `event_date` date DEFAULT NULL,
  `venue_id` int DEFAULT NULL,
  `committee_id` int DEFAULT NULL,
  PRIMARY KEY (`event_id`),
  KEY `itec_id` (`itec_id`),
  KEY `event_category_id` (`event_category_id`),
  KEY `venue_id` (`venue_id`),
  KEY `committee_id` (`committee_id`),
  CONSTRAINT `itec_events_ibfk_1` FOREIGN KEY (`itec_id`) REFERENCES `itec_editions` (`itec_id`) ON DELETE CASCADE,
  CONSTRAINT `itec_events_ibfk_2` FOREIGN KEY (`event_category_id`) REFERENCES `event_categories` (`event_category_id`) ON DELETE SET NULL,
  CONSTRAINT `itec_events_ibfk_3` FOREIGN KEY (`venue_id`) REFERENCES `venues` (`venue_id`) ON DELETE SET NULL,
  CONSTRAINT `itec_events_ibfk_4` FOREIGN KEY (`committee_id`) REFERENCES `committees` (`committee_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itec_events`
--

LOCK TABLES `itec_events` WRITE;
/*!40000 ALTER TABLE `itec_events` DISABLE KEYS */;
/*!40000 ALTER TABLE `itec_events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lookup`
--

DROP TABLE IF EXISTS `lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lookup` (
  `lookup_id` int NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL,
  `value` varchar(100) NOT NULL,
  PRIMARY KEY (`lookup_id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lookup`
--

LOCK TABLES `lookup` WRITE;
/*!40000 ALTER TABLE `lookup` DISABLE KEYS */;
INSERT INTO `lookup` VALUES (1,'UserRoles','Admin'),(2,'UserRoles','Faculty'),(3,'UserRoles','Student'),(4,'UserRoles','Sponsor'),(5,'EventCategories','Competition'),(6,'EventCategories','Seminar'),(7,'EventCategories','Exhibition'),(8,'EventCategories','Non-Tech'),(9,'ParticipantRoles','Student'),(10,'ParticipantRoles','Professional'),(11,'ParticipantRoles','Guest Speaker'),(12,'ParticipantRoles','Judge'),(13,'PaymentStatus','Pending'),(14,'PaymentStatus','Paid'),(15,'PaymentStatus','Canceled'),(16,'CommitteeRoles','Faculty Advisor'),(17,'CommitteeRoles','Student Lead'),(18,'CommitteeRoles','Volunteer'),(19,'DutyStatus','Pending'),(20,'DutyStatus','In Progress'),(21,'DutyStatus','Completed'),(22,'FinanceTypes','Sponsorship'),(23,'FinanceTypes','Ticket Sales'),(24,'FinanceTypes','Expense'),(25,'AllocationStatus','Pending'),(26,'AllocationStatus','Approved'),(27,'AllocationStatus','Rejected'),(28,'EntityTypes','User'),(29,'EntityTypes','Sponsor'),(30,'EntityTypes','Committee'),(31,'EntityTypes','Vendor'),(32,'EventPositions','Winner'),(33,'EventPositions','Runner-up'),(34,'EventPositions','Finalist'),(35,'EventPositions','Participant');
/*!40000 ALTER TABLE `lookup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `participants`
--

DROP TABLE IF EXISTS `participants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `participants` (
  `participant_id` int NOT NULL AUTO_INCREMENT,
  `itec_id` int DEFAULT NULL,
  `name` varchar(255) NOT NULL,
  `email` varchar(100) NOT NULL,
  `contact` varchar(50) DEFAULT NULL,
  `institute` varchar(255) DEFAULT NULL,
  `role_id` int DEFAULT NULL,
  PRIMARY KEY (`participant_id`),
  UNIQUE KEY `email` (`email`),
  KEY `itec_id` (`itec_id`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `participants_ibfk_1` FOREIGN KEY (`itec_id`) REFERENCES `itec_editions` (`itec_id`) ON DELETE CASCADE,
  CONSTRAINT `participants_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `participants`
--

LOCK TABLES `participants` WRITE;
/*!40000 ALTER TABLE `participants` DISABLE KEYS */;
/*!40000 ALTER TABLE `participants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `role_id` int NOT NULL AUTO_INCREMENT,
  `role_name` varchar(50) NOT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sponsors`
--

DROP TABLE IF EXISTS `sponsors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sponsors` (
  `sponsor_id` int NOT NULL AUTO_INCREMENT,
  `sponsor_name` varchar(255) NOT NULL,
  `contact` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`sponsor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sponsors`
--

LOCK TABLES `sponsors` WRITE;
/*!40000 ALTER TABLE `sponsors` DISABLE KEYS */;
/*!40000 ALTER TABLE `sponsors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `team_participants`
--

DROP TABLE IF EXISTS `team_participants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `team_participants` (
  `team_id` int NOT NULL,
  `participant_id` int NOT NULL,
  PRIMARY KEY (`team_id`,`participant_id`),
  KEY `participant_id` (`participant_id`),
  CONSTRAINT `team_participants_ibfk_1` FOREIGN KEY (`team_id`) REFERENCES `teams` (`team_id`) ON DELETE CASCADE,
  CONSTRAINT `team_participants_ibfk_2` FOREIGN KEY (`participant_id`) REFERENCES `participants` (`participant_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `team_participants`
--

LOCK TABLES `team_participants` WRITE;
/*!40000 ALTER TABLE `team_participants` DISABLE KEYS */;
/*!40000 ALTER TABLE `team_participants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teams`
--

DROP TABLE IF EXISTS `teams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teams` (
  `team_id` int NOT NULL AUTO_INCREMENT,
  `event_id` int DEFAULT NULL,
  `team_name` varchar(255) NOT NULL,
  PRIMARY KEY (`team_id`),
  KEY `event_id` (`event_id`),
  CONSTRAINT `teams_ibfk_1` FOREIGN KEY (`event_id`) REFERENCES `itec_events` (`event_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teams`
--

LOCK TABLES `teams` WRITE;
/*!40000 ALTER TABLE `teams` DISABLE KEYS */;
/*!40000 ALTER TABLE `teams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role_id` int DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendors`
--

DROP TABLE IF EXISTS `vendors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendors` (
  `vendor_id` int NOT NULL AUTO_INCREMENT,
  `vendor_name` varchar(255) NOT NULL,
  `contact` varchar(100) DEFAULT NULL,
  `service_type` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`vendor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendors`
--

LOCK TABLES `vendors` WRITE;
/*!40000 ALTER TABLE `vendors` DISABLE KEYS */;
/*!40000 ALTER TABLE `vendors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venue_allocations`
--

DROP TABLE IF EXISTS `venue_allocations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venue_allocations` (
  `venue_allocation_id` int NOT NULL AUTO_INCREMENT,
  `event_id` int DEFAULT NULL,
  `venue_id` int DEFAULT NULL,
  `assigned_date` date DEFAULT NULL,
  `assigned_time` time DEFAULT NULL,
  PRIMARY KEY (`venue_allocation_id`),
  KEY `event_id` (`event_id`),
  KEY `venue_id` (`venue_id`),
  CONSTRAINT `venue_allocations_ibfk_1` FOREIGN KEY (`event_id`) REFERENCES `itec_events` (`event_id`) ON DELETE CASCADE,
  CONSTRAINT `venue_allocations_ibfk_2` FOREIGN KEY (`venue_id`) REFERENCES `venues` (`venue_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venue_allocations`
--

LOCK TABLES `venue_allocations` WRITE;
/*!40000 ALTER TABLE `venue_allocations` DISABLE KEYS */;
/*!40000 ALTER TABLE `venue_allocations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venues`
--

DROP TABLE IF EXISTS `venues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venues` (
  `venue_id` int NOT NULL AUTO_INCREMENT,
  `venue_name` varchar(255) NOT NULL,
  `capacity` int NOT NULL,
  `location` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`venue_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venues`
--

LOCK TABLES `venues` WRITE;
/*!40000 ALTER TABLE `venues` DISABLE KEYS */;
/*!40000 ALTER TABLE `venues` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-23 23:59:30
