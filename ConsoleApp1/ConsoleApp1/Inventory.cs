using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Inventory
    {
        public static void EnterInventory(Character me) //인벤토리
        {
            int a = 0;
            int count = 0;
            Console.Clear();
            Console.WriteLine($"인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
            foreach (item item in me.inventory)//아이템 목록 출력
            {
                Console.Write($"- ");
                if (me.inventory[count].isEquipped == true)//장착되어 있을 경우 앞에 "[E]" 추가
                {
                    Console.Write("[E]");
                }
                Console.WriteLine(item.itemInfo("inventory"));
                count++;
            }
            Console.Write("\n1. 장착 관리\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
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
                    Equip(me);//장착관리
                    a = 1;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        public static void Equip(Character me)//아이템 장착
        {
            int b, a = 0;

            while (a == 0)
            {
                b = 0;
                int count = 0;
                Console.Clear();
                Console.WriteLine($"인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
                foreach (item item in me.inventory)
                {
                    count += 1;
                    Console.Write($"- {count} ");
                    if (me.inventory[count - 1].isEquipped == true)
                    {
                        Console.Write("[E]");
                    }
                    Console.WriteLine(me.inventory[count - 1].itemInfo("inventory"));
                }
                Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                while (b == 0)
                {
                    string? choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        EnterInventory(me);
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
                        else if (selected.isEquipped == false)
                        {

                            //itemlist.items[me.inventory[int.Parse(choice) - 1]].isEquipped = true;
                            if (selected.stat == "방어력")
                            {
                                foreach (item item in me.inventory)
                                {
                                    if (item.isEquipped == true && item.stat == "방어력")
                                    {
                                        item.isEquipped = false;
                                        me.def -= item.statNum;
                                    }
                                }
                                me.def += selected.statNum;
                            }
                            else if (selected.stat == "공격력")
                            {
                                foreach (item item in me.inventory)
                                {
                                    if (item.isEquipped == true && item.stat == "공격력")
                                    {
                                        item.isEquipped = false;
                                        me.def -= item.statNum;
                                    }
                                }
                                me.atk += selected.statNum;
                            }
                            selected.isEquipped = true;
                        }
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
