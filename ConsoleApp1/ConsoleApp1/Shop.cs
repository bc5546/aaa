using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shop
    {
        public static void EnterShop(Character me)//상점
        {
            int a = 0;
            Console.Clear();
            Console.WriteLine($"상점\n필요한 아이템을 얻를 수 있는 상점입니다.\n\n" +
                $"[보유 골드]\n{me.gold} G\n\n[아이템 목록]\n");
            foreach (item item in Program.itemlist.items)
            {
                Console.Write($"- {item.itemInfo("shop")}| ");
                if (item.isBought == true)
                {
                    Console.WriteLine(" 구매완료");
                }
                else if (item.isBought == false)
                {
                    Console.WriteLine($" {item.price}G");
                }
            }
            Console.Write("\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
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
                    Buy(me);
                    a = 1;
                }
                else if (choice == "2")
                {
                    Sell(me);
                    a = 1;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        public static void Buy(Character me)//구매
        {
            int a = 0;
            int b;
            int count;
            while (a == 0)
            {
                count = 0;
                b = 0;
                Console.Clear();
                Console.WriteLine($"상점 - 아이템 구매\n필요한 아이템을 얻를 수 있는 상점입니다.\n\n" +
                    $"[보유 골드]\n{me.gold} G\n\n[아이템 목록]\n");
                foreach (item item in Program.itemlist.items)
                {
                    count++;
                    Console.Write($"- {count} {item.itemInfo("shop")}| ");
                    if (item.isBought == true)
                    {
                        Console.WriteLine(" 구매완료");
                    }
                    else if (item.isBought == false)
                    {
                        Console.WriteLine($" {item.price}G");
                    }
                }
                Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                while (b == 0)
                {
                    string? choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        EnterShop(me);
                        a = 1;
                        b = 1;
                    }
                    else if (int.Parse(choice) <= 6 && int.Parse(choice) > 0)
                    {
                        item selected = Program.itemlist.items[int.Parse(choice) - 1];
                        if (selected.isBought == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (selected.price <= me.gold)
                        {
                            me.gold -= selected.price;
                            me.inventory.Add(selected);
                            selected.isBought = true;

                            b = 1;
                        }
                        else
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }
                }
            }
        }

        public static void Sell(Character me)//판매
        {
            int b, a = 0;

            while (a == 0)
            {
                b = 0;
                int count = 0;
                Console.Clear();
                Console.WriteLine($"상점 - 아이템 판매\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]\n{me.gold} G\n\n[아이템 목록]");
                if (me.inventory[0] != null)
                {
                    foreach (item item in me.inventory)
                    {
                        count += 1;
                        Console.Write($"- {count} ");
                        if (me.inventory[count - 1].isEquipped == true)
                        {
                            Console.Write("[E]");
                        }
                        Console.WriteLine($"{me.inventory[count - 1].itemInfo("inventory")} | {me.inventory[count - 1].price * 9 / 10}");
                    }
                }

                Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                while (b == 0)
                {
                    string? choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        EnterShop(me);
                        a = 1;
                        b = 1;
                    }
                    else if (int.Parse(choice) <= count)
                    {
                        //item selected = itemlist.items[me.inventory[int.Parse(choice)-1]];
                        item selected = me.inventory[int.Parse(choice) - 1];
                        if (selected.isEquipped == true)
                        {
                            //itemlist.items[me.inventory[int.Parse(choice) - 1]].isEquipped = false;

                            selected.isEquipped = false;
                            if (selected.stat == "방어력")
                            {
                                me.def -= selected.statNum;
                            }
                            else if (selected.stat == "공격력")
                            {
                                me.atk -= selected.statNum;
                            }

                        }
                        me.gold += selected.price * 9 / 10;
                        selected.isBought = false;
                        me.inventory.RemoveAt(int.Parse(choice) - 1);
                        b = 1;
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
