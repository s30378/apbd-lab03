namespace Transport;

public class KontenerZimny : Kontener, IHazardNotifier
{
    public string RodzajProduktu { get; set; }
    public double Temp { get; set; }
    public double MinTemp { get; set; }

    public KontenerZimny(double wysokosc, double wagaWlasna, double glebokosc, double maksLadownosc,
        string rodzajProduktu, double temp, double minTemp) : base(wysokosc, wagaWlasna, glebokosc, maksLadownosc, "Z")
    {
        RodzajProduktu = rodzajProduktu;
        Temp = temp;
        MinTemp = minTemp;

        if (Temp < MinTemp)
        {
            NotifyHazard("Temperatura jest zbyt niska dla tego typu produktu!");
        }
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("ALARM!!! " + message);
    }

    public override string ToString()
    {
        return NumerSeryjny + " - Wymiary: " + Wysokosc + " cm x" + Glebokosc + " cm || Ładowność: " + MasaLadunku +
               "kg /" + MaksLadownosc + " kg || Waga własna: " + WagaWlasna + " || Rodzaj: " + RodzajProduktu +
               " || Temperatura: " + Temp + " Min: " + MinTemp;
    }
}