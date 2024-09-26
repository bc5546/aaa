
using System.Dynamic;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace ConsoleApp1
{
    
    internal class Program
    {
        public static ItemList? itemlist;
        /*[Serializable]
        public class Character
        {
            public int level;
            public string name;
            public string job;
            public float atk;
            public int def;
            public int hp;
            public int gold;
            public List<item> inventory;
            public int exp;
            public Character(string name)
            {
                this.name = name;
                level = 1;
                job = "전사";
                atk = 10;
                def = 5;
                hp = 100;
                gold = 1500;
                inventory = new List<item>();
                exp = 0;
            }
            public void ClearStage()
            {
                exp++;
                if (level == exp)
                {
                    level++;
                    exp = 0;
                    atk += 0.5f;
                    def += 1;
                }
            }
        }
        [Serializable]
        public class item 
        {
            public string name;
            public string stat;
            public int statNum;
            public string content;
            public int price;
            public bool isBought;
            public bool isEquipped;
            public item(string name,string stat,int statNum,string content, int price, bool isBought,bool isEquipped)
            {
                this.name = name;
                this.stat = stat;
                this.statNum = statNum;
                this.content = content; 
                this.price = price;
                this.isBought = isBought;
                this.isEquipped = isEquipped;
            }
            public string itemInfo(string position)
            {
                string temp = "   ";
                if (isEquipped == true&&position=="inventory")
                {
                    temp = "";
                }
                return $"{name}{temp}| {stat} + {statNum} | {content}";
            }
        }
        [Serializable]
        public class ItemList 
        {
             public item[] items=new item[6];
             public ItemList()
            {
                items[0] = new item("수련자 갑옷    ", "방어력", 5, "수련에 도움을 주는 갑옷입니다.                     ", 1000, false,false);
                items[1] = new item("무쇠 갑옷      ", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.                 ", 2000, false,false);
                items[2] = new item("스파르타의 갑옷", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ", 3500, false,false);
                items[3] = new item("낡은 검        ", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.                    ", 600, false,false);
                items[4] = new item("청동 도끼      ", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.               ", 1500, false,false);
                items[5] = new item("스파르타의 창  ", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.    ", 3000, false,false);
            }

        }
        [Serializable]
        public class DataField
        {
            public int level;
            public string name;
            public string job;
            public float atk;
            public int def;
            public int hp;
            public int gold;
            public List<item> inventory;
            public int exp;
            public ItemList itemList;

        }*/
        static void SaveData(Character me, ItemList itemList)//저장
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(".\\data.dat", FileMode.Create);

            DataField filesaver = new DataField();

            filesaver.level=me.level;
            filesaver.name = me.name;
            filesaver.job = me.job;
            filesaver.atk = me.atk;
            filesaver.def = me.def;
            filesaver.hp = me.hp;
            filesaver.gold = me.gold;
            filesaver.inventory = me.inventory;
            filesaver.exp = me.exp;
            filesaver.itemList=itemlist;

            bf.Serialize(fs, filesaver);
            fs.Close();
        }

        static void LoadData(Character me, ItemList itemList)//불러오기
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(".\\data.dat", FileMode.Open);

            DataField filesaver = new DataField();
            filesaver=bf.Deserialize(fs) as DataField;
            me.level=filesaver.level ;
            me.name=filesaver.name ;
            me.job=filesaver.job ;
            me.atk=filesaver.atk ;
            me.def=filesaver.def ;
            me.hp=filesaver.hp ;
            me.gold=filesaver.gold ;
            me.exp = filesaver.exp ;
            itemlist=filesaver.itemList ;
            me.inventory=filesaver.inventory ;
            fs.Close();
        }

        static void Main(string[] args)
        {
            int a=0;
            string? choice;
            itemlist = new ItemList();
            if (File.Exists(".\\data.dat"))//저장된 데이터 있는지 확인해서 불러오거나 새로 시작
            {
                Console.Write($"저장된 데이터가 있습니다.\n불러오시겠습니까?\n\n1.불러오기\n2.새로 시작\n\n원하시는 행동을 입력해주세요.\n>>");
                while (true)
                {
                    choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Character me = new Character("");
                        LoadData(me, itemlist);
                        GameStart(me);
                        a = 1;
                        break;
                    }
                    else if (choice == "2")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }
                }
            }
            

            while (a==0)//데이터가 없거나 새로 시작하는 경우 이름 결정
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 결정해주세요.");
                string? name = Console.ReadLine();
                Console.Write($"입력하신 이름은 {name}입니다.\n\n1.저장\n2.취소\n\n원하시는 행동을 입력해주세요.\n>>");
                while (true)
                {
                    choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        a = 1;
                        Character me = new Character(name);
                        GameStart(me);
                        break;
                    }
                    else if (choice == "2")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }
                }
            }
        }
        public static void GameStart(Character me)//메인 화면
        {
            int a = 0;
            Console.Clear();
            Console.Write("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +
                "1. 상태보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식\n6. 저장\n\n원하시는 행동을 입력해주세요.\n>>");
            while (a==0)
            {
                string? choice = Console.ReadLine();
                if (choice == "1")
                {
                    Status(me);
                    a = 1;
                }
                else if (choice == "2")
                {
                    Inventory(me);
                    a = 1;
                }
                else if(choice == "3")
                {
                    Shop(me);
                    a = 1;
                }
                else if (choice == "4")
                {
                    EnterDungeon(me);
                    a = 1;
                }
                else if (choice == "5")
                {
                    Rest(me);
                    a = 1;
                }
                else if (choice == "6")
                {
                    SaveData(me,itemlist);
                    Console.Write("저장되었습니다.\n>> ");
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        public static void Status(Character me) //상태 보기
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
                    GameStart(me);
                    a = 1;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        public static void Inventory(Character me) //인벤토리
        {
            int a = 0;
            int count = 0;
            Console.Clear();
            Console.WriteLine($"인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n"); 
            foreach(item item in me.inventory)//아이템 목록 출력
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
                    GameStart(me);
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
            int b,a = 0;

            while (a == 0)
            {
                b = 0;
                int count = 0;
                Console.Clear();
                Console.WriteLine($"인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
                foreach (item item in me.inventory)
                 {
                     count+=1;
                    Console.Write($"- {count} ");
                    if (me.inventory[count-1].isEquipped == true)
                    {
                        Console.Write("[E]");
                    }
                    Console.WriteLine(me.inventory[count-1].itemInfo("inventory"));
                }
                Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                while (b == 0)
                {
                    string? choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        Inventory(me);
                        a = 1;
                        b = 1;
                    }
                    else if (int.Parse(choice) <=count)
                    {
                        //item selected = itemlist.items[me.inventory[int.Parse(choice)-1]];
                        item selected = me.inventory[int.Parse(choice)-1];
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
                                me.atk-= selected.statNum;
                            }
                        }
                        else if (selected.isEquipped == false)
                        {

                            //itemlist.items[me.inventory[int.Parse(choice) - 1]].isEquipped = true;
                            if (selected.stat == "방어력")
                            {
                                foreach (item item in me.inventory)
                                {
                                    if(item.isEquipped == true && item.stat == "방어력") 
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
        public static void Shop(Character me)//상점
        {
            int a = 0;
            Console.Clear();
            Console.WriteLine($"상점\n필요한 아이템을 얻를 수 있는 상점입니다.\n\n" +
                $"[보유 골드]\n{me.gold} G\n\n[아이템 목록]\n");
            foreach (item item in itemlist.items)
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
                    GameStart(me);
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
                foreach (item item in itemlist.items)
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
                        Shop(me);
                        a = 1;
                        b = 1;
                    }
                    else if (int.Parse(choice) <= 6&& int.Parse(choice)>0)
                    {
                        item selected=itemlist.items[int.Parse(choice)-1];
                        if (selected.isBought == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (selected.price <= me.gold)
                        {
                            me.gold -= selected.price;
                            me.inventory.Add(selected);
                            selected.isBought=true;
                            
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
        public static void Rest(Character me)//휴식
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
                    GameStart(me);
                    a = 1;
                }
                else if (choice == "1")
                {
                    if (me.gold >= 500) 
                    {
                        me.hp = 100;
                        me.gold -= 500;
                        Console.Write("휴식을 완료했습니다.\n>>");
                        int x=Console.GetCursorPosition().Left;
                        int y = Console.GetCursorPosition().Top;
                        Console.SetCursorPosition(53, 1);
                        Console.Write($"{me.gold}G)   ");
                        Console.SetCursorPosition(x,y);
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
                    Console.WriteLine($"{me.inventory[count - 1].itemInfo("inventory")} | {me.inventory[count - 1].price*9/10}");
                }
                }
                
                Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>>");
                while (b == 0)
                {
                    string? choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        Shop(me);
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
                        me.inventory[int.Parse(choice) - 1] = null;
                        b = 1;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }
                }

            }
        }
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
                    DungeonResult(me,1);
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
                    GameStart(me);
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
                        GameStart(me);
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
