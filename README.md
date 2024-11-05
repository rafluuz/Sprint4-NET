# 🌍 SustenAI - Previsão Personalizada de Demanda em E-commerce Sustentável 🌱
![Status](https://img.shields.io/badge/STATUS-EM%20DESENVOLVIMENTO-yellow?style=for-the-badge)

> Aplicação de Inteligência Artificial e Análise de Dados para otimizar o mercado de produtos sustentáveis.

## 📌 Descrição do Projeto

**SustenAI** é uma plataforma inovadora que utiliza Inteligência Artificial e análise de dados para prever a demanda de produtos sustentáveis em e-commerce, oferecendo insights poderosos tanto para empresas quanto para consumidores. Através de funcionalidades como previsão de demanda e curadoria de produtos, o SustenAI visa melhorar a eficiência da cadeia de suprimentos e incentivar o consumo sustentável.

O projeto é focado em:

- Previsão personalizada de demanda.
- Curadoria automatizada de produtos sustentáveis.
- Simulação de cenários para decisões empresariais mais informadas.
- Incentivo ao consumo consciente e à sustentabilidade.

## 🎯 Objetivo

Fornecer uma solução robusta para e-commerces que lidam com produtos sustentáveis, aumentando a precisão de estratégias de marketing e promovendo um ecossistema de sustentabilidade. A plataforma permite que os gestores tomem decisões mais informadas, baseadas em dados e projeções, enquanto os consumidores têm acesso a produtos que promovem um futuro mais sustentável.

## 💡 Funcionalidades

- **Previsão de Demanda**: Algoritmos avançados de machine learning para prever a demanda de produtos com alta precisão.
- **Curadoria de Produtos Sustentáveis**: Filtragem e categorização de produtos conforme critérios de sustentabilidade.
- **Simulação de Cenários**: Possibilidade de simular diferentes cenários de vendas para apoiar estratégias empresariais.
- **Insights para Decisão**: Painel intuitivo com insights para a tomada de decisão estratégica.

## 🗂️ Estrutura do Projeto

### 📂 Pasta API
- **Controller:** Gerencia as requisições HTTP e coordena a execução das previsões de demanda e manipulação de produtos.
- **Models:** Representações dos objetos principais, como `Usuario`, `Produto`, `Arquivo` e `Previsao`.
- **Services/Repository:** Responsáveis pela lógica de negócio, como a previsão de demanda, curadoria de produtos e simulações.

### 📂 Pasta Documentação
Documentação técnica detalhada sobre a API, incluindo endpoints, parâmetros e exemplos de uso, tudo configurado com **Swagger**.

### 📂 Pasta Testes
Contém testes unitários para garantir que os serviços e previsões de demanda estejam funcionando corretamente, utilizando princípios de TDD.

## 🛠️ Tecnologias Utilizadas

### 🔧 Ferramentas e Frameworks
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4.svg?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4.svg?style=for-the-badge&logo=dotnet&logoColor=white)
![Oracle](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle&logoColor=white)


### 📚 Bibliotecas e Ferramentas
- **ASP.NET Core** para o desenvolvimento da API.
- **Oracle EF** para persistência de dados.
- **Swagger** para documentação dos endpoints.
- **Git** para controle de versão.

## 🚀 Como Executar o Projeto

Siga estas etapas para configurar e executar a aplicação localmente:

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/rafluuz/SustenAI
   ```

2. **Navegue até o diretório do projeto:**
   ```bash
   cd SustenAI
   ```

3. **Instale as dependências:**
   ```bash
   dotnet restore
   ```

4. **Execute a Compilação do Projeto.**

5. **Execute, se necessário, o comando:**
   ```console do nuget
   dotnet restore
   ```

7. **Execute a aplicação:**
   ```
   https
   ```

8. **Acesse a documentação da API via Swagger:**
   Abra o navegador e vá até: `https://localhost:7222/swagger/index.html`.

## 📊 Estrutura de Dados

- **Usuario**: Gerencia as informações dos usuários e suas credenciais.
- **Produto**: Contém detalhes dos produtos sustentáveis para análise de demanda.
- **Arquivo**: Controla os metadados dos arquivos carregados pelos usuários.
- **Previsao**: Registra os resultados das previsões de demanda para cada produto.

## 💻 Requisitos

- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Oracle Database](https://www.oracle.com/database/)
- [Git](https://git-scm.com)

## 📈 Roadmap

- Implementar notificações de previsão em tempo real.
- Adicionar integração com outras APIs de e-commerce.
- Criar um painel para visualização de métricas ambientais dos produtos.


## 🫂 Equipe de Desenvolvimento

| Nome                        | Função                                 |        RM                                 |
| ----------------------------| -------------------------------------  | ------------------------------------------|
| **[Rafaela](https://github.com/rafluuz)** | .NET & Banco de Dados |  RM551857                                    |
| **[Ming](https://github.com/mingzinho)** | IA & DevOps Cloud Computing | RM99150                                 |
| **[Clara](https://github.com/clarabcerq)** | Java | RM98175                                                      |
| **[Guilherme](https://github.com/Guilherme379)** | Complience & Quality Assurance | RM551805                     |
| **[Pedro Batista ](https://github.com/yoboypb)** | Mobile | RM550334                                             |

---

<a href="#top">Voltar ao topo</a>

