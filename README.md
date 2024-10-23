https://tuyaportfolio.azurewebsites.net
# Portfolio Project - .NET Developer Portfolio

## Introduktion
Detta är mitt **Utvecklarportföljprojekt** som jag byggt självständigt som en del av kursen Projekt 2. Portföljen är byggd med [teknologin du använt (t.ex. Razor Pages, MVC, React)] och API:t är byggt med .NET Core och REST-principer.

## API Beskrivning
API:t är byggt för att visa information om mina tidigare projekt. Det är en **RESTful API** som kan användas för att hämta projektinformation som projektnamn, teknikstack, datum och en kort beskrivning av varje projekt.

### API Endpoints
| Metod  | URL                    | Funktionalitet                                       |
|--------|------------------------|-----------------------------------------------------|
| `GET`  | `/api/projects`         | Hämta alla projekt                                  |
| `GET`  | `/api/projects/{id}`    | Hämta ett enskilt projekt baserat på ID             |
| `POST` | `/api/projects`         | Lägg till ett nytt projekt                          |
| `PUT`  | `/api/projects/{id}`    | Uppdatera information om ett specifikt projekt      |
| `DELETE` | `/api/projects/{id}`  | Radera ett projekt                                  |

### Databasstruktur (Entiteter)
Här är en beskrivning av de viktigaste entiteterna som används i API:t.

#### Project Entity
```csharp
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TechStack { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}

Metoder och Teknologier
I skapandet av projektet har jag använt följande verktyg och teknologier:

ASP.NET Core: Back-end utveckling
Entity Framework Core: För databasinteraktion
SQL Server: Databashantering
NUnit: Enhetstester för API-metoder
React (eller annan front-end stack): För front-end delen av portföljen
Git och GitHub: Versionshantering och koddelning
Azure: Hosting av API
och distribution av webbplatsen
