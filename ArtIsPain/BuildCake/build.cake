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

Task("Dot-Net-Unit-Tests")
    .Does(() =>
{
    VSTest("../UnitTests/bin/Debug/netcoreapp3.1/ArtIsPain.UnitTests.dll");
});

Task("Dot-Net-Deploy-Database")
  .IsDependentOn("Dot-Net-Add-Migration")
  //.IsDependentOn("Dot-Net-Unit-Tests")
  .Does(() =>
{
  var settings = new DotNetCoreEfDatabaseUpdateSettings
    {
        Context = "DataContext"
    };

    DotNetCoreEfDatabaseUpdate("../Server", settings);
});

Task("Dot-Net-Add-Migration")
  .Does(() =>
{
  DotNetCoreEfMigrationAddSettings settings = new DotNetCoreEfMigrationAddSettings{
    Context = "DataContext",
    Migration = "Deployment_" + DateTime.Now.ToString("DD_mm_YYYY")
  };

  DotNetCoreEfMigrationAdd("../Server/", settings);
});

Task("Create-Build-Artifact")
  .Does(() =>
{
  Zip("../Server/bin/Debug/netcoreapp3.0", "BuildArtifact.zip");
});

Task("Default")
    .IsDependentOn("Dot-Net-Drop-Database")
    .IsDependentOn("Dot-Net-Build")
    .IsDependentOn("Dot-Net-Deploy-Database")
    .IsDependentOn("Create-Build-Artifact")
    .Does(() =>
{
});

RunTarget(target);