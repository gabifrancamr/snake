# 🐍 Snake Unity

## 📖 Visão Geral do Projeto

O projeto consiste no desenvolvimento de um jogo digital inspirado no clássico **Snake**, utilizando a engine Unity e programação em **C#**.

O objetivo principal do projeto é criar um jogo simples, funcional e didático, permitindo a análise completa de sua estrutura, funcionamento e código-fonte para fins acadêmicos.

### 🎯 Foco do Projeto

- Simplicidade
- Organização de código
- Clareza de funcionamento
- Fácil entendimento da lógica
- Fácil explicação técnica

---

# 🎮 Objetivo do Jogo

O jogador controlará uma cobra em um cenário 2D. O objetivo será:

- Coletar alimentos espalhados pelo mapa
- Aumentar o tamanho da cobra
- Aumentar a pontuação
- Evitar colisões com o próprio corpo e com as paredes

O jogo continuará até ocorrer uma colisão que resulte em **Game Over**.

---

# 🧩 Estrutura Geral do Projeto

O jogo será dividido em duas cenas principais.

---

## 1️⃣ Cena de Menu Inicial

Responsável por:

- Exibir o título do jogo
- Permitir iniciar o jogo
- Permitir fechar o jogo

### Elementos do Menu

- Título **"Snake"**
- Botão **"Play"**
- Botão **"Quit"**

---

## 2️⃣ Cena Principal do Jogo

Responsável por:

- Gameplay
- Movimentação
- Geração de comida
- Controle de pontuação
- Detecção de colisões
- Tela de Game Over

---

# ⚙️ Mecânicas Principais

## 🐍 Sistema de Movimentação

A cobra será controlada pelo jogador através do teclado.

### 🎮 Controles

- Setas direcionais
- Teclas **W, A, S, D**

### Funcionamento

A movimentação ocorrerá em grade (**grid**), onde a cobra se moverá em intervalos fixos.

A cobra poderá:

- Mover para cima
- Mover para baixo
- Mover para esquerda
- Mover para direita

> Não será permitido realizar curva instantânea para a direção oposta.  
> Exemplo: se estiver indo para direita, não poderá virar imediatamente para esquerda.

---

## 📈 Sistema de Crescimento

Ao coletar uma comida:

- A cobra aumentará de tamanho
- Um novo segmento será adicionado ao corpo
- A pontuação aumentará

---

## 🏆 Sistema de Pontuação

Cada comida coletada adicionará pontos ao jogador.

A pontuação será exibida na interface do jogo em tempo real.

---

## 💥 Sistema de Colisão

O jogo possuirá colisão com:

### 🧱 Paredes

Ao colidir com as bordas do mapa, o jogo terminará.

### 🐍 Corpo da Cobra

Ao colidir com o próprio corpo, ocorrerá **Game Over**.

### 🍎 Comida

Ao tocar na comida:

- A comida será destruída
- Uma nova comida será gerada em posição aleatória
- A cobra crescerá
- A pontuação aumentará

---

## 🍏 Sistema de Spawn de Comida

A comida será gerada:

- Aleatoriamente
- Dentro dos limites do mapa
- Em posições válidas do grid

O sistema evitará gerar comida fora do cenário.

---

# 🖥️ Interface do Usuário (UI)

## 🎮 Durante o Jogo

A interface exibirá:

- Pontuação atual
- Mensagens básicas

---

## ☠️ Tela de Game Over

Ao perder:

- Será exibida mensagem **"Game Over"**
- Será exibida pontuação final
- Será exibido botão de reiniciar
- Será exibido botão de fechar

---

# 🔊 Sistema de Áudio

O projeto utilizará apenas efeitos sonoros simples.

### 🔉 Sons previstos

- Som ao clicar em botões
- Som ao coletar comida
- Som ao perder o jogo

---

# 🎨 Estrutura Visual

## 🖌️ Estilo Artístico

O jogo utilizará visual minimalista 2D.

### Características

- Formas simples
- Cores sólidas
- Interface limpa
- Cenário simples
- Foco na jogabilidade

---

## 🌍 Cenário

O cenário será composto por:

- Fundo simples
- Área delimitada para movimentação da cobra

---

# 👤 Personagens

## 🐍 Cobra

A cobra será o personagem controlado pelo jogador.

### Características

- Crescimento progressivo
- Movimentação contínua
- Colisão com objetos
- Controle pelo teclado

---

# 🧱 Objetos do Jogo

## 🍎 Comida

Objeto coletável responsável por aumentar o tamanho da cobra e a pontuação.

---

## 🧱 Paredes

Objetos responsáveis por limitar o mapa e detectar colisão de derrota.

---

# 🗂️ Organização Técnica do Projeto

## 📁 Estrutura de Pastas

```bash
Assets/
│
├── Scenes/       # Cenas do jogo
├── Scripts/      # Scripts C#
├── Prefabs/      # Objetos pré-configurados
├── Audio/        # Efeitos sonoros
└── UI/           # Assets visuais da interface
```

---

# 📜 Scripts Principais

## 🐍 SnakeController.cs

Responsável por:

- Movimentação da cobra e leitura do teclado
- Controle e crescimento dos segmentos do corpo
- Detectar colisões com comida, parede e corpo

---

## 🍎 FoodSpawner.cs

Responsável por:

- Geração da comida
- Posicionamento aleatório dentro do grid
- Controle de spawn a cada coleta

---

## 🎮 GameManager.cs

Responsável por:

- Controle do estado geral do jogo e velocidade
- Gerenciamento da pontuação (**Score** e **High Score**)
- Acionamento do Game Over e reinício da partida

---

## 🖥️ UIManager.cs

Responsável por:

- Atualização da pontuação em tempo real
- Exibição e ocultação do painel de Game Over

---

## 🔊 AudioManager.cs

Responsável por:

- Centralizar e reproduzir os efeitos sonoros
- Som ao coletar comida
- Som ao mudar de direção
- Som no Game Over

---

## 📋 MenuController.cs

Responsável por:

- Lógica dos botões da interface
- Carregar a cena principal ao clicar em **"Jogar"**
- Encerrar o jogo ao clicar em **"Sair"**

---

# 🔄 Fluxo Geral de Funcionamento

```text
Menu Inicial
     ↓
Início do Jogo
     ↓
Cobra começa a se mover
     ↓
Jogador controla direção
     ↓
Comida é gerada
     ↓
Comida coletada
     ↓
+ Score
+ Crescimento
+ Nova comida
     ↓
Colisão
     ↓
Game Over
     ↓
Opção de Reiniciar
```

---

# 🛠️ Tecnologias Utilizadas

- Engine: Unity
- Linguagem: C#
- Desenvolvimento 2D
- Sistema de UI da Unity

---
