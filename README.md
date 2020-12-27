# Projeto2_LP2_2020

Game Rules:

https://www.fgbradleys.com/rules/Connect%20Four.pdf

---

### Classes

`class` **Program**

_Recieves input and controls flow of program (Calls **UI** and **GameManager** methods)_

- Has instances of **UI** and **BoardManager** classes

`class` **BoardManager**

_Gets pieces to place in board and checks for main game events (Victory/Tie)_

- Has instance of **BoardSearcher**, **BoardFiller** and Board

- Façade for **BoardFiller** and **BoardSearcher**

`class` **BoardFiller**

_Places pieces in board_

- Has instance of **Board**

`class` **BoardSearcher**

_Searches board for sequence_

- Has instance of **Board**

`class` **UI**

_Prints information and shows Menus_

`class` `static` **ExceptionManager** 

_Handles exceptions_

---

### Structs

`struct` **Board**

_Saves board dimensions and status of board spaces (Empty, Cross, Circle)_
	
- The board itself is a bi-dimensional array that holds chars with either "E" (empty), "O" (circle) or "X" (cross)

`struct` **Piece**

_Saves piece information (position and type)_

- PieceType is a char with either "O" (circle) or "X" (cross)