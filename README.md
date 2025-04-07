# Flag Explorer Setup

This project was created using .netCore.

# Software required
 Download and install docker from this [link](https://www.docker.com/products/docker-desktop/). This is required to run the unit and integration tests. 

 Download and install [MS SQL Server Management studios v18](https://go.microsoft.com/fwlink/?linkid=2088649)  

# Code Download

The code can be downloaded from this repository [Backend Code](https://github.com/yaasiercode2025/FlagExplorerBackend)


### Setting up the Solution

Open VS(Visual Studio 2022) and then select the 'FlagExplorer.sln' from the folder where the code has been downloaded to.

Build the solution and ensure that all the NuGet packages has been restored.

Change the (FEConnection) connection string  in the FlagExplorer.Api to point to the local sql server instance that was installed. The 'Initial Catalog' is 'FlagExplorerDB' which is already part of the connection string.

#### Package Manager Console command

In VS(Visual Studio 2022) open the PMC(Package Manager Console) and select the 'FlagExplorer.Api' as a default project. 

Execute the following commands 

- Add-Migration -Name {SeedData} -StartupProject "FlagExplorer.Api" -Project   "FlagExplorer.Infrastructure" -Context "FlagExplorerContext"

- Update-Database

This will create the database(FlagExplorerDB) and add the seed data to the country table.

## Running the code
 Ensure that the 'FlagExplorer.Api' is set as the 'Startup' project and run the application.

 The swagger endpoints (http://localhost:5011/swagger/index.html) will appear in the browser. 
 - http://localhost:5011/countries (Returns all countries)
 - http://localhost:5011/countries/Italy (Returns country details for Italy)


## Running Unit and Integration tests

Open the Docker Desktop application and wait until the Docker Engine starts.

In the VS(Visual Studio 2022) solution right click on the 'FlagExplorer.Testing' project and then click on 'Run Tests'. 

A temporary test container will be created in the (Docker Desktop Application) under containers, for the test to execute. Once the tests are finish it will disappear.  

## CI/CD pipeline

The CI/CD pipeline can be accessed through this [link](https://github.com/yaasiercode2025/FlagExplorerBackend/actions/runs/14266900927)  

Click on the re-run icon on the left and the click on the 'Re-run jobs' button in the popup.

