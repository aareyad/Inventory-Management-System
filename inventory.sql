-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 27, 2018 at 01:13 PM
-- Server version: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `inventory`
--

-- --------------------------------------------------------

--
-- Table structure for table `dealer_info`
--

CREATE TABLE IF NOT EXISTS `dealer_info` (
`id` int(11) NOT NULL,
  `dealer_name` varchar(50) NOT NULL,
  `company_name` varchar(50) NOT NULL,
  `contact` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `city` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `dealer_info`
--

INSERT INTO `dealer_info` (`id`, `dealer_name`, `company_name`, `contact`, `address`, `city`) VALUES
(1, 'Hasan', 'Hasan Co & Ltd', '0123654', 'dujdhde', 'feni'),
(3, 'Noman', 'ered', 'dfdfde', 'ercc', 'feref'),
(4, '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `order_item`
--

CREATE TABLE IF NOT EXISTS `order_item` (
`id` int(11) NOT NULL,
  `order_id` varchar(50) NOT NULL,
  `product` varchar(50) NOT NULL,
  `price` varchar(50) NOT NULL,
  `qty` varchar(50) NOT NULL,
  `total` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `order_item`
--

INSERT INTO `order_item` (`id`, `order_id`, `product`, `price`, `qty`, `total`) VALUES
(1, '3', 'Rice', '10', '2', '20'),
(2, '3', 'Rice', '10', '3', '30'),
(3, '3', 'banana', '2', '2', '4'),
(4, '4', 'Rice', '10', '2', '20');

-- --------------------------------------------------------

--
-- Table structure for table `order_user`
--

CREATE TABLE IF NOT EXISTS `order_user` (
`id` int(11) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `billtype` varchar(50) NOT NULL,
  `purchase_date` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `order_user`
--

INSERT INTO `order_user` (`id`, `firstname`, `lastname`, `billtype`, `purchase_date`) VALUES
(2, 'Ridoy', 'Ridoy', 'Cash', '28/02/2018'),
(3, 'Ridoy', 'Ridoy', 'Cash', '28/02/2018'),
(4, 'erdsa', 'erdsa', 'Debit', '20/02/2018');

-- --------------------------------------------------------

--
-- Table structure for table `product_name`
--

CREATE TABLE IF NOT EXISTS `product_name` (
`id` int(11) NOT NULL,
  `product_name` varchar(50) NOT NULL,
  `units` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product_name`
--

INSERT INTO `product_name` (`id`, `product_name`, `units`) VALUES
(1, 'Rice', 'gm'),
(2, 'banana', 'gm');

-- --------------------------------------------------------

--
-- Table structure for table `purchase_master`
--

CREATE TABLE IF NOT EXISTS `purchase_master` (
`id` int(11) NOT NULL,
  `product_name` varchar(50) NOT NULL,
  `product_qty` varchar(50) NOT NULL,
  `product_unit` varchar(50) NOT NULL,
  `product_price` varchar(50) NOT NULL,
  `product_total` varchar(50) NOT NULL,
  `purchase_date` varchar(50) NOT NULL,
  `purchase_party_name` varchar(50) NOT NULL,
  `purchase_type` varchar(50) NOT NULL,
  `expiry_date` varchar(50) NOT NULL,
  `profit` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `purchase_master`
--

INSERT INTO `purchase_master` (`id`, `product_name`, `product_qty`, `product_unit`, `product_price`, `product_total`, `purchase_date`, `purchase_party_name`, `purchase_type`, `expiry_date`, `profit`) VALUES
(3, 'Rice', '5', 'gm', '10', '50', '13-02-2018', 'Noman', 'Cash', '06-04-2018', '20'),
(4, 'Rice', '5', 'gm', '10', '50', '13-02-2018', 'Noman', 'Cash', '06-04-2018', '20'),
(5, 'banana', '8', 'gm', '2', '16', '11-12-2017', 'Hasan', 'Cash', '03-03-2018', '20'),
(6, 'banana', '2', 'gm', '3', '6', '11-12-2017', 'Hasan', 'Cash', '03-03-2018', '20');

-- --------------------------------------------------------

--
-- Table structure for table `registration`
--

CREATE TABLE IF NOT EXISTS `registration` (
`id` int(11) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `contact` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `registration`
--

INSERT INTO `registration` (`id`, `firstname`, `lastname`, `username`, `password`, `email`, `contact`) VALUES
(1, 'Ali', 'Akbar', 'akbar.reyad', '12345', 'aliakbar.reyad@gmail.com', '01814812929'),
(4, 'Coyon ', 'Ahmad', 'coyon', '12345', 'lajkfjk', 'erejdfkd'),
(7, 'a', 'b', 'b', 'a', 'a@hj.com', '5568952'),
(8, 'Noman', 'Abdullah', 'noman', '123', 'adjfkdj', '0155');

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE IF NOT EXISTS `stock` (
`id` int(11) NOT NULL,
  `product_name` varchar(50) NOT NULL,
  `product_qty` int(11) NOT NULL,
  `product_unit` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`id`, `product_name`, `product_qty`, `product_unit`) VALUES
(2, 'Rice', 10, 'gm'),
(3, 'banana', 10, 'gm');

-- --------------------------------------------------------

--
-- Table structure for table `units`
--

CREATE TABLE IF NOT EXISTS `units` (
`id` int(11) NOT NULL,
  `unit` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`id`, `unit`) VALUES
(1, 'gm'),
(3, 'kg');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dealer_info`
--
ALTER TABLE `dealer_info`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `order_item`
--
ALTER TABLE `order_item`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `order_user`
--
ALTER TABLE `order_user`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `product_name`
--
ALTER TABLE `product_name`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `purchase_master`
--
ALTER TABLE `purchase_master`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `registration`
--
ALTER TABLE `registration`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `units`
--
ALTER TABLE `units`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dealer_info`
--
ALTER TABLE `dealer_info`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `order_item`
--
ALTER TABLE `order_item`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `order_user`
--
ALTER TABLE `order_user`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `product_name`
--
ALTER TABLE `product_name`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `purchase_master`
--
ALTER TABLE `purchase_master`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `registration`
--
ALTER TABLE `registration`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `stock`
--
ALTER TABLE `stock`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `units`
--
ALTER TABLE `units`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
