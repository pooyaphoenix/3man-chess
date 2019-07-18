using Assets.Die;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class CastleClass
    {
        private string goal_possition, current_position;
        public CastleClass()
        {

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

            /*diametery*/
            int plus = 1, temp_i = now_x;
            for (int i = now_x, j = now_y + 1; ; j += plus)
            {


                if (j == 6)
                {
                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;

                    else
                        break;
                    /**/
                    if (i != 12) temp_i = (i + 12) % 24; else temp_i = 24;
                    /**/
                    if (Board.condition_matrix[temp_i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;

                    else
                        break;

                    plus = -1;

                }
                else if (Board.condition_matrix[temp_i, j] == DieClass.NO_DIE)
                    arr[counter++] = i + "_" + j;
                else
                    break;


                if (i >= 25 || j >= 7 || i <= 0 || j <= 0)
                    break;


            }

            /*clockwise*/
            int adder = now_x; if (adder == 24) adder = 1; else adder = now_x + 1;
            for (; ; adder++)
            {
                if (adder == 24 && adder != now_x)
                {
                    if (Board.condition_matrix[adder, now_y] == DieClass.NO_DIE)
                        arr[counter++] = adder + "_" + now_y;

                    else
                        break;

                    adder = 1;
                    if (Board.condition_matrix[adder, now_y] == DieClass.NO_DIE && adder != now_x)
                        arr[counter++] = adder + "_" + now_y;

                    else
                        break;
                }
                else if (Board.condition_matrix[adder, now_y] == DieClass.NO_DIE && adder != now_x)
                    arr[counter++] = adder + "_" + now_y;

                else
                    break;

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

                    else
                        break;

                    subber = 24;
                    if (Board.condition_matrix[subber, now_y] == DieClass.NO_DIE && subber != now_x)
                        arr[counter++] = subber + "_" + now_y;

                    else
                        break;
                }
                else if (Board.condition_matrix[subber, now_y] == DieClass.NO_DIE && subber != now_x)
                    arr[counter++] = subber + "_" + now_y;

                else
                    break;

                if (subber >= 25 || subber <= 0 || subber == now_x)
                    break;
            }
            return arr;
        }
    }
}
