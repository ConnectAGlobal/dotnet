# ConnectA

**Conceito**

ConnectA é uma plataforma mobile de requalificação intergeracional que usa IA como parceira para preparar jovens para carreiras que ainda não existem, conectando-os com profissionais 50+ para mentoria e troca de saberes.

**Problema que Resolve**

- **Jovens:** Não há caminhos claros ou cursos formais para "carreiras do futuro" (ex.: Engenheiro de Ética em IA, Estrategista de Economia Verde).
- **Profissionais 50+:** Têm décadas de experiência em soft skills e sistemas complexos, mas enfrentam dificuldade de reinserção e sentem-se desvalorizados.
- **Inclusão:** O mercado costuma excluir extremos — jovens sem experiência e seniores subaproveitados — criando perda de valor social e econômica.

**Solução (ConnectA)**

ConnectA facilita encontros de aprendizagem mútuos: os seniores transformam sua experiência em lições práticas e transferíveis; os jovens trazem perspectivas emergentes e habilidades digitais. A IA ajuda a "traduzir" experiências antigas em micro-learning relevante para carreiras emergentes e a fazer matchmaking eficiente entre mentores e mentorados.

---------------

## ⚙️ Instruções de Execução

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

**Nota**: O EF Core CLI será instalado automaticamente no passo 2 das instruções.

### Passos
1. Clone o repositório:
   ```bash
     git clone https://github.com/ConnectAGlobal/dotnet
   ```
2. Instale o EF Core CLI globalmente (se ainda não tiver):
   ```bash
     dotnet tool install --global dotnet-ef
   ```
3. Entre na pasta do projeto e rode o comando do docker compose para subir um banco mysql no docker:
   ```bash
     cd .\dotnet\
     docker-compose up -d
   ```
4. Rode o comando do database update para lançar as migrations no banco:
   ```bash
     dotnet ef database update --startup-project ConnectA.API --project ConnectA.Infrastructure
   ```
   
---------------

  ## **API Endpoints**

  - **UserController** (`ApiVersion`: 1.0)
    - `POST /api/v1/users` : Cria um usuário. Body: `UserRequestDTO`. Retorna `201 Created`.
    - `PATCH /edit-profile/{userId}` : Edita o perfil do usuário. Body: `ProfileRequestDTO`. Observação: rota absoluta (sem versão no path).
    - `GET /api/v1/users` : Retorna todos os usuários.
    - `DELETE /api/v1/users/{userId}` : Remove um usuário. Retorna `204 No Content`.

  - **MatchController** (`ApiVersion`: 2.0)
    - `POST /api/v2/matchs/match` : Inicia o processo de geração de matches. Retorna `200 OK` com mensagem.

  - **MentoredController** (`ApiVersion`: 1.0) — base: `/api/v1/mentees/learning-tracks`
    - `POST /api/v1/mentees/learning-tracks/follow` : Seguir um learning track. Body: `LearningTrackUserRequestDTO`. Retorna `201 Created`.
    - `GET /api/v1/mentees/learning-tracks/followed?userId={userId}&page={page}&pageSize={pageSize}` : Lista learning tracks seguidos por um usuário (paginação).
    - `PUT /api/v1/mentees/learning-tracks/follow/{id}` : Atualiza um follow (status, score, completedAt). Body: `LearningTrackUserUpdateRequestDTO`.
    - `DELETE /api/v1/mentees/learning-tracks/follow/{id}` : Remove um follow. Retorna `204 No Content`.

  - **MentorController** (`ApiVersion`: 1.0) — base: `/api/v1/mentors`
    - `POST /api/v1/mentors/learning-tracks` : Cria um learning track. Body: `LearningTrackRequestDTO`. Retorna `201 Created`.
    - `POST /api/v1/mentors/{learningTrackId}/stages` : Adiciona uma stage a um learning track. Body: `TrackStageRequestDTO`. Retorna `201 Created`.

  Notes:
  - Onde aplicável, substitua `{id}` ou `{userId}` por GUIDs no formato esperado pela API.

