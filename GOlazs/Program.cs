namespace GOlazs
{
    public class Program
    {
        static int[] registers = new int[4];
        static void Main(string[] args)
        {
            ProcessFile();
        }

        // Only for unit testing.
        public static void ProcessInputFile(string? fileIdentifier = null)
        {
            ProcessFile(fileIdentifier);
        }

        static void ProcessFile(string? fileIdentifier = null)
        {
            string[] inputLines = File.ReadAllLines($"input{fileIdentifier}.txt");

            string[] registerValues = inputLines[0].Split(',');

            for (int i = 0; i < 4; i++)
            {
                registers[i] = int.Parse(registerValues[i]);
            }

            int lineIndex = 1;
            while (lineIndex < inputLines.Length)
            {
                string[] parameters = inputLines[lineIndex].Split(' ');

                string instruction = parameters[0];
                char dest = parameters[1][0];

                string src1 = parameters[2];
                string src2 = string.Empty;
                int value1, value2 = 0;

                if (IsRegister(src1))
                {
                    value1 = registers[src1[0] - 'A'];
                }
                else
                {
                    value1 = int.Parse(src1);
                }

                if (parameters.Length>3)
                {
                    src2 = parameters[3];
                    if (IsRegister(src2))
                    {
                        value2 = registers[src2[0] - 'A'];
                    }
                    else
                    {
                        value2 = int.Parse(src2);
                    }
                }

                if (instruction == "MOV")
                {
                    registers[dest - 'A'] = value1;
                }
                else if (instruction == "ADD")
                {
                    registers[dest - 'A'] = value1 + value2;
                }
                else if (instruction == "SUB")
                {
                    registers[dest - 'A'] = value1 - value2;
                }
                else if (instruction == "JNE")
                {
                    int jumpTo = int.Parse(parameters[1]);

                    if (value1 != value2)
                    {
                        lineIndex = jumpTo;
                    }
                }

                lineIndex++;
            }

            File.WriteAllText($"output{fileIdentifier}.txt", string.Join(",", registers));
        }
        static bool IsRegister(string registerName)
        {
            return registerName[0] - 'A' >= 0;
        }
    }
}