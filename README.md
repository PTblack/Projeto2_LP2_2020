# Projeto2_LP2_2020

Game Rules for reference:

https://www.fgbradleys.com/rules/Connect%20Four.pdf

---

### Classes

`class` **Program**

_Recieves input and controls flow of program (Calls **UI** and **BoardManager** methods), has the GameLoop._

- Has instances of **UI** and **BoardManager** classes

`class` **BoardManager**

_Gets pieces to place in board and checks for main game events (Victory/Tie)_

- Has instance of **BoardSearcher** and **BoardFiller**

- Façade for **BoardFiller** and **BoardSearcher** (to be used in **Program**)

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

`struct` **Board** (deve ser uma struct?)

_Saves board dimensions and status of board spaces (Empty, Cross, Circle)_

- The board itself is a bi-dimensional array that holds chars with either "E" (empty), "Y" (yellow) or "R" (red)

---

## Explicação/Atualização

**O tabuleiro é um array de chars**

- Dimensões predefinidas com o tamanho standard do 4 em linha (Connect 4), definido no construtor da classe **Board**
- cada coordenada do array pode ser ocupada com um "E" de 'empty', "Y" de 'yellow' e "R" de 'red' (as cores das peças dos jogadores).
- Para a verificação de sequências, o programa compara o char na posição a ser avaliada com o char da peça mais recente (motivo da procura de sequencias)

**A Classe BoardManager é uma Façade para as classes BoardSearcher e BoardFiller**

- Classe **BoardSearcher** procura por sequencias de peças com a peça acabada de por.
- Classe **BoardFiller** verifica e - se possível - acrescenta a peça proposta ao tabuleiro.
- Classe **BoardManager** é a classe contactada pelo MainLoop no **Program** e é ela que por sua vez chama as classes **BoardSearcher** e **BoardFiller**.

---

## Divisão de Tarefas *(mais ou menos)*

Pedro Fernandes:
BoardManager, BoardFiller, BoardSearcher

Diogo Henriques:
Threads (?)

Dias:
Board, UI (?)