using DungeonGame;

namespace Models.Events
{
    public class Odami : Event
    {
        public string? CorrectAnswer { get; private set; } = "красный";

        public override void EventBody(Player player)
        {
            Console.WriteLine("Было 2 козла. Сколько?");
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
   
