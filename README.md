# Projeto2 - LP2 (2020)

## Autoria

* Diogo Henriques, nº 21802132
* João Dias, nº 21803573
* Pedro Fernandes, nº 21803791

### Distribuição de Tarefas

*Todos os membros do grupo estiveram envolvidos no projeto desde o seu início 
até à sua entrega, tendo todos tido parte no desenvolvimento da maioria das 
partes do mesmo*

1. O que cada membro fez
    * Diogo Henriques:

            Threads (?)

    * João Dias:

            Board, UI (?)

    * Pedro Fernandes:

            BoardManager, BoardFiller, BoardSearcher
            
[Repositório Git](https://github.com/PTblack/Projeto1_LP2_2020)

---

## Arquitetura da Solução

### Descrição da Solução

patterns usados: 
- doublebuffer - Usamos o double buffer pattern que faz com que o buffer seja atualizado incrementalmente, desta forma a classe `DoubleBuffer`tem dois buffers um buffer atual e outro que esta a desenhar a próxima frame, quando esta estiver pronta ambos os bufferstrocam de posição.
- facade - Esconde toda a complexidade de boardManager através das classes BoardFiller e BoardSearcher
- component - Permite game object obter os seus compontentes interagindo com uma classe component, que interage com várias classes component
- observer - Regista uma série de inputs e notifica...
- principle of least knowldge -...

#### Board
_Recieves input and controls flow of program (Calls **UI** and **BoardManager** 
methods), has the GameLoop._

- Has instances of **UI** and **BoardManager** classes

#### BoardComponent

_Gets pieces to place in board and checks for main game events (Victory/Tie)_

- Has instance of **BoardSearcher** and **BoardFiller**

- Façade for **BoardFiller** and **BoardSearcher** (to be used in **Program**)

#### BoardFiller

_Places pieces in board_

- Has instance of **Board**

#### BoardManager

_Searches board for sequence_

- Has instance of **Board**

#### BoardSearcher

_Prints information and shows Menus_

#### ExceptionManager

#### GameStage

#### Quitter

#### UI

#### UIComponent

_Handles exceptions_

---

### Enums

#### Color

#### Error Codes

---

## Explicação/Atualização

**O tabuleiro é um array de chars**

- Dimensões predefinidas com o tamanho standard do 4 em linha (Connect 4), 
  definido no construtor da classe **Board**
- cada coordenada do array pode ser ocupada com um "E" de 'empty', "Y" de 
  'yellow' e "R" de 'red' (as cores das peças dos jogadores).
- Para a verificação de sequências, o programa compara o char na posição a ser 
  avaliada com o char da peça mais recente (motivo da procura de sequencias)

**A Classe BoardManager é uma Façade para as classes BoardSearcher e BoardFiller**

- Classe **BoardSearcher** procura por sequencias de peças com a peça acabada 
  de por.
- Classe **BoardFiller** verifica e - se possível - acrescenta a peça proposta 
  ao tabuleiro.
- Classe **BoardManager** é a classe contactada pelo MainLoop no **Program** e é 
  ela que por sua vez chama as classes **BoardSearcher** e **BoardFiller**.

### TEXTO EXTRA

board é um array bidimensional de chars

program chama boardmanager e passa-lhe a coluna escolhida pelo jogador, 
boardmanager por sua vez manda a coordenada para a boardfiller.

boardfiller recebe a coluna em que a peça será posta e avalia se é possível, 
pondo-a no topo dessa coluna ou avisando que a jogada é invalida. Caso a
jogada seja valida, devolve a row em que a peça ficou, pondo-a no board em 
si (alterando o char para a peça do jogador).

no program, tendo agora a coluna e a row da peça, manda-se essas coordenadas
para a boardmanager, que as dá à boardsearcher.

A boardsearcher, com as coordenadas da peça posta, irá procurar sequencias
com peças do mesmo tipo, retornando booleans à gamemanager, que por sua vez 
irá retornar um bool à program a indicar se houve uma vitoria.

caso o program seja informado de uma vitoria, este chama o UI para anunciar 
o vencedor, passando como argumento o jogador atual.

### Diagrama UML

![Diagrama UML](/images/uml.png) 

---

### Program Controls

  **TBD:** AINDA POR PREENCHER \

---

## Referências

* Regras de jogo usadas para referência 
  https://www.fgbradleys.com/rules/Connect%20Four.pdf

* Visualização da proposta do jogo Connect Four do livro de matéria da cadeira
  _"The C# Players Guide 3rd Edition"_ para a classe `Board` do nosso projeto
  https://starboundsoftware.com/books/c-sharp/try-it-out/connect-four

* Visualização de como adaptar a parte de inputs da CoreGameEngine do professor
  Nuno Fachada para o projeto através do 2º projeto de LP2 2019/2020 dos alunos
  João Bernardo e Miguel Fernandez
  https://github.com/JBernardoRebelo/Projeto2_LPII_Fernandez_Rebelo

* Uso das classes relacionadas aos inputs do repositório Core Game Engine 
  referenciada pelo professor Nuno Fachada
  https://github.com/fakenmc/CoreGameEngine

* Exercícios 1, 2, 3 e 4 da Aula 11 de LP2 (2020) como base para a Game Engine
  https://github.com/VideojogosLusofona/lp2_2020_aulas/tree/main/Aula11
