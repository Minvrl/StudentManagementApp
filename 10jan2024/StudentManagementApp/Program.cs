using System;
using System.Globalization;

namespace StudentManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Abbas", "Tofiq", "Nermin","Hikmet" };
            byte[] ages = { 16, 20, 54, 73 };

            string opt;
            do
            {
                Console.WriteLine("1. Butun telebelere bax");
                Console.WriteLine("2. Telebe elave et");
                Console.WriteLine("3. Teleber uzerinde axtaris et");
                Console.WriteLine("4. Secilmis nomreli telebeni goster");
                Console.WriteLine("5. Secilmis nomreli telebeni sil");
                Console.WriteLine("0. Cix");

                Console.WriteLine("\nEmeliyyat secin:");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        for (int i = 0; i < names.Length; i++)
                            Console.WriteLine(names[i] + "-" + ages[i]);
                        break;
                    case "2":

                        string name;
                        byte age; 
                        bool hasOnlyLetter = true;

                        do
                        {
                            Console.WriteLine("Telebe adini daxil edin:");
                            name = Console.ReadLine();
                            Capitalize(ref name);
                        } while (!CheckName(name));

                        do
                        {
                            Console.WriteLine("Telebenin yasini daxil edin :");
                            string ageStr = Console.ReadLine();

                            if (byte.TryParse(ageStr, out age))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Yalniz reqem daxil etmek mumkundur!");
                            }
                        } while (true);

                        Array.Resize(ref names, names.Length + 1);
                        Array.Resize(ref ages, ages.Length + 1);
                        names[names.Length - 1] = name;
                        ages[ages.Length - 1] = age;


                        break;
                    case "3":
                        Console.Write("Axtaris deyerini daxil edin - ");
                        string search = Console.ReadLine();
                        bool found = false;  

                        for (int i = 0; i < names.Length; i++)
                        {
                            if (names[i].Contains(search))
                            {
                                Console.WriteLine(names[i]);
                                found = true;  
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Tapilmadi");
                        }

                        break;
                    case "4":
                        for (int i = 0; i < names.Length; i++)
                            Console.WriteLine(names[i] + "-" + ages[i]);

                        bool reqem = false;
                        int index=0;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Bir index daxil edin ");
                                string indexStr = Console.ReadLine();
                                index = int.Parse(indexStr);
                                reqem = true;

                            }
                            catch
                            {
                                Console.WriteLine("Yanliz reqem daxil etmek mumkundur !");
                            }

                            for (int i = 0;i<names.Length; i++)
                            {
                                if (i == index) Console.WriteLine(names[i]+ ":"+ ages[i]);
                            }

                        } while (!reqem);

                        break;
                    case "5":
                        for (int i = 0; i < names.Length; i++)
                            Console.WriteLine(names[i] +":" + ages[i] + " - " + i);

                        int num;
                        RemoveStudent(names,ages, out num);

                        break;
                    default:
                        break;
                }

            } while (opt != "0");
        }

        static bool HasOnlyLetter(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i])) return false;
            }

            return true;
        }

        static bool CheckName(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return false;

            if (name.Length >= 3 && name.Length <= 20 && HasOnlyLetter(name)) return true;
            return false;
        }

        static void Capitalize(ref string name)
        {
            char firstChar = char.ToUpper(name[0]);

            string restOfWord = name.Substring(1).ToLower();

            string capitalizedWord = firstChar + restOfWord;

            name = capitalizedWord;
        }

        static void RemoveStudent(string[] arr,byte[] ageArr, out int ind)
        {
            Console.WriteLine("Silmek istediyiniz telebenin indexini daxil edin:");

            bool validIndex = false;
            ind = -1;

            do
            {
                try
                {
                    string indexStr = Console.ReadLine();
                    ind = int.Parse(indexStr);

                    if (ind >= 0 && ind < arr.Length)
                    {
                        validIndex = true;
                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz index araliqda deyil.");
                    }
                }
                catch
                {
                    Console.WriteLine("Yanliz reqem daxil etmek mumkundur!");
                }

            } while (!validIndex);

            string[] newArr = new string[arr.Length - 1];
            byte[] newAgeArr = new byte[ageArr.Length - 1];

            int newArrIndex = 0; 

            for (int i = 0; i < arr.Length; i++)
            {
                if (i != ind) 
                {
                    newArr[newArrIndex] = arr[i];
                    newAgeArr[newArrIndex] = ageArr[i];

                    newArrIndex++; 
                }
            }

            arr = newArr;
            for (int i = 0; i < newArr.Length; i++)
            {
                Console.WriteLine(newArr[i]);
            }
        }

    }
}
