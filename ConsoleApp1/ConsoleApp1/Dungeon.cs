using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dungeon
    {
        public static void EnterDungeon(Character me)//던전 입장
        {
            int a = 0;
            Console.Clear();
            Console.Write("던전입장\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +
                "1. 쉬운 던전     | 방어력 5 이상 권장\n2. 일반 던전     | 방어력 11 이상 권장\n3. 어려운 던전   | 방어력 17 이상 권장\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
            while (a == 0)
            {
                string? choice = Console.ReadLine();
                if (choice == "1")
                {
                    DungeonResult(me, 1);
                    a = 1;
                }
                else if (choice == "2")
                {
                    DungeonResult(me, 2);
                    a = 1;
                }
                else if (choice == "3")
                {
                    DungeonResult(me, 3);
                    a = 1;
                }
                else if (choice == "0")
                {
                    Program.GameStart(me);
                    a = 1;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        public static void DungeonResult(Character me, int difficulty)//던전 결과
        {
            int a = 0;
            int recommend = 0;//권장 방어력
            bool cleared;
            int damage;
            int reward = 0;
            string dif = "";//스테이지 난이도
            int bonus = 0;//공격력에 따른 보너스 보상
            Random random = new Random();
            switch (difficulty)
            {
                case 1: recommend = 5; reward = 1000; dif = "쉬운"; break;
                case 2: recommend = 11; reward = 1700; dif = "일반"; break;
                case 3: recommend = 17; reward = 2500; dif = "어려운"; break;
            }
            if (me.def < recommend)
            {
                int result = random.Next(0, 10);
                if (result < 4) cleared = false;
                else
                {
                    cleared = true;
                }
            }
            else
            {
                cleared = true;
            }
            damage = random.Next(20, 36);
            damage = damage + recommend - me.def;
            bonus = random.Next((int)me.atk, (int)me.atk + 1);
            Console.Clear();
            if (cleared)
            {
                Console.Write($"던전 클리어\n축하합니다!!\n{dif} 던전을 클리어 하였습니다.\n\n" +
                $"[탐험 결과]\n체력 {me.hp} -> {me.hp - damage}\nGold {me.gold}G -> {me.gold + reward + reward * bonus / 100}G\n\n");
                me.hp -= damage;
                me.gold += reward + reward * bonus / 100;
                me.ClearStage();
            }
            else
            {
                Console.Write($"던전 클리어 실패\n유감입니다...\n{dif} 던전을 클리어 하지 못했습니다.\n\n" +
                $"[탐험 결과]\n체력 {me.hp} -> {me.hp - damage / 2}\n\n");
                me.hp -= damage / 2;
            }
            if (me.hp <= 0)
            {
                Console.Write($"{me.name} 캐릭터가 사망했습니다...\n\n0.게임종료\n\n원하시는 행동을 입력해주세요.\n >> ");
                while (a == 0)
                {
                    string? choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        a = 1;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }
                }
            }
            else
            {
                Console.Write("0.나가기\n\n원하시는 행동을 입력해주세요.\n >> ");
                while (a == 0)
                {
                    string? choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        Program.GameStart(me);
                        a = 1;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }
                }
            }
        }
    }
}
