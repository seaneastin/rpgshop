using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Inventory
    {

        //this is a dynamic array this is used by the shop and player inventory



        private Item[] _list = new Item[0];

        public virtual int remove(int index) //this removes something from an array
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

        public virtual int Add(Item value) //this add something to the array
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
        public virtual void Clear() //clears out an inventory used durring the load function
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
        public int Length //the Length of the array
        {
            get
            {
                return _list.Length;
            }
        }
        public Item GetItem(int choice) 
        {
            return _list[choice];
        }

    }


}

