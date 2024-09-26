using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class ItemList
    {
        public item[] items = new item[6];
        public ItemList()
        {
            items[0] = new item("수련자 갑옷    ", "방어력", 5, "수련에 도움을 주는 갑옷입니다.                     ", 1000, false, false);
            items[1] = new item("무쇠 갑옷      ", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.                 ", 2000, false, false);
            items[2] = new item("스파르타의 갑옷", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ", 3500, false, false);
            items[3] = new item("낡은 검        ", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.                    ", 600, false, false);
            items[4] = new item("청동 도끼      ", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.               ", 1500, false, false);
            items[5] = new item("스파르타의 창  ", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.    ", 3000, false, false);
        }

    }
}
