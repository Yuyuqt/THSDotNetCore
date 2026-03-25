# THSDotNetCore
# Pretend I write something amazing here
some awesome description here

"Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

efcore database first (manual, auto) / code first
dotnet ef dbcontext scaffold "Server=DESKTOP-BP9A061;Database=DotNetTraining;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f
