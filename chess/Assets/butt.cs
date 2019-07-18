using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Assets;
using Assets.Die;

public class butt : MonoBehaviour
{

    // we initialize this variables for checking a die move with no collision in its way

    Board myBoard;

    KingClass myKing;
    SoldireClass mySoldire;
    QueenClass myQueen;
    CastleClass myCastle;
    BishopClass myBishop;
    KnightClass myKnight;

    string[,] condition_matrix = new string[25, 7] {
        {"","","","","","",""},//0

        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","",""},{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","",""},//1,2
        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","","" },{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","","" },//3
        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","","" },{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","","" },//5
        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","","" },{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,"","","","" },//7

        {"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },{"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },//9
        {"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },{"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },//11
        {"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },{"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },//13
        {"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },{"",DieClass.RED_DIE,DieClass.RED_DIE,"","","","" },//15

        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","","" },{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","",""},//17
        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","",""},{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","","" },//19
        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","","" },{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","","" },//21
        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","","" },{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,"","","","" }//23
    };

    string[,] board_Matrix = new string[24, 6]
    {
        {"1_1","1_2","1_3","1_4","1_5","1_6"},{"2_1","2_2","2_3","2_4","2_5","2_6" },
        {"3_1","3_2","3_3","3_4","3_5","3_6" },{"4_1","4_2","4_3","4_4","4_5","4_6" },
        {"5_1","5_2","5_3","5_4","5_5","5_6" },{"6_1","6_2","6_3","6_4","6_5","6_6" },
        {"7_1","7_2","7_3","7_4","7_5","7_6" },{"8_1","8_2","8_3","8_4","8_5","8_6" },
        {"9_1","9_2","9_3","9_4","9_5","9_6" },{"10_1","10_2","10_3","10_4","10_5","10_6" },
        {"11_1","11_2","11_3","11_4","11_5","11_6" },{"12_1","12_2","12_3","12_4","12_5","12_6" },
        {"13_1","13_2","13_3","13_4","13_5","13_6" },{"14_1","14_2","14_3","14_4","14_5","14_6" },
        {"15_1","15_2","15_3","15_4","15_5","15_6" },{"16_1","16_2","16_3","16_4","16_5","16_6" },
        {"17_1","17_2","17_3","17_4","17_5","17_6" },{"18_1","18_2","18_3","18_4","18_5","18_6" },
        {"19_1","19_2","19_3","19_4","19_5","19_6" },{"20_1","20_2","20_3","20_4","20_5","20_6" },
        {"21_1","21_2","21_3","21_4","21_5","21_6" },{"22_1","22_2","22_3","22_4","22_5","22_6" },
        {"23_1","23_2","23_3","23_4","23_5","23_6" },{"24_1","24_2","24_3","24_4","24_5","24_6" },
    };

    public Transform nowObject;
    public Transform pastX;
    public String[] s;
    public string current_position;
    public string goal_position;





    public Text conditionText;
    public Text timeText;
    public GameObject rightTurn, leftTurn, bottomTurn;
    float Timer;
    public int turn_count = -1;
    int turn;
    private string whoIs = null;
    bool isSecondClick= false;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
      

    }

    public void printGameobject(Transform x)
    {

        /*myKing = new KingClass(goal_position, current_position);
        mySoldire = new SoldireClass(goal_position, current_position);
        myQueen = new QueenClass(goal_position, current_position);
        myCastle = new CastleClass(goal_position, current_position);
        myBishop = new BishopClass(goal_position, current_position);*/
        myKnight = new KnightClass();





        if (x.transform.childCount == 1)
        {
            whoIs = x.transform.GetChild(0).name;
            nowObject = x.transform.GetChild(0);
            pastX = x;
            string nameX = pastX.transform.name;
            s = nameX.Split('_');
            current_position = nameX;


            if (whoIs == DieClass.KNIGHT_NAME)
            {
                String[] a = myKnight.showKnightMovementSuggestion(current_position);
                foreach (string c in a)
                {
                    print(c);
                    // Color the Homes
                }
            }
        }

        else if ((x.transform.childCount == 0))
        {


            goal_position = x.transform.name;

            /**/



            if (isSecondClick == true)
            {
                print("isSecondClick");
                isSecondClick = false;
                
            }

            turn_count++;
            isSecondClick = true;


            if (whoIs == DieClass.SOLDIRE_NAME)
            {

                if (checkSoldireMove(goal_position, current_position,"tag"))
                {


                    conditionText.text = ("SOLDIRE MOVED").ToString();

                    doMove(x);

                    conditionText.text = ("SOLDIRE MOVED").ToString();
                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }

            }
            else if (whoIs == DieClass.CASTLE_NAME)
            {

                if (checkCastleMove2(x.transform.name,current_position))
                {
                    conditionText.text = ("CASTLE MOVED").ToString();

                    doMove(x);

                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
                }

            else if (whoIs == DieClass.KNIGHT_NAME) 
            {
                
                if (myKnight.checkKnightMovementValidity(goal_position,current_position))
                {
                    conditionText.text = ("KNIGHT MOVED").ToString();
                    if(doMove(x))
                    {
                        Board.condition_matrix[Int32.Parse(goal_position.Split('_')[0]), Int32.Parse(goal_position.Split('_')[1])] = DieClass.SET_DIE;
                        Board.condition_matrix[Int32.Parse(current_position.Split('_')[0]), Int32.Parse(current_position.Split('_')[1])] = DieClass.NO_DIE;

                    }

                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;

                }
            }

            else if (whoIs == DieClass.KING_NAME)
            {
                if (checkBishopMove2(goal_position, current_position))
                {


                    conditionText.text = ("King MOVED").ToString();
                    print(goal_position + ": updated");
                    print(current_position + ": updated");

                    doMove(x);

                    conditionText.text = ("SOLDIRE MOVED").ToString();
                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
              }
            else if (whoIs == DieClass.BISHOP_NAME)
            {
                if (checkBishopMove2(x.transform.name,current_position))
                {


                    conditionText.text = ("KNIGHT MOVED").ToString();
                    print(goal_position + ": updated");
                    print(current_position + ": updated");

                    doMove(x);

                    conditionText.text = ("BISHOP MOVED").ToString();
                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
              }

            else if (whoIs == DieClass.QUEEN_NAME)
            {
                if (checkBishopMove2(goal_position,current_position)
                    || checkCastleMove2(goal_position,current_position))
                {


                    conditionText.text = ("KNIGHT MOVED").ToString();
                    print(goal_position + ": updated");
                    print(current_position + ": updated");


                    doMove(x);
                    conditionText.text = ("QUEEN MOVED").ToString();
                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
            }

        }
        

        turn = turn_count % 3;
        switch (turn)
        {
            case 0:
                leftTurn.SetActive(true);
                rightTurn.SetActive(false);
                bottomTurn.SetActive(false);
                break;
            case 1:
                leftTurn.SetActive(false);
                rightTurn.SetActive(true);
                bottomTurn.SetActive(false);
                break;
            case 2:
                leftTurn.SetActive(false);
                rightTurn.SetActive(false);
                bottomTurn.SetActive(true);
                break;
        }
    }







    Boolean checkSoldireMove(string goal_position, string current, string tag)
    {
        print(tag);
        bool soldireReturnFlag = false;
        bool IamYellow = false, IamRed = false, IamGreen = false;
        int goalX = Int32.Parse(goal_position.Split('_')[0]);
        int goalY = Int32.Parse(goal_position.Split('_')[1]);
        int nowX = Int32.Parse(current.Split('_')[0]);
        int nowY = Int32.Parse(current.Split('_')[1]);
        print(current + " ---> " + goal_position);

        GameObject[] yellow_soldires = GameObject.FindGameObjectsWithTag("yellow_soldire");
        GameObject[] red_soldires = GameObject.FindGameObjectsWithTag("red_soldire");
        GameObject[] green_soldires = GameObject.FindGameObjectsWithTag("green_soldire");

        foreach(GameObject gobj in yellow_soldires)
        {

        }


        if (nowY == 2)
        {
            if(goalY == 4)
            {
                print("available: " + nowX + "_" + nowY + 1);
                print("available: " + nowX + "_" + goalY);
                soldireReturnFlag = true;
            }
            else if(goalY == 3 && nowX == goalX)
            {
                print("available: " + nowX + "_" + goalY);
                soldireReturnFlag = true;
            }
            else if (goalY == 3 && (24 % nowX + 1 == goalX) || (24 % nowX - 1 == goalX))//wrong
            {
                // حالت زدن مهره حریف
            }
            else
            {
                print("Wrong Soldire First Movement");
                return false;
            }
        }else if(nowY == 6 && goalY == 6)
        {
            if(nowX + 12 == goalX)
            {
                print("available: " + (nowX + 12) + "_" + goalY);
                soldireReturnFlag = true;
            }
            else if(nowX - 12 == goalX)
            {
                print("available: " + (nowX - 12) + "_" + goalY);
                soldireReturnFlag = true;
            }
            else if (nowX + 13 == goalX)
            {
                //مورب
            }
            else if (nowX + 11 == goalX)
            {
                // مورب
            }
            else if (nowX - 13 == goalX)
            {
                // مورب
            }
            else if (nowX - 11 == goalX)
            {
                // مورب
            }
            //x change
        }else if(nowX == goalX && Math.Abs(nowY - goalY) == 1)
        {
            print("available: " + nowX + "_" + goalY);
            soldireReturnFlag = true;
        }else
        {
            print("Wrong Soldire First Movement");
            return false;
        }
            



        return soldireReturnFlag;
    }





    Boolean checkCastleMove2(string goal_position, string current)
    {
        int x1 = Int32.Parse(goal_position.Split('_')[0]);
        int y1 = Int32.Parse(goal_position.Split('_')[1]);
        int x2 = Int32.Parse(current.Split('_')[0]);
        int y2 = Int32.Parse(current.Split('_')[1]);
        print(current + " ---> " + goal_position);

        /* 
         * first and second arguments are goal position (x1,y1) => (17_1)
         * second and third arguments are current position (x2,y2) => (17_4)
         * */


        bool isQotr = false, isMohit = false;
        if (y1 == y2) // یعنی اگر حرکت در محیط دایره باشد
        {
            isMohit = true;
        }
        if (Math.Abs(x1 - x2) % 12 == 0) // یعنی اگر حرکت در قطر دایره باشد
        {
            isQotr = true;
        }

        return CastleCheckHomesForDie(x2, y2, x1, y1, isQotr, isMohit);

    }




    Boolean CastleCheckHomesForDie(int now_x, int now_y, int goal_x, int goal_y,bool isQotr,bool isMohit)
    {
        bool returnCastleFlag = false;
        if(isQotr) // qotr
        {
            if (Math.Abs(goal_x - now_x) == 12)
            {
                int plus = 1;
                int i = now_x, j = now_y;

                bool flag6 = true;
                while (i != goal_x || j != goal_y)
                {
                    if(j == 6  && flag6)
                    {
                        flag6 = false;
                        plus = -1;

                        if(goal_x < now_x) 
                            i -= 12;
                        else
                            i += 12;
                        print("Available: " + i + "_" + j);
                        if (i == goal_x && j == goal_y)
                            break;
                    }
                    if (j >= 24 || j <= -1 || i >= 24 || i <= -1)
                    {
                        print("error in code");
                        return false;
                    }
                    j += plus;


                    print("Available: " + i + "_" + j);

                }
                print("Available: " + i + "_" + j);


                returnCastleFlag = true;
            }
           else if ((goal_x - now_x) == 0)
            {
                print("#2");
                int plus = 1;
                if ( goal_y > now_y)
                {
                    plus = 1;
                }
                else if (goal_y < now_y) { plus = -1; }
                else { if (now_x > goal_x) plus = -1; else plus = 1; }

                int i = now_x, j = now_y + plus;
                while (i != goal_x || j != goal_y)
                {
                    print("Available: " + i + "_" + j);

                    if (j >= 24 || j <= -1)
                    {
                        print("error in code");
                        return false;
                    }
                    j += plus;
                } 
                print("Available: " + i + "_" + j);

            }
            returnCastleFlag = true;

        }


        if (isMohit)
        {
            int i = now_x;

           
            while (i != goal_x)
            {

                if (i == 24)
                {
                    i = 1;
                    print("CLOCKWISE => Available: " + i + "_" + now_y);

                    if (i == goal_x)
                    {
                        returnCastleFlag = true; break;
                    }

                }
                else
                    i++;
                
                    print("CLOCKWISE => Available: " + i + "_" + now_y);

                if (i >= 25)
                {
                    print("error in code"); return false;
                }
            }

            i = now_x;
            while (i != goal_x ) 
            {

                if (i == 1)
                {
                    i = 24;
                    print("ANTI-CLOCKWISE => Available: " + i + "_" + now_y);
                    if (i == goal_x)
                    {
                        returnCastleFlag = true; break;
                    }

                }
                else
                    i--;
                   print("ANTI-CLOCKWISE => Available: " + i + "_" + now_y);
                if (i >= 25 || i < -1)
                {
                    print("error in code"); return false;
                }  
            } 

            returnCastleFlag = true;
        }


        return returnCastleFlag;
    }










    Boolean checkBishopMove2(string goal_position, string current_position)
    {

        int x1 = Int32.Parse(goal_position.Split('_')[0]);
        int y1 = Int32.Parse(goal_position.Split('_')[1]);
        int x2 = Int32.Parse(current_position.Split('_')[0]);
        int y2 = Int32.Parse(current_position.Split('_')[1]);
        print(current_position + "->" + goal_position);


        if((x1 + y1) %2 != (x2 + y2) % 2)
        {
            print("@3 => wrong");
            return false;
        }
        if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2) )
        {
            print("@1");
            return BishipCheckHomesForDieInNormalMove(x2, y2, x1, y1, false);
        }else if(Math.Abs(y1 - y2) == Math.Abs(24 % x1 - x2) )
        {
            print("@2");
            return BishipCheckHomesForDieInNormalMove(x2, y2, x1, y1, true);
        }
        else
        {


            bool chinaWallFlag = false,pos1Flag = false, pos2Flag = false;

            bool chinaWallFlagInFirst = false;
            bool chinaWallFlagInSecond = false;

            if (x2 >= 15 && x1 <= 5 || x2 <= 10 && x1 >= 20)
                chinaWallFlagInSecond = true;



            int diff = y2 - 1;
            int pos1 = x2 + diff; if (pos1 >= 25) { pos1 -= 24; chinaWallFlagInFirst = true; pos1Flag = true; }
            int pos2 = x2 - diff; if (pos2 <= 0) { pos2 += 24; chinaWallFlagInFirst = true; pos2Flag = true; }



            if (Math.Abs(x1 - pos1) == Math.Abs(y1 - 1))
            {
                print("pos1: " + pos1);
                if (pos1Flag)
                    return BishipCheckHomesForDieInNormalMove(x2, y2, pos1, 1, chinaWallFlagInFirst);
                else if (BishipCheckHomesForDieInNormalMove(x2, y2, pos1, 1, pos1Flag) && BishipCheckHomesForDieInNormalMove(pos1, 1, x1, y1, false))
                    return true;
                else
                {
                    print("way has a die");
                    return false;
                }
            }
            else if (Math.Abs(x1 - pos2) == Math.Abs(y1 - 1))
            {
                print("pos2: " + pos2);

                if (pos2Flag)
                    return BishipCheckHomesForDieInNormalMove(x2, y2, pos2, 1, chinaWallFlagInFirst);
                else if (BishipCheckHomesForDieInNormalMove(x2, y2, pos2, 1, chinaWallFlagInFirst) && BishipCheckHomesForDieInNormalMove(pos2, 1, x1, y1, false))
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {


                int temp1 = Math.Abs(pos1 - x1), temp2 = Math.Abs(pos2 - x1);
                if (temp2 >= 19) { chinaWallFlagInSecond = true; temp2 = 24 % temp2; }
                if (temp1 >= 19) { chinaWallFlagInSecond = true; temp1 = 24 % temp1; }

                if (temp2 != Math.Abs(1 - y1) || temp2 != Math.Abs(1 - y1))
                {
                    print("wrong");
                    return false;
                 }

                if (Math.Abs(pos1 - x2) == Math.Abs(y1 - 1) && Math.Abs(pos1 - x1)> Math.Abs(pos2 - x1))
                {
                    print("\n place A \n");
                    return (BishipCheckHomesForDieInNormalMove(x2, y2, pos1, 1, false) && BishipCheckHomesForDieInNormalMove(pos1, y2, x1, y1, true));
                }
                else if (Math.Abs(pos2 - x2) == Math.Abs(y1 - 1) && Math.Abs(pos1 - x1) < Math.Abs(pos2 - x1))
                {
                    print("\n place B \n");
                    return (BishipCheckHomesForDieInNormalMove(x2, y2, pos2, 1, false) && BishipCheckHomesForDieInNormalMove(pos2, y2, x1, y1, true));
                }else if(pos1 == x2 || pos2 == x2)
                {
                    print("place C");
                    return (BishipCheckHomesForDieInNormalMove(x2, y2, x1, y1, true)) ;
                }
                else
                {
                    print("place D");

                    return false;
                }
                    
            }
        }
    }

    Boolean BishipCheckHomesForDieInNormalMove(int now_x,int now_y,int goal_x,int goal_y,bool chinaWallFlag)
    {

        print("this is inside function");
        if (chinaWallFlag)
        {


            print("**0**");
            if (now_x < goal_x && now_y > goal_y)
            {


                print("**1**");
                if (now_x == 1) now_x = 25;
                for (int i = now_x - 1, j = now_y - 1; ;j--)
                {
                    condition_matrix[i, j] = "1"; // فعلا 1 میگذاریم
                    condition_matrix[i, j] = DieClass.NO_DIE;

                    print("available1 => " + i + "__" + j);
                    if (i == 1)
                    {
                        j--;
                        print("available1 => " + 24 + "__" + j);
                        i = 24;

                    }
                    if (j == goal_y) return true;
                    i--;

                }
                return true;
            }
            else if (now_x > goal_x && now_y < goal_y)
            {
                print("2");/** بررسی شد درست کار میکند**/
                if (now_x == 24) now_x = 0;
                for (int i = now_x + 1, j = now_y + 1; ; j++)
                {
                    
                    condition_matrix[i, j] = "1"; // فعلا 1 میگذاریم
                    condition_matrix[i, j] = DieClass.NO_DIE;
                    print("available2: " + i + "__" + j);/***/
                    if (i == 24)
                    {
                        j++;
                        print("available2: " + 1 + "__" + j);/***/
                        i = 1;
                    }
                    if (j == goal_y) return true;
                    i++;
                }
                return true;
            }
            else if (now_x < goal_x && now_y < goal_y)
            {
                print("9 "+ goal_y); /** بررسی شد درست کار میکند**/
                for (int i = now_x - 1, j = now_y + 1;; j++)
                {

                    condition_matrix[i, j] = "1"; // فعلا 1 میگذاریم
                    condition_matrix[i, j] = DieClass.NO_DIE;
                    print("available9: " + i + "__" + j);/***/
                    if (i == 1)
                    {
                        j++; 
                        print("available9: " + 24 + "__" + j);/***/
                        i = 24;
                    }
                    if (j == goal_y) return true;
                    i--;
                }
                return true;
                print("updating soon ...");
                return true;
            }else if (now_x > goal_x && now_y > goal_y)
            {

                print("8");
                if (now_x == 24) now_x = 0;
                for (int i = now_x + 1, j = now_y - 1; j != 0; j--)
                {

                    condition_matrix[i, j] = "1"; // فعلا 1 میگذاریم
                    condition_matrix[i, j] = DieClass.NO_DIE;
                    print("available8: " + i + "__" + j);/***/
                    if (i == 24)
                    {
                        j--;
                        print("available8: " + 1 + "__" + j);/***/
                        i = 1;
                    }
                    i++;
                }
                return true;


                print("updating soon ...");
            }
            else
                return false;
        }
        else
        {
            if (goal_x > now_x && goal_y > now_y)
            {
                //درست
                for (int i = now_x + 1, j = now_y + 1; i <= goal_x; j++, i++)
                {
                    condition_matrix[goal_x, goal_y] = "1"; // فعلا 1 میگذاریم
                    condition_matrix[now_x, now_y] = DieClass.NO_DIE;

                    print("available3: " + i + "__" + j);
                }
                return true;
            }
            else if (goal_x < now_x && goal_y < now_y)
            {
                    //درست
                    for (int i = now_x - 1, j = now_y - 1; i >= goal_x; j--, i--)
                    {
                        condition_matrix[goal_x, goal_y] = "1"; // فعلا 1 میگذاریم
                        condition_matrix[now_x, now_y] = DieClass.NO_DIE;

                        print("available3: " + i + "__" + j);
                    }
                    return true;
                
            }
            else if (goal_x < now_x && goal_y > now_y)
            {
                // درست
                for (int i = now_x - 1, j = now_y + 1; i >= goal_x; j++, i--)
                {
                    condition_matrix[goal_x, goal_y] = "1"; // فعلا 1 میگذاریم
                    condition_matrix[now_x, now_y] = DieClass.NO_DIE;

                    print("available4: " + i + "__" + j);
                }
                return true;
            }
            else if (goal_x > now_x && goal_y < now_y)
            {
                // درست
                for (int i = now_x + 1, j = now_y - 1; i <= goal_x; j--, i++)
                {
                    condition_matrix[goal_x, goal_y] = "1"; // فعلا 1 میگذاریم
                    condition_matrix[now_x, now_y] = DieClass.NO_DIE;

                    print("available5: " + i + "__" + j);
                }
                return true;
            }

            return false;
        }
    }

    Boolean BishopCheckHomesForDieInChinaWallMove(int now_x, int now_y, int goal_x, int goal_y)
    {
        return false;
    }


    Boolean doMove(Transform x)
    {

        try
        {

            conditionText.color = Color.white;


            pastX = x;
            string nameX = pastX.transform.name;
            s = nameX.Split('_');

            current_position = pastX.transform.name;

            nowObject.SetParent(x);
            nowObject.transform.localPosition = Vector3.zero;

            nowObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            nowObject.transform.Rotate(0f, 0f, -7f, Space.World);

            return true;
        }
        catch (Exception)
        {
            print("Trouble ...");
            return false;
        }
    }



}