namespace infoerettsegi_2021 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static List<int> deepTable = new List<int>();
        private static int pitCount = 0;
        private static int currentIndex = 0;

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();

            Console.ReadKey();
        }


        public static void Task6()
        {
            Console.WriteLine("6. feladat");
            if (deepTable[currentIndex] <= 0)
            {
                Console.WriteLine("Az adott helyen nincs gödör");
                return;
            }

            int startIndex = currentIndex;
            int lastIndex = currentIndex;

            while (deepTable[startIndex - 1] > 0)
            {
                startIndex--;
            }

            while (deepTable[lastIndex] > 0)
            {
                lastIndex++;
            }

            Console.WriteLine("a)");
            Console.WriteLine("A gödör kezdete: {0} méter, a gödör vége: {1} méter", startIndex + 1, lastIndex);

            int deepestIndex = startIndex;

            for (int i = startIndex; i < lastIndex; i++)
            {
                if (deepTable[deepestIndex] < deepTable[i])
                {
                    deepestIndex = i;
                }
            }

            Console.WriteLine("b)");


            bool isConstant = true;

            for (int i = startIndex + 1; i < deepestIndex; i++) // Folyamatosan nő
            {
                if (deepTable[i] < deepTable[i - 1])
                {
                    isConstant = false;
                }
            }

            for (int i = lastIndex + 1; i > deepestIndex; i--) // Folyamatosan nő
            {
                if (deepTable[i] < deepTable[i + 1])
                {
                    isConstant = false;
                }
            }


            if (!isConstant)
            {
                Console.WriteLine("Nem mélyül folyamatosan");
            } else
            {
                Console.WriteLine("Folyamatosan mélyül");
            }


            Console.WriteLine("c)");
            Console.WriteLine("A legnagyobb mélysége {0} méter", deepTable[deepestIndex]);

            int pitSum = 0;
            for (int i = startIndex; i < lastIndex; i++)
            {
                pitSum += deepTable[i] * 10;
            }

            Console.WriteLine("d)");
            Console.WriteLine("A térfogata {0} m^3", pitSum);

            Console.WriteLine("e)");
            Console.WriteLine("A vízmennyiség {0} m^3", pitSum - ((lastIndex - startIndex) * 10));
        }


        public static void Task5()
        {
            Console.WriteLine("5. feladat");
            Console.WriteLine("A gödrök száma: {0}", pitCount);
        }

        public static void Task4()
        {
            using (StreamWriter newFile = new StreamWriter("godrok.txt"))
            {
                bool startPit = false;
               

                for (int i = 1; i < deepTable.Count - 1; i++)
                {

                    if (startPit)
                    {
                        newFile.Write(deepTable[i] + " ");                      
                    }

                    if (deepTable[i] != 0 && deepTable[i - 1] == 0) // Gödör kezdete vagy vége
                    {
                        newFile.Write(deepTable[i] + " ");
                        startPit = true;
                        pitCount++;
                    }

                    if (deepTable[i] != 0 && deepTable[i + 1] == 0)
                    {
                        newFile.WriteLine("");
                        startPit = false;
                    }

                }

                newFile.Close();
            }
        }

        public static void Task3()
        {
            double tableLength = deepTable.Count;
            double zeroValue = 0;


            for (int i = 0; i < tableLength; i++)
            {
                if (deepTable[i] == 0)
                {
                    zeroValue++;
                }
            }

            double untouchedValue = (zeroValue / tableLength) * 100;


            Console.WriteLine("Az érintetlen terület aránya {0}%", Math.Round(untouchedValue, 2));
        }

        public static void Task2()
        {
            Console.WriteLine("2. feladat");
            Console.Write("Adjon meg egy távolságértéket! ");
            currentIndex = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ezen a helyen a felszín {0} méter mélyen van.", deepTable[currentIndex]);

        }

        public static void Task1()
        {
            using (StreamReader openedFile = new StreamReader("melyseg.txt"))
            {
                while (!openedFile.EndOfStream)
                {
                    deepTable.Add(Convert.ToInt32(openedFile.ReadLine()));
                }
            }

            Console.WriteLine("1. feladat.");
            Console.WriteLine("A fájl datainak száma: {0}", deepTable.Count);

        }
    }
}