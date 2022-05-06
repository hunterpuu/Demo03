# Demo03
Demo .Net core 5.0 connect to MS SQL and use docker

How to use
1. Pull code to your computer
2. Restore database to your MS SQL (backup in folder DB\Mobile.bak)
3. Edit appsetting.json => "Server=yourserver; database=Mobile; uid=youraccount; pwd=yourpasword"
4. Run docker build --tag yourimagename .
5. Run docker run –d --name yourcontainername --env ASPNETCORE_ENVIRONMENT=Development -p 80:80 yourimagename
