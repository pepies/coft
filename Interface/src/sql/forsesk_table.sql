-- phpMyAdmin SQL Dump
-- version 4.6.6deb4
-- https://www.phpmyadmin.net/
--
-- Hostiteľ: localhost:3306
-- Čas generovania: St 11.Okt 2017, 21:20
-- Verzia serveru: 5.7.19-0ubuntu0.17.04.1
-- Verzia PHP: 5.6.11-1ubuntu3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáza: `forsesk`
--

-- --------------------------------------------------------

--
-- Štruktúra tabuľky pre tabuľku `noszel`
--

CREATE TABLE `noszel` (
  `sql_id` int(10) UNSIGNED NOT NULL,
  `PV` varchar(63) COLLATE utf8_bin NOT NULL,
  `partner` varchar(63) COLLATE utf8_bin NOT NULL,
  `partner_id` varchar(15) COLLATE utf8_bin NOT NULL,
  `norma` varchar(7) COLLATE utf8_bin NOT NULL,
  `material_nazov` varchar(63) COLLATE utf8_bin NOT NULL,
  `material_cislo` int(7) NOT NULL,
  `spz` varchar(9) COLLATE utf8_bin NOT NULL,
  `vodic` varchar(40) COLLATE utf8_bin NOT NULL,
  `vazil` varchar(40) COLLATE utf8_bin NOT NULL,
  `poznamka` varchar(126) COLLATE utf8_bin NOT NULL,
  `id_paired_brutto` varchar(15) CHARACTER SET utf8 DEFAULT NULL COMMENT 'FK',
  `id_paired_tara` varchar(15) CHARACTER SET utf8 DEFAULT NULL COMMENT 'FK',
  `brutto_time` datetime NOT NULL,
  `brutto_weight` varchar(7) COLLATE utf8_bin NOT NULL,
  `tara_time` datetime NOT NULL,
  `tara_weight` varchar(7) COLLATE utf8_bin NOT NULL,
  `netto_time` datetime NOT NULL,
  `netto_weight` varchar(7) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Kľúče pre exportované tabuľky
--

--
-- Indexy pre tabuľku `noszel`
--
ALTER TABLE `noszel`
  ADD PRIMARY KEY (`sql_id`),
  ADD KEY `zodpovedá` (`id_paired_brutto`),
  ADD KEY `zodpoveda1` (`id_paired_tara`);

--
-- AUTO_INCREMENT pre exportované tabuľky
--

--
-- AUTO_INCREMENT pre tabuľku `noszel`
--
ALTER TABLE `noszel`
  MODIFY `sql_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- Obmedzenie pre exportované tabuľky
--

--
-- Obmedzenie pre tabuľku `noszel`
--
ALTER TABLE `noszel`
  ADD CONSTRAINT `zodpoveda1` FOREIGN KEY (`id_paired_tara`) REFERENCES `strediska`.`noszel` (`id`),
  ADD CONSTRAINT `zodpovedá` FOREIGN KEY (`id_paired_brutto`) REFERENCES `strediska`.`noszel` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
