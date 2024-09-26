using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SaveAndLoad
    {
        public static void SaveData(Character me, ItemList itemList)//저장
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(".\\data.dat", FileMode.Create);

            DataField filesaver = new DataField();

            filesaver.level = me.level;
            filesaver.name = me.name;
            filesaver.job = me.job;
            filesaver.atk = me.atk;
            filesaver.def = me.def;
            filesaver.hp = me.hp;
            filesaver.gold = me.gold;
            filesaver.inventory = me.inventory;
            filesaver.exp = me.exp;
            filesaver.itemList = Program.itemlist;

            bf.Serialize(fs, filesaver);

            fs.Close();
        }

        public static void LoadData(Character me, ItemList itemList)//불러오기
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(".\\data.dat", FileMode.Open);

            DataField filesaver = new DataField();
            filesaver = bf.Deserialize(fs) as DataField;
            me.level = filesaver.level;
            me.name = filesaver.name;
            me.job = filesaver.job;
            me.atk = filesaver.atk;
            me.def = filesaver.def;
            me.hp = filesaver.hp;
            me.gold = filesaver.gold;
            me.exp = filesaver.exp;
            Program.itemlist = filesaver.itemList;
            me.inventory = filesaver.inventory;
            fs.Close();
        }
    }
}
