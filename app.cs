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

      public static void LaddaUppBokningar() // Läser_ in bokningarna från filen till listan vid varja uppstart
      {
            bokningar.Clear(); // Tömmer listan så vi inte får dubletter/ gammal data
            string[] rad = File.ReadAllLines(filnamn); // Läser in alla rader från textfilen precis som admin.txt

            foreach(string n in rad) // Loopar igenom varje rad i filen
            {
                  string[] delar = n.Split('-'); // Vi splitar upp varje index med '-'

                  string namn = delar[0]; // index 0 blir string
                  int rum = int.Parse(delar[1]); // index 1 omvandlar text till siffra
                  Avalability status = Enum.Parse<Avalability>(delar[2]); // index 2 omvandlar till enum

                  bokningar.Add(new Booking(namn, rum, status)); // Lägger till objektet i listan
            }
      }

      public static void AddBooking()
      {
            // Metod för att lägga till en gäst i fil och lista
            Console.WriteLine("---Boka gäst---");
            Console.Write("Namn och efternamn: ");
            string? nyttnamn = Console.ReadLine();

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
                  return;
            }

            // Lägger in mina värden i konstruktorn och skapar ett nytt Bookings objekt 
            Booking booking = new Booking(nyttnamn, nyttrum, Avalability.Upptaget);
            bokningar.Add(booking); // Lägger till det nya objektet i listan

            // Lägger till bokningen i filen "Bokningar.txt" som på varje ny rad sparas med formatet Namn + Rum + Status
            File.AppendAllText(filnamn, booking.Namn + " - " + booking.Rum + " - " + Avalability.Upptaget + Environment.NewLine);

            Console.WriteLine("Bokningen lyckades!");


      }

      public static void CheckaUt()
      {
            Console.Write("Ange rummsnummer för utcheckning: ");
            int rumut = Convert.ToInt32(Console.ReadLine());

            // 
            Booking bokningTaBort = null;
            // Försöker hitta bokningen där jag jämför input rumsnummer mot rumsnummer i listan OCH enum ska vara .Upptaget
            foreach (Booking i in bokningar)
            {
                  if (rumut == i.Rum && i.Status == Avalability.Upptaget)
                  {
                        bokningTaBort = i;
                        break; // Avslutar loopen när vi matchat rätt
                  }
            }
            if (bokningTaBort == null)
            {
                  Console.WriteLine("Ingen aktiv bokning på detta rumsnummer");
                  return; // Avbryter metoden och hoppar över resten av koden
            }

            bokningar.Remove(bokningTaBort); // Tar bort ur listan

            // Skriver om filen
            File.WriteAllText(filnamn, ""); // Skriver om hela filens innehåll med en tom sträng => ""
            foreach (Booking n in bokningar) // Med hjälp av listan, skriver vi in till filen alla bokningar som är kvar
            {
                  File.AppendAllText(filnamn, n.Namn + " - " + n.Rum + " - " + n.Status + Environment.NewLine);
            }

            Console.WriteLine("Utcheckat rum: " + rumut);


      }

      public static void VisaLedigaRum()
      {
            Console.WriteLine("=== Lediga Rum===");

            for (int i = 1; i <= 20; i++) // Loopar igenom alla 20 rum först 
            {
                  bool ÄrUpptaget = false; // Sätter hittade rum till false 

                  foreach (Booking n in bokningar) // Loopar igenom listan med våra objekt
                  {
                        if (n.Rum == i && (n.Status == Avalability.Upptaget || n.Status == Avalability.EjTillängligt))
                        {
                              ÄrUpptaget = true; // Efter varje varv, om ÄrUpptaget är enum Upptaget eller EjTillängligt sätt till true;
                              break; // kör nästa varv
                        }
                  }
                  if (!ÄrUpptaget) // Om rummet inte blev markerat med true;, skriv ut lediga rum
                  {
                        Console.WriteLine("Rum: " + i + " - Ledigt");
                  }
            }
      }

      public static void VisaUpptagnaRum()
      {
            Console.WriteLine("=== Upptagna rum ===");

            int upptagnarum = 0; // Lägger räknaren på noll, håller koll på antal upptagna rum

            foreach (Booking n in bokningar) // Loopar igenom listan med objekten bokningar
            {
                  // Kollar om rummet är Upptaget eller EjTillängligt med enum
                  if (n.Status == Avalability.Upptaget || n.Status == Avalability.EjTillängligt)
                  {
                        Console.WriteLine(n.Rum + " - " + n.Namn + " - " + n.Status); // Rumsnummer - Namn - Status
                        upptagnarum++; // Efter varje träff, öka räknaren
                  }
            }
            if (upptagnarum == 0) // Om noll, inget rum upptaget
            {
                  Console.WriteLine("Inga upptagna rum");
            }
            else
            {
                  Console.WriteLine("Antal upptagna rum: " + upptagnarum); // Annars skriv ut antal upptagna rum
            }
      }
      
      public static void ReserveraRum()
      {
            Console.WriteLine("=== Reservera rum ===");
            Console.WriteLine("Ange namn för reservationen: ");
            string? name = Console.ReadLine();
            Console.WriteLine("(Rum 1-20) Rum: ");
            int room = Convert.ToInt32(Console.ReadLine());
            
            // Säkerhetskontroll så vi inte bokar ett rum som redan är upptaget eller ej tillängligt
            bool rumupptaget = false; // bool för att hitta om rummet redan är upptaget
            foreach (Booking n in bokningar)
            {
                  // Om angivet rum matcher ett existerande rum OCH om enum Status matcher Upptaget ELLER EjTillängligt
                  if (room == n.Rum && (n.Status == Avalability.Upptaget || n.Status == Avalability.EjTillängligt))
                  {
                        rumupptaget = true; // Om den hittar matchning sätt till true;
                        break;
                  }
            }
            if (rumupptaget) // Om true, skicka felmeddelande
            {
                  Console.WriteLine("Rummet är inte tillängligt att reservera");
                  return; // Avbryter att resten av metoden körs
            }

            //SKapar ett nytt Booking objekt med hårdkodat enum EjTillänglig
            Booking reserveraBokning = new Booking(name, room, Avalability.EjTillängligt);
            bokningar.Add(reserveraBokning); // Lägger till i listan

            // Sparar till filen
            File.AppendAllText(filnamn, reserveraBokning.Namn + " - " + reserveraBokning.Rum + " - " + reserveraBokning.Status + Environment.NewLine);
            Console.WriteLine("Reservationen har lagt till för: " + name);
      



      }
}