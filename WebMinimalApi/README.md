### Implementacja Minimal API w .NET 

- Aplikacja uruchamia Minimal API na .NET 8,
- Konfiguruje bazę danych InMemory za pomocą Entity Framework Core,
- Tworzy encję Person z polami: ID, FirstName, LastName, BirthDate, Address,
- Aplikacja rejestruje endpointy API, pozwalające na operacje CRUD na encji Person,
- Przeprowadza walidację danych przy operacjach dodawania i aktualizacji osoby,
- Dane zostają automatycznie usunięte z pamięci po zatrzymaniu aplikacj.
  
### Obsługa endpointów API

- #### POST /api/persons
    - Dodaje nową osobę do bazy w pamięci,
    - Weryfikuje dane wejściowe,
    - Zwraca 201 Created po pomyślnym dodaniu lub 400 Bad Request w przypadku błędów walidacji.
- #### GET /api/persons
    - Zwraca listę wszystkich osób w bazie danych,
    - Wysyła listę osób z kodem 200 OK.
- #### GET /api/persons/{id}
    - Pobiera dane konkretnej osoby na podstawie jej ID,
    - Jeśli osoba istnieje, zwraca jej dane z kodem 200 OK,
    - Jeśli osoba nie istnieje, zwraca 404 Not Found z informacją o błędzie.
- #### DELETE /api/persons/{id}
    - Usuwa osobę na podstawie ID,
    - Zwraca 200 OK po usunięciu lub 404 Not Found jeśli osoba o podanym ID nie istnieje.
- #### PUT /api/persons/{id}
    - Aktualizuje dane istniejącej osoby,
    - Sprawdza, czy osoba istnieje oraz waliduje wprowadzone dane,
    - Zwraca 200 OK z nowymi danymi lub 400 Bad Request/404 Not Found w przypadku błędów.

## Przykład działania

#### Dodanie osoby do bazy
![image](https://github.com/user-attachments/assets/2bae359c-9427-4d3e-8139-873b03b0d03f)
![image](https://github.com/user-attachments/assets/caf86453-c16e-452e-a648-41d50278c893)

#### Pobranie wszystkich osób z bazy
![image](https://github.com/user-attachments/assets/36fb5822-4e33-44a0-8de6-7ce256af17a7)

#### Pobranie konkretnej osoby po ID z bazy
![image](https://github.com/user-attachments/assets/98635ffe-5116-4b68-a24b-d0df0c0fa899)
![image](https://github.com/user-attachments/assets/b722c8c9-719e-4298-8f45-c55e7806b081)

#### Usunięcie konkretnej osoby po ID z bazy
![image](https://github.com/user-attachments/assets/2338d629-d891-4f7a-be61-b89afbcb9aa6)
![image](https://github.com/user-attachments/assets/04b2d0ee-df91-4747-8897-f72ec40477ed)

#### Modyfikacja konkretnej osoby po ID z bazy
![image](https://github.com/user-attachments/assets/b48e54b7-dd89-45b3-94d9-fcdcdda8d0e7)
![image](https://github.com/user-attachments/assets/db5556d2-8fd2-4601-8e94-a8894c647ef4)
