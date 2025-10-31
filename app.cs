namespace app;

public enum Avalability
{
      Ledigt,
      Upptaget,
      EjTillängligt
}

public class Booking
{
      string Namn;
      int Rum;
      Avalability Status;

      public Booking (string namn, int rum, Avalability status)
      {
            Namn = namn;
            Rum = rum;
            Status = status;

      }
}