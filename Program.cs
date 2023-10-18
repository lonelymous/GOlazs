namespace GOlázs
{
    public class Program
    {
        static int[] registers = new int[4];
        static void Main(string[] args)
        {
            // Feájl beolvasása
            string[] inputData = File.ReadAllLines("input3.txt");

            // Regiszter értékek inicializálása
            string[] registerValues = inputData[0].Split(',');
            
            // Regiszterek értékeinek megadása
            for (int i = 0; i < registers.Length; i++)
            {
                registers[i] = int.Parse(registerValues[i]);
            }
            // Fájl végig olvasása | feldolgozása
            int lineIndex = 1;
            while (lineIndex < inputData.Length)
            {
                Console.WriteLine($"lineIndex:\t{lineIndex}");
                Console.WriteLine($"line:\t{inputData[lineIndex]}");

                PrintRegisters();

                string[] parameters = inputData[lineIndex].Split(' ');

                string command = parameters[0].ToLower();

                int destinationIndex = OliverTanaraEgyGeci(parameters[1]);
                int sourceIndex = OliverTanaraEgyGeci(parameters[2]);
                int parameter = 0;

                Console.WriteLine("destinationIndex");
                Console.WriteLine(destinationIndex);
                Console.WriteLine("sourceIndex");
                Console.WriteLine(sourceIndex);

                if (parameters.Length > 3)
                {
                    parameter = OliverTanaraEgyGeci(parameters[3]);
                }

                Console.WriteLine("parameter");
                Console.WriteLine(parameter);

                bool returnToLine = false;

                if (command == "add") {
                    registers[destinationIndex] = registers[sourceIndex] + parameter;
                } else if (command == "mov") {
                    registers[destinationIndex] = registers[sourceIndex];
                } else if (command == "sub") {
                    registers[destinationIndex] = registers[sourceIndex] - parameter;
                } else if (command == "jne") {
                    if (registers[sourceIndex] != parameter)
                    {
                        Console.WriteLine("returnToLine:\tTrue");
                        returnToLine = true;
                    }
                } else {
                    Console.WriteLine("Cringe geci vagy ha kibugoltatod! :D");
                }

                if (returnToLine) {
                    lineIndex = destinationIndex + 1;
                } else {
                    lineIndex++;
                }
            }

            File.WriteAllText("output3.txt", $"{registers[0]},{registers[1]}, {registers[2]}, {registers[3]}");
        }

        static int OliverTanaraEgyGeci(string geci)
        {
            // System.Console.WriteLine(geci);
            // System.Console.WriteLine("geci");
            // System.Console.WriteLine(int.Parse("B"));
            // System.Console.WriteLine(int.Parse("1"));
            // System.Console.WriteLine(int.Parse("10"));
            try
            {
                if (geci[0] - 'A' < 0)
                {
                    return int.Parse(geci);
                }
                return geci[0] - 'A';
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
            return 0;
        }

        static void PrintRegisters()
        {
            Console.WriteLine($"A:{registers[0]}\tB:{registers[1]}\tC:{registers[2]}\tD:{registers[3]}\t");
        }
    }
}