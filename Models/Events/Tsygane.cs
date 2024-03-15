using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Events
{
    public class Tsygane : Event
    {
        public override void EventBody(DungeonGame.Player player)
        {
            Console.WriteLine("Куда бы вы ни шли - вас притягивает шарманка, которая внезапно появляется на вашем пути.\nОна манит подойти ближе, а вы не можете сопротивляться этому зову музыки и тайн.\nВнезапный круговорот красок сбивает вас с толку - это странные незнакомцы в ярких одеждах окружили и преграждают путь.\nВы слышали о них, ведь бабушка пугала этими людьми в детстве.\nЦыгане.\nОдин из них выходит из круга и предлагает игру, под названием \"Монеточка\". ");
            bool menu = true;
            while (menu)
            {
                Console.WriteLine(player);
                Console.WriteLine("Для того, чтобы пройти дльше, необходимо кинуть монетку и угадать выпавшую сторону: 1 - орел, 2 - решка");
                int n = Convert.ToInt32(Console.ReadLine());

                Random rnd = new Random();
                int i = rnd.Next(0, 3);
                switch (n)
                {
                    case 1:
                        {
                            if(i == 1)
                            {
                                Console.WriteLine("Вы угадали!");
                                player.IncreaseModey(1);
                                player.IncreaseHP(0);
                                EndEvent();
                                menu = false;
                            }
                            else
                            {
                                player.IncreaseModey(1);
                                Console.WriteLine("Попробуйте ещё раз!");
                                player.ReduceModey(1);
                                player.GetDamage(1);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (i == 2)
                            {
                                Console.WriteLine("Вы угадали!");
                                player.IncreaseModey(1);
                                player.IncreaseHP(0);
                                EndEvent();
                                menu = false;
                            }
                            else
                            {
                                player.IncreaseModey(1);
                                Console.WriteLine("Попробуйте ещё раз!");
                                player.ReduceModey(1);
                                player.GetDamage(1);
                            }
                            break;
                        }
                }

            }
        }
    }
}
