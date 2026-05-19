Documentação do Projeto — Jogo Snake em Unity
Nome do Projeto
Snake Unity
Visão Geral do Projeto
O projeto consiste no desenvolvimento de um jogo digital inspirado no clássico Snake, utilizando a engine Unity e programação em C#.
O objetivo principal do projeto é criar um jogo simples, funcional e didático, permitindo a análise completa de sua estrutura, funcionamento e código-fonte para fins acadêmicos.
O jogo terá foco em:

simplicidade;
organização de código;
clareza de funcionamento;
fácil entendimento da lógica;
fácil explicação técnica.


Objetivo do Jogo
O jogador controlará uma cobra em um cenário 2D. O objetivo será:

coletar alimentos espalhados pelo mapa;
aumentar o tamanho da cobra;
aumentar a pontuação;
evitar colisões com o próprio corpo e com as paredes.

O jogo continuará até ocorrer uma colisão que resulte em Game Over.

Estrutura Geral do Projeto
O jogo será dividido em duas cenas principais:
1. Cena de Menu Inicial
Responsável por:

exibir o título do jogo;
permitir iniciar o jogo;
permitir fechar o jogo.

Elementos do Menu

Título "Snake"
Botão "Jogar"
Botão "Sair"

2. Cena Principal do Jogo
Responsável por:

gameplay;
movimentação;
geração de comida;
controle de pontuação;
detecção de colisões;
tela de Game Over.


Mecânicas Principais
Sistema de Movimentação
A cobra será controlada pelo jogador através do teclado.
Controles

Setas direcionais

Funcionamento
A movimentação ocorrerá em grade (grid), onde a cobra se moverá em intervalos fixos. A cobra poderá:

mover para cima;
mover para baixo;
mover para esquerda;
mover para direita.

Não será permitido realizar curva instantânea para a direção oposta. Exemplo: se estiver indo para direita, não poderá virar imediatamente para esquerda.
Sistema de Crescimento
Ao coletar uma comida:

a cobra aumentará de tamanho;
um novo segmento será adicionado ao corpo;
a pontuação aumentará.

Sistema de Pontuação
Cada comida coletada adicionará pontos ao jogador. A pontuação será exibida na interface do jogo em tempo real.
Sistema de Colisão
O jogo possuirá colisão com:
Paredes
Ao colidir com as bordas do mapa, o jogo terminará.
Corpo da Cobra
Ao colidir com o próprio corpo, ocorrerá Game Over.
Comida
Ao tocar na comida:

a comida será destruída;
uma nova comida será gerada em posição aleatória;
a cobra crescerá;
a pontuação aumentará.

Sistema de Spawn de Comida
A comida será gerada:

aleatoriamente;
dentro dos limites do mapa;
em posições válidas do grid.

O sistema evitará gerar comida fora do cenário.

Interface do Usuário (UI)
Durante o Jogo
A interface exibirá:

pontuação atual;
mensagens básicas.

Tela de Game Over
Ao perder:

será exibida mensagem "Game Over";
será exibida pontuação final;
será exibido botão de reiniciar.


Sistema de Áudio
O projeto utilizará apenas efeitos sonoros simples.
Sons previstos

som ao clicar em botões;
som ao coletar comida.

Não haverá música de fundo complexa nem sistema avançado de áudio.

Estrutura Visual
Estilo Artístico
O jogo utilizará visual minimalista 2D. Características:

formas simples;
cores sólidas;
interface limpa;
cenário simples;
foco na jogabilidade.

Cenário
O cenário será composto por:

fundo simples;
área delimitada para movimentação da cobra;
grid invisível ou visual discreto.


Personagens
Cobra
A cobra será o personagem controlado pelo jogador. Características:

crescimento progressivo;
movimentação contínua;
colisão com objetos;
controle pelo teclado.


Objetos do Jogo
Comida
Objeto coletável responsável por aumentar o tamanho da cobra e a pontuação.
Paredes
Objetos responsáveis por limitar o mapa e detectar colisão de derrota.

Organização Técnica do Projeto
Estrutura de Pastas

Scenes — cenas do jogo (Menu e Principal)
Scripts — todos os scripts C# do projeto
Prefabs — objetos pré-configurados (cobra, comida, paredes)
Sprites — imagens e elementos visuais 2D
Audio — arquivos de efeitos sonoros
UI — assets visuais de interface (fontes, sprites de botão, ícones)


Observação: os scripts de interface ficam dentro da pasta Scripts, não da pasta UI. A pasta UI é exclusiva para assets visuais.


Scripts Principais
SnakeController.cs
Responsável por:

movimentação da cobra;
leitura de input do teclado;
crescimento ao coletar comida;
detecção de colisão com paredes e corpo;
controle dos segmentos do corpo.

FoodSpawner.cs
Responsável por:

geração da comida;
posicionamento aleatório dentro do grid;
controle de spawn a cada coleta.

GameManager.cs
Responsável por:

controle do estado geral do jogo;
gerenciamento da pontuação;
acionamento do Game Over;
reinício da partida.

UIManager.cs
Responsável por:

atualização da pontuação em tempo real na tela;
exibição e ocultação da tela de Game Over;
exibição de mensagens ao jogador;
conexão dos botões de interface com a lógica do jogo.

AudioManager.cs
Responsável por:

centralizar e reproduzir os efeitos sonoros do jogo;
som ao coletar comida;
som ao clicar em botões.

MenuController.cs
Responsável por:

lógica dos botões da cena de menu;
carregar a cena principal ao clicar em "Jogar";
encerrar o aplicativo ao clicar em "Sair".


Fluxo Geral de Funcionamento

O jogador inicia o jogo pelo menu;
A cena principal é carregada;
A cobra começa a se mover;
O jogador controla a direção;
A comida é gerada;
Ao coletar comida:

score aumenta;
cobra cresce;
nova comida aparece;


O jogo continua até colisão;
Ao colidir:

ocorre Game Over;
aparece opção de reiniciar.




Tecnologias Utilizadas

Engine: Unity
Linguagem: C#
Desenvolvimento 2D
Sistema de UI do Unity
