using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class KingClass
    {
        string color;
        public KingClass(string color)
        {
            this.color = color;
        }


        public String[] showBishopMovementSuggestion(string current_position)
        {

            String[] arr = new String[40];
            
            /****/
            return arr;
        }



        public Boolean checkKingCheckMateValidity(string goal_position, string current_position)
        {
            string[] arr = showBishopMovementSuggestion(current_position);
            if (arr.Contains(goal_position))
                return true;
            else
                return false;
        }
    }
}
