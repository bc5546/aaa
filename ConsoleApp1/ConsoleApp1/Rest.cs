using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Rest
    {
        public static void EnterRest(Character me)//휴식
        {
            int a = 0;
            Console.Clear();
            Console.Write($"휴식하기\n500G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {me.gold}G)\n\n" +
                "1. 휴식하기\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
            while (a == 0)
            {
                string? choice = Console.ReadLine();
                if (choice == "0")
                {
                    Program.GameStart(me);
                    a = 1;
                }
                else if (choice == "1")
                {
                    if (me.gold >= 500)
                    {
                        me.hp = 100;
                        me.gold -= 500;
                        Console.Write("휴식을 완료했습니다.\n>>");
                        int x = Console.GetCursorPosition().Left;
                        int y = Console.GetCursorPosition().Top;
                        Console.SetCursorPosition(53, 1);
                        Console.Write($"{me.gold}G)   ");
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        Console.Write("Gold 가 부족합니다.\n>>");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
    }
}
