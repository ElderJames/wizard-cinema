/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : wizard_cinema

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-08-23 00:28:03
*/

SET FOREIGN_KEY_CHECKS=0;

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
  `CreateTime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_DivisionId` (`DivisionId`),
  UNIQUE KEY `UNQ_CityId` (`CityId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
-- Table structure for wizards
-- ----------------------------
DROP TABLE IF EXISTS `wizards`;
CREATE TABLE `wizards` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `WizardId` bigint(20) NOT NULL,
  `Email` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Account` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_WizardId` (`WizardId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Table structure for wizard_profiles
-- ----------------------------
DROP TABLE IF EXISTS `wizard_profiles`;
CREATE TABLE `wizard_profiles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `WizardId` bigint(20) NOT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `PortraitUrl` char(255) DEFAULT NULL,
  `Gender` tinyint(4) DEFAULT NULL,
  `Birthday` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Slogan` varchar(255) DEFAULT NULL,
  `House` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNQ_WizardId` (`WizardId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
SET FOREIGN_KEY_CHECKS=1;
