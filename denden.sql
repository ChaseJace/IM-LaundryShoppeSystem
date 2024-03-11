-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: denden_laundry
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_address`
--

DROP TABLE IF EXISTS `tbl_address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_address` (
  `Address_ID` int(11) NOT NULL,
  `Lot` int(11) DEFAULT NULL,
  `Block` int(11) DEFAULT NULL,
  `Street_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`Address_ID`),
  KEY `Street_ID` (`Street_ID`),
  CONSTRAINT `tbl_address_ibfk_1` FOREIGN KEY (`Street_ID`) REFERENCES `tbl_street` (`Street_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_address`
--

LOCK TABLES `tbl_address` WRITE;
/*!40000 ALTER TABLE `tbl_address` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_barangay`
--

DROP TABLE IF EXISTS `tbl_barangay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_barangay` (
  `Barangay_ID` int(11) NOT NULL,
  `Barangay_Name` varchar(20) DEFAULT NULL,
  `City_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`Barangay_ID`),
  KEY `City_ID` (`City_ID`),
  CONSTRAINT `tbl_barangay_ibfk_1` FOREIGN KEY (`City_ID`) REFERENCES `tbl_city` (`City_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_barangay`
--

LOCK TABLES `tbl_barangay` WRITE;
/*!40000 ALTER TABLE `tbl_barangay` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_barangay` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_city`
--

DROP TABLE IF EXISTS `tbl_city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_city` (
  `City_ID` int(11) NOT NULL,
  `City_Name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`City_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_city`
--

LOCK TABLES `tbl_city` WRITE;
/*!40000 ALTER TABLE `tbl_city` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_customer`
--

DROP TABLE IF EXISTS `tbl_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_customer` (
  `Customer_ID` int(11) NOT NULL,
  `Address_ID` int(11) DEFAULT NULL,
  `Cus_Lname` varchar(20) DEFAULT NULL,
  `Cus_Fname` varchar(20) DEFAULT NULL,
  `Cus_Initial` char(1) DEFAULT NULL,
  `Cus_Gender` varchar(6) DEFAULT NULL,
  `Cus_Age` int(2) DEFAULT NULL,
  `Cus_ContactNum` int(11) DEFAULT NULL,
  PRIMARY KEY (`Customer_ID`),
  KEY `Address_ID` (`Address_ID`),
  CONSTRAINT `tbl_customer_ibfk_1` FOREIGN KEY (`Address_ID`) REFERENCES `tbl_address` (`Address_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_customer`
--

LOCK TABLES `tbl_customer` WRITE;
/*!40000 ALTER TABLE `tbl_customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_employee`
--

DROP TABLE IF EXISTS `tbl_employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_employee` (
  `Emp_ID` int(11) NOT NULL,
  `Emp_Lname` varchar(20) DEFAULT NULL,
  `Emp_Fname` varchar(20) DEFAULT NULL,
  `Emp_Initial` char(1) DEFAULT NULL,
  `Emp_Age` int(2) DEFAULT NULL,
  `Emp_Gender` varchar(6) DEFAULT NULL,
  PRIMARY KEY (`Emp_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_employee`
--

LOCK TABLES `tbl_employee` WRITE;
/*!40000 ALTER TABLE `tbl_employee` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_inventory`
--

DROP TABLE IF EXISTS `tbl_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_inventory` (
  `Laundry_ID` int(11) DEFAULT NULL,
  `Product_ID` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Unit` int(11) DEFAULT NULL,
  KEY `Laundry_ID` (`Laundry_ID`),
  KEY `Product_ID` (`Product_ID`),
  CONSTRAINT `tbl_inventory_ibfk_1` FOREIGN KEY (`Laundry_ID`) REFERENCES `tbl_laundry` (`Laundry_ID`),
  CONSTRAINT `tbl_inventory_ibfk_2` FOREIGN KEY (`Product_ID`) REFERENCES `tbl_product` (`Product_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_inventory`
--

LOCK TABLES `tbl_inventory` WRITE;
/*!40000 ALTER TABLE `tbl_inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_laundry`
--

DROP TABLE IF EXISTS `tbl_laundry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_laundry` (
  `Laundry_ID` int(11) NOT NULL,
  `Laundry_Date` date DEFAULT NULL,
  `Customer_ID` int(11) DEFAULT NULL,
  `Employee_ID` int(11) DEFAULT NULL,
  `Laundry_Type_ID` int(11) DEFAULT NULL,
  `Weight` double DEFAULT NULL,
  `Cost` float DEFAULT NULL,
  `Subtotal` float DEFAULT NULL,
  PRIMARY KEY (`Laundry_ID`),
  KEY `Customer_ID` (`Customer_ID`),
  KEY `Employee_ID` (`Employee_ID`),
  KEY `Laundry_Type_ID` (`Laundry_Type_ID`),
  CONSTRAINT `tbl_laundry_ibfk_1` FOREIGN KEY (`Customer_ID`) REFERENCES `tbl_customer` (`Customer_ID`),
  CONSTRAINT `tbl_laundry_ibfk_2` FOREIGN KEY (`Employee_ID`) REFERENCES `tbl_employee` (`Emp_ID`),
  CONSTRAINT `tbl_laundry_ibfk_3` FOREIGN KEY (`Laundry_Type_ID`) REFERENCES `tbl_laundry_details` (`Laundry_Type_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_laundry`
--

LOCK TABLES `tbl_laundry` WRITE;
/*!40000 ALTER TABLE `tbl_laundry` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_laundry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_laundry_details`
--

DROP TABLE IF EXISTS `tbl_laundry_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_laundry_details` (
  `Laundry_Type_ID` int(11) NOT NULL,
  `Laundry_Type` varchar(20) DEFAULT NULL,
  `Laundry_Type_Price` float DEFAULT NULL,
  PRIMARY KEY (`Laundry_Type_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_laundry_details`
--

LOCK TABLES `tbl_laundry_details` WRITE;
/*!40000 ALTER TABLE `tbl_laundry_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_laundry_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_product`
--

DROP TABLE IF EXISTS `tbl_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_product` (
  `Product_ID` int(11) NOT NULL,
  `Product_Name` varchar(20) DEFAULT NULL,
  `Product_Price` float DEFAULT NULL,
  `Product_Quantity` int(11) DEFAULT NULL,
  `Product_Desc` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Product_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_product`
--

LOCK TABLES `tbl_product` WRITE;
/*!40000 ALTER TABLE `tbl_product` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_street`
--

DROP TABLE IF EXISTS `tbl_street`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_street` (
  `Street_ID` int(11) NOT NULL,
  `Street_Name` varchar(20) DEFAULT NULL,
  `Barangay_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`Street_ID`),
  KEY `Barangay_ID` (`Barangay_ID`),
  CONSTRAINT `tbl_street_ibfk_1` FOREIGN KEY (`Barangay_ID`) REFERENCES `tbl_barangay` (`Barangay_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_street`
--

LOCK TABLES `tbl_street` WRITE;
/*!40000 ALTER TABLE `tbl_street` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_street` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-11 17:08:54
