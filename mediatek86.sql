-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : jeu. 28 mai 2026 à 07:22
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86`
--
CREATE DATABASE IF NOT EXISTS `mediatek86` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `mediatek86`;

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES
(1, '2025-09-08 08:00:00', '2025-09-10 18:00:00', 1),
(1, '2026-05-31 20:21:38', '2026-06-04 20:21:38', 2),
(1, '2026-09-30 08:00:00', '2026-10-02 18:00:00', 3),
(1, '2027-02-17 08:00:00', '2027-02-18 18:00:00', 3),
(2, '2025-05-30 08:00:00', '2025-06-01 18:00:00', 3),
(2, '2026-01-13 08:00:00', '2026-01-15 18:00:00', 1),
(2, '2026-03-08 08:00:00', '2026-03-10 18:00:00', 1),
(2, '2026-05-27 17:49:47', '2026-05-27 17:49:47', 4),
(2, '2026-05-27 17:52:47', '2026-05-27 17:52:47', 2),
(2, '2027-01-14 08:00:00', '2027-01-16 18:00:00', 2),
(3, '2025-08-12 08:00:00', '2025-08-14 18:00:00', 3),
(3, '2025-10-01 08:00:00', '2025-10-03 18:00:00', 1),
(3, '2026-05-17 08:00:00', '2026-05-19 18:00:00', 3),
(3, '2026-05-20 16:12:09', '2026-05-25 16:12:09', 4),
(3, '2026-05-27 16:11:56', '2026-05-28 16:11:56', 2),
(3, '2026-06-27 08:00:00', '2026-06-29 18:00:00', 2),
(4, '2025-10-02 08:00:00', '2025-10-04 18:00:00', 3),
(4, '2025-12-20 08:00:00', '2025-12-22 18:00:00', 3),
(4, '2026-07-13 08:00:00', '2026-07-15 18:00:00', 2),
(4, '2027-02-19 08:00:00', '2027-02-21 18:00:00', 2),
(5, '2025-10-25 08:00:00', '2025-10-27 18:00:00', 2),
(5, '2025-11-04 08:00:00', '2025-11-06 18:00:00', 4),
(5, '2026-06-05 08:00:00', '2026-06-06 18:00:00', 3),
(5, '2026-06-28 08:00:00', '2026-07-31 18:00:00', 2),
(5, '2026-08-14 08:00:00', '2026-08-16 18:00:00', 1),
(6, '2025-06-26 08:00:00', '2025-06-28 18:00:00', 3),
(6, '2025-06-28 08:00:00', '2025-06-30 18:00:00', 2),
(6, '2026-03-28 08:00:00', '2026-03-30 18:00:00', 3),
(6, '2026-05-27 20:46:54', '2026-05-27 20:46:54', 3),
(6, '2027-01-07 08:00:00', '2027-01-09 18:00:00', 2),
(6, '2027-01-25 08:00:00', '2027-01-27 18:00:00', 2),
(6, '2027-04-23 08:00:00', '2027-04-25 18:00:00', 3),
(7, '2025-06-06 08:00:00', '2025-06-08 18:00:00', 2),
(7, '2025-08-12 08:00:00', '2025-08-14 18:00:00', 2),
(7, '2025-10-11 08:00:00', '2025-10-13 18:00:00', 3),
(7, '2026-05-27 20:33:46', '2026-05-28 20:33:45', 2),
(7, '2026-05-28 20:34:01', '2026-05-30 20:34:01', 4),
(7, '2026-07-21 08:00:00', '2026-07-23 18:00:00', 2),
(7, '2026-11-11 08:00:00', '2026-11-13 18:00:00', 1),
(7, '2027-03-03 08:00:00', '2027-03-05 18:00:00', 1),
(8, '2025-06-30 08:00:00', '2025-07-02 18:00:00', 2),
(8, '2025-08-25 08:00:00', '2025-08-27 18:00:00', 1),
(8, '2026-06-04 08:00:00', '2026-06-06 18:00:00', 3),
(8, '2026-11-09 08:00:00', '2026-11-11 18:00:00', 2),
(9, '2025-06-11 08:00:00', '2025-06-13 18:00:00', 3),
(9, '2025-08-17 08:00:00', '2025-08-19 18:00:00', 3),
(9, '2025-12-11 08:00:00', '2025-12-13 18:00:00', 1),
(9, '2026-02-24 08:00:00', '2026-02-26 18:00:00', 2),
(9, '2027-02-26 08:00:00', '2027-02-28 18:00:00', 1),
(10, '2025-06-17 08:00:00', '2025-06-19 18:00:00', 2),
(10, '2027-03-13 08:00:00', '2027-03-15 18:00:00', 3),
(10, '2027-04-02 08:00:00', '2027-04-04 18:00:00', 2);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `tel` varchar(15) DEFAULT NULL,
  `mail` varchar(128) DEFAULT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Patterson', 'Hunter', '04 65 81 47 82', 'non.egestas@hotmail.com', 1),
(2, 'Pittman', 'Aristotle', '03 44 61 53 20', 'in.tempus.eu@hotmail.couk', 2),
(3, 'Rasmussen', 'Sybill', '03 22 13 12 32', 'ac@outlook.org', 3),
(4, 'Mayer', 'Elvis', '07 35 43 35 24', 'egestas.sed@google.net', 1),
(5, 'Patterson', 'Hayes', '03 10 33 51 15', 'magna.et@outlook.ca', 2),
(6, 'Mcmahon', 'Xantha', '06 79 28 65 20', 'nulla@outlook.edu', 3),
(7, 'Stafford', 'Cameran', '03 53 82 00 36', 'libero.morbi@google.edu', 1),
(8, 'Wooten', 'Sonya', '07 36 12 28 91', 'curae.donec@aol.net', 2),
(9, 'Morin', 'Keane', '01 40 33 21 31', 'pede.cras.vulputate@icloud.net', 3),
(10, 'Poppins', 'Mary', '03 32 45 48 47', 'phasellus.dolor.elit@hotmail.net', 1);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) DEFAULT NULL,
  `pwd` varchar(64) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
