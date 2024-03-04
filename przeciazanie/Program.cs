using System;
using System.Collections.Generic;

class Produkt
{
    public string Nazwa { get; set; }
    public double Cena { get; set; }
    public int Ilość { get; set; }

    public Produkt(string nazwa, double cena, int ilość)
    {
        Nazwa = nazwa;
        Cena = cena;
        Ilość = ilość;
    }

    public void Informacje()
    {
        Console.WriteLine($"Nazwa: {Nazwa}, Cena: {Cena}, Ilość: {Ilość}");
    }

    public static bool operator ==(Produkt p1, Produkt p2)
    {
        return p1.Cena == p2.Cena;
    }

    public static bool operator !=(Produkt p1, Produkt p2)
    {
        return p1.Cena != p2.Cena;
    }

    public static bool operator <(Produkt p1, Produkt p2)
    {
        return p1.Cena < p2.Cena;
    }

    public static bool operator >(Produkt p1, Produkt p2)
    {
        return p1.Cena > p2.Cena;
    }

    public static Produkt operator ++(Produkt p)
    {
        p.Ilość++;
        return p;
    }

    public static Produkt operator --(Produkt p)
    {
        if (p.Ilość > 0)
            p.Ilość--;
        return p;
    }
}

class Magazyn
{
    public string Nazwa { get; set; }
    public List<Produkt> Produkty { get; set; }

    public Magazyn(string nazwa)
    {
        Nazwa = nazwa;
        Produkty = new List<Produkt>();
    }

    public void DodajProdukt(Produkt produkt)
    {
        Produkty.Add(produkt);
    }

    public void WyświetlProdukty()
    {
        foreach (var produkt in Produkty)
        {
            produkt.Informacje();
        }
    }

    public void SortujProdukty()
    {
        Produkty.Sort((p1, p2) => p1.Cena.CompareTo(p2.Cena));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Produkt p1 = new Produkt("Mleko", 2.5, 10);
        Produkt p2 = new Produkt("Chleb", 3.0, 15);
        Produkt p3 = new Produkt("Jajka", 4.0, 20);

        if (p1 == p2)
            Console.WriteLine("Produkty mają taką samą cenę.");
        else
            Console.WriteLine("Produkty mają różne ceny.");

        Magazyn magazyn = new Magazyn("Sklep Spożywczy");
        magazyn.DodajProdukt(p1);
        magazyn.DodajProdukt(p2);
        magazyn.DodajProdukt(p3);

        magazyn.WyświetlProdukty();
        Console.WriteLine("Po posortowaniu:");
        magazyn.SortujProdukty();
        magazyn.WyświetlProdukty();

        Console.ReadLine();
    }
}