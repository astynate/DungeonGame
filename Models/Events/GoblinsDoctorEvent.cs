using DungeonGame;

namespace Models.Events
{
    public class GoblinsDoctorEvent : Event
    {
        private const int DELAY = 500;


        private void HealingProcces(Player p)
        {
            while (true)
            {
                Thread.Sleep(DELAY);
                var healingThrow = ThrowD20();
                switch (Random.Shared.Next(0, 3))
                {
                    case 0:
                        Console.WriteLine($"Доктор достает из кармана скальпель и начинает что-то делать с вашим телом: {healingThrow.doc}");
                        break;
                    case 1:
                        Console.WriteLine($"Доктор достает из кармана молоток.. и начинает вас лечить: {healingThrow.doc}");
                        break;
                    case 2:
                        Console.WriteLine($"Доктор достает из кармана пилу.. и начинает вас лечить: {healingThrow.doc}");
                        break;
                }
                Thread.Sleep(DELAY);
                Console.WriteLine($"Вы пытаетесь оставаться в сознании: {healingThrow.pl}");
                Thread.Sleep(DELAY);
                if (healingThrow.pl < healingThrow.doc)
                {
                    Console.WriteLine("Вы теряете 1хп");
                }
                else if (healingThrow.pl > healingThrow.doc)
                {
                    Console.WriteLine("Вы настаиваете на том, что вы уже получили достаточное лечение. Вы получаете 5 хп");
                    p.IncreaseHP(5);
                    return;
                }
                else
                {
                    Console.WriteLine("Вы смогли не отключиться, но доктор все еще продолжает вас лечить. Вы получаете 1 хп");
                    p.IncreaseHP(1);

                }
                Helper.PrintDevide();
            }
        }
        private void TryToEscape(Player p)
        {
            bool end = false;
            Console.WriteLine("Вы начинаете убегать, доктор бежит за вами");
            Thread.Sleep(DELAY);
            while (!end)
            {
                var runningThrow = ThrowD20();
                Console.WriteLine($"Вы пытаетесь ускроиться: {runningThrow.pl}");
                Thread.Sleep(DELAY);
                Console.WriteLine($"Доктор пытается догнать вас: {runningThrow.doc}");
                Thread.Sleep(DELAY);
                if (runningThrow.pl > runningThrow.doc)
                {
                    Helper.PrintDevide();
                    Console.WriteLine("Вы смогли удалиться на достаточное расстояние, чтобы доктор не мог дотянуться до вас");
                    end = true;
                }
                else if (runningThrow.pl < runningThrow.doc)
                {
                    Console.WriteLine("Доктор смог дотянуться до вас своим ножом. Вы теряете 1хп");
                    p.GetDamage(1);
                }
                else
                {
                    Console.WriteLine("Доктор достает нож и метает его в вас");
                    Thread.Sleep(DELAY);
                    var knifeThrow = ThrowD20();
                    if (knifeThrow.doc > knifeThrow.pl)
                    {
                        Console.WriteLine("Нож попадает в вас и вы теряете 2 хп");
                        p.GetDamage(2);
                    }
                    if (knifeThrow.pl > knifeThrow.doc)
                    {
                        Console.WriteLine("Нож доктора улетает куда-то в кусты и доктор, совершенно не обращая внимания на вас, бежит его искать");
                        Thread.Sleep(DELAY);
                        Console.WriteLine("- О нет! Мой нож, где ты?");
                        Thread.Sleep(DELAY);
                        Helper.PrintDevide();
                        Console.WriteLine("Вы благополучно сбегаете");
                        end = true;
                    }
                }
            }

        }

        private static (int doc, int pl) ThrowD20() => (Random.Shared.Next(1, 21), Random.Shared.Next(1, 21));
        private class Doctor
        {

        }
        public override void EventBody(Player player)
        {
            Console.WriteLine("Следуя по своему пути, вы натыкаетесь на странного человека, который сидит у дороги");
            Helper.PrintDevide();
            Doctor doc = new();

            Console.WriteLine("1 - подойти к нему 2 - попытаться незаметно его обойти");
            string? userAnswer = Console.ReadLine();
            Helper.PrintDevide();
            if (userAnswer != "1")
            {
                var detectionThrow = ThrowD20();
                Thread.Sleep(DELAY);
                Console.WriteLine($"Странная фигура осматривается по сторонам: {detectionThrow.doc} ");
                Thread.Sleep(DELAY);
                Console.WriteLine($"Вы пытаетесь спрятаться: {detectionThrow.pl} ");
                Thread.Sleep(DELAY);
                if (detectionThrow.doc > detectionThrow.pl)
                {
                    Console.WriteLine("Что-то очень сильно хватает вас за руку из-за спины и тянет к себе. Вам больно. Вы теряете 1хп ");
                    player.GetDamage(1);
                }
                else
                {
                    Console.WriteLine("Вы смогли проскочить незаметно");
                    return;

                }
            }
            Thread.Sleep(DELAY);
            Console.WriteLine("- Привет, странник!");
            Console.WriteLine("Человек машет вам рукой");
            Helper.PrintDevide();
            Thread.Sleep(DELAY);
            var detetionThrow = ThrowD20();
            Console.WriteLine($"Вы пытаетесь разглядеть его: {detetionThrow.pl}");
            Thread.Sleep(DELAY);
            if (detetionThrow.pl >= 16)
            {
                Console.WriteLine("Вы замечаете, что человек одет в старый потрепанный плащ и измазанные кровью перчатки.\nОдна рука у него находится в кармане и крепко за что-то держится");
            }
            else
            {
                Console.WriteLine("Ничего не вышло, ваш разум будто затуманен, вы не можете разглядеть ничего");
            }
            Thread.Sleep(DELAY);
            Console.WriteLine("- Я - странствующий лекарь, я посвятил всю свою жизнь бесплатно помогая таким как ты, странник. Хочешь ли ты подлечиться?");
            Helper.PrintDevide();
            Thread.Sleep(DELAY);
            Console.WriteLine("1 - Согласиться 2 - Отказаться от лечения");
            userAnswer = Console.ReadLine();
            if (userAnswer != "1")
            {
                Console.WriteLine("- Никто еще не отказывался от моего лечения! Я настаиваю, чтобы ты принял мою помощь");
                Thread.Sleep(DELAY);
                Console.WriteLine("Доктор начинает нервничать, он будто пытается достать что-то из кармана");
                Thread.Sleep(DELAY);
                Console.WriteLine(" - Вы не можете просто так взять и отказаться..Я даю вам последний шанс принять мою помощь!");

                Helper.PrintDevide();
                Thread.Sleep(DELAY);
                Console.WriteLine("1 - Согласиться 2 - Все равно отказаться от лечения");
                userAnswer = Console.ReadLine();
                Thread.Sleep(DELAY);
                if (userAnswer != "1")
                {
                    Console.WriteLine("- НЕТ, ТЫ НЕ ОТКАЖЕШЬСЯ ");
                    TryToEscape(player);
                    return;
                }
            }



            HealingProcces(player);
            Console.WriteLine("- Ладно, дружок, с тебя хватит.");
            Helper.PrintDevide();
            Console.WriteLine("Доктор улыбаясь вытирает кровь со своих приборов и проважает вас рукой");
            return;
        }
    }
}
