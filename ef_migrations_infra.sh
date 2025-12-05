# ef.sh
#!/bin/bash
dotnet ef "$@" --startup-project WebApp\\WebApp --project Infrastructure --output-dir Persistence\\Migrations -c AppDbContext

read -p "Press any key to continue"