USE sit_metric_store;
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;

--
-- Table structure for table `topic`
--
DROP TABLE IF EXISTS `topic`;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `topic` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `CreatedOn` timestamp NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `group`
--
DROP TABLE IF EXISTS `group`;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `CreatedOn` timestamp NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `subject`
--
DROP TABLE IF EXISTS `subject`;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subject` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `CreatedOn` timestamp NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `source`
--
DROP TABLE IF EXISTS `source`;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `source` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `Code` varchar(255) NOT NULL,
  `CreatedOn` timestamp NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `identity_context`
--
DROP TABLE IF EXISTS `identity_context`;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `identity_context` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Start` DATETIME DEFAULT NULL,
  `End` DATETIME DEFAULT NULL,
  `SubjectIdentifier` varchar(255) NOT NULL,
  `Provider` varchar(255) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `CreatedOn` timestamp NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `metric`
--
DROP TABLE IF EXISTS `metric`;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `metric` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TopicId` INT(11) NOT NULL,
  `GroupId` INT(11) NOT NULL,
  `Type` INT(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `CreatedOn` timestamp NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `observation`
--
DROP TABLE IF EXISTS `observation`;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `observation` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MetricId` INT(11) NOT NULL,
  `SourceId` INT(11) NOT NULL,
  `ContextId` INT(11) NOT NULL,
  `SubjectId` INT(11) NOT NULL,
  `Timestamp` TIMESTAMP NOT NULL,
  `nI` INT(11) DEFAULT NULL,
  `nD` DECIMAL(12,5) DEFAULT NULL,
  `dT` DATETIME DEFAULT NULL,
  `t25` VARCHAR(25) DEFAULT NULL,
  `tX` TEXT DEFAULT NULL,
  `CreatedOn` DATETIME NOT NULL,
  PRIMARY KEY (`Id`, `CreatedOn`),
  KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1 PARTITION BY HASH(MONTH(`CreatedOn`));
/*!40101 SET character_set_client = @saved_cs_client */;