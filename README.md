
# Quadient technical test

The goal is to return the closest suggestions from a list of words based on:
-  Number of character differences
- Closest word length
- Alphabetical orde

More info [here](pdf/test.pdf)


## Run Locally

Need NET SDK 8 or newer

Clone the project

```bash
  git clone https://github.com/marieesss/technical-test-quadient.git
```

Go to the project directory

```bash
  cd technical-test-quadient
```

Start

```bash
  dotnet run dotnet run <term> <numberOfSuggestions> <choice1> <choice2> <choice3> ...
```

Example 
```bash
  dotnet run gros 2 gros gras graisse go ros gro
```

