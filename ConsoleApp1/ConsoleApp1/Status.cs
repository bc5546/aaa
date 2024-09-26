using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Status
    {
        public static void EnterStatus(Character me) //상태 보기
        {
            int a = 0;
            Console.Clear();
            Console.Write($"상태보기\n캐릭터의 정보가 표시됩니다.\n\nLv. {me.level}\n" +
                $"{me.name} ( {me.job} )\n공격력 : {me.atk}\n방어력 : {me.def}\n체력 : {me.hp}\nGold : {me.gold}\n\n" +
                "0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
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
