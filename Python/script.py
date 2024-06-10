import psycopg2
import json

def read_db_config(filename='config.json'):
    with open(filename, 'r') as file:
        config = json.load(file)
        return config

def create_database():
    conn = create_connection("postgres")
    conn.autocommit = True
    cursor = conn.cursor()

    cursor.execute("SELECT 1 FROM pg_catalog.pg_database WHERE datname = 'biblioteka'")
    exists = cursor.fetchone()

    if not exists:
        cursor.execute("CREATE DATABASE biblioteka")
        print("Baza biblioteka została utworzona")
    else:
        print("Baza biblioteka już istnieje")

    cursor.close()
    conn.close()

def create_connection(dbname="biblioteka"):
    config = read_db_config()
    return psycopg2.connect(
        dbname=dbname,
        user=config["user"],
        password=config["password"],
        host=config["host"]
    )

def create_table():
    with create_connection() as conn:
        with conn.cursor() as cursor:
            cursor.execute("""
                CREATE TABLE IF NOT EXISTS ksiazki (
                    id SERIAL PRIMARY KEY,
                    tytul VARCHAR(255),
                    autor VARCHAR(255),
                    rok_wydania INT,
                    isbn VARCHAR(13)
                )
            """)
            conn.commit()

def add_book(tytul, autor, rok_wydania, isbn):
    with create_connection() as conn:
        with conn.cursor() as cursor:
            cursor.execute("""
                INSERT INTO ksiazki (tytul, autor, rok_wydania, isbn)
                VALUES (%s, %s, %s, %s)
            """, (tytul, autor, rok_wydania, isbn))
            conn.commit()

def update_book(book_id, tytul, autor, rok_wydania, isbn):
    with create_connection() as conn:
        with conn.cursor() as cursor:
            cursor.execute("""
                UPDATE ksiazki
                SET tytul = %s, autor = %s, rok_wydania = %s, isbn = %s
                WHERE id = %s
            """, (tytul, autor, rok_wydania, isbn, book_id))
            conn.commit()

def delete_book(book_id):
    with create_connection() as conn:
        with conn.cursor() as cursor:
            cursor.execute("""
                DELETE FROM ksiazki
                WHERE id = %s
            """, str(book_id))
            conn.commit()

def get_books():
    with create_connection() as conn:
        with conn.cursor() as cursor:
            cursor.execute("SELECT * FROM ksiazki")
            books = cursor.fetchall()
            cursor.close()
            return books

def get_book(book_id):
    with create_connection() as conn:
        with conn.cursor() as cursor:
            cursor.execute("""
                SELECT * FROM ksiazki
                WHERE id = %s
            """, str(book_id))
            books = cursor.fetchall()
            cursor.close()
            return books

def clear_table():
    with create_connection() as conn:
        with conn.cursor() as cursor:
            cursor.execute("TRUNCATE TABLE ksiazki RESTART IDENTITY")
            conn.commit()

if __name__ == "__main__":
    create_database()
    create_table()
    clear_table()

    print("Dodanie przykładowych ksiązek")
    add_book("Pan Tadeusz", "Adam Mickiewicz", 1834, "1234567890123")
    add_book("Lalka", "Boleslaw Prus", 1890, "1234567890124")
    add_book("Quo Vadis", "Henryk Sienkiewicz", 1896, "1234567890125")
    add_book("Ferdydurke", "Witold Gombrowicz", 1937, "1234567890126")
    add_book("Kamienie na szaniec", "Aleksander Kaminski", 1943, "1234567890127")

    print("Wypisanie książek")
    for book in get_books():
        print(book)

    print()
    print("Edycja Quo Vadis")
    update_book(3,"Quo Vadis 2", "Adam Mickiewicz", 2024,"1234567890125")
    print(get_book((3)))

    print()
    print("Usunięcie lalki")
    delete_book(2)
    for book in get_books():
        print(book)



