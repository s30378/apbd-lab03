namespace Transport;

public class Statek
{
    private List<Kontener> kontenery;
    public double MaxPredkosc { get; set; }
    public int MaksLiczbaKontenerow { get; set; }
    public double MaksWagaKontenerow { get; set; }

    public Statek(double maxPredkosc, int maksLiczbaKontenerow, double maksWagaKontenerow)
    {
        MaxPredkosc = maxPredkosc;
        MaksLiczbaKontenerow = maksLiczbaKontenerow;
        MaksWagaKontenerow = maksWagaKontenerow;
        kontenery = new List<Kontener>();
    }

    public bool Zaladuj(Kontener kontener)
    {
        if (kontenery.Count >= MaksLiczbaKontenerow)
        {
            Console.WriteLine("Załadunek nieudany! Przekroczono dop. ilość kontenerów.");
            return false;
        }

        double waga = 0;
        foreach (var kon in kontenery)
        {
            waga += kon.WagaWlasna + kon.MasaLadunku;
        }

        waga += kontener.WagaWlasna + kontener.MasaLadunku;

        if (waga > MaksWagaKontenerow * 1000)
        {
            Console.WriteLine("Załadunek nieudany! Przekroczono dop. wagę kontenerów.");
            return false;
        }

        kontenery.Add(kontener);
        Console.WriteLine("Załadunek kontenera " + kontener.NumerSeryjny + " udany!");
        return true;
    }

    public void Zaladuj(List<Kontener> kont)
    {
        foreach (var kontener in kont)
        {
            Zaladuj(kontener);
        }
    }

    public bool Wyladuj(string nrKontenera)
    {
        Kontener kon = null;
        foreach (var iKontener in kontenery)
        {
            if (iKontener.NumerSeryjny == nrKontenera)
            {
                kon = iKontener;
                break;
            }
        }

        if (kon == null)
        {
            Console.WriteLine("Nie znaleziono kontenera o takim ID!");
            return false;
        }

        kontenery.Remove(kon);
        Console.WriteLine("Wyładowano kontener o numerze: " + kon.NumerSeryjny);
        return true;
    }

    public void Zastap(string nrKontenera, Kontener kontener)
    {
        if (Wyladuj(nrKontenera)) Zaladuj(kontener);
    }

    public void Przenies(string nrKontenera, Statek statek)
    {
        Kontener kon = null;
        foreach (var iKontener in kontenery)
        {
            if (iKontener.NumerSeryjny == nrKontenera)
            {
                kon = iKontener;
                break;
            }
        }

        if (kon != null && statek.Zaladuj(kon))
        {
            kontenery.Remove(kon);
            Console.WriteLine("Pomyślnie przeniesiono kontener o numerze " + kon.NumerSeryjny);
        }
        else
        {
            Console.WriteLine("Nie udało się przenieść danego kontenera!");
        }
    }

    public override string ToString()
    {
        string output = "Maksymalna prędkość: " + MaxPredkosc + " kn || Kontenery: " + kontenery.Count + "/" +
                        MaksLiczbaKontenerow + " Maksymalna waga kontenerów: " + MaksWagaKontenerow +
                        " t\nKontenery na pokładzie:";
        foreach (var kontener in kontenery)
        {
            output += "\n" + kontener;
        }
        return output;
    }
}