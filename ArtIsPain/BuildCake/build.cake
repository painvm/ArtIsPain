#addin "Cake.Npm"
#addin "Cake.DotNetCoreEf"

var target = Argument("target", "Default");
bool dropDatabase = Argument("Drop-Database", false);

Task("Dot-Net-Build")
.IsDependentOn("Dot-Net-Restore-Packages")
.IsDependentOn("Angular-Restore-Packages")
  .Does(() =>
{
  DotNetCoreBuild("../../ArtIsPain.sln");
});

Task("Dot-Net-Restore-Packages")
    .Does(() =>
{
    DotNetCoreRestore("../../ArtIsPain.sln");
});

Task("Angular-Restore-Packages")
  .Does(() =>
{
  var settings = new NpmInstallSettings();

        settings.LogLevel = NpmLogLevel.Info;
        settings.WorkingDirectory = "../Client";
        settings.Production = false;

        NpmInstall(settings);
});


Task("Dot-Net-Drop-Database")
  .Does(() =>
{
  if(dropDatabase){
    var settings = new DotNetCoreEfDatabaseDropSettings
    {
        Context = "DataContext",
        Force = true
    };

    DotNetCoreEfDatabaseDrop("../Server", settings);
  }
});

Task("Dot-Net-Deploy-Database")
  .Does(() =>
{
  var settings = new DotNetCoreEfDatabaseUpdateSettings
    {
        Context = "DataContext"
    };

    DotNetCoreEfDatabaseUpdate("../Server", settings);
});

Task("Default")
    .IsDependentOn("Dot-Net-Drop-Database")
    .IsDependentOn("Dot-Net-Build")
    .IsDependentOn("Dot-Net-Deploy-Database")
    .Does(() =>
{
});

RunTarget(target);