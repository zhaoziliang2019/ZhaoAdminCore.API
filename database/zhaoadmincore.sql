/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 80016
Source Host           : localhost:3306
Source Database       : zhaoadmincore

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2020-10-27 21:20:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for interfacesinfo
-- ----------------------------
DROP TABLE IF EXISTS `interfacesinfo`;
CREATE TABLE `interfacesinfo` (
  `iID` int(11) NOT NULL,
  `iIsDeleted` bit(1) DEFAULT NULL,
  `iName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `iLinkUrl` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `iDescription` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `iEnabled` bit(1) DEFAULT NULL,
  `iCreateId` int(11) DEFAULT NULL,
  `iCreateBy` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `iCreateTime` datetime DEFAULT NULL,
  `iModifyId` int(11) DEFAULT NULL,
  `iModifyBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `iModifyTime` datetime DEFAULT NULL,
  PRIMARY KEY (`iID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of interfacesinfo
-- ----------------------------
INSERT INTO `interfacesinfo` VALUES ('1', '\0', '获取所有用户列表', 'api/user/get', '获取所有用户列表', '', null, null, '2020-10-16 14:51:54', null, null, null);

-- ----------------------------
-- Table structure for menuinfo
-- ----------------------------
DROP TABLE IF EXISTS `menuinfo`;
CREATE TABLE `menuinfo` (
  `mID` int(11) NOT NULL AUTO_INCREMENT,
  `mPath` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `mName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `mPid` int(11) DEFAULT NULL,
  `mMid` int(11) DEFAULT NULL,
  `mOrderSort` int(11) DEFAULT NULL,
  `mIcon` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `mDescription` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `mIsDeleted` bit(1) DEFAULT NULL,
  `mCreateTime` datetime DEFAULT NULL,
  `mCreateId` int(11) DEFAULT NULL,
  `mCreateBy` varchar(50) DEFAULT NULL,
  `mModifyId` int(11) DEFAULT NULL,
  `mModifyBy` varchar(50) DEFAULT NULL,
  `mUpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`mID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of menuinfo
-- ----------------------------
INSERT INTO `menuinfo` VALUES ('1', '-', '系统管理', '0', '0', '0', 'el-icon-s-operation', '系统管理根节点', '\0', '2020-10-22 17:53:34', null, null, null, null, '2020-10-22 17:53:34');
INSERT INTO `menuinfo` VALUES ('3', '/users', '用户管理', '1', '0', '0', 'el-icon-menu', '用户管理', '\0', '2020-10-22 18:13:55', null, null, null, null, '2020-10-22 18:13:55');
INSERT INTO `menuinfo` VALUES ('4', '/roles', '角色管理', '1', '0', '1', 'el-icon-menu', '角色管理', '\0', '2020-10-23 09:28:06', null, null, null, null, '2020-10-23 09:28:06');
INSERT INTO `menuinfo` VALUES ('6', '/menus', '菜单权限管理', '1', '0', '0', 'el-icon-menu', '菜单权限管理', '\0', '2020-10-23 09:33:49', null, null, null, null, '2020-10-23 09:33:49');
INSERT INTO `menuinfo` VALUES ('9', '/users/adduser', '添加用户', '3', '0', '0', 'el-icon-add', '添加用户按钮', '\0', '2020-10-26 11:02:18', null, null, null, null, '2020-10-26 11:02:18');
INSERT INTO `menuinfo` VALUES ('10', '/users/updateuser', '更新用户', '3', '0', '1', 'el-icon-edit', '更新用户信息按钮', '\0', '2020-10-26 11:33:00', null, null, null, null, '2020-10-26 11:33:00');
INSERT INTO `menuinfo` VALUES ('11', '/users/delete', '删除用户', '3', '0', '3', 'el-icon-delete', '删除用户按钮', '\0', '2020-10-26 11:43:41', null, null, null, null, '2020-10-26 11:43:41');

-- ----------------------------
-- Table structure for permissioninfo
-- ----------------------------
DROP TABLE IF EXISTS `permissioninfo`;
CREATE TABLE `permissioninfo` (
  `pID` int(11) NOT NULL,
  `pName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `pIsDelete` bit(1) DEFAULT NULL,
  `pCreateTime` datetime DEFAULT NULL,
  `pCreateId` int(11) DEFAULT NULL,
  `pCreateBy` varchar(50) DEFAULT NULL,
  `pModifyId` int(11) DEFAULT NULL,
  `pModifyBy` varchar(100) DEFAULT NULL,
  `pUpdateTime` datetime DEFAULT NULL,
  `mID` int(11) DEFAULT NULL,
  PRIMARY KEY (`pID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of permissioninfo
-- ----------------------------
INSERT INTO `permissioninfo` VALUES ('101', '添加用户', '\0', null, null, '超级管理员', null, null, null, '2');
INSERT INTO `permissioninfo` VALUES ('102', '编辑用户', '\0', null, null, '超级管理员', null, null, null, '2');
INSERT INTO `permissioninfo` VALUES ('103', '删除用户', '\0', null, null, '超级管理员', null, null, null, '2');
INSERT INTO `permissioninfo` VALUES ('104', '查看用户详细', '\0', null, null, '超级管理员', null, null, null, '2');
INSERT INTO `permissioninfo` VALUES ('105', '打印用信息', '\0', null, null, '超级管理员', null, null, null, '2');
INSERT INTO `permissioninfo` VALUES ('106', '导出用户信息', '\0', null, null, '超级管理员', null, null, null, '2');
INSERT INTO `permissioninfo` VALUES ('107', '添加角色', '\0', null, null, '超级管理员', null, null, null, '3');

-- ----------------------------
-- Table structure for roleinfo
-- ----------------------------
DROP TABLE IF EXISTS `roleinfo`;
CREATE TABLE `roleinfo` (
  `rID` int(11) NOT NULL AUTO_INCREMENT,
  `rName` varchar(100) DEFAULT NULL,
  `rIsDelete` bit(1) DEFAULT NULL,
  `rCreateTime` datetime DEFAULT NULL,
  `rCreateId` int(11) DEFAULT NULL,
  `rCreateBy` varchar(50) DEFAULT NULL,
  `rModifyId` int(11) DEFAULT NULL,
  `rModifyBy` varchar(100) DEFAULT NULL,
  `rUpdateTime` datetime DEFAULT NULL,
  `rDescription` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`rID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of roleinfo
-- ----------------------------
INSERT INTO `roleinfo` VALUES ('1', '超级管理员', '\0', '2020-10-19 15:58:51', null, '超级管理员', null, '超级管理员', '2020-10-20 15:58:55', '有所有的权限');
INSERT INTO `roleinfo` VALUES ('2', '查看角色', '\0', '2020-10-21 10:46:52', null, '超级管理员', null, '超级管理员', '2020-10-21 10:46:52', '只允许查看');
INSERT INTO `roleinfo` VALUES ('3', '普通管理员', '\0', '2020-10-21 11:04:03', null, null, null, null, '2020-10-21 11:04:03', '可以添加编辑删除查看导出功能');

-- ----------------------------
-- Table structure for rolemenuinfo
-- ----------------------------
DROP TABLE IF EXISTS `rolemenuinfo`;
CREATE TABLE `rolemenuinfo` (
  `rmID` int(11) NOT NULL AUTO_INCREMENT,
  `rID` int(11) DEFAULT NULL,
  `mID` int(11) DEFAULT NULL,
  PRIMARY KEY (`rmID`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of rolemenuinfo
-- ----------------------------
INSERT INTO `rolemenuinfo` VALUES ('33', '1', '3');
INSERT INTO `rolemenuinfo` VALUES ('34', '1', '9');
INSERT INTO `rolemenuinfo` VALUES ('35', '1', '10');
INSERT INTO `rolemenuinfo` VALUES ('37', '1', '4');
INSERT INTO `rolemenuinfo` VALUES ('38', '1', '6');

-- ----------------------------
-- Table structure for sysuserinfo
-- ----------------------------
DROP TABLE IF EXISTS `sysuserinfo`;
CREATE TABLE `sysuserinfo` (
  `uID` int(11) NOT NULL AUTO_INCREMENT,
  `uLoginName` varchar(10) DEFAULT NULL,
  `uPassWord` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `uIsDelete` bit(1) DEFAULT NULL COMMENT '1是true, 0是false',
  `uRealName` varchar(100) DEFAULT NULL,
  `uSex` int(1) DEFAULT NULL,
  `uAddress` varchar(200) DEFAULT NULL,
  `uEmail` varchar(20) DEFAULT NULL,
  `uPhone` varchar(11) DEFAULT NULL,
  `uCreateTime` datetime DEFAULT NULL,
  `uUpdateTime` datetime DEFAULT NULL,
  `uLastErrTime` datetime DEFAULT NULL,
  `uErrorCount` int(11) DEFAULT NULL,
  PRIMARY KEY (`uID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of sysuserinfo
-- ----------------------------
INSERT INTO `sysuserinfo` VALUES ('3', 'admin', 'e10adc3949ba59abbe56e057f20f883e', '\0', '超级管理员', '1', '北京海淀区西三旗', '907606163@qq.com', '15231451752', '2020-10-14 18:21:48', '2020-10-21 21:15:32', '2020-10-14 18:21:48', '0');
INSERT INTO `sysuserinfo` VALUES ('7', 'test', '47EC2DD791E31E2EF2076CAF64ED9B3D', '\0', '测试账号', '2', '北京海淀区西三旗街道', '907606163@qq.com', '15617421451', '2020-10-15 17:05:29', '2020-10-15 17:05:29', '2020-10-15 17:05:29', '0');

-- ----------------------------
-- Table structure for userroleinfo
-- ----------------------------
DROP TABLE IF EXISTS `userroleinfo`;
CREATE TABLE `userroleinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `uID` int(11) DEFAULT NULL,
  `rID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of userroleinfo
-- ----------------------------
INSERT INTO `userroleinfo` VALUES ('8', '3', '1');
