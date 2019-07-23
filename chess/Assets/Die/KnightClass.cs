
using Assets.Die;
using System;
using System.Linq;
using UnityEngine;

namespace Assets
{
/*    try
    {
     فراموش نشود
    }catch(Exception)
    {
    
    }

*/
    class KnightClass
    {
        string color;
        public KnightClass(string color)
        {
            this.color = color;
            
        }




        public String[] showKnightMovementSuggestion(string current_position)
        {
            Debug.Log(current_position);
            {

                string[] returnString = new string[8];

                int x2 = Int32.Parse(current_position.Split('_')[0]);
                int y2 = Int32.Parse(current_position.Split('_')[1]);


                int nowX = x2, nowY = y2;

                int tempX = nowX, tempY = nowY;

                if (tempX + 2 >= 25)
                {

                    tempY = nowY; tempX = nowX;

                    if (tempX == 24)
                        tempX = 2;
                    else if (tempX == 23)
                        tempX = 1;
                    else tempX += 2;

                    if (tempY == 6) { tempY = 6; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else tempY += 1;
          
                    
                   
                    if (Board.condition_matrix[Math.Abs(tempX), (tempY)] == DieClass.NO_DIE)
                        returnString[0] = Math.Abs(tempX) + "_" + (tempY);

                    tempX = nowX; tempY = nowY;
                    
                    if (tempY - 1 >= 1)
                    {
                        if (tempX == 23)
                            tempX = 1;
                        else if (tempX == 24)
                            tempX = 2;
                        if (Board.condition_matrix[Math.Abs(tempX), (tempY - 1)] == DieClass.NO_DIE)
                            returnString[1] = Math.Abs(tempX) + "_" + (tempY - 1);
                    }

                    tempY = nowY;
                }
                else
                {

                    //**2**

                    tempY = nowY; tempX = nowX;

                    if (tempX == 24)
                        tempX = 2;
                    else if (tempX == 23)
                        tempX = 1;
                    else tempX += 2;

                    if (tempY == 6) { tempY = 6; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else tempY += 1;
                    //0
                    if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                        returnString[0] = (tempX) + "_" + (tempY);


                    tempY = nowY; tempX = nowX;


                    //1
                    if (Board.condition_matrix[(tempX + 2), (tempY - 1)] == DieClass.NO_DIE)
                        returnString[1] = (tempX + 2) + "_" + (tempY - 1);

                    tempY = nowY;
                }

                /**/
                tempY = nowY; tempX = nowX;

                if (tempX - 2 <= 0)
                {

                    if (tempX == 1)
                        tempX = 23;
                    else if (tempX == 2)
                        tempX = 24;
                    else tempX -= 2;

                    if (tempY == 6) { tempY = 6; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else tempY += 1;


                    if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                        returnString[2] = (tempX) + "_" + (tempY);

                    tempX = nowX; tempY = nowY;

                    if (tempY - 1 >= 1)
                    {
                        if (tempX == 2)
                            tempX = 24;
                        else if (tempX == 1)
                            tempX = 23;

                        if (Board.condition_matrix[(tempX), (tempY - 1)] == DieClass.NO_DIE)
                            returnString[3] = (tempX) + "_" + (tempY - 1);

                    }
                }
                else
                {
                    // print("**4**");
                    tempY = nowY; tempX = nowX;

                    if (tempX == 1)
                        tempX = 23;
                    else if (tempX == 2)
                        tempX = 24;
                    else tempX -= 2;

                    if (tempY == 6) { tempY = 6; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else tempY += 1;

                    if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                            returnString[2] = (tempX) + "_" + (tempY);

                        tempY = nowY; tempX = nowX;

                    if (tempY - 1 >= 1)
                    {
                        if (tempX == 2)
                            tempX = 24;
                        else if (tempX == 1)
                            tempX = 23;

                        if (Board.condition_matrix[(tempX), (tempY - 1)] == DieClass.NO_DIE)
                            returnString[3] = (tempX) + "_" + (tempY - 1);

                    }

                    tempY = nowY;
                }

                tempY = nowY; tempX = nowX;

                /**/
                if (tempX + 1 >= 25)
                {

                    if (tempX == 24)
                        tempX = 1;
                    else tempX++;

                    if (tempY == 5) { tempY = 6; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else if (tempY == 6) { tempY = 5; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else tempY += 2;

                    if (Board.condition_matrix[(tempX ), (tempY)] == DieClass.NO_DIE)
                        returnString[4] = (tempX) + "_" + (tempY);

                    tempY = nowY; tempX = nowX;

                    if ((tempY - 2) >= 1)
                    {
                        if (tempX == 24)
                            tempX = 1;
                        else tempX++;
                        tempY -= 2;

                        if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                            returnString[5] = (tempX) + "_" + (tempY);
                    }

                



                }
                else
                {
                    //print("**6**");

                    tempY = nowY; tempX = nowX;

                    if (tempX == 24)
                        tempX = 1;
                    else tempX ++;

                    if (tempY == 5) { tempY = 6; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else if (tempY == 6) { tempY = 5; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                    else tempY += 2;

                    if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                        returnString[4] = (tempX) + "_" + (tempY);


                    tempY = nowY;tempX = nowX;

                    if ((tempY - 2) >= 1)
                    {
                        if (tempX == 24)
                            tempX = 1;
                        else tempX++;
                        tempY -= 2;

                        if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                            returnString[5] = (tempX) + "_" + (tempY);
                    }

                }


                /***/
                //                print("**7**");

                tempX = nowX;tempY = nowY;


                if (tempX == 1)
                    tempX = 24;
                else
                    tempX--;

                if (tempY == 5) { tempY = 6; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                else if (tempY == 6) { tempY = 5; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }
                else tempY += 2;


                if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                    returnString[6] = (tempX) + "_" + (tempY);




                tempY = nowY;tempX = nowX;
                if ((tempY - 2) >= 1 /*&& (tempX - 1) >= 1*/)
                {

                    if (tempX == 1)
                        tempX = 24;
                    else
                        tempX--;
                    tempY -= 2;


                    if (Board.condition_matrix[(tempX), (tempY)] == DieClass.NO_DIE)
                        returnString[7] = (tempX) + "_" + (tempY);

                }
                
                else if ((tempY - 2) >= 1)
                {
                    if (Board.condition_matrix[(tempX + 24 - 1), (tempY - 2)] == DieClass.NO_DIE)
                        returnString[7] = (tempX + 24 - 1) + "_" + (tempY - 2);
                    //print("available_8: " + (tempX + 24 - 1) + "_" + (tempY - 2));
                }
                return returnString;               
            }
        }

        public Boolean checkKnightMovementValidity(string goal_position,string current_position)
        {
            string[] arr = showKnightMovementSuggestion(current_position);
            if (arr.Contains(goal_position))
                return true;
            else
                return false;
            /*int x1 = Int32.Parse(goal_position.Split('_')[0]);
            int y1 = Int32.Parse(goal_position.Split('_')[1]);
            int x2 = Int32.Parse(current_position.Split('_')[0]);
            int y2 = Int32.Parse(current_position.Split('_')[1]);


            int nowX = x2, nowY = y2, goalX = x1, goalY = y1;

            int tempX = nowX, tempY = nowY;


            if (tempX + 2 >= 25)
            {
                //print("**1**");

                if (tempY == 5) { tempY--; tempX += 12; }
                else if (tempY == 6) { tempY--; tempX += 12; }

                //print("available_1: " + Math.Abs(tempX - 24 + 2) + "_" + (tempY + 1));
                if (goalX == Math.Abs(tempX - 24 + 2) && goalY == (tempY + 1))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
                tempX = nowX; tempY = nowY;

                /*if (tempY - 1 >= 1)
                    print("available_2: " + Math.Abs(tempX - 24 + 2) + "_" + (tempY - 1));*//*

                if (goalX == Math.Abs(tempX - 24 + 2) && goalY == (tempY - 1))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
                tempY = nowY;
            }
            else
            {

                //print("**2**");
                if (tempY == 6) { tempY = 5; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }

                //print("available_1: " + (tempX + 2) + "_" + (tempY + 1));
                if (goalX == Math.Abs(tempX + 2) && goalY == (tempY + 1))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }

                tempY = nowY; tempX = nowX;

               /* if (tempY - 1 >= 1)
                    print("available_2: " + (tempX + 2) + "_" + (tempY - 1));*//*


                if (goalX == Math.Abs(tempX + 2) && goalY == (tempY - 1))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }

                tempY = nowY;
            }

            /**//*

            if (tempX - 2 <= 0)
            {

                //print("**3**");
                if (tempY == 6) { tempY = 5; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }


                //print("available_3: " + (tempX + 24 - 2) + "_" + (tempY + 1));
                if (goalX == (tempX + 24 - 2) && goalY == (tempY + 1))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
                tempX = nowX; tempY = nowY;

                /*if (tempY - 1 >= 1)
                    print("available_4: " + (tempX + 24 - 2) + "_" + (tempY - 1));*//*


                if (goalX == (tempX + 24 - 2) && goalY == (tempY - 1))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
            }
            else
            {
               // print("**4**");


                if ((tempX - 2) >= 1)
                {
                    if (tempY == 5) { tempY--; tempX += 12; }
                    else if (tempY == 6) { tempY = 5; if (tempX < 12) tempX += 12; else if (tempX > 12) tempX -= 12; else tempX = 24; }

                    //print("available_3: " + (tempX - 2) + "_" + (tempY + 1));
                    if (goalX == (tempX - 2) && goalY == (tempY + 1))
                    {
                        Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                        return true;
                    }
                    tempY = nowY; tempX = nowX;
                }
                /*if (tempY - 1 >= 1)
                    print("available_4: " + (tempX - 2) + "_" + (tempY - 1));
                    *//*
                if (goalX == (tempX - 2) && goalY == (tempY - 1))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }

                tempY = nowY;
            }


            /**//*
            if (tempX + 1 >= 25)
            {
               // print("**5**");

                if (tempY == 5) { tempY--; tempX += 12; }
                else if (tempY == 6) { tempY -= 2; tempX += 12; }

                //print("available_5: " + (tempX - 24 + 1) + "_" + (tempY + 2));
                if (goalX == Math.Abs(tempX - 24 + 1) && goalY == (tempY + 2))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
                tempY = nowY; tempX = nowX;

                //if ((tempY - 2) >= 1)
                   // print("available_6: " + (tempX - 24 + 1) + "_" + (tempY - 2));


                if (goalX == Math.Abs(tempX - 24 + 1) && goalY == (tempY - 2))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }


            }
            else
            {
                //print("**6**");


                if (tempY == 5) { tempY--; tempX += 12; }
                else if (tempY == 6) { tempY = 3; if (tempX < 12) tempX += 12 - 1; else if (tempX > 12) tempX = 12 - 1; else tempX = 24 - 1; }


                //print("available_5: " + (tempX + 1) + "_" + (tempY + 2));
                if (goalX == Math.Abs(tempX + 1) && goalY == (tempY + 2))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
                tempY = nowY; tempX = nowX;

                /*if ((tempY - 2) >= 1)
                    print("available_6: " + (tempX + 1) + "_" + (tempY - 2));
                    *//*

                if (goalX == Math.Abs(tempX + 1) && goalY == (tempY - 2))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
            }


            /***//*
            //print("**7**");



            if (tempY == 5) { tempY--; tempX += 12; }
            else if (tempY == 6) { tempY = 3; if (tempX < 12) tempX += 12 - 1; else if (tempX > 12) tempX = 12 - 1; else tempX = 24 - 1; }

           // print("available_7: " + (tempX - 1) + "_" + (tempY + 2));
            if (goalX == Math.Abs(tempX - 1) && goalY == (tempY + 2))
            {
                Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                return true;
            }

            tempY = nowY; tempX = nowX;


            if ((tempY - 2) >= 1 && (tempX - 1) >= 1)
            {
                // print("available_8: " + (tempX - 1) + "_" + (tempY - 2));
                if (goalX == Math.Abs(tempX - 1) && goalY == (tempY - 2))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
            }

            else if ((tempY - 2) >= 1)
            {
                //print("available_8: " + (tempX + 24 - 1) + "_" + (tempY - 2));
                if (goalX == Math.Abs(tempX + 24 - 1) && goalY == (tempY - 2))
                {
                    Board.condition_matrix[goalX, goalY] = DieClass.SET_DIE;
                    return true;
                }
            }
            
            return false;*/
        }
    }
}
