using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class QueenClass
    {
        private string goal_possition, current_position;
        BishopClass bishop;
        CastleClass castle;
        string color;
        public QueenClass(string color)
        {
            this.color = color;
             bishop = new BishopClass(color);
             castle = new CastleClass(color);
        }


        public String[] showQueenMovementSuggestion(string current_position)
        {
            string[] arr = new string[100];
            bishop.showBishopMovementSuggestion(current_position).CopyTo(arr,0);
            castle.showCastleMovementSuggestion(current_position).CopyTo(arr, 41);
            return arr;
        }

        public Boolean checkQueenMovementValidity(string goal_position, string current_position)
        {
            string[] arr = showQueenMovementSuggestion(current_position);
            if (arr.Contains(goal_position))
                return true;
            else
                return false;
        }
    }
}
