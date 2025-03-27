namespace Transport;

public abstract class Kontener
{
    public double MasaLadunku { get; set; }
    public double Wysokosc { get; set; }
    public double WagaWlasna { get; set; }
    public double Glebokosc { get; set; }
    public string NumerSeryjny { get; private set; }
    public double MaksLadownosc { get; set; }

    private static int IdContenera = 1;

    protected Kontener(double wysokosc, double wagaWlasna, double glebokosc, double maksLadownosc, string typ)
    {
        MasaLadunku = 0;
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        MaksLadownosc = maksLadownosc;
        NumerSeryjny = "KON-" + typ + "-" + IdContenera++;

    }

    public virtual void Zaladuj(double waga)
    {
        if (MasaLadunku + waga > MaksLadownosc)
        {
            throw new OverfillException("PRZECIĄŻENIE!!! Nie można załadować więcej do kontenera o id: " + NumerSeryjny);
        }
        MasaLadunku += waga;
    }

    public virtual void Wyladuj()
    {
        MasaLadunku = 0;
    }
}