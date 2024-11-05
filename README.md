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
- **Models:** Representações dos objetos principais, como `Usuario`, `Produto` e `Previsao`.
- **Services/Repository:** Responsáveis pela lógica de negócio, como a previsão de demanda, curadoria de produtos e simulações.

### 📂 Pasta Documentação
Documentação técnica detalhada sobre a API, incluindo endpoints, parâmetros e exemplos de uso, tudo configurado com **Swagger**.

### 📂 Pasta Testes
Contém testes unitários para garantir que os serviços e previsões de demanda estejam funcionando corretamente, utilizando princípios de TDD.


### 🤖 Recomendação de Produtos com Machine Learning
O serviço de recomendação de produtos na API é implementado utilizando o Microsoft ML.NET, uma biblioteca poderosa para construção de modelos de machine learning. Essa funcionalidade permite prever a pontuação que um usuário pode atribuir a um produto com base em avaliações anteriores.

## 1. Modelos de Dados
ProductRating: Representa a avaliação de um produto por um usuário. Contém as seguintes propriedades:

UserId: Identificador do usuário.
ProductId: Identificador do produto.
Label: A pontuação que o usuário atribuiu ao produto.
ProductPrediction: Representa a previsão de pontuação para um produto específico.Contém uma única propriedade:
Score: A pontuação prevista pelo modelo.

## 2. Serviço de Recomendação
O RecommendationService é a classe responsável por treinar o modelo e prever pontuações.

Treinamento do Modelo
O método TrainModel é utilizado para treinar o modelo com base nas avaliações fornecidas. O processo de treinamento envolve:

Carregamento dos Dados: Os dados de avaliações são carregados a partir de uma coleção de ProductRating.
Pipeline de Transformação: O pipeline transforma os dados, mapeando os IDs de usuários e produtos para valores de chave, e utiliza a técnica de fatoração de matriz para treinar o modelo de recomendação.

Previsão de Pontuação
O método PreverPontuacao recebe o ID de um usuário e o ID de um produto, utilizando o modelo treinado para prever a pontuação que o usuário atribuiria ao produto.

## 3. Controller de Recomendação
O RecommendationController é responsável por expor os endpoints para treinar o modelo e prever pontuações.

Métodos
Treinar:
Endpoint: POST /api/recommendation/treinar
Descrição: Este método treina o modelo com uma lista de avaliações. Recebe as avaliações via corpo da solicitação e retorna uma mensagem de sucesso.

Prever:
Endpoint: GET /api/recommendation/prever
Descrição: Este método prevê a pontuação que um usuário atribuiria a um produto, recebendo os IDs de usuário e produto como parâmetros de consulta.

A implementação do serviço de recomendação oferece uma maneira eficaz de personalizar a experiência do usuário, sugerindo produtos com base nas avaliações anteriores. O uso do ML.NET possibilita a criação de um modelo robusto e adaptável a diferentes cenários de avaliação.


### 🧪 Testes Implementados
# 1. ProdutoRepositoryTests
A classe ProdutoRepositoryTests é responsável por testar as funcionalidades do repositório de produtos (ProdutoRepository). Ela utiliza um banco de dados em memória para simular a interação com o banco de dados real, garantindo que os testes sejam rápidos e não dependam do estado do banco de dados externo.

# Métodos de Teste
Adicionar_Produto_Deve_Salvar_Produto: Este teste verifica se um novo produto é salvo corretamente no banco de dados. Ele cria um objeto Produto, chama o método Adicionar do repositório e, em seguida, busca o produto no contexto para garantir que ele foi salvo com os atributos esperados.

BuscarPorId_Deve_Retornar_Produto_Quando_Produto_Existe: Este teste verifica se o método BuscarPorId retorna um produto existente corretamente. Após adicionar um produto ao banco de dados, o teste chama o método e verifica se o produto retornado possui os mesmos atributos que o produto adicionado.

BuscarTodosProdutos_Deve_Retornar_Todos_Produtos: Este teste ainda precisa ser implementado. O objetivo é garantir que todos os produtos armazenados no banco de dados sejam retornados corretamente.

Atualizar_Produto_Deve_Modificar_Produto_Quando_Produto_Existe: Este teste verifica se um produto existente pode ser atualizado corretamente. Um produto é adicionado e, em seguida, um novo objeto Produto com os dados atualizados é passado para o método Atualizar. O teste então verifica se o produto foi atualizado com sucesso.

Apagar_Produto_Deve_Remover_Produto_Quando_Produto_Existe: Este teste verifica se um produto pode ser removido do banco de dados. Um produto é adicionado, e o método Apagar é chamado. O teste verifica se o produto foi realmente removido ao tentar buscá-lo novamente.

# 2. UserRepositoryTests
A classe UserRepositoryTests é responsável por testar as funcionalidades do repositório de usuários (UserRepository). Assim como na classe de testes de produtos, um banco de dados em memória é utilizado.

# Métodos de Teste
Adicionar_Usuario_Deve_Salvar_Usuario: Este teste verifica se um novo usuário é salvo corretamente no banco de dados. Um objeto Usuario é criado, o método Adicionar é chamado e o teste busca o usuário no contexto para garantir que ele foi salvo com os atributos esperados.
Práticas de Teste
Utilização de InMemory Database: O uso do banco de dados em memória permite testes rápidos e independentes do ambiente. Isso garante que cada teste começa com um estado limpo, evitando interferências de testes anteriores.

Assertivas com o xUnit: A biblioteca xUnit é utilizada para asserções em cada teste, permitindo verificar se o resultado obtido é o esperado.

Implementação de IDisposable: Ambas as classes implementam a interface IDisposable para garantir que os recursos do banco de dados sejam liberados após a execução dos testes.

Esses testes garantem que as operações básicas de CRUD (Create, Read, Update, Delete) nos repositórios estão funcionando corretamente e ajudam a manter a qualidade do código à medida que o projeto evolui.



## 🛠️ Tecnologias Utilizadas

### 🔧 Ferramentas e Frameworks
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4.svg?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4.svg?style=for-the-badge&logo=dotnet&logoColor=white)
![Oracle](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle&logoColor=white)


### 📚 Bibliotecas e Ferramentas
- ASP.NET Core para o desenvolvimento da API.
- Oracle EF para persistência de dados.
- Swagger para documentação dos endpoints.
- Git para controle de versão.
- Firebase Admin SDK para autenticação e gerenciamento de usuários.
- ML.NET para implementação de recomendações de produtos.
- Microsoft.Extensions.Configuration para gerenciar a configuração da aplicação.

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

4. **Configure a string de conexão no `appsettings.json`:**
   - Atualize a string de conexão para conectar ao seu banco de dados Oracle.

5. **Execute a aplicação:**
   ```bash
   dotnet run
   ```

6. **Acesse a documentação da API via Swagger:**
   Abra o navegador e vá até: `https://localhost:7222/swagger/index.html`.

## 📊 Estrutura de Dados

- **Usuario**: Gerencia as informações dos usuários e suas credenciais.
- **Produto**: Contém detalhes dos produtos sustentáveis para análise de demanda.
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

| Nome                        | Função                                |
| ---------------------------- | ------------------------------------- |
| **[Rafaela](https://github.com/rafluuz)** | .NET & Banco de Dados |
| **[Ming](https://github.com/mingzinho)** | IA & DevOps Cloud Computing
| **[Clara](https://github.com/clarabcerq)** | Java |
| **[Guilherme](https://github.com/Guilherme379)** | Complience & Quality Assurance |
| **[Pedro Batista ](https://github.com/yoboypb)** | Mobile |

---

<a href="#top">Voltar ao topo</a>

