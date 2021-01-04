# Projeto2 - LP2 (2020)

## Autoria

* Diogo Henriques, nº 21802132
* João Dias, nº 21803573
* Pedro Fernandes, nº 21803791

### Distribuição de Tarefas

_Todos os membros do grupo estiveram envolvidos no projeto desde o seu
início até à sua entrega_

1. O que cada membro fez
    * Diogo Henriques:

            Responsável pelas classes Engine, Input, e pelo UML e o Doxyfile.
            Envolvido na junção e adaptação do Engine utilizado com o jogo
            desenvolvido, e no Markdown.

    * João Dias:

            Responsável pela junção e adaptação do Engine utilizado
            com o jogo desenvolvido.
            Envolvido também nas classes Board, BoardComponent, UI e
            ExceptionManager.

    * Pedro Fernandes:

            Responsável pelas classes Board, BoardManager, BoardFiller,
            BoardSearcher, BoardComponent, UI e ExceptionManager.
            Envolvido no Markdown.

[Repositório Git](https://github.com/PTblack/Projeto2_LP2_2020)

---

## Arquitetura da Solução

### Design Patterns utilizados

* **DoubleBuffer** - Usamos o double buffer pattern que faz com que o buffer
  seja atualizado incrementalmente, desta forma, a classe `DoubleBuffer`tem dois
  buffers, um buffer atual e outro que está a desenhar a próxima frame, quando
  esta está pronta, ambos os buffers trocam de posição.

* **Component** - Permite **GameObject** obter e controlar todos os seus
  componentes interagindo com uma única classe **Component**, que por sua vez
  interage com as várias classes que derivam da mesma.

* **Facade** - Utilizado para as classes que influenciam o tabuleiro do jogo. A
  `class` facade **BoardManager** instancia as classes **BoardFiller** e
  **BoardSearcher**, e ela, por sua vez, é instânciada pela **BoardComponent**.
  A classe **BoardManager** serve para simplificar a utilização dos métodos
  nestas duas classes, aplicando-as logo no contexto pretendido e em métodos
  simples de entender. Desta maneira diminui-se o número de classes que
  necessitam ser acedidas pela **BoardComponent** e facilita-se a leitura do
  código.
  
* **Observer** - Este pattern foi utilizado para identificar, a diversos pontos
  do programa, que inputs a aplicação deve identificar. Por exemplo, no menu,
  antes do jogo em si, o programa identifica quando o jogador carrega 'Q', 'A'
  ou 'Z', e, quando se passa para o jogo, o programa passa só a registar quando
  o utilizador carrega num número de 1 a 7.

---

### Jogo (Connect 4)

#### O tabuleiro (boardArray) é um array de Color

* **Color** é uma `enum` que tem os itens 'None', 'Yellow' e 'Red'.
  Estes servem para identificar se um espaço está vazio, ocupado por uma
  peça amarela, ou se está ocupado por uma peça vermelha.

* Dimensões do tabuleiro predefinidas com o tamanho standard do 4 em linha
  (Connect 4), 7 colunas e 6 filas, definido no construtor da `class` **Board**.
  (valores escolhidos de acordo com este
  [manual de regras original.](https://www.fgbradleys.com/rules/Connect%20Four.pdf))

#### A classe BoardManager é uma Façade para BoardSearcher e BoardFiller

* `class` **BoardSearcher** tem métodos que procuram sequências de 4 ou mais
  peças do mesmo tipo que a peça mais recente no tabuleiro, sejam na horizontal,
  vertical, diagonal de tangente positiva ou na tangente negativa. Também tem um
  método para verificar se o tabuleiro está cheio, analisando todos os espaços
  do topo board.

* `class` **BoardFiller** tem um método que verifica se a coluna escolhida tem
  um espaço livre (no topo) e um método que verifica adiciona uma peça à coluna
  escolhida.

* `class` **BoardManager** é a classe contactada pelo MainLoop no **Program** e
  é ela que por sua vez chama as classes **BoardSearcher** e **BoardFiller**
  para realizar as funções de verifiar se uma coluna tem espaço livre, adicionar
  uma peça a uma coluna, verificar se a peça colocada criou uma sequencia de
  vitoria e verificar se o tabuleiro está cheio.

### Engine

#### Rendering

* DIAS E DIOGO VOCÊS TÊM DE ESCREVER AQUI!!!!!!!!!!!!!!!!!!!

### Diagrama UML

![Diagrama UML](/images/UML.png)

---

### Fluxograma

![Fluxograma](/images/flowchart.png)

---

## Referências

* Regras de jogo usadas para referência.
  [(link)](https://www.fgbradleys.com/rules/Connect%20Four.pdf)

* Visualização da proposta do jogo Connect Four do livro de matéria da cadeira
  _"The C# Players Guide 3rd Edition"_ para a classe `Board` do nosso projeto.
  [(link)](https://starboundsoftware.com/books/c-sharp/try-it-out/connect-four)

* Visualização de como adaptar a parte de inputs da CoreGameEngine do professor
  Nuno Fachada para o projeto através do 2º projeto de LP2 2019/2020 dos alunos
  João Bernardo e Miguel Fernandez.
  [(link)](https://github.com/JBernardoRebelo/Projeto2_LPII_Fernandez_Rebelo)

* Uso das classes relacionadas aos inputs do repositório Core Game Engine
  referenciada pelo professor Nuno Fachada
  [(link)](https://github.com/fakenmc/CoreGameEngine)

* Exercícios 1, 2, 3 e 4 da Aula 11 de LP2 (2020) como base para a Game Engine
  [(link)](https://github.com/VideojogosLusofona/lp2_2020_aulas/tree/main/Aula11)
