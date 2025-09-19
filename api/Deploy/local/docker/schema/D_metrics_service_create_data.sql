--
-- Standard Metrics Create Script
--
use sit_metric_store;

--
-- Metrics
--
-- Group 1 (Micro Apps)
-- Topic 2 (Journey)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'TTF Save', 'Time To First Save', NOW()); -- ID 18 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Call Icon', 'Invoke Call Icon', NOW()); -- ID 19 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Link to Edit Client Page', 'Link to Edit Client Page', NOW()); -- ID 20 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Call Phone', 'Invoke Call Phone', NOW()); -- ID 21 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Link to Split Job Page', 'Link to Split Job Page', NOW()); -- ID 22 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Print', 'Invoke Print', NOW()); -- ID 23 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Email', 'Invoke Email', NOW()); -- ID 24 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Grouping', 'Invoke Grouping', NOW()); -- ID 25 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Sorting', 'Invoke Sorting', NOW()); -- ID 26 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Expand', 'Invoke Expand', NOW()); -- ID 27 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Collapse', 'Invoke Collapse', NOW()); -- ID 28 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Invoke Completed', 'Invoke Completed', NOW()); -- ID 29 (Number, Type = 0)
