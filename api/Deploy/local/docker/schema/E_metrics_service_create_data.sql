--
-- Standard Metrics Create Script
--
use sit_metric_store;

--
-- Metrics
--
-- Group 1 (Micro Apps)
-- Topic 2 (Journey)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke PDF', 'Invoke PDF', NOW()); -- ID 30 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Excel', 'Invoke Excel', NOW()); -- ID 31 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke CSV', 'Invoke CSV', NOW()); -- ID 32 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Save Format Preference', 'Invoke Save Format Preference', NOW()); -- ID 33 (Number, Type = 0)
-- Topic 1 (Performance)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 1, 0, 'Page Size', 'Page Size', NOW()); -- ID 34 (Number, Type = 0)
-- Topic 2 (Journey)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Report Type', 'Report Type', NOW()); -- ID 35 (Number, Type = 0)

--
-- Metric Subjects (Pages, Apis etc.)
--
INSERT INTO `subject` (`Name`, `Description`, `CreatedOn`) VALUES ('Reports Home', 'Standard Reports, Home', NOW()); -- ID 3
INSERT INTO `subject` (`Name`, `Description`, `CreatedOn`) VALUES ('Reports Report', 'Standard Reports, Report', NOW()); -- ID 4
