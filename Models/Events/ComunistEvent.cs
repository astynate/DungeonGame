using DungeonGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Models.Events
{
    public class ComunistEvent : Event
    {
        private static void StarWars()
        {
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
        }

        /// <summary>
        /// Это пример описывает то как вы можете создавать 
        /// уровни в игре здесь простой код котрый
        /// просит пользователя ввести ответ на вопрос
        /// если ввёл не правильно то снимаются хп
        /// иначе добавляются говнокоины
        /// </summary>


        public override void EventBody(Player player)
        {
            Helper.PrintDevide();
            Console.Clear();
            Console.WriteLine(" \u001b[29m");
            Helper.PrintDevide();
            Thread.Sleep(1000);
            Console.WriteLine( "На вас напал Маг одетый в красное одеянние; его пышные усы развевались на ветру, как пара гордых орлов.");
            Thread.Sleep(2500);
            Console.WriteLine("Маг использует заклинание \" Комуняшек \"!");
            Thread.Sleep(2000);
            Console.WriteLine("Выкините 13> на веру");
            Console.WriteLine("(Для этого, нажмите любую клавишу)");
            Helper.PrintDevide();
             

            //
            while (IsActive)
            {
                Console.ReadKey();

                Thread.Sleep(1000);
                Console.WriteLine("  ░");
                Thread.Sleep(1000);
                Console.WriteLine(" ▒▒▒ ");
                Thread.Sleep(1000);
                Console.WriteLine("▓▓▓▓▓");
                int dice = new Random().Next(1, 20);
                Console.WriteLine(dice.ToString());
                if (dice >= 13)
                {

                    Helper.PrintDevide();
                    Console.WriteLine("Ваша вера в Отца русской демократии оказалась сильнее.");
                    player.IncreaseModey(5);
                    Console.WriteLine("Вы получили 5 монет и ушли с победой.");
                    Thread.Sleep(1000);
                    Console.WriteLine(" \u001b[32m"+"    ___  _______   ________  ___  ___  ________          \r\n   |\\  \\|\\  ___ \\ |\\   ____\\|\\  \\|\\  \\|\\   ____\\         \r\n   \\ \\  \\ \\   __/|\\ \\  \\___|\\ \\  \\\\\\  \\ \\  \\___|_        \r\n __ \\ \\  \\ \\  \\_|/_\\ \\_____  \\ \\  \\\\\\  \\ \\_____  \\       \r\n|\\  \\\\_\\  \\ \\  \\_|\\ \\|____|\\  \\ \\  \\\\\\  \\|____|\\  \\      \r\n\\ \\________\\ \\_______\\____\\_\\  \\ \\_______\\____\\_\\  \\     \r\n \\|________|\\|_______|\\_________\\|_______|\\_________\\    \r\n                     \\|_________|        \\|_________|    \r\n                                                         \r\n                                                         ");
                    Thread.Sleep(500);
                    Console.WriteLine(" \u001b[32m" + " ___       ___  ___      ___ _______   ________      \r\n|\\  \\     |\\  \\|\\  \\    /  /|\\  ___ \\ |\\   ____\\     \r\n\\ \\  \\    \\ \\  \\ \\  \\  /  / | \\   __/|\\ \\  \\___|_    \r\n \\ \\  \\    \\ \\  \\ \\  \\/  / / \\ \\  \\_|/_\\ \\_____  \\   \r\n  \\ \\  \\____\\ \\  \\ \\    / /   \\ \\  \\_|\\ \\|____|\\  \\  \r\n   \\ \\_______\\ \\__\\ \\__/ /     \\ \\_______\\____\\_\\  \\ \r\n    \\|_______|\\|__|\\|__|/       \\|_______|\\_________\\\r\n                                         \\|_________|\r\n                                                     \r\n                                                     ");
                    Thread.Sleep(500);
                    Console.WriteLine(" \u001b[32m" + " ________ ________  ________  _______   ___      ___ _______   ________     \r\n|\\  _____\\\\   __  \\|\\   __  \\|\\  ___ \\ |\\  \\    /  /|\\  ___ \\ |\\   __  \\    \r\n\\ \\  \\__/\\ \\  \\|\\  \\ \\  \\|\\  \\ \\   __/|\\ \\  \\  /  / | \\   __/|\\ \\  \\|\\  \\   \r\n \\ \\   __\\\\ \\  \\\\\\  \\ \\   _  _\\ \\  \\_|/_\\ \\  \\/  / / \\ \\  \\_|/_\\ \\   _  _\\  \r\n  \\ \\  \\_| \\ \\  \\\\\\  \\ \\  \\\\  \\\\ \\  \\_|\\ \\ \\    / /   \\ \\  \\_|\\ \\ \\  \\\\  \\| \r\n   \\ \\__\\   \\ \\_______\\ \\__\\\\ _\\\\ \\_______\\ \\__/ /     \\ \\_______\\ \\__\\\\ _\\ \r\n    \\|__|    \\|_______|\\|__|\\|__|\\|_______|\\|__|/       \\|_______|\\|__|\\|__|\r\n                                                                            ");
                    Helper.PrintDevide();
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(" \u001b[29m");
                    EndEvent();
                    return;
                }
                else
                {
                    
                    Helper.PrintDevide();//----
                    Thread.Sleep(250);
                    Console.WriteLine(" Ваши деньги, наши деньги.");
                    Thread.Sleep(250);
                    Console.WriteLine(" Вы получили урон и лишились своих денег.");
                    Thread.Sleep(250);
                    Console.WriteLine(" ТЕПЕРЬ ТЫ КОММУНИСТ!!!");
                    Thread.Sleep(500);
                    Console.WriteLine(" \u001b[31m");
                    Console.WriteLine(" ██████╗ ██████╗ ███╗   ███╗███╗   ███╗██╗   ██╗███╗   ██╗██╗███████╗███╗   ███╗\r\n██╔════╝██╔═══██╗████╗ ████║████╗ ████║██║   ██║████╗  ██║██║╚══███╔╝████╗ ████║\r\n██║     ██║   ██║██╔████╔██║██╔████╔██║██║   ██║██╔██╗ ██║██║  ███╔╝ ██╔████╔██║\r\n██║     ██║   ██║██║╚██╔╝██║██║╚██╔╝██║██║   ██║██║╚██╗██║██║ ███╔╝  ██║╚██╔╝██║\r\n╚██████╗╚██████╔╝██║ ╚═╝ ██║██║ ╚═╝ ██║╚██████╔╝██║ ╚████║██║███████╗██║ ╚═╝ ██║\r\n ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝╚══════╝╚═╝     ╚═╝\r\n                                                                                ");
                    Console.WriteLine(" \u001b[29m");
                    Console.ReadLine();
                    Console.WriteLine(" \u001b[31m");

                    player.GetDamage(1);
                    player.ReduceModey(1);
                    StarWars();
                    EndEvent();
                    Helper.PrintDevide();
                    Console.WriteLine(player);
                }
            }
        }
    }

}
