// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;


string adminfil = "admin.txt"; // Sparar admin.txt filen till en variabel
if (!File.Exists(adminfil)) // Om filen inte skulle existera , skapa den och skriv innehåll admin;password
{
      File.WriteAllText(adminfil, "admin;password");
}

