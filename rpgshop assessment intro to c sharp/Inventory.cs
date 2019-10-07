using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Inventory
    {

        private Item[] _list = new Item[0];

        public void ArrayList()
        {
            _list = new Item[0];
        }

        public virtual int remove(int index)
        {
            Item[] newList = new Item[_list.Length - 1];
            int newPosition = 0;
            for (int i = 0; i < _list.Length; i++)
            {
                if (i != index)
                {
                    newList[newPosition] = _list[i];
                    newPosition++;
                }

            }
            _list = newList;
            int j = 0;
            return j;
        }

        public virtual int Add(Item value)
        {
            Item[] newList = new Item[_list.Length + 1];
            for (int i = 0; i < _list.Length; i++)
            {
                newList[i] = _list[i];
            }
            //Put the new value at the end of the new array
            newList[newList.Length - 1] = value;

            _list = newList;
            int j = 0;
            return j;
        }
        public virtual void Clear()
        {
            _list = new Item[0];
        }

        public virtual Item this[int index]
        {
            set
            {
                _list[index] = value;
            }
            get
            {
                return _list[index];
            }
        }
        public void print()
        {
            foreach (Item i in _list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        public int Length
        {
            get
            {
                return _list.Length;
            }
        }
        public void transfer() //this is for testing dont think it will work but 
        {

        }
        public Item GetItem(int choice)
        {
            return _list[choice];
        }

    }


}

