using Assets.Die;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class SoldireClass
    {
        private string goal_possition, current_position;
        string color;
        public SoldireClass(string color) { this.color = color; }
        public SoldireClass(string goal_possition,string current_position)
        {
            this.goal_possition = goal_possition;
            this.current_position = current_position;
        }

        public String[] showSoldireMovementSuggestion(string current_position) 
        {
            String[] arr = new String[10];
            int counter = 0;
            int temp;


            int nowX = Int32.Parse(current_position.Split('_')[0]);
            int nowY = Int32.Parse(current_position.Split('_')[1]);


            if (color == DieClass.GREEN_DIE)
            {
                if (nowX >= 1 && nowX <= 8 && nowY != 6)
                {

                    if (Board.condition_matrix[nowX, nowY + 1] == DieClass.NO_DIE)
                        arr[counter++] = nowX + "_" + (nowY + 1);

                    if (nowY == 2)
                    {
                        if (Board.condition_matrix[nowX, nowY + 2] == DieClass.NO_DIE)
                            arr[counter++] = nowX + "_" + (nowY + 2);
                    }

                    temp = nowX;
                    if (temp == 1) temp = 24;
                    if (Board.condition_matrix[temp, nowY + 1] != DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY + 1);

                    temp = nowX;
                    if (temp == 24) temp = 1;
                    if (Board.condition_matrix[temp, nowY + 1] != DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY + 1);
                }else if(nowX < 24 && nowX > 8)
                {
                    if (Board.condition_matrix[nowX, nowY - 1] == DieClass.NO_DIE)
                        arr[counter++] = (nowX) + "_" + (nowY - 1);

                    if (Board.condition_matrix[nowX + 1, nowY - 1] != DieClass.NO_DIE)
                        arr[counter++] = (nowX + 1) + "_" + (nowY - 1);

                    if (Board.condition_matrix[nowX - 1, nowY - 1] != DieClass.NO_DIE)
                        arr[counter++] = (nowX - 1) + "_" + (nowY - 1);
                }
                else if (nowY == 6)
                {

                    if (Board.condition_matrix[nowX + 12, nowY] == DieClass.NO_DIE)
                        arr[counter++] = (nowX + 12) + "_" + (nowY);
           
                    if (Board.condition_matrix[nowX + 11, nowY] != DieClass.NO_DIE)
                        arr[counter++] = (nowX + 11) + "_" + (nowY);

                    if (Board.condition_matrix[nowX + 13, nowY] != DieClass.NO_DIE)
                        arr[counter++] = (nowX + 13) + "_" + (nowY);

                }

            }
            else if (color == DieClass.RED_DIE)
            {
                if (nowX >= 9 && nowX <= 16  && nowY != 6)
                {

                    if (Board.condition_matrix[nowX, nowY + 1] == DieClass.NO_DIE)
                        arr[counter++] = nowX + "_" + (nowY + 1);

                    if (nowY == 2)
                    {
                        if (Board.condition_matrix[nowX, nowY + 2] == DieClass.NO_DIE)
                            arr[counter++] = nowX + "_" + (nowY + 2);
                    }


                    if (Board.condition_matrix[nowX, nowY + 1] != DieClass.NO_DIE)
                        arr[counter++] = nowX + "_" + (nowY + 1);


                    if (Board.condition_matrix[nowX, nowY + 1] != DieClass.NO_DIE)
                        arr[counter++] = nowX + "_" + (nowY + 1);
                }
                else if (nowX > 18 || nowX < 10 )
                {
                    if (Board.condition_matrix[nowX, nowY - 1] == DieClass.NO_DIE)
                        arr[counter++] = (nowX) + "_" + (nowY - 1);

                    if (Board.condition_matrix[nowX + 1, nowY - 1] != DieClass.NO_DIE)
                        arr[counter++] = (nowX + 1) + "_" + (nowY - 1);


                    if(nowY - 1 != 0)
                        if (Board.condition_matrix[nowX - 1, nowY - 1] != DieClass.NO_DIE)
                            arr[counter++] = (nowX - 1) + "_" + (nowY - 1);
                }
                else if (nowY == 6)
                {
                    temp = (nowX + 12) % 24;
                    if (temp == 0)
                        temp = 24;
                    if (Board.condition_matrix[temp, nowY] == DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY);


                    temp = (nowX + 11) % 24;
                    if (temp == 0)
                        temp = 24;
                    if (Board.condition_matrix[temp, nowY] != DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY);


                    temp = (nowX + 13) % 24;
                    if (temp == 0)
                        temp = 24;
                    if (Board.condition_matrix[temp, nowY] != DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY);
                }
            }
            if (color == DieClass.YELLOW_DIE)
            {
                if (nowX >= 16 && nowX <= 24 && nowY != 6)
                {

                    if (Board.condition_matrix[nowX, nowY + 1] == DieClass.NO_DIE)
                        arr[counter++] = nowX + "_" + (nowY + 1);

                    if (nowY == 2)
                    {
                        if (Board.condition_matrix[nowX, nowY + 2] == DieClass.NO_DIE)
                            arr[counter++] = nowX + "_" + (nowY + 2);
                    }


                    if (Board.condition_matrix[nowX, nowY + 1] != DieClass.NO_DIE)
                        arr[counter++] = nowX + "_" + (nowY + 1);


                    if (Board.condition_matrix[nowX, nowY + 1] != DieClass.NO_DIE)
                        arr[counter++] = nowX + "_" + (nowY + 1);
                }
                else if (nowX > 2 && nowX < 15)
                {
                    if (Board.condition_matrix[nowX, nowY - 1] == DieClass.NO_DIE)
                        arr[counter++] = (nowX) + "_" + (nowY - 1);

                    if (Board.condition_matrix[nowX + 1, nowY - 1] != DieClass.NO_DIE)
                        arr[counter++] = (nowX + 1) + "_" + (nowY - 1);


                    if (nowY - 1 != 0)
                        if (Board.condition_matrix[nowX - 1, nowY - 1] != DieClass.NO_DIE)
                            arr[counter++] = (nowX - 1) + "_" + (nowY - 1);
                }
                else if (nowY == 6)
                {
                    temp = (nowX - 12);
                    if (temp < 0)
                        temp += 24;
                    if (Board.condition_matrix[temp, nowY] == DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY);


                    temp = (nowX - 11);
                    if (temp < 0)
                        temp += 24;
                    if (Board.condition_matrix[temp, nowY] != DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY);


                    temp = (nowX - 13);
                    if (temp < 0)
                        temp += 24;
                    if (Board.condition_matrix[temp, nowY] != DieClass.NO_DIE)
                        arr[counter++] = temp + "_" + (nowY);
                }
            }

            
            return arr;
        }

        public Boolean checkSoldiertMovementValidity(string goal_position, string current_position,string color)
        {
            string[] arr = showSoldireMovementSuggestion(current_position);
            if (arr.Contains(goal_position))
                return true;
            else
                return false;
        }


    }
}
