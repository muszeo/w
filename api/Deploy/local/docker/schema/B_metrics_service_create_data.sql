--
-- Standard Metrics Create Script
--
use sit_metric_store;

--
-- Metric Groups
--
INSERT INTO `group` (`Name`, `Description`, `CreatedOn`) VALUES ('Micro Apps', 'Micro Apps', NOW()); -- ID 1
INSERT INTO `group` (`Name`, `Description`, `CreatedOn`) VALUES ('Micro Services', 'Micro Services', NOW()); -- ID 2
INSERT INTO `group` (`Name`, `Description`, `CreatedOn`) VALUES ('Integrations', 'Integrations', NOW()); -- ID 3

--
-- Metric Topics
--
INSERT INTO `topic` (`Name`, `Description`, `CreatedOn`) VALUES ('Performance', 'Performance', NOW()); -- ID 1
INSERT INTO `topic` (`Name`, `Description`, `CreatedOn`) VALUES ('Journey', 'Journey', NOW()); -- ID 2
INSERT INTO `topic` (`Name`, `Description`, `CreatedOn`) VALUES ('Platform', 'Platform', NOW()); -- ID 3

--
-- Metrics
--
-- Group 1 (Micro Apps)
-- Topic 1 (Performance)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 1, 0, 'Load Time', 'Load Time', NOW()); -- ID 1'
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 1, 0, 'Network Speed', 'Network Speed', NOW()); -- ID 2
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 1, 0, 'Browser Performance', 'Browser Performance', NOW()); -- ID 3
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 1, 0, 'Save Time', 'Save Time', NOW()); -- ID 4
-- Topic 2 (Journey)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Page View', 'Page View', NOW()); -- ID 5 (Number, Type = 0)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Page Save', 'Page Save', NOW()); -- ID 6 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Job Update', 'Job Update', NOW()); -- ID 7 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 4, 'Job Field Update', 'Job Field Update', NOW()); -- ID 8 (Code, Type = 4)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Drag Job Activity', 'Drag Job Activity', NOW()); -- ID 9 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Assign Job Activity', 'Assign Job Activity', NOW()); -- ID 10 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Unassign Job Activity', 'Unassign Job Activity', NOW()); -- ID 11 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Settings Vehicles Update', 'Settings Vehicles Update', NOW()); -- ID 12 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Show Full Day', 'Show Full Day', NOW()); -- ID 13 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 2, 'Change Date', 'Change Date', NOW()); -- ID 14 (DateTime, Type = 2)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Link to Edit Job Page', 'Link to Edit Job Page', NOW()); -- ID 15 (Number)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 2, 0, 'Resize Job Activity', 'Resize Job Activity', NOW()); -- ID 16 (Number)
-- Topic 3 (Platform)
INSERT INTO `metric` (`GroupId`, `TopicId`, `Type`, `Name`, `Description`, `CreatedOn`) VALUES (1, 3, 3, 'Browser', 'Browser', NOW()); -- ID 17 (Text, Type = 3)


--
-- Metric Sources (Components)
--
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Job Scheduling App', 'Job Scheduling App', 'Micro App', 'JSA', NOW()); -- ID 1
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Standard Reports App', 'Standard Reports App', 'Micro App', 'KSR', NOW()); -- ID 2
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Resource Management App', 'Resource Management App', 'Micro App', 'RMA', NOW()); -- ID 3
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Onboarding App', 'Onboarding App', 'Micro App', 'OBA', NOW()); -- ID 4
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Xero Sign-Up App', 'Xero Sign-Up App', 'Micro App', 'XSA', NOW()); -- ID 5
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('MAC', 'MAC', 'Micro App', 'MAC', NOW()); -- ID 6
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Web Application', 'Web Application', 'Micro App', 'WAM', NOW()); -- ID 7
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Identity Provider', 'Identity Provider', 'Micro App', 'IDP', NOW()); -- ID 8
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Web API v2', 'Web API', 'Micro Service', 'WAP', NOW()); -- ID 9
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Event API', 'Event API', 'Micro Service', 'ELS', NOW()); -- ID 10
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Notification API', 'Notification API', 'Micro Service', 'NOS', NOW()); -- ID 11
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Cache Services API', 'Cache Services API', 'Micro Service', 'CAS', NOW()); -- ID 12
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Metrics Service API', 'Metrics Service API', 'Micro Service', 'MXS', NOW()); -- ID 13
INSERT INTO `source` (`Name`, `Description`, `Type`, `Code`, `CreatedOn`) VALUES ('Billing App', 'Billing App', 'Micro Service', 'BAP', NOW()); -- ID 14

--
-- Metric Subjects (Pages, Apis etc.)
--
INSERT INTO `subject` (`Name`, `Description`, `CreatedOn`) VALUES ('Planner', 'Job Scheduler, Calendar View, Planner', NOW()); -- ID 1
INSERT INTO `subject` (`Name`, `Description`, `CreatedOn`) VALUES ('New Daysheet', 'Job Scheduler, Daysheet', NOW()); -- ID 2

