using System;
using System.Collections.Generic;
using System.IO;
using app;


string adminfil = "admin.txt"; // Sparar admin.txt filen till en variabel
if (!File.Exists(adminfil)) // Om filen inte skulle existera , skapa den och skriv innehåll admin;password
{
      File.WriteAllText(adminfil, "admin;password");
}

if (!File.Exists(Service.filnamn)) // 1. Om filen inte finns
{
      File.WriteAllText(Service.filnamn, ""); // 2. Skapa den tom
}
Service.LaddaUppBokningar(); // Laddar upp allt nytt från förra körningen

bool programigång = true;

while (programigång)
{
      // Meny 1 för inloggning
      bool inloggad = false;
      while (!inloggad)
      {
            Console.WriteLine("===Meny===");
            Console.WriteLine("1. Logga in ");
            Console.WriteLine("2. Avsluta");
            string input = Console.ReadLine();

            if (input == "1")
            {
                  Console.Write("Användarnamn: ");
                  string? anvnamn = Console.ReadLine();
                  Console.Write("Lösenord: ");
                  string? lösenord = Console.ReadLine();

                  string[] rad = File.ReadAllLines("admin.txt"); // Läsen in hela filen som skickar tillbaka en array av rader, rader[0] = "admin;password"
                  string[] del = rad[0].Split(';'); // Delar upp raden från filen i två delar med ';' till 2 olika index

                  string rättanvnamn = del[0]; // admin = index [0]
                  string rättlösenord = del[1]; // password = index[1]

                  if (anvnamn == rättanvnamn && lösenord == rättlösenord) // Matcher användarens input mot index som vi sparade i filen
                  {
                        inloggad = true; // Inloggning lyckades, hoppar över till meny 2
                  }
                  else
                  {
                        Console.WriteLine("Fel användarnamn eller lösenord"); // Om inte input matcher med index [0] och [1], skicka felmeddelande
                  }
            }
            else if (input == "2")
            {
                  programigång = false;
                  break;
            }
      }

      while (inloggad)
      {
            Console.WriteLine("=== Receptionist Meny ===");
            Console.WriteLine(" 1. Boka ny gäst");
            Console.WriteLine(" 2. Checka ut gäst");
            Console.WriteLine(" 3. Visa lediga rum");
            Console.WriteLine(" 4. Visa upptagna rum");
            Console.WriteLine(" 5.");
            Console.WriteLine(" 6. Logga ut");
            string input2 = Console.ReadLine();

            switch (input2)
            {
                  case "1" :
                        Service.AddBooking();
                        break;
                  case "2":
                        Service.CheckaUt();
                        break;
                  case "3":
                        Service.VisaLedigaRum();
                        break;
                  case "4":
                        Service.VisaUpptagnaRum();
                        break;
                  case "6" :
                        inloggad = false;
                        break;
            }





      }

}

// Meny 1 för inloggning
/*bool inloggad = false;
while (!inloggad)
{
      Console.WriteLine("===Meny===");
      Console.WriteLine("1. Logga in ");
      Console.WriteLine("2. Avsluta");
      string input = Console.ReadLine();

      if (input == "1")
      {
            Console.Write("Användarnamn: ");
            string? anvnamn = Console.ReadLine();
            Console.Write("Lösenord: ");
            string? lösenord = Console.ReadLine();

            string[] rad = File.ReadAllLines("admin.txt");
            string[] delar = rad[0].Split(';');

            string rättanvnamn = delar[0];
            string rättlösenord = delar[1];

            if (anvnamn == rättanvnamn && lösenord == rättlösenord)
            {
                  inloggad = true; // Hoppar över till meny 2
            }
            else
            {
                  Console.WriteLine("Fel användarnamn eller lösenord");
            }
      }
      else if (input == "2")
      {
            break;
      }
}

while (inloggad)
{
      Console.WriteLine("=== Receptionist Meny ===");
      Console.WriteLine(" 1.");
      Console.WriteLine(" 2.");
      Console.WriteLine(" 3.");
      Console.WriteLine(" 4.");
      Console.WriteLine(" 5.");
      Console.WriteLine(" 6. Logga ut");
      string input2 = Console.ReadLine();

      switch (input2)
      {
            case "6":
                  inloggad = false;
                  break;
      }





}
*/