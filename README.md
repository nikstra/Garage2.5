# Garage2.5
Lexicon ASP.Net MVC5 exercise "Garage 2.5"
<pre>
Övning 14: Garage 2.5 - This isn’t even my final form
I den rafflande följetången ‘Garaget’ fortsätter äventyret men en utbyggd databas och
ytterligare funktionalitet. I ett försök att hålla oseriäsa söndagsförare ute stänger man
portarna för icke-medlemmar. För att parkera i garaget måste föraren finnas registrerad
i applikationen. För att inte tappa alla kunder så är medlemskapet gratis, och
registreringen går snabbt och enkelt. När vi ändå skriver om databasen passar vi på att
skapa en egen, normaliserad, tabell för fordonstyper (ersätter den Enum ni använde i 2.0
versionen).
Relationsdatabas
Den nya applikationen ska hantera tre entiteter: Medlem/Ägare, Fordon och Fordonstyp
(eller dess engelska motsvarigheter) . Läs igenom övrig uppgiftsbeskrivning och starta
sedan arbetet med att rita ett ER-diagram. ER-diagrammet skall godkännas av Oscar
innan ni börjar implementera .
OBS: Fordonstyperna skall seedas in i tabellen. Separat CRUD ses som en extrauppgift .
Funktionalitet
Ni har kortare tid på er med denna implementation, så det kan visa sig viktigt att
prioritera. Gör grundläggande funktionalitet och spara t.ex. kvittoutskrifter till sist.
● Medlemmar skall kunna registreras och lagras i databasen (utan koppling till fordon)
● En sökbar översiktsvy för registrerade medlemmar.
● När ett fordon parkeras skall det kopplas den medlem som parkerade den.
● När ett fordon parkeras kopplas det till sin fordonstyp i databasen via en dropdown.
● En översiktsvy för fordon med fälten: Ägare, fordonstyp, RegNum, ParkTid
● En detaljerad översiktsvy för fordon med alla fält kopplade till fordon (utom id )
● Sökfunktion för fordonstyp och registreringsnummer i båda fordonsöversikterna
● Övrig funktionalitet från Garage 2.0 t.ex. tidsstämpel och kvittovy
Taktik
Vi kommer att lägga till flera nya vyer och det är en god idé att ta några minuter för att
tänka igenom applikationens flöde och navigation. Hur passar vyerna ihop? Vart borde
man göra vad? Hur kommer applikationen att användas osv.
Garage 2.5 går alldeles utmärkt att bygga ovanpå er implementation av 2.0 men arbetet
är inte lika vänligt för att dela upp. Åtminstone första halvan av projektet är det en god
idé att alla arbetar tillsammans på samma dator så att alla sedan utgår från samma
databasmigrationer etc.
Parprogrammering (eller trillingprogrammering?)
Turas om att sitta vid tangentbordet och byt regelbundet t.ex. var 15e minut. Den som
sitter vid tangentbordet skriver, medan de andra berättar vad denne skall skriva ( förare
och navigatörer ). Detta är ett vedertaget arbetssätt för två programmerare på en dator
och väl utfört är det effektivare än om de skulle arbetat på separata datorer - extra sant
i projekt som inte lämpar sig väl för parallell utveckling.
Tips: Efter att ni skrivit era nya modeller och migrerat till databasen är det en god idé att
scaffolda en ny fordonscontroller med ett annat namn (t.ex. Fordon2Controller ) för att
använda som referens när ni bygger ut era gamla vyer med dropdowns och relationer.
</pre>
