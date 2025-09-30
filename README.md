# Mastermind - Jeu Console en C#

![Mastermind](https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Mastermind_board_game.png/320px-Mastermind_board_game.png)

## Description

Mastermind est un jeu de réflexion classique dans lequel le joueur doit deviner une combinaison secrète de couleurs (ou chiffres) en un nombre limité d'essais. Ce projet est une implémentation en console de ce jeu, développée en C# dans le cadre d'un projet pour l'ETML.

Le but est de deviner la bonne combinaison en recevant à chaque tentative des indices sur la justesse des éléments proposés.

---

## Fonctionnalités

- Génération aléatoire d'une combinaison secrète.
- Interface console simple et intuitive.
- Indications données après chaque tentative :
  - Nombre de bonnes couleurs bien placées.
  - Nombre de bonnes couleurs mal placées.
- Limite du nombre de tentatives.
- Option pour rejouer à la fin d'une partie.

---

## Technologies

- C# (Console Application)
- .NET (version ciblée selon ton projet, ex: .NET 6)

---

## Installation

1. Cloner ce dépôt :
    ```bash
    git clone https://github.com/ton-utilisateur/ton-projet-mastermind.git
    ```
2. Ouvrir le projet dans un IDE compatible C# (Visual Studio, Visual Studio Code, Rider, etc.).
3. Compiler et exécuter le projet.

---

## Utilisation

- Lance l'application.
- Suis les instructions à l'écran pour faire une proposition.
- Tu recevras des indices pour t'aider à deviner la bonne combinaison.
- Essaie de trouver la combinaison avant la fin des essais.

---

## Exemple de partie

Bienvenue dans Secret Code !
Devinez la combinaison secrète de 4 chiffres entre 1 et 6.
Vous avez 10 essais.

Essai 1 : 1234
Indices : 2 bons chiffres bien placés, 1 bon chiffre mal placé.

Essai 2 : 1256
Indices : 3 bons chiffres bien placés, 0 bon chiffre mal placé.

ou 

Essai 1 : 1234
Indices : 🟥 🟩 🟨 🟥

Essai 2 : 1256
Indices : 🟩 🟩 🟥 🟥

...

Félicitations, vous avez gagné !

yaml
Copier le code

---

## Auteur

**Kyllian.G** - Étudiant à l'ETML

---