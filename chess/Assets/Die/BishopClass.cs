using Assets.Die;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class BishopClass
    {
        private string goal_possition, current_position;
        string color;
        public BishopClass(string color) { this.color = color; }



        public String[] showBishopMovementSuggestion(string current_position)
        {

            String[] arr = new String[40];

            int now_x = Int32.Parse(current_position.Split('_')[0]);
            int now_y = Int32.Parse(current_position.Split('_')[1]);


            /***/
           downRight(now_x, now_y).CopyTo(arr, 0);
           topLeft(now_x, now_y).CopyTo(arr, 10);
           topRight(now_x, now_y).CopyTo(arr, 20);
           downLeft(now_x, now_y).CopyTo(arr, 30);

            /****/
            return arr;
        }



        public Boolean checkBishopMovementValidity(string goal_position, string current_position)
        {
            string[] arr = showBishopMovementSuggestion(current_position);
            if (arr.Contains(goal_position)||true)
                return true;
            else
                return false;
        }










        private Int32 nextNumber(int x)
        {
            if (x <= 14)
                return x + 10;
            if (x > 14)
                return x - 14;
            else return -1;
        }
        private Int32 nextNumber2(int x)
        {
            if (x <= 10)
                return x + 14;
            if (x > 14)
                return x - 10;
            else return -1;
        }
        private Int32 nextNumberTopToLeft(int x)
        {
            if (x - 10 > 0)
                return x - 10;
            else
                return x - 10 + 24;
        }

        private Int32 nextNumberDownToLeft(int x)
        {
            if (x - 10 > 0)
                return x - 10;
            else
                return x - 10 + 24;
        }


        private string[] downLeft(int now_x,int now_y)
        {
            int counter = 0,i = now_x,j=now_y;
            string[] arr = new String[10];
            int plus = 1;int minus = -1;
            bool flag2 = false, firstcome = true;
            if (j == 1)
            {
                if (i == 24)
                    i = 1;
                else i++;

                j++;

                plus = 1;
            }
            else
            {
                if (i == 24) { i = 1; j--; plus = -1; } else /*if (j != 6)*/ { i++; j--; plus = -1; } //else { plus = -1; flag2 = true; }
            }
            minus = 1;
            for (; i != now_x || j != now_y; i += minus, j += plus)
            {

                if (i == now_x && j == now_y) break;
                if (j == 1 && i != now_x)
                {
                    if (i == now_x && j == now_y) break;

                    if (counter < 47 && Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) /* do nothing */; //home has die but same color
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    minus = 1; plus = 1;
                    if (i == 24)
                    {
                        j++; plus = 1;

                        i = 1;
                        minus = 1;

                    }
                    else
                    {
                        i++; j++;
                        minus = 1; plus = 1;
                    }
                }
                if (j == 6)
                {
                    if (i == now_x && j == now_y) break;


                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    i = nextNumberTopToLeft(i);
                    Debug.Log(i);
                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    if (i == now_x && j == now_y) break;

                    plus = -1; minus = 1;
                }
                else if (i == 24 && j != 6)
                {
                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    i = 1;
                    minus = 1;
                    j += plus;

                    if (j == 1) plus = 1;

                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color
                }
                else if (j != 6 && counter < 47 && Board.condition_matrix[i, j] == DieClass.NO_DIE)
                    arr[counter++] = i + "_" + j;
                else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                    break;
                else
                { arr[counter++] = i + "_" + j; break; } //home has die but different color

            }

            return arr;
        }

        private string[] topRight(int now_x,int now_y)
        {
            string[] arr = new string[10];int counter = 0, i = now_x, j = now_y;
            int plus = 1; int minus = -1;

            bool flag2 = false, firstcome = true;
            if (j == 1)
            {
                i--; j++;

                plus = 1;
            }
            else
            {
                if (i == 1 && j != 6) { i = 24; j++; plus = 1; } else if (j != 6) { i--; j++; plus = 1; } else { plus = -1; flag2 = true; }
            }
            minus = -1;
            for (; i != now_x || j != now_y || flag2; i += minus, j += plus)
            {

                if (flag2 == false && i == now_x && j == now_y) break;
                if (j == 1 && i != now_x)
                {
                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) /* do nothing */; //home has die but same color
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    minus = -1; plus = 1;
                    if (i == 1)
                    {
                        i = 24;
                        j++;
                        minus = -1; plus = 1;

                    }
                    else
                    {
                        i--; j++;
                        minus = -1; plus = 1;
                    }
                }
                if (j == 6 && firstcome)
                {
                    firstcome = false;
                    if (!flag2)
                    {
                        if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                            arr[counter++] = i + "_" + j;
                        else
                            break;
                        flag2 = false;
                    }
                    i = nextNumber(i);

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    plus = -1; minus = -1;
                }
                else if (i == 1 && j != 6)
                {
                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else
                        break;

                    i = 24;
                    j += plus;

                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color
                }
                else if (j != 6 && Board.condition_matrix[i, j] == DieClass.NO_DIE)
                    arr[counter++] = i + "_" + j;
                else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                    break;
                else
                { arr[counter++] = i + "_" + j; break; } //home has die but different color

            }

            return arr;
        }


        private string[] topLeft(int now_x, int now_y)
        {
            int counter = 0, i = now_x, j = now_y;
            string[] arr = new String[10];
            int plus = 1; int minus = -1;
            bool flag2 = false, firstcome = true;
            if (j == 1)
            {
                if (i == 24)
                    i = 1;
                else i++;

                j++;

                plus = 1;
            }
            else
            {
                if (i == 24) { i = 1; j++; plus = +1; } else if (j != 6) { i++; j++; plus = 1; } else { plus = 1; flag2 = true; }
            }
            minus = 1;
            for (; i != now_x || j != now_y; i += minus, j += plus)
            {

                if (i == now_x && j == now_y) break;
                if (j == 1 && i != now_x)
                {
                    if (i == now_x && j == now_y) break;

                    if (counter < 47 && Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) /* do nothing */; //home has die but same color
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    minus = 1; plus = 1;
                    if (i == 24)
                    {
                        j++; plus = 1;

                        i = 1;
                        minus = 1;

                    }
                    else
                    {
                        i++; j++;
                        minus = 1; plus = 1;
                    }
                }
                if (j == 6)
                {
                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    i = nextNumberTopToLeft(i);


                    
                    try
                    {
                        if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                            arr[counter++] = i + "_" + j;
                        else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                            break;
                        else
                        { arr[counter++] = i + "_" + j; break; } //home has die but different color
                    }catch(Exception )
                    {
                        Debug.Log("error i: " + i);
                        Debug.Log("error j: " + j);


                    }
                    if (i == now_x && j == now_y) break;

                    plus = -1; minus = 1;
                }
                else if (i == 24 && j != 6)
                {
                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    i = 1;
                    minus = 1;
                    j += plus;

                    //=>>>>
                    if (j == 1) plus = 1;

                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color
                }
                else if (j != 6 && counter < 10 && i < 25 && j < 7 && i > 0 && j > 0 && Board.condition_matrix[i, j] == DieClass.NO_DIE )
                    arr[counter++] = i + "_" + j;
                else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                    break;
                else
                { arr[counter++] = i + "_" + j; break; } //home has die but different color

            }

            return arr;
        }

        private string[] downRight(int now_x, int now_y)
        {
            string[] arr = new string[30]; int counter = 0, i = now_x, j = now_y;
            int plus = 1; int minus = -1;

            bool flag2 = false, firstcome = true;
            if (j == 1)
            {
                if (i == 1)
                    i = 24;
                else
                i--;

                j++;

                plus = 1;
            }
            else
            {
                if (i == 1 && j != 6) { i = 24; j--; plus = -1; } else if (j != 6) { i--; j--; plus = -1; } else { plus = -1; flag2 = true; }
            }
            minus = -1;
            for (; i != now_x || j != now_y || flag2; i += minus, j += plus)
            {

                if (flag2 == false && i == now_x && j == now_y) break;
                if (j == 1 && i != now_x)
                {
                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) /* do nothing */; //home has die but same color
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    minus = -1; plus = 1;
                    if (i == 1)
                    {
                        i = 24;
                        j++;
                        minus = -1; plus = 1;

                    }
                    else
                    {
                        i--; j++;
                        minus = -1; plus = 1;
                    }
                }
                if (j == 6 && firstcome)
                {

                    firstcome = false;
                    if (!flag2)
                    {
                        if (i == now_x && j == now_y) break;

                        if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                            arr[counter++] = i + "_" + j;
                        else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                            break;
                        else
                        { arr[counter++] = i + "_" + j; break; } //home has die but different color

                        flag2 = false;
                    }else
                    {
                        i--;j--;
                        if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                            arr[counter++] = i + "_" + j;
                        else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                            break;
                        else
                        { arr[counter++] = i + "_" + j; break; } //home has die but different color

                        flag2 = false;
                    }
                    i = nextNumber(i);

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color
                    
                    plus = -1; minus = -1;
                }
                else if (i == 1 && j != 6)
                {
                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color

                    i = 24;
                    j += plus;

                    if (i == now_x && j == now_y) break;

                    if (Board.condition_matrix[i, j] == DieClass.NO_DIE)
                        arr[counter++] = i + "_" + j;
                    else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                        break;
                    else
                    { arr[counter++] = i + "_" + j; break; } //home has die but different color
                }
                else if (i == now_x && j == now_y) break;
                else if (j != 6 && Board.condition_matrix[i, j] == DieClass.NO_DIE)
                    arr[counter++] = i + "_" + j;
                else if (DieClass.colorCheck(i, j) == color) //home has die but same color
                    break;
                else
                { arr[counter++] = i + "_" + j; break; } //home has die but different color

            }

            return arr;
        }



    }


}
