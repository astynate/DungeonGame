using DungeonGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Events
{
    public class GoblinsUltraEvent : Event
    {
        public override void EventBody(Player player)
        {
            Console.WriteLine("Вы не понимаете что происходит, вокруг темно");
            Thread.Sleep(1500);
            Console.WriteLine("Вдруг в темноте появляется человек средних лет, ростом метр восемдесят, худощавого телосложения");
            Thread.Sleep(2000);
            Console.WriteLine("Этот человек говорит: \n- проснитесь и пойте \n и называет ваше имя");
            Thread.Sleep(1000);
            Console.WriteLine("Диалог: \n1. кто ты черт возьми такой? \n2. что происходит, где я?");
            Console.ReadLine();
            Thread.Sleep(1000);
            Console.WriteLine("Вы не можете говорить");
            Thread.Sleep(1000);
            Console.WriteLine("Вы просыпаетесь в поезде который скоро прибудет на станцию \"Лебяжий\" ");
            Thread.Sleep(1500);
            Console.WriteLine("Вы смотрите в окно видите разрушенный город и рынок \"Ждановичи\"");
            Thread.Sleep(1000);
            Console.WriteLine("Поезд останавливается и вы видете у себя на коленях икону и гоблина который ее оставил");
            Thread.Sleep(1500);
            Console.WriteLine("Вы не понимаете откуда в вашем мире взялись гоблины выбегаете из поезда и попадаете на рынок полный гоблинов, все сотальное вокруг выглядит как раньше");
            Thread.Sleep(1500);
            bool g = true;
                bool adv = false, vietnam = true, scammers = true, radio = true, china = true; //проверка посещения локаций
            bool gun = false, desomorphine = false; //кринжовый инвентарь
            bool effect = false;
            Console.WriteLine("Вы нашли деньги 2");
            player.IncreaseModey(2);
            while (g)
            {
                Console.WriteLine("Куда вы хотите отправиться:");//нельзя посетить одну и ту же локацию дважды 
                if (vietnam) Console.WriteLine("1. Сайгон(вы голодны)");
                if (scammers) Console.WriteLine("2. Поле чудес ");
                //if (radio) Console.WriteLine("3. Радиорынок");
                //if (china) Console.WriteLine("4. Китайский оптовый рынок");
                if (adv) Console.WriteLine("5.Вернуться на вокзал и уехать");// уехать домой можно только после хотя бы одного приключения
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {//сайгон
                            Console.WriteLine("Выбор\n1. Купить еды(-2 говнокоина)(от -2 до +6 хп) \n2. Выйти(это может расстроить продовца)");
                            if (Convert.ToInt32(Console.ReadLine()) == 1)
                            {
                                player.ReduceModey(2);
                                Random r = new Random();
                                int rand = r.Next(-2, 6 + 1);
                                if (rand == 0) { Console.WriteLine($"вы покушали, вы получили {rand} xp,выходя сказали \n - Спасибо \n повар сказал вам \n - Nếu bạn sống sót sau thức ăn của tôi một lần nữa, tôi sẽ tự tay giết bạn \n -Да");
                                    break;
                                }
                                if (rand >= 1)
                                {
                                    Console.WriteLine($"вы покушали, вы получили {rand} xp, ваши глаза заблестели, вы почувствовали невероятный прилив сил, выходя вы сказали: \n - Спасибо \n повар сказал вам: \n - Nếu bạn sống sót sau thức ăn của tôi một lần nữa, tôi sẽ tự tay giết bạn \n -Да");
                                    player.IncreaseHP(rand);
                                    break;
                                }
                                if (rand <= -1)
                                {
                                    Console.WriteLine("вы покушали, вас вывернуло на изнанку");

                                    Thread.Sleep(1000);
                                    Console.WriteLine("стены будто сжимали вас,");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("вы начали бежать к выходу, не смотря на то что стены приближаются к вам выход отдаляется");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Сайгон начал приобретать форму коридора");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Появившиеся горы мебели не давали вам пройти");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("вы приши в сознание, собрали вещи, выходя вы сказали \n -..."); ;
                                    player.IncreaseHP(rand);
                                    Thread.Sleep(1000);
                                    Console.WriteLine("-...");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("-...");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("-...");
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"вы получили {rand} xp");
                                    effect = true;
                                    break;
                                }
                            }
                            if (Convert.ToInt32(Console.ReadLine()) == 2)
                            {
                                Console.WriteLine("Вы стоите в ступоре \n только решив развернуться вы слышите \n -NGƯỜI ĐÀN ÔNG NGƯỜI ĐÀN ÔNG!!!!!!!!  \n вы поварачиваетесь и видете летящего в вас краба \n Вы получаете -1 xp");
                                player.GetDamage(1);
                            }
                            adv = true;
                            break;
                        }
                    case 2: //мошенники
                        {
                            Console.WriteLine("вы находите 2 говнокоина");
                            player.IncreaseModey(2);
                            bool i = true;
                            while (i)
                            {
                                Console.WriteLine("Вы попадаете на рынок у вас есть уникальная возможность приобрести самые разные предметы \n 1. самопал(1 говнокоин) \n 2.дезоморфин(2 говнокоина) \n3. выйти  ");
                                int qd = Convert.ToInt32(Console.ReadLine());
                                if (qd == 1)
                                {
                                    Console.WriteLine("вы потратили 1 говнокоина");
                                    gun = true;
                                    player.ReduceModey(1);
                                    Console.WriteLine("🔫"); 
                                }
                                if (qd == 2)
                                {
                                    Console.WriteLine("вы потратили 2 говнокоина");
                                    player.ReduceModey(2);
                                    desomorphine = true;
                                    Console.WriteLine("обидно что я живу в стране где дезоморфин стоит в два раза дороже чем самопал");
                                    Console.WriteLine("💉"); 
                                }
                                if (qd == 3)
                                {
                                    Console.WriteLine("вы потратили 0 говнокоинов");
                                    
                                }
                                Console.WriteLine("на вас напали \n выберете что использовать:");
                                bool en = true;
                                int enhp = 10;
                                while (en)
                                {
                                if (effect) Console.WriteLine("1.драться в рукопаную из-за отравления ваш шанс на победу 40%");
                                if (!effect) Console.WriteLine("1. драться в рукопашную шанс 60%");
                                if (gun) Console.WriteLine("2. выстрелить шанс 70%");
                                if (desomorphine) Console.WriteLine("3. вколоть дезоморфин шанс 110%");
                                Console.WriteLine("4. Бежать шанс 50%");

                                    Random rr = new Random();
                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                            {
                                                if (effect)
                                                {
                                                    int fight = rr.Next(-6, 4);
                                                    if (fight >= 0)
                                                    {
                                                        Console.WriteLine($"вы нанесли{fight}урона");
                                                        enhp = enhp - fight;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Вы получили {fight} урона");
                                                        player.GetDamage(Math.Abs(fight));
                                                    }

                                                }
                                                if (!effect)
                                                {
                                                    int fight = rr.Next(-4, 6);
                                                    if (fight >= 0)
                                                    {
                                                        Console.WriteLine($"вы нанесли{fight}урона");
                                                        enhp = enhp - fight;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Вы получили {fight} урона");
                                                        player.GetDamage(Math.Abs(fight));
                                                    }
                                                }
                                                break;
                                            }
                                            case 2:
                                            {
                                                    int fight = rr.Next(-3, 7);
                                                    if (fight >= 0)
                                                    {
                                                        Console.WriteLine($"вы нанесли{fight}урона");
                                                        enhp = enhp - fight;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Вы получили {fight} урона");
                                                        player.GetDamage(Math.Abs(fight));
                                                    }
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Наркотики зло, вы справились с противником ");
                                                en = false;
                                                return;
                                            }
                                    case 4:
                                            {
                                                Console.WriteLine("вы попытались убежать");
                                                int fight = rr.Next(-5, 5);
                                                if (fight >= 0)
                                                {
                                                    Console.WriteLine($"вы убежали");
                                                    en = false;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Вы получили {4} урона");
                                                    player.GetDamage(Math.Abs(4));
                                                }
                                                break;
                                            }
                                    }
                                    if (enhp <= 0) return;
                                }
                                adv = true;
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("На вокзале вы проходите энергетическую рамку и все приобретенные предметы пропадают");
                            g = false;
                            return;
                        }
                }
                

            }
        }
    }
}
