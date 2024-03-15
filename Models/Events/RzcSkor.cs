using DungeonGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Events
{
    internal class RzcSkor: Event
    {
        public string? CorrectAnswer { get; private set; } = "Настрой!";

        public override void EventBody(Player player)
        {
            Console.WriteLine("Если вам в тюрьме кинули метлу со словами 'Сыграй!', что нужно отвечать, чтобы иметь почет??");
            Console.WriteLine("За неверный ответ снимаются 1 хп");

            Helper.PrintDevide();

            while (IsActive)
            {
                string? userAnswer = Console.ReadLine();

                if (userAnswer?.ToLower() == CorrectAnswer?.ToLower())
                {
                    player.IncreaseModey(1);
                    EndEvent();

                    Helper.PrintDevide();
                    Console.WriteLine("Правильно!");

                    return;
                }

                player.GetDamage(1);

                Helper.PrintDevide();
                Console.WriteLine("Неверно!");

                Helper.PrintDevide();
                Console.WriteLine(player);
            }
        }
    }
}
