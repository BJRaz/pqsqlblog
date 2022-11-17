## installation / konfig på linux:

Check

Log ind som "postgres" som root.

kør `pg_ctl start`

.. databasen skulle da gerne starte op.


## installation i vscode:

Gik ind på følgende site:

http://www.npgsql.org/efcore/

- fulgte beskrivelserne indtil den nederste sætning vedr. scaffolding:

Ville bruge kommandoen 'dotnet ef', men fik fejlen:

```bash
No executable found matching command "dotnet-ef"
```

- var nødt til at ændre i .csproj med følgende:

```xml
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
  <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.0" />
</ItemGroup>
```
- prøvede da følgende kommando:

```bash
dotnet ef dbcontext scaffold "Host=my_host;Database=my_db;Username=my_user;Password=my_pw" Npgsql.EntityFrameworkCore.PostgreSQL
```

Fejlede med "error at ORDER ..." 

Viste sig at databasen på fedora24 kørte version 8.4, som ikke understøtter "Order by" i en aggregate-funktion.



