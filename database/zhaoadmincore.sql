/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 80016
Source Host           : localhost:3306
Source Database       : zhaoadmincore

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2020-11-10 22:11:51
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for categorieinfo
-- ----------------------------
DROP TABLE IF EXISTS `categorieinfo`;
CREATE TABLE `categorieinfo` (
  `cat_ID` int(11) NOT NULL AUTO_INCREMENT,
  `cat_Name` varchar(50) DEFAULT NULL,
  `cat_Pid` int(11) DEFAULT NULL,
  `cat_Level` int(11) DEFAULT NULL,
  `cat_IsDelete` bit(1) DEFAULT NULL,
  PRIMARY KEY (`cat_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of categorieinfo
-- ----------------------------
INSERT INTO `categorieinfo` VALUES ('1', '男装', '0', '0', '\0');
INSERT INTO `categorieinfo` VALUES ('2', '专场推荐', '1', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('3', '男装馆', '2', '2', '\0');
INSERT INTO `categorieinfo` VALUES ('4', '热卖分类', '1', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('5', '针织衫', '4', '2', '\0');
INSERT INTO `categorieinfo` VALUES ('6', '羽绒服', '1', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('7', '新品', '6', '2', '\0');
INSERT INTO `categorieinfo` VALUES ('8', '衬衫', '1', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('9', '商务衬衫', '8', '2', '\0');
INSERT INTO `categorieinfo` VALUES ('10', '奢侈品', '0', '0', '\0');
INSERT INTO `categorieinfo` VALUES ('11', '热门精选', '10', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('12', '男士奢品', '11', '2', '\0');
INSERT INTO `categorieinfo` VALUES ('13', '手机', '0', '0', '\0');
INSERT INTO `categorieinfo` VALUES ('14', '热门品牌', '13', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('15', '小米', '14', '2', '\0');
INSERT INTO `categorieinfo` VALUES ('16', '运营商', '13', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('17', '选号卡', '16', '2', '\0');
INSERT INTO `categorieinfo` VALUES ('18', '数码', '0', '0', '\0');
INSERT INTO `categorieinfo` VALUES ('19', '摄影摄像', '18', '1', '\0');
INSERT INTO `categorieinfo` VALUES ('20', '单反相机', '19', '2', '\0');

-- ----------------------------
-- Table structure for cateparaminfo
-- ----------------------------
DROP TABLE IF EXISTS `cateparaminfo`;
CREATE TABLE `cateparaminfo` (
  `attr_ID` int(11) NOT NULL AUTO_INCREMENT,
  `attr_Name` varchar(50) DEFAULT NULL,
  `cat_ID` int(11) DEFAULT NULL,
  `attr_Sel` varchar(4) DEFAULT NULL,
  `attr_Write` varchar(6) DEFAULT NULL,
  `attr_Vals` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`attr_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of cateparaminfo
-- ----------------------------
INSERT INTO `cateparaminfo` VALUES ('2', '尺寸', '3', 'only', null, '175 170');
INSERT INTO `cateparaminfo` VALUES ('3', '颜色', '3', 'many', null, '白色 褐色 黄色');
INSERT INTO `cateparaminfo` VALUES ('5', '款式', '3', 'many', null, '土豪金 黄毒');

-- ----------------------------
-- Table structure for goodslistinfo
-- ----------------------------
DROP TABLE IF EXISTS `goodslistinfo`;
CREATE TABLE `goodslistinfo` (
  `goods_ID` int(11) NOT NULL AUTO_INCREMENT,
  `goods_Name` varchar(50) DEFAULT NULL,
  `goods_Price` decimal(10,0) DEFAULT NULL,
  `goods_Number` int(10) DEFAULT NULL,
  `goods_Weight` int(10) DEFAULT NULL,
  `goods_State` int(10) DEFAULT NULL,
  `add_Time` datetime DEFAULT NULL,
  `upd_Time` datetime DEFAULT NULL,
  `hot_Number` int(11) DEFAULT NULL,
  `is_Promote` bit(1) DEFAULT NULL,
  `goods_Cat` varchar(10) DEFAULT NULL,
  `goods_Introduce` varchar(100) DEFAULT NULL,
  `goods_Attrs` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`goods_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of goodslistinfo
-- ----------------------------
INSERT INTO `goodslistinfo` VALUES ('2', '男裤', '0', '0', '0', null, '2020-11-08 10:28:31', '2020-11-08 10:28:31', '0', '\0', '1,2,3', '<p>男裤</p>', '3,5,2');

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
-- Table structure for logisticsprogressinfo
-- ----------------------------
DROP TABLE IF EXISTS `logisticsprogressinfo`;
CREATE TABLE `logisticsprogressinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `time` datetime DEFAULT NULL,
  `ftime` datetime DEFAULT NULL,
  `context` varchar(50) DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,
  `order_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of logisticsprogressinfo
-- ----------------------------
INSERT INTO `logisticsprogressinfo` VALUES ('1', '2020-11-08 21:43:38', '2020-11-08 21:43:46', '已签收，使用顺丰快递，欢迎下次使用', '北京昌平天通苑', '231');
INSERT INTO `logisticsprogressinfo` VALUES ('2', '2020-11-07 21:44:50', '2020-11-07 21:44:55', '快递来到北京', '北京顺义区', '231');

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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of menuinfo
-- ----------------------------
INSERT INTO `menuinfo` VALUES ('1', '-', '系统管理', '0', '0', '0', 'el-icon-setting', '系统管理根节点', '\0', '2020-10-22 17:53:34', null, null, '3', '超级管理员', '2020-11-10 10:25:19');
INSERT INTO `menuinfo` VALUES ('3', '/users', '用户管理', '1', '0', '0', 'el-icon-menu', '用户管理', '\0', '2020-10-22 18:13:55', null, null, '3', '超级管理员', '2020-10-28 10:17:25');
INSERT INTO `menuinfo` VALUES ('4', '/roles', '角色管理', '1', '0', '1', 'el-icon-menu', '角色管理', '\0', '2020-10-23 09:28:06', null, null, null, null, '2020-10-23 09:28:06');
INSERT INTO `menuinfo` VALUES ('6', '/menus', '菜单权限管理', '1', '0', '0', 'el-icon-menu', '菜单权限管理', '\0', '2020-10-23 09:33:49', null, null, null, null, '2020-10-23 09:33:49');
INSERT INTO `menuinfo` VALUES ('9', '/users/adduser', '添加用户', '3', '0', '0', 'el-icon-add', '添加用户按钮', '\0', '2020-10-26 11:02:18', null, null, null, null, '2020-10-26 11:02:18');
INSERT INTO `menuinfo` VALUES ('10', '/users/updateuser', '更新用户', '3', '0', '1', 'el-icon-edit', '更新用户信息按钮', '\0', '2020-10-26 11:33:00', null, null, null, null, '2020-10-26 11:33:00');
INSERT INTO `menuinfo` VALUES ('11', '/users/delete', '删除用户', '3', '0', '3', 'el-icon-delete', '删除用户按钮', '\0', '2020-10-26 11:43:41', null, null, null, null, '2020-10-26 11:43:41');
INSERT INTO `menuinfo` VALUES ('12', '-', '商品管理', '0', '0', '1', 'el-icon-goods', '商品管理根节点', '\0', '2020-10-27 22:30:28', null, null, '3', '超级管理员', '2020-11-09 09:57:07');
INSERT INTO `menuinfo` VALUES ('13', '/categories', '商品分类', '12', '0', '0', 'el-icon-menu', '商品分类', '\0', '2020-10-27 22:31:40', null, null, null, null, '2020-10-27 22:31:40');
INSERT INTO `menuinfo` VALUES ('14', '/cateparams', '商品参数', '12', '0', '1', 'el-icon-menu', '商品参数', '\0', '2020-10-30 11:13:12', '3', '超级管理员', '3', '超级管理员', '2020-11-01 10:05:24');
INSERT INTO `menuinfo` VALUES ('15', '/goods/addcate', '添加分类', '13', '0', '0', 'el-icon-add', '添加商品分类', '\0', '2020-10-30 12:34:31', '3', '超级管理员', null, null, '2020-10-30 12:34:31');
INSERT INTO `menuinfo` VALUES ('16', '/goodslists', '商品列表', '12', '0', '2', 'el-icon-menu', '商品列表', '\0', '2020-11-01 10:04:53', '3', '超级管理员', '3', '超级管理员', '2020-11-01 20:24:57');
INSERT INTO `menuinfo` VALUES ('17', '-', '订单管理', '0', '0', '2', 'el-icon-tickets', '订单管理', '\0', '2020-11-08 15:37:01', '3', '超级管理员', '3', '超级管理员', '2020-11-10 10:27:14');
INSERT INTO `menuinfo` VALUES ('18', '/orders', '订单列表', '17', '0', '0', 'el-icon-menu', '订单列表', '\0', '2020-11-08 15:38:00', '3', '超级管理员', null, null, '2020-11-08 15:38:00');
INSERT INTO `menuinfo` VALUES ('19', '-', '数据统计', '0', '0', '3', 'el-icon-view', '数据统计', '\0', '2020-11-09 09:45:33', '3', '超级管理员', '3', '超级管理员', '2020-11-10 10:27:51');
INSERT INTO `menuinfo` VALUES ('20', '/reports', '数据报表', '19', '0', '0', 'el-icon-menu', '数据报表', '\0', '2020-11-09 09:46:10', '3', '超级管理员', null, null, '2020-11-09 09:46:10');

-- ----------------------------
-- Table structure for orderinfo
-- ----------------------------
DROP TABLE IF EXISTS `orderinfo`;
CREATE TABLE `orderinfo` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `order_number` varchar(20) DEFAULT NULL,
  `order_price` decimal(10,0) DEFAULT NULL,
  `order_pay` int(1) DEFAULT NULL,
  `Is_send` int(1) DEFAULT NULL,
  `trade_no` int(10) DEFAULT NULL,
  `order_fapiao_title` varchar(20) DEFAULT NULL,
  `order_fapiao_company` varchar(50) DEFAULT NULL,
  `order_fapiao_content` varchar(50) DEFAULT NULL,
  `consignee_addr` varchar(50) DEFAULT NULL,
  `pay_status` int(1) DEFAULT NULL,
  `creat_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  PRIMARY KEY (`order_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of orderinfo
-- ----------------------------
INSERT INTO `orderinfo` VALUES ('1', null, '231', null, null, null, null, null, null, null, null, null, '2020-11-08 16:57:36', null);

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of roleinfo
-- ----------------------------
INSERT INTO `roleinfo` VALUES ('1', '超级管理员', '\0', '2020-10-19 15:58:51', null, '超级管理员', null, '超级管理员', '2020-10-20 15:58:55', '有所有的权限');
INSERT INTO `roleinfo` VALUES ('2', '查看角色', '\0', '2020-10-21 10:46:52', null, '超级管理员', '3', '超级管理员', '2020-10-28 10:09:57', '只允许查看');
INSERT INTO `roleinfo` VALUES ('3', '普通管理员', '\0', '2020-10-21 11:04:03', null, null, '3', '超级管理员', '2020-10-28 10:10:12', '可以添加编辑删除查看导出功能');

-- ----------------------------
-- Table structure for rolemenuinfo
-- ----------------------------
DROP TABLE IF EXISTS `rolemenuinfo`;
CREATE TABLE `rolemenuinfo` (
  `rmID` int(11) NOT NULL AUTO_INCREMENT,
  `rID` int(11) DEFAULT NULL,
  `mID` int(11) DEFAULT NULL,
  PRIMARY KEY (`rmID`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of rolemenuinfo
-- ----------------------------
INSERT INTO `rolemenuinfo` VALUES ('54', '1', '3');
INSERT INTO `rolemenuinfo` VALUES ('55', '1', '9');
INSERT INTO `rolemenuinfo` VALUES ('56', '1', '10');
INSERT INTO `rolemenuinfo` VALUES ('57', '1', '11');
INSERT INTO `rolemenuinfo` VALUES ('58', '1', '13');
INSERT INTO `rolemenuinfo` VALUES ('59', '1', '15');

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
INSERT INTO `sysuserinfo` VALUES ('3', 'admin', 'e10adc3949ba59abbe56e057f20f883e', '\0', '超级管理员', '1', '北京海淀区西三旗', '907606163@qq.com', '15231451752', '2020-10-14 18:21:48', '2020-10-21 21:15:32', '2020-11-10 21:00:45', '0');
INSERT INTO `sysuserinfo` VALUES ('7', 'test', '47EC2DD791E31E2EF2076CAF64ED9B3D', '\0', '测试账号', '2', '北京海淀区西三旗街道', '907606163@qq.com', '15617421451', '2020-10-15 17:05:29', '2020-10-28 10:42:11', '2020-10-15 17:05:29', '0');

-- ----------------------------
-- Table structure for userroleinfo
-- ----------------------------
DROP TABLE IF EXISTS `userroleinfo`;
CREATE TABLE `userroleinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `uID` int(11) DEFAULT NULL,
  `rID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of userroleinfo
-- ----------------------------
INSERT INTO `userroleinfo` VALUES ('8', '3', '1');
INSERT INTO `userroleinfo` VALUES ('9', '7', '1');
INSERT INTO `userroleinfo` VALUES ('10', '7', '2');
INSERT INTO `userroleinfo` VALUES ('11', '7', '3');
