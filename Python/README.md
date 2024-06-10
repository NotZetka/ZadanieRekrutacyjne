# Biblioteka - Skrypt Python + PostgreSQL

## Instalacja

Zainstaluj bibliotekę `psycopg2`:

```bash
pip install psycopg2
```

## Odpalenie

W pliku config.json ustaw dane do logowania do swojej bazy PostgreSQL.
Następnie otwórz konsole w katalogu ze skryptem i wywołaj polecenie

```bash
python spript.py
```

## Działanie

Jeśli baza biblioteka nie istnieje zostanie utworzona, 
w przeciwnym wypadku zostanie nawiązane połaczenie do istniejącej bazy.
Jesli tabela Książki nie istnieje zostanie utworzona. 
Tabela książki zostanie wyczyszczona, nastepnie zostanie do niej dodane 5 przykładowych ksiażek.
Wszystkie książki w tabeli zostaną wypisane. 
Nastepnie jedna ksiazka zostanie zedytowana i wypisana.
Nastepnie jedna ksiażka zostanie usunieta i wszystkie pozostałe ksiażki zostana wypisane. 
