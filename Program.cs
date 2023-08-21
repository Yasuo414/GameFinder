namespace GameFinder
{
    class Program
    {
        static List<string> GetInstalledGamesFromFoldersFile()
        {
            List<string> gameList = new List<string>();

            if (File.Exists("folders.txt"))
            {
                string[] folders = File.ReadAllLines("folders.txt");

                foreach (string folder in folders)
                {
                    if (Directory.Exists(folder))
                    {
                        string[] exeFiles = Directory.GetFiles(folder, ".exe", SearchOption.AllDirectories);
                        foreach (string file in exeFiles)
                        {
                            gameList.Add(file);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Soubor 'folders.txt' nebyl nalezen.");
            }
            return gameList;
        }

        static void Main(string[] args)
        {
            List<string> games = GetInstalledGamesFromFoldersFile();
            if (games.Count == 0)
            {
                Console.WriteLine("Nebyly nalezeny žádné hry.");
                return;
            }

            for (int i = 0; i < games.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {games[i]}");
            }

            Console.WriteLine("Vyberte hru (číslo hry): ");
            if (int.TryParse(Console.ReadLine(), out int selectedGameIndex) && selectedGameIndex >= 1 && selectedGameIndex <= games.Count)
            {
                Console.WriteLine($"Vybraná hra: {games[selectedGameIndex - 1]}");
            }
            else
            {
                Console.WriteLine("Neplatný výběr hry.");
            }
        }
    }
}