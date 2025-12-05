# ef.sh
#!/bin/bash
dotnet ef "$@" --startup-project WebApp\\WebApp --project Infrastructure -c AppDbContext

read -p "Press any key to continue"