using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
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
        public item(string name, string stat, int statNum, string content, int price, bool isBought, bool isEquipped)
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
            if (isEquipped == true && position == "inventory")
            {
                temp = "";
            }
            return $"{name}{temp}| {stat} + {statNum} | {content}";
        }
    }
}
