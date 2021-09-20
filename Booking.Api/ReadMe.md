# **Booking - API demo**

## Vejledning ##
- Tilret database connection
- Udfør database migration
- Kør projektet


### Tilret database connection ###
Åben appsettings.json og tilret DefaultConnection


### Database migration
- Sæt Booking.Api som dit startup projekt.
- Kør følgende kommandoer i "Package Manager Console":
  - Add-Migration MigrationName -Project Booking.Persistance
  - Update-Database

Hvis du gerne vil se den SQL der anvendes, kan du skrive nedendstående kommandoen i "Package Manager Console":
  - Script-Migration


### Kør projektet
- Skift fra "IIS Express" til "Booking.Api"
- Start koden i "Debug"
- Prøv programmet af i Swagger og tjek data i "Microsoft SQL Server Management Studio"