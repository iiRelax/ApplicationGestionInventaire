# Logiciel de Gestion 

## Présentation

Ce logiciel permet la gestion complète de l'inventaire matériel, des factures et des sites favoris de l'entreprise.

## Fonctionnalités

### Gestion d'Inventaire

- Ajout, modification et suppression d'éléments d'inventaire
- Catégorisation par type et marque
- Suivi des entrées et sorties de matériel
- Recherche et filtrage avancés

### Gestion des Factures

- Création et gestion des factures clients
- Suivi des prestations effectuées
- Recherche et filtrage des factures

### Gestion des Sites Favoris

- Sauvegarde et organisation des sites web fréquemment utilisés

### Visualisation des Données

- Graphiques et tableaux de bord pour le suivi des stocks
- Statistiques sur les ventes et prestations

## Architecture Technique

### Technologies Utilisées

- **Langage** : C#
- **Framework** : .NET 6.0 Windows Forms
- **Base de données** : SQLite (fichiers .db)
- **Visualisation** : WinForms.DataVisualization

### Structure du Projet (MVC)

- **Modèle** : Classes représentant les entités métier (InventaireLigne, FactureLigne, etc.)
- **Vue** : Interface utilisateur Windows Forms
- **Contrôleur** : Gestion de la logique métier et des interactions

## Installation et Utilisation

### Prérequis

- Windows 10/11
- .NET 6.0 ou supérieur
- Visual Studio 2022 (pour le développement)

### Démarrage

1. Ouvrir la solution dans Visual Studio 2022
2. Compiler et exécuter l'application
3. À la première utilisation, créer une nouvelle base de données via l'interface

### Gestion des Données

- Les données sont stockées dans un fichier SQLite (.db)
- L'application permet de créer, ouvrir et sauvegarder ces fichiers
- Aucun serveur de base de données externe n'est nécessaire

## Développement

Ce projet suit les bonnes pratiques de développement C# et utilise une architecture MVC pour une maintenance facilitée.
