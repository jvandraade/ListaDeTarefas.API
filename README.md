# Documentação de Projeto C#: API de Lista de Tarefas

API da Lista de Tarefas em C# que desenvolvi o CRUD anteriormente, utilizando o Swagger como ferramenta de teste para consumir e testar a API.

# Base URL
- http://localhost:44368.

# Endpoints
Lista de Tarefas:
- Endpoint: /TarefasAPI.
- Método HTTP: POST.
- Descrição: Inclui uma nova tarefa na lista lista.
- Resposta de Sucesso:
    - Código: 200.
    - Conteúdo: Inclui um objeto JSON a lista de tarefas.
  Exemplo de Resposta:
  ```
    {
      "id": 5,
      "titulo": "Exemplo",
      "descricao": "Exemplo",
      "status": true
    }
  

- Método HTTP: GET
- Descrição: Retorna todas as tarefas que foram inclusas na lista.
- Resposta de Sucesso:
  - Código: 200.
  - Conteúdo: Retorna as tarefas da lista que ainda não foram concluídas.
  - Status da tarefa não concluída: FALSE.
    Exemplo de Resposta:
   ``` 
      {
        "id": 2,
        "titulo": "Cinema",
        "descricao": "Ir ao cinema com a namorada",
        "status": false
      }
    

- Método HTTP: DELETE
- Descrição: Deleta qualquer tarefa da lista sendo ela concluída ou não.
- Resposta de Sucesso:
    - Código: 200.
    - Conteúdo: Remove a tarefa da lista através do ID da tarefa.

- Método HTTP: PUT
- Descrição: Marca a tarefa como concluída através do ID.
- Resposta de Sucesso:
  - Código: 200.
  - Conteúdo: Marca a conclusão da tarefa.
