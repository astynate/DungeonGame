using DungeonGame;

namespace Models.Events
{
    public class Cruwis : Event
    {
        private const int CorrectAnswerHealthPoints = 3;
        private const int IncorrectAnswerHealthPoints = 2;

        private readonly List<Riddle> riddles = new List<Riddle>()
        {
            new Riddle("Вопрос: Что такое квазар?",
                       new List<string>() { "a) Математическая функция",
                           "b) Горящий метеорит",
                           "c) Очень яркое и далекое галактическое ядро" },
                       "c"),

            new Riddle("Вопрос: Кто победил в номинации альбома года 2024 Грэмми?",
                       new List<string>() { "a) Тейлор Свифт",
                           "b) Майли Сайрус",
                           "c) Лана Дель Рей" },
                       "a"),

            new Riddle("Вопрос: Кто был  главным героем мультсериала Смешарики эпизода Счастьемет?",
                       new List<string>() { "a) Нюша",
                           "b) Пин",
                           "c) Совунья" },
                       "b")
        };

        public override void EventBody(Player player)
        {
            Console.WriteLine("Отгадай загадки и получи хп.");

            Helper.PrintDevide();

            foreach (Riddle riddle in riddles)
            {
                Console.WriteLine(riddle.Question);
                foreach (string option in riddle.Options)
                {
                    Console.WriteLine(option);
                }

                string? userAnswer = Console.ReadLine();

                if (userAnswer?.ToLower() == riddle.CorrectAnswer)
                {
                    player.IncreaseHP(CorrectAnswerHealthPoints);
                    Console.WriteLine("Правильно! Ваше количество хп увеличивается на 3.");
                }
                else
                {
                    player.GetDamage(IncorrectAnswerHealthPoints);
                    Console.WriteLine("Неверно! Ваше количество хп уменьшается на 2.");
                }

                Helper.PrintDevide();
                Console.WriteLine(player);
            }

            EndEvent();
        }

        private class Riddle
        {
            public string Question { get; set; }
            public List<string> Options { get; set; }
            public string CorrectAnswer { get; set; }

            public Riddle(string question, List<string> options, string correctAnswer)
            {
                Question = question;
                Options = options;
                CorrectAnswer = correctAnswer;
            }
        }
    }
}