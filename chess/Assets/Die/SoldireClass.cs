using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class SoldireClass
    {
        private string goal_possition, current_position;
        public SoldireClass(string goal_possition,string current_position)
        {
            this.goal_possition = goal_possition;
            this.current_position = current_position;
        }

        String[] soldireSuggesstionHomesForMove()
        {
            String[] arr = new String[10];
            return arr;
        }

        Boolean soldireCheckMovementValidity()
        {
            return false;
        }
    }
}
