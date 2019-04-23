using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Data;
using Mono.Data.SQLite;

namespace Shopping
{
    [Table("Uzytkownik")]
    public class Uzytk
    {
        [PrimaryKey, AutoIncrement]
        public int IdUzytkownika { get; set; }
        [MaxLength(20)]
        public string Login { get; set; }
        [MaxLength(20)]
        public string Haslo { get; set; }
        [MaxLength(20)]
        public string Imie { get; set; }
        [MaxLength(20)]
        public string Nazwisko { get; set; }
        public int Punkty { get; set; }
        public bool Subskrypcja { get; set; }

        [OneToMany]
        public List<Lista> ListaZakupow { get; set; }
    }
    [Table("ListaZakupow")]
    public class Lista
    {
        [PrimaryKey, AutoIncrement]
        public int Liczba { get; set; }

        [ForeignKey(typeof(Uzytk))]
        public int IdUzytkownika { get; set; }
        public int KodKreskowy { get; set; }
        public bool JestWKoszyku { get; set; }
        public DateTime Data { get; set; }


    }
    [Table("Produkt")]
    public class Produ
    {
        [PrimaryKey]
        public int KodKreskowy { get; set; }
        public int IdKategoria { get; set; }
        [MaxLength(50)]
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public double Promocja { get; set; }
    }
    [Table("Kategorie")]
    public class Kateg
    {
        [PrimaryKey, AutoIncrement]
        public int IdKategoria { get; set; }
        [MaxLength(50)]
        public string Kategoria { get; set; }
        [MaxLength(50)]
        public string PodKategoria { get; set; }
    }
}
