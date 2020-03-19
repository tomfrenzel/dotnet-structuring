# Usage

## Debug the Program
```sh
cd /src/dotnet-structuring.console/
dotnet run new -h
```
## Build & Run the Program
1. Run `build.bat` from the root directory of this repo
2. Go to /artifacts/console
3. Execute `dotnet-structuring.console.exe` from the command line
   
### The following options a available
|Option               |Description                                      |
|---------------------|-------------------------------------------------|
|-template *template* |  Choose a Template of the 'dotnet new' command  |
|  -name *name*       |     Name of the Project being created           |
|  -output *output*   |     Output Directory                            |
|  --artifacts        |     Create artifacts Directory                  |
|  --build            |     Create build Directory                      |
|  --docs             |     Create docs Directory                       |
|  --lib              |     Create lib Directory                        |
|  --samples          |     Create samples Directory                    |
|  --packages         |     Create packages Directory                   |
|  --test             |     Create test Directory                       |
