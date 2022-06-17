using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programowanie_obiektowe_cwiczenia_projekt
{
    public interface IInfo
    {
        void WypiszInfo();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Osoba : IInfo
    {
        protected string imie = " ";
        protected string nazwisko = " ";
        protected string dataUrodzenia = " ";
        public string Imie
        { get { return imie; } }
        public string Nazwisko
        { get { return nazwisko; } }
        public Osoba(string imie_, string nazwisko_, string dataUrodzenia_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            dataUrodzenia = dataUrodzenia_;
        }
        public void WypiszInfo()
        {
            Console.WriteLine(imie + ", " + nazwisko + ", " + dataUrodzenia);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Student : Osoba
    {
        private List<OcenaKoncowa>ocenaKoncowa = new List<OcenaKoncowa>();
        private List<Przedmiot>przedmiot = new List<Przedmiot>();
        private string kierunek = " ";
        private string specjalnosc = " ";
        private int rok = 0;
        private int grupa = 0;
        private int nrIndeksu = 0;
        public int NrIndeksu
            { get { return nrIndeksu; } }
        public Student (string imie_, string nazwisko_, string dataUrodzenia_) : base (imie_, nazwisko_, dataUrodzenia_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            dataUrodzenia = dataUrodzenia_;
        }
        public Student (string imie_, string nazwisko_, string dataUrodzenia_, string kierunek_, string specjalnosc_, int rok_, int grupa_, int nrIndeksu_) : base (imie_, nazwisko_, dataUrodzenia_)
        {
            kierunek = kierunek_;
            specjalnosc = specjalnosc_;
            rok = rok_;
            grupa = grupa_;
            nrIndeksu = nrIndeksu_;
        }
        public void InfoOceny()
        {
            for (int i = 0; i < ocenaKoncowa.Count; i++)
            {
                OcenaKoncowa o = ocenaKoncowa[i];
                if (ocenaKoncowa[i] != null)
                {
                    o.WypiszInfo();
                }
            }
        }
        public void DodajOcene (string nazwaPrzedmiotu_, double ocena_, string data_)
        {
            for (int i = 0; i < przedmiot.Count; i++)
            {
                Przedmiot p = przedmiot[i];
                if (p.Nazwa == nazwaPrzedmiotu_)
                {
                    ocenaKoncowa.Add(new OcenaKoncowa(ocena_, data_, p));
                }
            }
        }
        public void WypiszInfo()
        {
            Console.WriteLine(imie + ", " + nazwisko + ", " + dataUrodzenia + ", " + kierunek + ", " + specjalnosc + ", " + rok + ", " + grupa + ", " + nrIndeksu);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Wykladowca : Osoba
    {
        private string tytulNaukowy = " ";
        private string stanowisko = " ";
        public Wykladowca (string imie_, string nazwisko_, string dataUrodzenia_) : base (imie_, nazwisko_, dataUrodzenia_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            dataUrodzenia = dataUrodzenia_;
        }
        public Wykladowca (string imie_, string nazwisko_, string dataUrodzenia_, string stanowisko_, string tytulNaukowy_) : base (imie_, nazwisko_, dataUrodzenia_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            dataUrodzenia = dataUrodzenia_;
            stanowisko = stanowisko_;
            tytulNaukowy = tytulNaukowy_;
        }
        public void WypiszInfo()
        {
            Console.WriteLine(imie + ", " + nazwisko + ", " + dataUrodzenia + ", " + stanowisko + ", " + tytulNaukowy);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class OcenaKoncowa : IInfo
    {
        private double wartosc = 0.0;
        private string data = " ";
        private Przedmiot przedmiot;
        public OcenaKoncowa(double wartosc_, string data_, Przedmiot p)
        {
            wartosc = wartosc_;
            data = data_;
            przedmiot = p;
        }
        public void WypiszInfo()
        {
            przedmiot.WypiszInfo();
            Console.WriteLine(wartosc + ", " + data);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Przedmiot : IInfo
    {
        private string nazwa = " ";
        private string kierunek = " ";
        private string specjalnosc = " ";
        private int semestr = 0;
        private int ilGodzin = 0;
        public string Nazwa
        {
            get { return nazwa; }
        }
        public Przedmiot(string nazwa_, string kierunek_, string specjalnosc_, int semestr_, int ilGodzin_)
        {
            nazwa = nazwa_;
            kierunek = kierunek_;
            specjalnosc = specjalnosc_;
            semestr = semestr_;
            ilGodzin = ilGodzin_;
        }
        public void WypiszInfo()
        {
            Console.WriteLine(nazwa + ", " + kierunek + ", " + specjalnosc + ", " + semestr + ", " + ilGodzin);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Jednostka : IInfo
    {
        private List<Wykladowca>wykladowca = new List<Wykladowca>();
        private string nazwa = " ";
        private string adres = " ";
        public string Nazwa
        {
            get { return nazwa;}
        }
        public string Adres
        {
            get { return adres; }
        }
        public Jednostka(string nazwa_, string adres_)
        {
            nazwa = nazwa_;
            adres = adres_;
        }
        public void DodajWykladowce ( Wykladowca w)
        {
            wykladowca.Add(w);
        }
        public bool UsunWykladowce(Wykladowca w)
        {
            for (int i = 0; i < wykladowca.Count;)
            {
                if (wykladowca[i] == w)
                {
                    wykladowca.RemoveAt(i);
                    Console.WriteLine("Usunięto wykładowcę ");
                    return true;
                }
                else
                {
                    ++i;
                }
            }
            Console.WriteLine("Nie usunięto wykładowcy");
            return false;
        }
        public bool UsunWykladowce(string imie_, string nazwisko_)
        {
            for (int i = 0; i < wykladowca.Count;)
            {
                Wykladowca w = wykladowca[i];
                if (w.Imie == imie_ && w.Nazwisko == nazwisko_)
                {
                    wykladowca.RemoveAt(i);
                    Console.WriteLine("Usunięto wykładowcę ");
                    return true;
                }
                else
                {
                    ++i;
                }
            }
            Console.WriteLine("Nie usunięto wykładowcy");
            return false;
        }
        public void InfoWykladowcy()
        {
            foreach (Wykladowca w in wykladowca) w.WypiszInfo();
        }
        public void WypiszInfo()
        {
            Console.WriteLine(nazwa + ", " + adres);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Wydzial
    {
        private List<Student> student = new List<Student>();
        private List<Przedmiot> przedmiot = new List<Przedmiot>();
        private List<Jednostka> jednostka = new List<Jednostka>();
        private List<Wykladowca> wykladowca = new List<Wykladowca>();
        public void DodajJednostke(string nazwa_, string adres_)
        {
            jednostka.Add(new Jednostka(nazwa_, adres_));
        }
        public void DodajPrzedmiot (Przedmiot p)
        {
            przedmiot.Add(p);
        }
        public void DodajStudenta (Student s)
        {
            student.Add(s);
        }
        public bool DodajWykladowce (Wykladowca w, string nazwaJednostki_)
        {
            for (int i = 0; i < jednostka.Count; i++)
            {
                Jednostka j = jednostka[i];
                if (j.Nazwa == nazwaJednostki_)
                {
                    wykladowca.Add(w);
                    Console.WriteLine("Dodano wykładowcę");
                    return true;
                }
            }
            Console.WriteLine("Nie dodano wykładowcy");
            return false;
        }
        public void InfoStudenci (bool b)
        {
            foreach (Student s in student)
            {
                s.WypiszInfo();
                if (b) s.InfoOceny();
            }
        }
        public void InfoJednostki(bool b)
        {
            foreach (Jednostka j in jednostka)
            {
                j.WypiszInfo();
                if (b == true) j.InfoWykladowcy();
            }
        }
        public void InfoPrzedmioty()
        {
            for (int i = 0; i < przedmiot.Count; i++)
            {
                Przedmiot p = przedmiot[i];
                if (p != null)
                {
                    p.WypiszInfo();
                }
            }
        }
        public bool DodajOcene(int nrIndeksu_, string nazwaPrzedmiotu_, int ocena_, string data_)
        {
            for (int i = 0; i < przedmiot.Count; i++)
            {
                Przedmiot p = przedmiot[i];
                Student s = student[i];
                if (p.Nazwa == nazwaPrzedmiotu_ && s.NrIndeksu == nrIndeksu_)
                {
                    s.DodajOcene(nazwaPrzedmiotu_, ocena_, data_);
                    Console.WriteLine("Dodano Ocenę");
                    return true;
                }
            }
            Console.WriteLine("Nie dodano oceny");
            return false;
        }
        public bool UsunStudenta(int nrIndeksu_)
        {
            foreach (Student s in student)
            {
                if (s.NrIndeksu == nrIndeksu_)
                {
                    Console.WriteLine("Usunięto studenta");
                    student.Remove(s);
                    return true;
                }
            }
            Console.WriteLine("Nie usunięto studenta");
            return false;
        }
        public bool PrzeniesWykladowce (Wykladowca w, string obecnaJednostka_, string nowaJednostka_)       //do dokonczenia
        {
            for (int i = 0; i < jednostka.Count; ++i)
            {
                Jednostka j = jednostka[i];
                if (j.Nazwa == obecnaJednostka_)
                {
                    j.UsunWykladowce(w);
                }
                else if (j.Nazwa == nowaJednostka_)
                {
                    j.DodajWykladowce(w);
                    Console.WriteLine("Przeniesiono wykładowcę");
                    return true;
                }
            }
            Console.WriteLine("Nie przeniesiono wykładowcy");
            return false;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Zbigniew", "Kowalksi", "25.12.1990");
            Student s2 = new Student("Andrzej", "Nowak", "21.01.1991", "Informatyka", "Programowanie", 2, 3, 12345);
            Student s3 = new Student("Adam", "Wiśniewski", "01.01.2000", "Ekonomia", "Rachunkowość", 3, 4, 54321);
            Student s4 = new Student("Kamil", "Węgielski", "19.10.2001", "Informatyka", "Programowanie", 2, 3, 98765);
            Wykladowca wykladowca1 = new Wykladowca("Piotr", "Trawiński", "14.02.1980");
            Wykladowca wykladowca2 = new Wykladowca("Mieczysław", "Cichocki", "25.03.1979", "Wykładowca", "Profesor");
            Wykladowca wykladowca3 = new Wykladowca("Przemysław", "Laskowski", "31.03.1970", "Wykładowca", "mgr inż");
            Wykladowca wykladowca4 = new Wykladowca("Szczepan", "Krowiński", "10.09.1969", "Profesor uczelni", "dr inż");
            Jednostka j1 = new Jednostka("Dział elektroniki", "ul. 11 Listopada 209");
            Jednostka j2 = new Jednostka("Dział mechaniki", "ul. 1 maja 99");
            Jednostka j3 = new Jednostka("Dział eksploatacji", "ul. 15 sierpnia 33");
            Przedmiot p1 = new Przedmiot("Bazy danych", "Informatyka", "Programowanie", 4, 42);
            Przedmiot p2 = new Przedmiot("Prawo podatkowe", "Ekonomia", "Rachunkowość", 5, 38);
            Przedmiot p3 = new Przedmiot("Matematyka", "Informatyka", "Programowanie", 4, 50);
            Przedmiot p4 = new Przedmiot("Historia Starożytna", "Historia", "Archeologia", 6, 44);
            OcenaKoncowa o1 = new OcenaKoncowa(5.0, "26.06.2022", p1);
            OcenaKoncowa o2 = new OcenaKoncowa(4.5, "19.06.2022", p2);
            OcenaKoncowa o3 = new OcenaKoncowa(3.0, "18.06.2022", p3);
            o1.WypiszInfo();
            o3.WypiszInfo();
            p2.WypiszInfo();
            Wydzial wydzial1 = new Wydzial();
            Wydzial wydzial2 = new Wydzial();
            s1.DodajOcene("Matematyka", 4.0, "18.06.2022");
            s2.DodajOcene("Prawo podatkowe", 4.5, "19.06.2022");
            s3.DodajOcene("Matematyka", 3.0, "18.06.2022");
            s3.DodajOcene("Bazy danych", 4.0, "26.06.2022");
            wydzial1.DodajJednostke("Dział elektroniki", "ul. 11 Listopada 209");
            wydzial1.DodajJednostke("Dział mechaniki", "ul. 1 maja 99");
            wydzial2.DodajJednostke("Dział eksploatacji", "ul. 15 sierpnia 33");
            wydzial1.InfoJednostki(true);
            j1.DodajWykladowce(wykladowca1);
            j1.DodajWykladowce(wykladowca2);
            j1.DodajWykladowce(wykladowca3);
            j2.DodajWykladowce(wykladowca4);
            j1.InfoWykladowcy();
            j1.UsunWykladowce(wykladowca1);
            wydzial1.DodajStudenta(s1);
            wydzial1.DodajStudenta(s2);
            wydzial1.UsunStudenta(12345);
            wydzial1.DodajStudenta(s3);
            wydzial2.DodajStudenta(s4);
            wydzial1.InfoStudenci(true);
            wydzial2.InfoJednostki(false);
            j1.InfoWykladowcy();
            j2.InfoWykladowcy();
            wydzial2.DodajPrzedmiot(p4);
            wydzial2.DodajOcene(98765, "Historia Starożytna", 6, "22.05.2022");
            wydzial1.DodajWykladowce(wykladowca1, "Dział elektroniki");
            wydzial1.PrzeniesWykladowce(wykladowca1, "Dział elektroniki", "Dział mechaniki");
            wydzial1.DodajWykladowce(wykladowca2, "Dział elektroniki");
        }
    }
}
