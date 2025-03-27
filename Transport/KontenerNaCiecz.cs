namespace Transport;

public class KontenerNaCiecz : Kontener, IHazardNotifier
{
    public bool CzyNiebezpieczne { get; set; }

    public KontenerNaCiecz(double wysokosc, double wagaWlasna, double glebokosc, double maksLadownosc,
        bool czyNiebezpieczne) : base(wysokosc, wagaWlasna, glebokosc, maksLadownosc, "L")
    {
        CzyNiebezpieczne = czyNiebezpieczne;
    }

    public override void Zaladuj(double waga)
    {
        double limit = 0.9 * MaksLadownosc;
        if (CzyNiebezpieczne)
        {
            limit = 0.5 * MaksLadownosc;
        }

        if (MasaLadunku + waga > limit)
        {
            NotifyHazard("Osiągnięto maksymalną bezpieczną ładowność kontenera o id: " + NumerSeryjny);
            throw new OverfillException("PRZECIĄŻENIE!!! Nie można załadować więcej do kontenera o id: " +
                                        NumerSeryjny);
        }

        MasaLadunku += waga;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("ALARM!!! " + message);
    }

    public override string ToString()
    {
        return NumerSeryjny + " - Wymiary: " + Wysokosc + " cm x" + Glebokosc + " cm || Ładowność: " + MasaLadunku +
               "kg /" + MaksLadownosc + " kg || Waga własna: " + WagaWlasna + " || Czy niebezpieczny: " + CzyNiebezpieczne;
    }
}