#database creation

create database grocery_management;
use grocery_management;


#table creation

CREATE TABLE `user` (
   `User_ID` int NOT NULL AUTO_INCREMENT,
   `First_Name` varchar(50) NOT NULL,
   `Last_name` varchar(50) DEFAULT NULL,
   `Email` varchar(100) NOT NULL,
   `Password` varchar(50) NOT NULL,
   `Address` varchar(250) NOT NULL,
   `State` varchar(25) NOT NULL,
   `Country` varchar(25) NOT NULL,
   PRIMARY KEY (`User_ID`),
   UNIQUE KEY `Email` (`Email`)
 );


CREATE TABLE `category` (
   `Cat_id` int NOT NULL AUTO_INCREMENT,
   `Cate_name` varchar(50) NOT NULL,
   `Cate_desc` varchar(250) DEFAULT NULL,
   PRIMARY KEY (`Cat_id`)
 );


CREATE TABLE `products` (
   `Prod_id` int NOT NULL AUTO_INCREMENT,
   `Prod_cat_id` int NOT NULL,
   `Prod_name` varchar(50) NOT NULL,
   `Prod_price` float NOT NULL,
   `Prod_picture` varchar(2000) DEFAULT NULL,
   `Prod_desc` varchar(250) DEFAULT NULL,
   `Prod_units` int NOT NULL,
   PRIMARY KEY (`Prod_id`),
   KEY `Prod_cat_id` (`Prod_cat_id`),
   CONSTRAINT `products_ibfk_1` FOREIGN KEY (`Prod_cat_id`) REFERENCES `category` (`Cat_id`),
   CONSTRAINT `products_chk_1` CHECK ((`Prod_price` > 0)),
   CONSTRAINT `products_chk_2` CHECK ((`Prod_units` >= 0))
 );


CREATE TABLE `cart` (
   `Cart_id` int NOT NULL AUTO_INCREMENT,
   `Cart_user_id` int NOT NULL,
   `Cart_prod_id` int NOT NULL,
   `Quan_in_cart` int NOT NULL,
   `Total_amount` float NOT NULL,
   PRIMARY KEY (`Cart_id`),
   KEY `Cart_user_id` (`Cart_user_id`),
   KEY `Cart_prod_id` (`Cart_prod_id`),
   CONSTRAINT `cart_ibfk_1` FOREIGN KEY (`Cart_user_id`) REFERENCES `user` (`User_ID`),
   CONSTRAINT `cart_ibfk_2` FOREIGN KEY (`Cart_prod_id`) REFERENCES `products` (`Prod_id`),
   CONSTRAINT `cart_chk_1` CHECK ((`Quan_in_cart` >= 0)),
   CONSTRAINT `cart_chk_2` CHECK ((`Total_amount` >= 0))
 );


CREATE TABLE `orders` (
   `Order_id` int NOT NULL AUTO_INCREMENT,
   `Order_user_id` int NOT NULL,
   `Order_date` date DEFAULT NULL,
   `Pay_amount` float DEFAULT NULL,
   `Pay_method` varchar(50) NOT NULL,
   PRIMARY KEY (`Order_id`),
   KEY `Order_user_id` (`Order_user_id`),
   CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`Order_user_id`) REFERENCES `user` (`User_ID`)
 );


CREATE TABLE `order_item` (
   `Item_prod_id` int NOT NULL,
   `Item_order_id` int NOT NULL,
   `Item_quan` int NOT NULL,
   `Item_price` int NOT NULL,
   PRIMARY KEY (`Item_prod_id`,`Item_order_id`),
   KEY `Item_order_id` (`Item_order_id`),
   CONSTRAINT `order_item_ibfk_1` FOREIGN KEY (`Item_prod_id`) REFERENCES `products` (`Prod_id`),
   CONSTRAINT `order_item_ibfk_2` FOREIGN KEY (`Item_order_id`) REFERENCES `orders` (`Order_id`),
   CONSTRAINT `order_item_chk_1` CHECK ((`Item_prod_id` > 0)),
   CONSTRAINT `order_item_chk_2` CHECK ((`Item_order_id` > 0)),
   CONSTRAINT `order_item_chk_3` CHECK ((`Item_quan` > 0)),
   CONSTRAINT `order_item_chk_4` CHECK ((`Item_price` > 0))
 );


#Auto increment

alter table products auto_increment = 1;
alter table user auto_increment = 100;


#insertion queries for category table

insert into category values(1, 'Fruits',  'Buy farm fresh fruits at the best prices here.');
insert into category values(2, 'Vegetables', 'Buy farm fresh vegetables at the best prices here');
insert into category values(3, 'Beverages', 'Find various types of Beverages in India from this beverage world.');
insert into category values(4, 'Diary', 'Buy various types of dairy products at great prices here.');
insert into category values(5, 'Cleaning Supplies', 'Buy from wide variety of cleaning supplies at best available prices here.');
insert into category values(6, 'Personal Care', 'Find all types of Personal Care products here.');
insert into category values(7, 'Paper Goods', 'Choose from wide variety of disposable paper goods at best available prices here.');
insert into category values(8, 'Dry Goods', 'Find a variety of foodgrains, spices and snacks here.');
insert into category values(9, 'Stationery', 'Find a huge selection of regular school stationery items');