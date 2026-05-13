using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuuxi.SurePath.DAL.Migrations
{
    public partial class SeedTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "surepath",
                table: "TranslationKeys",
                columns: new[] { "Key", "Description" },
                values: new object[,]
                {
                    { "web.title",                             "Page title on the web site" },
                    { "web.welcome.title",                     "Main heading on the web front page" },
                    { "web.welcome.description",               "Intro text on the web front page" },
                    { "web.portal.link",                       "Link text to the portal" },
                    { "web.showkeys",                          "Button label: show translation keys" },
                    { "web.hidekeys",                          "Button label: hide translation keys" },
                    { "portal.login.title",                    "Login page heading" },
                    { "portal.login.username",                 "Username field label" },
                    { "portal.login.password",                 "Password field label" },
                    { "portal.login.submit",                   "Login button label" },
                    { "portal.login.error.invalid",            "Error shown for wrong credentials" },
                    { "portal.login.error.inactive",           "Error shown when account is inactive" },
                    { "portal.profile.title",                  "Profile page heading" },
                    { "portal.profile.firstname",              "First name field label" },
                    { "portal.profile.lastname",               "Last name field label" },
                    { "portal.profile.country",                "Country field label" },
                    { "portal.profile.save",                   "Save button label on profile page" },
                    { "portal.profile.saved",                  "Success message after saving profile" },
                    { "portal.nav.logout",                     "Logout navigation link" },
                    { "portal.nav.login",                      "Login navigation link" },
                    { "backend.nav.users",                     "Users link in admin nav" },
                    { "backend.nav.translations",              "Translations link in admin nav" },
                    { "backend.users.title",                   "Users list page heading" },
                    { "backend.users.col.id",                  "Id column header" },
                    { "backend.users.col.name",                "Name column header" },
                    { "backend.users.col.country",             "Country column header" },
                    { "backend.users.col.status",              "Status column header" },
                    { "backend.users.status.active",           "Active status badge" },
                    { "backend.users.status.inactive",         "Inactive status badge" },
                    { "backend.users.details",                 "Details button label" },
                    { "backend.users.details.notfound",        "Message when user is not found" },
                    { "backend.users.details.back",            "Back button label" },
                    { "backend.users.details.contact",         "Contact card header" },
                    { "backend.users.details.id",              "Id label in contact card" },
                    { "backend.users.details.firstname",       "First name label in contact card" },
                    { "backend.users.details.lastname",        "Last name label in contact card" },
                    { "backend.users.details.country",         "Country label in contact card" },
                    { "backend.users.details.status",          "Status label in contact card" },
                    { "backend.users.details.loginhistory",    "Login history section heading" },
                    { "backend.users.details.nologs",          "Message when no login logs exist" },
                    { "backend.users.loginlog.time",           "Time column in login log table" },
                    { "backend.users.loginlog.provider",       "Provider column in login log table" },
                    { "backend.users.loginlog.key",            "Key column in login log table" },
                    { "backend.users.loginlog.result",         "Result column in login log table" },
                    { "backend.users.loginlog.ok",             "OK badge in login log" },
                    { "backend.users.loginlog.fail",           "Fail badge in login log" },
                    { "backend.translations.title",            "Translations list page heading" },
                    { "backend.translations.newkey",           "New key card header" },
                    { "backend.translations.key.placeholder",  "Placeholder for new key input" },
                    { "backend.translations.desc.placeholder", "Placeholder for description input" },
                    { "backend.translations.addkey",           "Add key button label" },
                    { "backend.translations.col.key",          "Key column header in translations list" },
                    { "backend.translations.col.description",  "Description column header in translations list" },
                    { "backend.translations.edit",             "Edit button label" },
                    { "backend.translations.saveall",          "Save all button on edit page" },
                    { "backend.translations.saved",            "Success message after saving translations" },
                });

            migrationBuilder.InsertData(
                schema: "surepath",
                table: "Translations",
                columns: new[] { "LanguageCode", "Key", "Value" },
                values: new object[,]
                {
                    { "da", "web.title",                             "SurePath" },
                    { "en", "web.title",                             "SurePath" },
                    { "de", "web.title",                             "SurePath" },
                    { "da", "web.welcome.title",                     "Velkommen til SurePath" },
                    { "en", "web.welcome.title",                     "Welcome to SurePath" },
                    { "de", "web.welcome.title",                     "Willkommen bei SurePath" },
                    { "da", "web.welcome.description",               "Din komplette platform til sikker håndtering af data og processer." },
                    { "en", "web.welcome.description",               "Your complete platform for secure management of data and processes." },
                    { "de", "web.welcome.description",               "Ihre vollständige Plattform für die sichere Verwaltung von Daten und Prozessen." },
                    { "da", "web.portal.link",                       "Gå til Portal" },
                    { "en", "web.portal.link",                       "Go to Portal" },
                    { "de", "web.portal.link",                       "Zum Portal" },
                    { "da", "web.showkeys",                          "Vis nøgler" },
                    { "en", "web.showkeys",                          "Show keys" },
                    { "de", "web.showkeys",                          "Schlüssel anzeigen" },
                    { "da", "web.hidekeys",                          "Skjul nøgler" },
                    { "en", "web.hidekeys",                          "Hide keys" },
                    { "de", "web.hidekeys",                          "Schlüssel verbergen" },
                    { "da", "portal.login.title",                    "Log ind" },
                    { "en", "portal.login.title",                    "Log in" },
                    { "de", "portal.login.title",                    "Anmelden" },
                    { "da", "portal.login.username",                 "Brugernavn" },
                    { "en", "portal.login.username",                 "Username" },
                    { "de", "portal.login.username",                 "Benutzername" },
                    { "da", "portal.login.password",                 "Adgangskode" },
                    { "en", "portal.login.password",                 "Password" },
                    { "de", "portal.login.password",                 "Passwort" },
                    { "da", "portal.login.submit",                   "Log ind" },
                    { "en", "portal.login.submit",                   "Log in" },
                    { "de", "portal.login.submit",                   "Anmelden" },
                    { "da", "portal.login.error.invalid",            "Ukendt brugernavn eller forkert adgangskode." },
                    { "en", "portal.login.error.invalid",            "Unknown username or incorrect password." },
                    { "de", "portal.login.error.invalid",            "Unbekannter Benutzername oder falsches Passwort." },
                    { "da", "portal.login.error.inactive",           "Din konto er ikke aktiv." },
                    { "en", "portal.login.error.inactive",           "Your account is not active." },
                    { "de", "portal.login.error.inactive",           "Ihr Konto ist nicht aktiv." },
                    { "da", "portal.profile.title",                  "Min profil" },
                    { "en", "portal.profile.title",                  "My profile" },
                    { "de", "portal.profile.title",                  "Mein Profil" },
                    { "da", "portal.profile.firstname",              "Fornavn" },
                    { "en", "portal.profile.firstname",              "First name" },
                    { "de", "portal.profile.firstname",              "Vorname" },
                    { "da", "portal.profile.lastname",               "Efternavn" },
                    { "en", "portal.profile.lastname",               "Last name" },
                    { "de", "portal.profile.lastname",               "Nachname" },
                    { "da", "portal.profile.country",                "Land" },
                    { "en", "portal.profile.country",                "Country" },
                    { "de", "portal.profile.country",                "Land" },
                    { "da", "portal.profile.save",                   "Gem ændringer" },
                    { "en", "portal.profile.save",                   "Save changes" },
                    { "de", "portal.profile.save",                   "Änderungen speichern" },
                    { "da", "portal.profile.saved",                  "Dine oplysninger er gemt." },
                    { "en", "portal.profile.saved",                  "Your information has been saved." },
                    { "de", "portal.profile.saved",                  "Ihre Informationen wurden gespeichert." },
                    { "da", "portal.nav.logout",                     "Log ud" },
                    { "en", "portal.nav.logout",                     "Log out" },
                    { "de", "portal.nav.logout",                     "Abmelden" },
                    { "da", "portal.nav.login",                      "Log ind" },
                    { "en", "portal.nav.login",                      "Log in" },
                    { "de", "portal.nav.login",                      "Anmelden" },
                    { "da", "backend.nav.users",                     "Brugere" },
                    { "en", "backend.nav.users",                     "Users" },
                    { "de", "backend.nav.users",                     "Benutzer" },
                    { "da", "backend.nav.translations",              "Oversættelser" },
                    { "en", "backend.nav.translations",              "Translations" },
                    { "de", "backend.nav.translations",              "Übersetzungen" },
                    { "da", "backend.users.title",                   "Brugere" },
                    { "en", "backend.users.title",                   "Users" },
                    { "de", "backend.users.title",                   "Benutzer" },
                    { "da", "backend.users.col.id",                  "Id" },
                    { "en", "backend.users.col.id",                  "Id" },
                    { "de", "backend.users.col.id",                  "Id" },
                    { "da", "backend.users.col.name",                "Navn" },
                    { "en", "backend.users.col.name",                "Name" },
                    { "de", "backend.users.col.name",                "Name" },
                    { "da", "backend.users.col.country",             "Land" },
                    { "en", "backend.users.col.country",             "Country" },
                    { "de", "backend.users.col.country",             "Land" },
                    { "da", "backend.users.col.status",              "Status" },
                    { "en", "backend.users.col.status",              "Status" },
                    { "de", "backend.users.col.status",              "Status" },
                    { "da", "backend.users.status.active",           "Aktiv" },
                    { "en", "backend.users.status.active",           "Active" },
                    { "de", "backend.users.status.active",           "Aktiv" },
                    { "da", "backend.users.status.inactive",         "Inaktiv" },
                    { "en", "backend.users.status.inactive",         "Inactive" },
                    { "de", "backend.users.status.inactive",         "Inaktiv" },
                    { "da", "backend.users.details",                 "Detaljer" },
                    { "en", "backend.users.details",                 "Details" },
                    { "de", "backend.users.details",                 "Details" },
                    { "da", "backend.users.details.notfound",        "Bruger ikke fundet." },
                    { "en", "backend.users.details.notfound",        "User not found." },
                    { "de", "backend.users.details.notfound",        "Benutzer nicht gefunden." },
                    { "da", "backend.users.details.back",            "Tilbage" },
                    { "en", "backend.users.details.back",            "Back" },
                    { "de", "backend.users.details.back",            "Zurück" },
                    { "da", "backend.users.details.contact",         "Kontaktoplysninger" },
                    { "en", "backend.users.details.contact",         "Contact information" },
                    { "de", "backend.users.details.contact",         "Kontaktinformationen" },
                    { "da", "backend.users.details.id",              "Id" },
                    { "en", "backend.users.details.id",              "Id" },
                    { "de", "backend.users.details.id",              "Id" },
                    { "da", "backend.users.details.firstname",       "Fornavn" },
                    { "en", "backend.users.details.firstname",       "First name" },
                    { "de", "backend.users.details.firstname",       "Vorname" },
                    { "da", "backend.users.details.lastname",        "Efternavn" },
                    { "en", "backend.users.details.lastname",        "Last name" },
                    { "de", "backend.users.details.lastname",        "Nachname" },
                    { "da", "backend.users.details.country",         "Land" },
                    { "en", "backend.users.details.country",         "Country" },
                    { "de", "backend.users.details.country",         "Land" },
                    { "da", "backend.users.details.status",          "Status" },
                    { "en", "backend.users.details.status",          "Status" },
                    { "de", "backend.users.details.status",          "Status" },
                    { "da", "backend.users.details.loginhistory",    "Login historik" },
                    { "en", "backend.users.details.loginhistory",    "Login history" },
                    { "de", "backend.users.details.loginhistory",    "Anmeldeverlauf" },
                    { "da", "backend.users.details.nologs",          "Ingen login forsøg registreret." },
                    { "en", "backend.users.details.nologs",          "No login attempts recorded." },
                    { "de", "backend.users.details.nologs",          "Keine Anmeldeversuche registriert." },
                    { "da", "backend.users.loginlog.time",           "Tidspunkt" },
                    { "en", "backend.users.loginlog.time",           "Time" },
                    { "de", "backend.users.loginlog.time",           "Zeitpunkt" },
                    { "da", "backend.users.loginlog.provider",       "Udbyder" },
                    { "en", "backend.users.loginlog.provider",       "Provider" },
                    { "de", "backend.users.loginlog.provider",       "Anbieter" },
                    { "da", "backend.users.loginlog.key",            "Nøgle" },
                    { "en", "backend.users.loginlog.key",            "Key" },
                    { "de", "backend.users.loginlog.key",            "Schlüssel" },
                    { "da", "backend.users.loginlog.result",         "Resultat" },
                    { "en", "backend.users.loginlog.result",         "Result" },
                    { "de", "backend.users.loginlog.result",         "Ergebnis" },
                    { "da", "backend.users.loginlog.ok",             "OK" },
                    { "en", "backend.users.loginlog.ok",             "OK" },
                    { "de", "backend.users.loginlog.ok",             "OK" },
                    { "da", "backend.users.loginlog.fail",           "Fejl" },
                    { "en", "backend.users.loginlog.fail",           "Fail" },
                    { "de", "backend.users.loginlog.fail",           "Fehler" },
                    { "da", "backend.translations.title",            "Oversættelser" },
                    { "en", "backend.translations.title",            "Translations" },
                    { "de", "backend.translations.title",            "Übersetzungen" },
                    { "da", "backend.translations.newkey",           "Ny nøgle" },
                    { "en", "backend.translations.newkey",           "New key" },
                    { "de", "backend.translations.newkey",           "Neuer Schlüssel" },
                    { "da", "backend.translations.key.placeholder",  "f.eks. nav.home" },
                    { "en", "backend.translations.key.placeholder",  "e.g. nav.home" },
                    { "de", "backend.translations.key.placeholder",  "z.B. nav.home" },
                    { "da", "backend.translations.desc.placeholder", "Beskrivelse (valgfri)" },
                    { "en", "backend.translations.desc.placeholder", "Description (optional)" },
                    { "de", "backend.translations.desc.placeholder", "Beschreibung (optional)" },
                    { "da", "backend.translations.addkey",           "Tilføj nøgle" },
                    { "en", "backend.translations.addkey",           "Add key" },
                    { "de", "backend.translations.addkey",           "Schlüssel hinzufügen" },
                    { "da", "backend.translations.col.key",          "Nøgle" },
                    { "en", "backend.translations.col.key",          "Key" },
                    { "de", "backend.translations.col.key",          "Schlüssel" },
                    { "da", "backend.translations.col.description",  "Beskrivelse" },
                    { "en", "backend.translations.col.description",  "Description" },
                    { "de", "backend.translations.col.description",  "Beschreibung" },
                    { "da", "backend.translations.edit",             "Rediger" },
                    { "en", "backend.translations.edit",             "Edit" },
                    { "de", "backend.translations.edit",             "Bearbeiten" },
                    { "da", "backend.translations.saveall",          "Gem alle" },
                    { "en", "backend.translations.saveall",          "Save all" },
                    { "de", "backend.translations.saveall",          "Alle speichern" },
                    { "da", "backend.translations.saved",            "Oversættelser gemt." },
                    { "en", "backend.translations.saved",            "Translations saved." },
                    { "de", "backend.translations.saved",            "Übersetzungen gespeichert." },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM [surepath].[Translations]
                WHERE [Key] IN (
                    'web.title','web.welcome.title','web.welcome.description','web.portal.link',
                    'web.showkeys','web.hidekeys',
                    'portal.login.title','portal.login.username','portal.login.password','portal.login.submit',
                    'portal.login.error.invalid','portal.login.error.inactive',
                    'portal.profile.title','portal.profile.firstname','portal.profile.lastname',
                    'portal.profile.country','portal.profile.save','portal.profile.saved',
                    'portal.nav.logout','portal.nav.login',
                    'backend.nav.users','backend.nav.translations',
                    'backend.users.title','backend.users.col.id','backend.users.col.name',
                    'backend.users.col.country','backend.users.col.status',
                    'backend.users.status.active','backend.users.status.inactive',
                    'backend.users.details','backend.users.details.notfound','backend.users.details.back',
                    'backend.users.details.contact','backend.users.details.id',
                    'backend.users.details.firstname','backend.users.details.lastname',
                    'backend.users.details.country','backend.users.details.status',
                    'backend.users.details.loginhistory','backend.users.details.nologs',
                    'backend.users.loginlog.time','backend.users.loginlog.provider',
                    'backend.users.loginlog.key','backend.users.loginlog.result',
                    'backend.users.loginlog.ok','backend.users.loginlog.fail',
                    'backend.translations.title','backend.translations.newkey',
                    'backend.translations.key.placeholder','backend.translations.desc.placeholder',
                    'backend.translations.addkey','backend.translations.col.key',
                    'backend.translations.col.description','backend.translations.edit',
                    'backend.translations.saveall','backend.translations.saved'
                )");

            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "web.title");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "web.welcome.title");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "web.welcome.description");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "web.portal.link");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "web.showkeys");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "web.hidekeys");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.login.title");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.login.username");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.login.password");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.login.submit");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.login.error.invalid");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.login.error.inactive");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.profile.title");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.profile.firstname");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.profile.lastname");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.profile.country");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.profile.save");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.profile.saved");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.nav.logout");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "portal.nav.login");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.nav.users");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.nav.translations");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.title");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.col.id");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.col.name");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.col.country");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.col.status");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.status.active");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.status.inactive");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.notfound");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.back");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.contact");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.id");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.firstname");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.lastname");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.country");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.status");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.loginhistory");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.details.nologs");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.loginlog.time");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.loginlog.provider");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.loginlog.key");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.loginlog.result");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.loginlog.ok");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.users.loginlog.fail");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.title");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.newkey");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.key.placeholder");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.desc.placeholder");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.addkey");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.col.key");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.col.description");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.edit");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.saveall");
            migrationBuilder.DeleteData(schema: "surepath", table: "TranslationKeys", keyColumn: "Key", keyValue: "backend.translations.saved");
        }
    }
}
