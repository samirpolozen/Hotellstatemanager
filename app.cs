namespace app;

public enum Avalability
{
      Ledigt,
      Upptaget,
      EjTillängligt
}

public class Booking
{
      public string Namn;
      public int Rum;
      public Avalability Status;

      public Booking(string namn, int rum, Avalability status)
      {
            Namn = namn;
            Rum = rum;
            Status = status;

      }
}

public class Service
{
      public static string filnamn = "Bokningar.txt";
      public static List<Booking> bokningar = new();

      public static void AddBooking()
      {
            // Metod för att lägga till en gäst i fil och lista
            Console.WriteLine("---Boka gäst---");
            Console.Write("Namn och efternamn: ");
            string? nyttnamn= Console.ReadLine();

            Console.Write("(Rum 1-20) Rum: ");
            int nyttrum = Convert.ToInt32(Console.ReadLine());

            bool rumupptaget = false; // bool för att hitta om rummet är upptaget
            foreach (Booking n in bokningar)
            {
                  // Om angivet rum matcher ett existerande rum OCH om enum Status matcher Upptaget ELLER EjTillängligt
                  if (nyttrum == n.Rum && (n.Status == Avalability.Upptaget || n.Status == Avalability.EjTillängligt))
                  {
                        rumupptaget = true; // Om den hittar matchning sätt till true;
                        break;
                  }
            }
            if (rumupptaget) // Om true, skicka felmeddelande
            {
                  Console.WriteLine("Rummet är inte tillängligt att boka!");
            }
            
            // Lägger in mina värden i konstruktorn och skapar ett nytt Booking objekt 
            Booking booking = new Booking(nyttnamn, nyttrum, Avalability.Upptaget);
            bokningar.Add(booking); // Lägger till det nya objektet i listan
            
            // Lägger till bokningen i filen "Bokningar.txt" som på varje ny rad sparas med formatet Namn + Rum + Status
            File.AppendAllText(filnamn, booking.Namn + " - " + booking.Rum + " - " + Avalability.Upptaget + Environment.NewLine);

            Console.WriteLine("Bokningen lyckades!");
             

      }
}