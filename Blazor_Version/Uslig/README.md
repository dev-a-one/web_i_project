# USLIG – University, Science and Literature Information Guide

Ein interaktives Informationsportal, entwickelt mit **Blazor Server**, **Entity Framework Core** und **SQLite**.  
Die Anwendung bietet strukturierte Übersichten über **Universitäten**, **Wissenschaftler**, **Schriftsteller** und **Nobelpreisträger** – inklusive intelligenter Suchfunktion, Filtermöglichkeiten und relationaler Datenbankverknüpfungen.

---

## Projektübersicht

USLIG ist eine moderne Webanwendung, die Daten aus verschiedenen Bereichen der Wissenschaft und Literatur zentral darstellt.  
Das Projekt demonstriert den vollen Entwicklungsprozess einer datenbankgestützten Blazor-Anwendung – vom Datenmodell über Datenbankmigrationen bis hin zur UI mit Bootstrap.

**Implementierte Bereiche:**
- Universitäten (mit Logos, Ländern & Weblinks)  
- Wissenschaftler (inkl. zugehöriger Universitäten)  
- Schriftsteller (mit Werken & Erscheinungsjahren)  
- Nobelpreisträger (sortier- und durchsuchbar)  

Jede Seite verfügt über eine **debounced Suche** (250 ms), die mit dem Entity Framework interagiert und sofortige, performante Filterung ermöglicht.

---

## Verwendete Technologien

| Komponente | Beschreibung |
|-------------|---------------|
| **Blazor Server (.NET 8)** | Frontend + Backend in einer App, serverseitiges Rendering |
| **C# / .NET** | Hauptsprache und Framework |
| **Entity Framework Core** | ORM zur Datenbankanbindung |
| **SQLite** | Leichtgewichtige Datei-Datenbank (`app.db`) |
| **Bootstrap 5** | UI-Layout, responsive Design |
| **DBeaver** | Verwaltung & Dateninspektion |
| **Visual Studio 2022** | IDE für Entwicklung & Debugging |

---

## Datenbankstruktur

### Tabellen
- **Universities** → Name, Ort, Land, Logo, Webseite, Trägerschaft  
- **Scientists** → Name, Geburts-/Todesdatum  
  - *n:m-Relation* zu `Universities` über `ScientistAlmaMater`  
- **Writers** → Name, Geburts-/Todesdatum  
  - *1:n-Relation* zu `Works` (Titel, Jahr)  
- **NobelLaureates** → Jahr, Fachrichtung, Vorname, Nachname  

Die Daten wurden über eigene `INSERT`-Skripte in SQLite eingefügt.

---

## Besondere Features

-  **Debounced Live-Suche** (mit Entity Framework, 250 ms Delay)
-  **Filterung nach Ländern** (mit Flag-Emoji & Checkboxen)
-  **Saubere Entity-Beziehungen** (1:n und n:m)
-  **SQL-Injection-sicher** durch EF Core Parameterbindung
-  **Minimaler Ressourcenverbrauch** dank SQLite
-  **Responsive Design** mit Bootstrap

---

## Installation & Start

### Voraussetzungen
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) oder JetBrains Rider
- (optional) [DBeaver](https://dbeaver.io/) zur Datenbankinspektion

### Setup

```
# Repository klonen
git clone https://github.com/dev-a-one/web_i_project.git
cd uslig-blazor

# Abhängigkeiten wiederherstellen
dotnet restore

# Datenbank erstellen ( ggf. bereits vorhanden mittels app.db)
dotnet ef database update

# Anwendung starten
dotnet run
'''