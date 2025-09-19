USE sit_metric_store;
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;

--
-- Table structure for table `identity_context`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
ALTER TABLE `identity_context` 
ADD COLUMN `Username` VARCHAR(255) NULL DEFAULT NULL AFTER `Provider`,
ADD COLUMN `Email` VARCHAR(255) NULL DEFAULT NULL AFTER `Username`;
/*!40101 SET character_set_client = @saved_cs_client */;