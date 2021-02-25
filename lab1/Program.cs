/*
Суть игры:
Аналог классической игры "Виселица", но без графической реализации. Нужно просто угадать слово за
отведённое количество попыток.
Есть вариант самому вводить слово, но и можно и воспользоваться уже закотовленными словами
*/

using System;
using System.IO;
using System.Collections.Generic;


namespace lab1
{
    class Program
    {
        static bool check_input(string word)
        {
            if (word.Length < 3) return false;
            word = word.ToLower();
            foreach (char symbol in word)
            {
                if ((symbol < 'а' || symbol > 'я') && symbol != 'ё') return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string path = @"D:\study\isp\lab1\word_list.txt";
            Console.WriteLine("Добро пожаловать в игру \"Виселица aka Угадай слово\"!\n");
            do
            {
                int choice = -1;
                Console.WriteLine("Выберите режим игры: ");
                Console.WriteLine("1) Ввести слово.");
                Console.WriteLine("2) Случайное слово из набора слов.\n");
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Ошибка ввода! Введение корректное число (1 или 2)!");
                }

                string word = "дефолт";

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите ваше слово (от 3 букв, содержащее только русские буквы без пробелов). Все буквы будут преобразованы к строчным: \n");
                        word = Console.ReadLine();
                        word = word.ToLower();
                        while (!check_input(word))
                        {
                            Console.WriteLine("Ошибка ввода! Введите корректное слово!");
                            word = Console.ReadLine();
                            word = word.ToLower();
                        }
                        break;
                    case 2:
                        List<string> words = new List<string>();
                        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                        {
                            string current_word;
                            while ((current_word = sr.ReadLine()) != null)
                            {
                                words.Add(current_word);
                            }
                        }
                        Random random = new Random();
                        word = words[random.Next(words.Count)];
                        break;
                    default: break;
                }

                int remain = word.Length;
                int lifes = remain;
                string current = new string('*', word.Length);
                bool[] used = new bool[remain];
                Console.Clear();

                while (remain > 0 && lifes > 0)
                {
                    Console.WriteLine($"Загаданное слово. Осталось попыток: {lifes}");
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine(current);
                    Console.WriteLine(new string('-', 30));


                    Console.WriteLine($"Введите предполагаемую букву слова (русская буква). Осталось попыток: {lifes} ");

                    char letter;
                    while (!char.TryParse(Console.ReadLine().ToLower(), out letter) || ((letter < 'a' || letter > 'я') && letter != 'ё'))
                    {
                        Console.WriteLine("Ошибка ввода! Введение корректную русскую букву!\n");
                    }

                    Console.WriteLine(letter);

                    bool answered = false;

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == letter && !used[i])
                        {
                            answered = true;
                            char[] str = current.ToCharArray();
                            str[i] = letter;
                            current = new string(str);
                            remain--;
                            used[i] = true;
                        }
                    }

                    if (!answered) lifes--;

                    Console.Clear();
                }

                if (lifes == 0 && remain > 0)
                {
                    Console.WriteLine("YOU LOSE\n\n\n");
                    Console.WriteLine($"Было загадано слово {word}");
                    Console.WriteLine($"Вы не отгадали {remain} букв(-ы).");
                }

                else
                {
                    Console.WriteLine("YOU WIN\n\n\n");
                    Console.WriteLine($"Было загадано слово \"{word}\"");
                }

                Console.WriteLine("Желаете сыграть ещё раз? (y / N)");
                char answ;
                while (!char.TryParse(Console.ReadLine(), out answ) || (answ != 'y' && answ != 'N'))
                {
                    Console.WriteLine("Неверный ввод! Повторите попытку");
                }
                if (answ == 'N') return;
                Console.Clear();
            } while (true);
        }
    }
}
