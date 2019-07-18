using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class QueenClass
    {
        private string goal_possition, current_position;
        public QueenClass(string goal_possition, string current_position)
        {
            this.goal_possition = goal_possition;
            this.current_position = current_position;
        }
    }
}
