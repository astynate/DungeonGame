using DungeonGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Events
{
    public class GoblinsEvent : Event
    {
        private class Goblin
        {
            public static string Picture { get; } = 
                """
                             ,      ,
                            /(.-""-.)\
                        |\  \/      \/  /|
                        | \ / =.  .= \ / |
                        \( \   o\/o   / )/
                         \_, '-/  \-' ,_/
                           /   \__/   \
                           \ \__/\__/ /
                         ___\ \|--|/ /___
                       /`    \      /    `\
                      /       '----'       \
                """;
            public int MaxHealth { get; init; } = Random.Shared.Next(4, 8);
            public int HealthPoints { get; private set; }
            public int Coins { get; private set; } = Random.Shared.Next(1, 6);

            public Goblin()
            {
                HealthPoints = MaxHealth;
            }

            public void GetDamage()
            {
                if (HealthPoints > 0)
                    HealthPoints--;
            }

            public void LoseCoin()
            {
                if (Coins > 0)
                    Coins--;
            }
        }

        private void Drink(Player player, Goblin goblin)
        {
            const int DELAY = 500;

            Thread.Sleep(DELAY);
            Console.WriteLine("Бармен наливает две кружки чего-то крепкого");
            int goblin_dice = Random.Shared.Next(1, 21);
            Thread.Sleep(DELAY);
            Console.WriteLine($"Гоблин делает глоток: {goblin_dice}");
            int player_dice = Random.Shared.Next(1, 21);
            Thread.Sleep(DELAY);
            Console.WriteLine($"Вы делаете глоток: {player_dice}");
            Console.WriteLine();
            Thread.Sleep(DELAY);
            
            if (goblin_dice > player_dice) 
            {
                Console.WriteLine("Вы чуствуете себя не хорошо: -1хп");
                player.GetDamage(1);
            }
            else if (goblin_dice < player_dice) 
            {
                Console.WriteLine("Гоблин пошатнулся");
                goblin.GetDamage();
            }
            else
                Console.WriteLine("- Хорошо пошла! - ухмыляется гоблин");
        }

        public override void EventBody(Player player)
        {
            Console.WriteLine("Вы заходите в бар");
            Helper.PrintDevide();

            Goblin goblin = new Goblin();
            Console.WriteLine("Вам машет гоблин у барной стойки");
            Console.WriteLine();
            Console.WriteLine(Goblin.Picture);
            Console.WriteLine();
            Console.WriteLine("- Садись! Первый раунд за мой счет");
            Console.WriteLine();
            Console.WriteLine("1 - присоединиться, 2 - отказаться");

            string? userAnswer = Console.ReadLine();
            Helper.PrintDevide();
            if (userAnswer != "1") 
            {
                Console.WriteLine("Вы вежливо отказываетесь и проводите остаток вечера в одиночестве");
                Helper.PrintDevide();
                Console.WriteLine(player);
                return;
            }
            Console.WriteLine("- Вот это по нашему! - воскликнул гоблин, кладя говнокоин на стойку");

            goblin.LoseCoin();
            int bank = 1;
            while (true)
            {
                Helper.PrintDevide();
                Console.WriteLine($"На стойке {bank} говнокоинов");
                Console.WriteLine();
                Drink(player, goblin);

                if (goblin.HealthPoints <= 0)
                {
                    Console.WriteLine("Гоблин падает замертво");
                    Console.WriteLine("Похоже, все говнокоины теперь ваши");
                    player.IncreaseModey(bank);
                    break;
                }
                if (goblin.Coins <= 0)
                {
                    Console.WriteLine("- Все, говнокоины кончились, забирай и проваливай");
                    player.IncreaseModey(bank);
                    break;
                }
                if (player.Coins == 0)
                {
                    Console.WriteLine("Вы выварачиваете пустые карманы");
                    Console.WriteLine("Бармен вышвыривает вас из заведения за то, что вы нищий");
                    break;
                }

                Helper.PrintDevide();
                Console.WriteLine(player);
                Helper.PrintDevide();

                Console.WriteLine("- Ну как, еще по одной?");

                Console.WriteLine("1 - положить говнокоин на стойку, 2 - отказаться");

                userAnswer = Console.ReadLine();
                Helper.PrintDevide();
                if (userAnswer != "1")
                {
                    Console.WriteLine("Вы жестами показываете, что на сегодня вам уже хватит");
                    Console.WriteLine("- Хе, говнокоины теперь мои, проваливай - издевательски протягивает гоблин");
                    break;
                }

                player.ReduceModey(1);
                goblin.LoseCoin();
                bank += 2;

                Console.WriteLine("Вы с гоблином кладете на стойку по говнокоину");
            }
            Helper.PrintDevide();
            Console.WriteLine(player);
        }
    }
}
