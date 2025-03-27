namespace Transport;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Statek statek = new Statek(25, 5, 80); // 80 ton

            KontenerNaCiecz paliwo = new KontenerNaCiecz(250, 3000, 500, 10000, true);
            KontenerZimny banany = new KontenerZimny(250, 3000, 500, 10000, "Banany", 13, 13.3);
            KontenerNaGaz hel = new KontenerNaGaz(250, 3000, 500, 10000, 200);

            paliwo.Zaladuj(4000);
            banany.Zaladuj(9000);
            hel.Zaladuj(4800);

            statek.Zaladuj(paliwo);
            statek.Zaladuj(banany);
            statek.Zaladuj(hel);

            Console.WriteLine(statek.ToString());
            
            banany.Zaladuj(15000);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}