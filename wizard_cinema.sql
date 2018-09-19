/*
Navicat MySQL Data Transfer

Source Server         : 本地
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : wizard_cinema

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-09-19 20:52:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for activity
-- ----------------------------
DROP TABLE IF EXISTS `activity`;
CREATE TABLE `activity` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ActivityId` bigint(20) NOT NULL,
  `DivisionId` bigint(20) NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` tinyint(4) NOT NULL,
  `Status` tinyint(4) NOT NULL,
  `BeginTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `FinishTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `RegistrationBeginTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `RegistrationFinishTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Price` decimal(10,2) NOT NULL,
  `CreatorId` bigint(20) NOT NULL,
  `CreateTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_ActivityId` (`ActivityId`),
  KEY `IDX_DivisionId` (`DivisionId`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of activity
-- ----------------------------
INSERT INTO `activity` VALUES ('1', '1', '1', '吃鸡', '<p>吃鸡吃鸡吃鸡afd&nbsp;</p>', '鸡场', '1', '0', '2018-09-14 16:30:49', '2018-09-14 16:30:49', '2018-09-14 16:30:49', '2018-09-14 16:30:49', '100.00', '1', '2018-09-14 18:28:45');

-- ----------------------------
-- Table structure for cinemas
-- ----------------------------
DROP TABLE IF EXISTS `cinemas`;
CREATE TABLE `cinemas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CinemaId` int(11) DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CityId` int(11) DEFAULT NULL,
  `Address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `LastUpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `UNQ_CinemaId` (`CinemaId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of cinemas
-- ----------------------------

-- ----------------------------
-- Table structure for cities
-- ----------------------------
DROP TABLE IF EXISTS `cities`;
CREATE TABLE `cities` (
  `Id` int(11) NOT NULL,
  `CityId` int(11) DEFAULT NULL,
  `Name` varchar(0) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Pinyin` varchar(0) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CinemaCount` int(11) DEFAULT NULL,
  `LastUpdateTime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of cities
-- ----------------------------

-- ----------------------------
-- Table structure for divisions
-- ----------------------------
DROP TABLE IF EXISTS `divisions`;
CREATE TABLE `divisions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DivisionId` bigint(20) DEFAULT NULL,
  `CityId` bigint(20) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `TotalMember` int(11) DEFAULT NULL,
  `CreatorId` bigint(20) DEFAULT NULL,
  `CreateTime` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_DivisionId` (`DivisionId`),
  UNIQUE KEY `UNQ_CityId` (`CityId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of divisions
-- ----------------------------
INSERT INTO `divisions` VALUES ('1', '1', '20', '广州分部', '1', '1032831325616209920', '2018-09-05');
INSERT INTO `divisions` VALUES ('2', '1037598440072151040', '45', '重庆分部1', '0', '1032831325616209920', '2018-09-06');

-- ----------------------------
-- Table structure for halls
-- ----------------------------
DROP TABLE IF EXISTS `halls`;
CREATE TABLE `halls` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `HallId` int(11) DEFAULT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CinemaId` int(11) DEFAULT NULL,
  `SeatHtml` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SeatJson` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LastUpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `UNQ_HallId` (`HallId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of halls
-- ----------------------------

-- ----------------------------
-- Table structure for ministry_traces
-- ----------------------------
DROP TABLE IF EXISTS `ministry_traces`;
CREATE TABLE `ministry_traces` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TraceId` bigint(20) NOT NULL,
  `WizardId` bigint(20) NOT NULL,
  `LoginIp` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_TraceId` (`TraceId`),
  KEY `IDX_WizardId` (`WizardId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of ministry_traces
-- ----------------------------

-- ----------------------------
-- Table structure for wizards
-- ----------------------------
DROP TABLE IF EXISTS `wizards`;
CREATE TABLE `wizards` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `WizardId` bigint(20) NOT NULL,
  `Email` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Account` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DivisionId` bigint(20) NOT NULL,
  `IsAdmin` bit(1) NOT NULL,
  `CreateTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `CreatorId` bigint(20) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_WizardId` (`WizardId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of wizards
-- ----------------------------
INSERT INTO `wizards` VALUES ('7', '1032831325616209920', 'shunjiey@hotmail.com', 'elderjames', 'E10ADC3949BA59ABBE56E057F20F883E', '1', '', '2018-09-05 18:29:17', '0');
INSERT INTO `wizards` VALUES ('8', '1037286902887088128', null, 'admin1', 'F59BD65F7EDAFB087A81D4DCA06C4910', '1', '', '2018-09-05 18:49:28', '1032831325616209920');
INSERT INTO `wizards` VALUES ('9', '1037288287334563840', null, 'yangsj', 'E10ADC3949BA59ABBE56E057F20F883E', '1', '', '2018-09-05 18:36:14', '1032831325616209920');

-- ----------------------------
-- Table structure for wizard_profiles
-- ----------------------------
DROP TABLE IF EXISTS `wizard_profiles`;
CREATE TABLE `wizard_profiles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `WizardId` bigint(20) NOT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `PortraitUrl` char(255) DEFAULT NULL,
  `Mobile` char(12) DEFAULT NULL,
  `Gender` tinyint(4) DEFAULT NULL,
  `Birthday` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Slogan` varchar(255) DEFAULT NULL,
  `House` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_WizardId` (`WizardId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of wizard_profiles
-- ----------------------------
INSERT INTO `wizard_profiles` VALUES ('2', '1032831325616209920', null, null, null, '0', '0001-01-01 00:00:00', null, '0');
SET FOREIGN_KEY_CHECKS=1;
