namespace Transport;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; set; }

    public KontenerNaGaz(double wysokosc, double wagaWlasna, double glebokosc, double maksLadownosc, double cisnienie) : base(wysokosc, wagaWlasna, glebokosc, maksLadownosc, "G")
    {
        Cisnienie = cisnienie;
    }

    public override void Wyladuj()
    {
        MasaLadunku *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("ALARM!!! " + message);
    }
    
    public override string ToString()
    {
        return NumerSeryjny + " - Wymiary: " + Wysokosc + " cm x" + Glebokosc + " cm || Ładowność: " + MasaLadunku +
               "kg /" + MaksLadownosc + " kg || Waga własna: " + WagaWlasna + " || Ciśnienie: " + Cisnienie + " atm";
    }
}