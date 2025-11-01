# Hotellstatemanager
Kommer gå igenom punkt för punkt för det som står som krav på uppgiften. Det handlar om en receptionist som kommer kunna logga in med sparad inlogningsuppgift i en fil.
Receptionisten kommer först få en meny, efter inloggningen ska det komma en till meny. I den andra menyn ska receptionisten kunna göra följande : 

1. Logga in med uppgifter som ligger sparade i en fil.
2. Se en lista av alla rum som har gäster just nu.
3. Se en lista av alla lediga rum.
4. Boka in en gäst i ett ledigt rum.
5. Checka ut en gäst från ett upptaget rum.
6. Markera att ett rum, temporärt, inte är tillgängligt.

Extra information var : 
1. Ni bör använda enums för statusen på ett rum.
2. Programmet ska kunna spara och ladda data från filsystemet automatiskt när
ändringar sker.

# Programmet 
Jag börjar med att skapa enums och en Booking klass. Denna klassen är grunden, då varje bokning blir ett objekt som sparas i en lista och filen. Konstruktorn kommer ta emot string, int och enum. Där jag sen ska kunna filtrera/söka på objekten tex vid utcheckning. 

Nästa steg är att logga in. Jag hårdkodar in i filen admin;password, där jag sedan jämför input mot det som står i filen.

Jag kommer använda mig av en Service klass. Enkelt förklarat så känns det som jag får bättre struktur och flöde i min kod, gillar ha minimalt med kod i program.cs och lägger in statiska metoder istället. Även om vi gått igenom det mesta med att skriva allt i program.cs direkt så efter en tid nu känns det som att lite mer kod hör hemma i en metod för simpelhetens skull? Det är känslan för tillfället och såklart kommer det säkert att ändras när jag är mer erfaren. 

