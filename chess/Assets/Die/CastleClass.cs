using Assets.Die;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class CastleClass
    {
        private string goal_possition, current_position,color;
        public CastleClass(string color)
        {
            this.color = color;
        }
        public CastleClass(string goal_possition, string current_position)
        {
            this.goal_possition = goal_possition;
            this.current_position = current_position;
        }


        
        public String[] showCastleMovementSuggestion(string current_position)
        {
            string[] arr = new string[58];
            int counter = 0;
            int now_x = Int32.Parse(current_position.Split('_')[0]);
            int now_y = Int32.Parse(current_position.Split('_')[1]);

            /*diametery down to up */
            int plus = 1, temp_i = now_x;bool first6 = false;
            int j = now_y; if (j < 6) j++; else first6 = true;

            for (int i = now_x; ; j += plus)
            {


                if (j == 6)
                {
                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE && !first6)
                        arr[counter++] = i + "_" + j;
                    // check this
                    else if (DieClass.colorCheck(i, now_y) == color && !first6) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + now_y; break; } //home has die but different color
                    /**/
                    if (i != 12) { temp_i = (now_x + 12) % 24; } else temp_i = 24;
                    /**/
                    if (Board.condition_matrix[temp_i, j] == DieClass.NO_DIE)
                        arr[counter++] = temp_i + "_" + j;

                    else if (DieClass.colorCheck(temp_i, now_y) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = temp_i + "_" + now_y; break; } //home has die but different color

                    plus = -1;

                }
                else if (Board.condition_matrix[temp_i, j] == DieClass.NO_DIE)
                    arr[counter++] = temp_i + "_" + j;
                else if (DieClass.colorCheck(temp_i, now_y) == color) //home has die but same color
                    break;
                else
                { arr[counter++] = temp_i + "_" + now_y; break; } //home has die but different color


                if (i >= 25 || j >= 7 || i <= 0 || j <= 0)
                    break;


            }



            /*diametery up to down */
            plus = -1; temp_i = now_x; 
            j = now_y;

            if (j > 1 && j <= 6)
            {
                j--;

                for (int i = now_x; j != 0; j += plus)
                {

                    if (Board.condition_matrix[now_x, j] == DieClass.NO_DIE)
                        arr[counter++] = now_x + "_" + j;
                    else if (DieClass.colorCheck(now_x, now_y) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = now_x + "_" + now_y; break; } //home has die but different color


                    if (i >= 25 || j >= 7 || i <= 0 || j <= 0)
                        break;
                }
            }


            /*clockwise*/
            int adder = now_x; if (adder == 24) adder = 1; else adder = now_x + 1;
            for (; ; adder++)
            {
                if (adder == 24 && adder != now_x)
                {
                    if (Board.condition_matrix[adder, now_y] == DieClass.NO_DIE)
                        arr[counter++] = adder + "_" + now_y;
                    else if (DieClass.colorCheck(adder, now_y) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = adder + "_" + now_y; break; } //home has die but different color

                    adder = 1;
                    if (Board.condition_matrix[adder, now_y] == DieClass.NO_DIE && adder != now_x)
                        arr[counter++] = adder + "_" + now_y;
                    else if (DieClass.colorCheck(adder, now_y) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = adder + "_" + now_y; break; } //home has die but different color

                }
                else if (Board.condition_matrix[adder, now_y] == DieClass.NO_DIE && adder != now_x)
                    arr[counter++] = adder + "_" + now_y;
                else if (DieClass.colorCheck(adder, now_y) == color) //home has die but same color
                    break;
                else
                { arr[counter++] = adder + "_" + now_y; break; } //home has die but different color

                if (adder >= 25 || adder <= 0 || adder == now_x)
                    break;
            }

            /*anti-clockwise*/
            int subber = now_x; if (subber == 1) subber = 24; else subber = now_x - 1;
            for (; ; subber--)
            {
                if (subber == 1 && subber != now_x)
                {
                    if (Board.condition_matrix[subber, now_y] == DieClass.NO_DIE)
                        arr[counter++] = subber + "_" + now_y;
                    else if (DieClass.colorCheck(subber, now_y) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = subber + "_" + now_y; break; } //home has die but different color

                    subber = 24;
                    if (Board.condition_matrix[subber, now_y] == DieClass.NO_DIE && subber != now_x)
                        arr[counter++] = subber + "_" + now_y;
                    else if (DieClass.colorCheck(subber, now_y) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = subber + "_" + now_y; break; } //home has die but different color

                }
                else if (Board.condition_matrix[subber, now_y] == DieClass.NO_DIE && subber != now_x)
                    arr[counter++] = subber + "_" + now_y;
                else if (DieClass.colorCheck(subber, now_y) == color) //home has die but same color
                    break;
                else
                { arr[counter++] = subber + "_" + now_y; break; } //home has die but different color

                if (subber >= 25 || subber <= 0 || subber == now_x)
                    break;
            }
            return arr;
        }

        public Boolean checkCastleMovementValidity(string goal_position, string current_position)
        {
            string[] arr = showCastleMovementSuggestion(current_position);
            if (arr.Contains(goal_position))
                return true;
            else
                return false;         
        }


    }
}
