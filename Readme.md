To run the project make sure the following:

- Configure visual studio to run multiple startup projects 
	right click on the solution -> properties -> check "multiple startup projects", then set action = "start" for all the three projects
- Open ocelot.json in StudentApiGateway project -> Change the ports in "Routes":"DownstreamHostAndPorts":"Port". Try to run each project individually to know the right ports.
- Run the projects