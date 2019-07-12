﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// Hi Successfully , Im here :)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// Hi Successfully , Im here :)

public class butt : MonoBehaviour
{

    // we initialize this variables for checking a die move with no collision in its way
    public const string RED_DIE = "1";
    public const string GREEN_DIE = "1";
    public const string YELLOW_DIE = "1";
    public const string NO_DIE = "";



    string[,] condition_matrix = new string[25, 7] {
        {"","","","","","",""},//0

        {"",GREEN_DIE,GREEN_DIE,"","","",""},{"",GREEN_DIE,GREEN_DIE,"","","",""},//1,2
        {"",GREEN_DIE,GREEN_DIE,"","","","" },{"",GREEN_DIE,GREEN_DIE,"","","","" },//3
        {"",GREEN_DIE,GREEN_DIE,"","","","" },{"",GREEN_DIE,GREEN_DIE,"","","","" },//5
        {"",GREEN_DIE,GREEN_DIE,"","","","" },{"",GREEN_DIE,GREEN_DIE,"","","","" },//7

        {"",RED_DIE,RED_DIE,"","","","" },{"",RED_DIE,RED_DIE,"","","","" },//9
        {"",RED_DIE,RED_DIE,"","","","" },{"",RED_DIE,RED_DIE,"","","","" },//11
        {"",RED_DIE,RED_DIE,"","","","" },{"",RED_DIE,RED_DIE,"","","","" },//13
        {"",RED_DIE,RED_DIE,"","","","" },{"",RED_DIE,RED_DIE,"","","","" },//15

        {"",YELLOW_DIE,YELLOW_DIE,"","","","" },{"",YELLOW_DIE,YELLOW_DIE,"","","",""},//17
        {"",YELLOW_DIE,YELLOW_DIE,"","","",""},{"",YELLOW_DIE,YELLOW_DIE,"","","","" },//19
        {"",YELLOW_DIE,YELLOW_DIE,"","","","" },{"",YELLOW_DIE,YELLOW_DIE,"","","","" },//21
        {"",YELLOW_DIE,YELLOW_DIE,"","","","" },{"",YELLOW_DIE,YELLOW_DIE,"","","","" }//23
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
    public string[] s;
    public string current_position;



    //type of die
    public const string SOLDIRE_NAME = "soldire";
    public const string CASTLE_NAME = "castle";
    public const string KING_NAME = "king";
    public const string QUEEN_NAME = "queen";
    public const string BISHOP_NAME = "bishop";
    public const string KNIGHT_NAME = "knight";

    public Text conditionText;
    public Text timeText;
    public GameObject rightTurn, leftTurn, bottomTurn;
    float Timer;
    public int turn_count = -1;
    int turn;
    private string whoIs = null;
    bool isSecondClick = false;

    // Use this for initialization
    void Start()
    {
        print(
            "21_3" + condition_matrix[21, 3]);
    }
    // Update is called once per frame
    void Update()
    {


    }

    public void printGameobject(Transform x)
    {

        /** we have two position (1_2) : first position => 1 , second position => 2 **/
        /** for pawn **/

        if ((x.transform.childCount == 0))
        {

            if (isSecondClick == true)
            {
                print("isSecondClick");
                isSecondClick = false;
                //print(x.transform.name.ToString());


            }

            turn_count++;
            isSecondClick = true;


            string goal_position = x.transform.name;
            int x1 = Int32.Parse(goal_position.Split('_')[0]);
            int y1 = Int32.Parse(goal_position.Split('_')[1]);
            int x2 = Int32.Parse(current_position.Split('_')[0]);
            int y2 = Int32.Parse(current_position.Split('_')[1]);


            if (whoIs == SOLDIRE_NAME)
            {



                if (((x1 - x2) == 0 || (x1 - x2) == 12))
                    switch (y1 - y2)/** parent first position - child **/
                    {

                        case (1):
                            conditionText.text = ("PAWN MOVED").ToString();

                            condition_matrix[x1, y1] = "1";
                            print(goal_position + ": updated"); print(condition_matrix[x1, y1]);
                            condition_matrix[x2, y2] = NO_DIE;
                            print(current_position + ": updated"); print(condition_matrix[x2, y2]);
                            doMove(x);

                            break;
                        case (2):
                            /**if second position be 2, its ok otherwise its wrong movement.... Lets implement this**/
                            if (Int32.Parse(s[1]) == 2)
                            {
                                conditionText.text = ("PAWN MOVED").ToString();
                                if (condition_matrix[x2, y2 + 1] == "")
                                {
                                    condition_matrix[x1, y1] = "1";
                                    print(goal_position + ": updated");
                                    condition_matrix[x2, y2] = NO_DIE;
                                    print(current_position + ": updated");
                                    doMove(x);
                                }

                                else
                                    print("You cant move");// حرکت اول اگر جلوی سرباز مهره خودی یا غیر خودی باشد نمیتواند جلو برود

                            }
                            else
                            {
                                conditionText.text = ("check if first move").ToString();
                                conditionText.color = Color.red;
                            }

                            break;
                        case (0):
                            conditionText.text = ("PAWN MOVED").ToString();
                            condition_matrix[x1, y1] = "1";
                            print(goal_position + ": updated");
                            condition_matrix[x2, y2] = NO_DIE;
                            print(current_position + ": updated");
                            doMove(x);
                            break;
                        case (-1):
                            conditionText.text = ("WRONG").ToString();
                            // print("-1");
                            conditionText.color = Color.red;
                            break;
                        default:
                            conditionText.text = ("WRONG").ToString();
                            conditionText.color = Color.red;


                            break;

                    }
            }
            else if (whoIs == CASTLE_NAME)
            {

                //اینجوری تغییر داده شده، اگر دیدی پاک کن =>Int32.Parse(x.transform.name.Split('_')[0]), Int32.Parse(x.transform.name.Split('_')[1]), Int32.Parse(s[0]), Int32.Parse(s[1]))
                if (checkCastleMove2(x.transform.name, current_position))
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

            else if (whoIs == KNIGHT_NAME)
            {
                if (checkKnightMove(Int32.Parse(x.transform.name.Split('_')[0]), Int32.Parse(x.transform.name.Split('_')[1]), Int32.Parse(s[0]), Int32.Parse(s[1])))
                {
                    conditionText.text = ("KNIGHT MOVED").ToString();
                    condition_matrix[x1, y1] = "1";
                    print(goal_position + ": updated");
                    condition_matrix[x2, y2] = NO_DIE;
                    print(current_position + ": updated");
                    doMove(x);

                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;

                }
            }

            else if (whoIs == KING_NAME)
            {
                if (Math.Abs(Int32.Parse(x.transform.name.Split('_')[0]) - Int32.Parse(s[0])) % 23 <= 1 && Math.Abs(Int32.Parse(x.transform.name.Split('_')[1]) - Int32.Parse(s[1])) % 23 <= 1)
                {
                    conditionText.text = ("KING MOVED").ToString();

                    doMove(x);

                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
            }
            else if (whoIs == BISHOP_NAME)
            {
                if (checkBishopMove2(x.transform.name, current_position))
                {


                    conditionText.text = ("KNIGHT MOVED").ToString();
                    condition_matrix[x1, y1] = "1";
                    print(goal_position + ": updated");
                    condition_matrix[x2, y2] = NO_DIE;
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

            else if (whoIs == QUEEN_NAME)
            {
                if (checkBishopMove(Int32.Parse(x.transform.name.Split('_')[0]), Int32.Parse(x.transform.name.Split('_')[1]), Int32.Parse(s[0]), Int32.Parse(s[1]))
                    || checkCastleMove(Int32.Parse(x.transform.name.Split('_')[0]), Int32.Parse(x.transform.name.Split('_')[1]), Int32.Parse(s[0]), Int32.Parse(s[1])))
                {


                    conditionText.text = ("KNIGHT MOVED").ToString();
                    condition_matrix[x1, y1] = "1";
                    print(goal_position + ": updated");
                    condition_matrix[x2, y2] = NO_DIE;
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
        else if (x.transform.childCount == 1)
        {
            whoIs = x.transform.GetChild(0).name;
            nowObject = x.transform.GetChild(0);
            pastX = x;
            string nameX = pastX.transform.name;
            s = nameX.Split('_');
            current_position = nameX;
            //print(s.ToString());
            print("firstClick");
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











    Boolean checkCastleMove2(string goal_position, string current)
    {
        int x1 = Int32.Parse(goal_position.Split('_')[0]);
        int y1 = Int32.Parse(goal_position.Split('_')[1]);
        int x2 = Int32.Parse(current.Split('_')[0]);
        int y2 = Int32.Parse(current.Split('_')[1]);
        print(current + "->" + goal_position);

        /* 
         * first and second arguments are goal position (x1,y1) => (17_1)
         * second and third arguments are current position (x2,y2) => (17_4)
         * */



        print("17_1:" + condition_matrix[17, 1]);
        print("17_2:" + condition_matrix[17, 2]);
        print("17_3:" + condition_matrix[17, 3]);




        if (y1 == y2) // یعنی اگر حرکت در محیط دایره باشد
        {
            print("mohit");
            return true;
        }
        else if (Math.Abs(x1 - x2) % 12 == 0) // یعنی اگر حرکت در قطر دایره باشد
        {
            print("qotr");
            if (y1 < y2)
            {
                print(y1);
                for (int i = y1 + 1; i < y2; i++)
                {
                    if (condition_matrix[x1, i] == NO_DIE)
                    {
                        condition_matrix[x1, y1] = "1";
                        condition_matrix[x2, y2] = NO_DIE;
                        return true;
                    }


                    else
                        return false;
                }
                return false;

            }
            else if (y2 < y1)
            {
                print("y2: " + y2);



                for (int i = y2 + 1; i < y1; i++)
                {
                    if (condition_matrix[x1, i] == NO_DIE)
                    {
                        condition_matrix[x1, y1] = "1"; // فعلا 1 میگذاریم
                        condition_matrix[x2, y2] = NO_DIE;
                        return true;
                    }

                    else
                        return false;
                }
                return false;

            }
            else
            {
                // چک شود اگر خودی است مهره را بزن در غیر اینصورت حرکت باطل است
                // در مراحل بعدی تکمیل می شود ...
                return false;
            }

        }
        else
            return false;
    }



    Boolean checkBishopMove2(string goal_position, string current_position)
    {

        int x1 = Int32.Parse(goal_position.Split('_')[0]);
        int y1 = Int32.Parse(goal_position.Split('_')[1]);
        int x2 = Int32.Parse(current_position.Split('_')[0]);
        int y2 = Int32.Parse(current_position.Split('_')[1]);
        print(current_position + "->" + goal_position);

        /* 
         * first and second arguments are goal position (x1,y1) => (17_1)
         * second and third arguments are current position (x2,y2) => (17_4)
         * */



        int pos1, pos2, def;
        if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
        {
            condition_matrix[x1, y1] = "1"; // فعلا 1 میگذاریم
            condition_matrix[x2, y2] = NO_DIE;


            print("bishop :: " + current_position + "->" + goal_position);

            int xLow, xHigh, yLow, yHigh;
            // می خواهیم ضربدری مسیر را چک کنیم
            if (x1 > x2) { xLow = x2; xHigh = x1; } else { xLow = x1; xHigh = x2; }
            if (y1 > y2) { yLow = y2; yHigh = y1; } else { yLow = y1; yHigh = y2; }

            // print("x low -> x high: "+xLow + "->" + xHigh);
            //print(yLow + "_" + yHigh);

            for (int i = xLow + 1, j = yLow + 1; i < xHigh; i++, j++)
            {
                if (condition_matrix[i, j] == NO_DIE)
                {
                    print("no die in => " + i + "_" + j);
                }

                else
                {
                    print("founded a die in => " + i + "_" + j);
                    return false;
                }

            }
            print("here");
            return true;
        }
        else
        {

            // go to first layer and check
            //راه حل دیوار چین
            def = y2 - 1;

            pos1 = x2 + def; if (pos1 > 25) pos1 -= 24;
            pos2 = x2 - def; if (pos2 <= 0) pos2 += 24;

            int temp1 = temp1 = Math.Abs(pos1 - x1), temp2 = Math.Abs(pos2 - x1);
            if (temp2 >= 20) temp2 = 24 % temp2;
            if (temp1 >= 20) temp1 = 24 % temp1;


            int xLow, xHigh, yLow, yHigh;
            // می خواهیم ضربدری مسیر را چک کنیم
            if (pos2 > x1) { yLow = y2; yHigh = y1; } else { yLow = y1; yHigh = y2; }

            //pos1_1 //pos2_1
            if (temp1 == Math.Abs(1 - y1))
            {

                if (pos1 > x1) { xLow = x1; xHigh = pos1; } else { xLow = pos1; xHigh = x1; }


                int i = xLow;
                for (int j = 1; i < xHigh; j++, i++)
                {
                    if (condition_matrix[i, j] == NO_DIE)
                    {
                        print("bis :: die not in: " + i + "_" + j);
                        return true;
                    }
                    else
                    {
                        print("bis :: die found in: " + i + "_" + j);
                    }

                }
                return true;
            }
            else if (temp2 == Math.Abs(1 - y1))
            {
                condition_matrix[x1, y1] = "1"; // فعلا 1 میگذاریم
                condition_matrix[x2, y2] = NO_DIE;

                return true;
            }
            else
            {
                print("false");
                return false;
            }


        }
    }















    Boolean checkBishopMove(Int32 x1, Int32 y1, Int32 x2, Int32 y2)
    {
        int pos1, pos2, def;
        if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
            return true;
        else
        {


            // go to first layer and check
            def = y1 - 1;

            // در لایه اخر دو جایی که میخوره به دیوار رو پیدا میکنیم سپس ازونجا چک میکنیم
            pos1 = x1 + def;
            pos2 = x1 - def;

            if (pos2 <= 0) pos2 = 24 - pos2;

            if (Math.Abs(pos1 - x2) == Math.Abs(1 - y2) || Math.Abs(pos2 - x2) == Math.Abs(1 - y2))
                return true;

        }


        return false;
    }
    Boolean checkQueenMove(Int32 x1, Int32 y1, Int32 x2, Int32 y2)
    {
        if (checkBishopMove(x1, y1, x2, y2))
            return true;
        else if (checkCastleMove(x1, y1, x2, y2))
            return true;


        return false;
    }

    Boolean checkCastleMove(Int32 x1, Int32 y1, Int32 x2, Int32 y2)
    {
        /* 
         * first and second arguments are goal position (x1,y1) => (17_1)
         * second and third arguments are current position (x2,y2) => (17_4)
         * */

        if (Math.Abs(x1 - x2) % 12 == 0 || (y1 == y2))
        {
            return true;
        }
        else
            return false;

    }



    Boolean checkKnightMove(Int32 x1, Int32 y1, Int32 x2, Int32 y2)
    {

        if ((x1 + 2 == x2) && (y1 + 1 == y2) ||
           (y1 + 2 == y2) && (x1 + 1 == x2) ||
           (x1 + 2 == x2) && (y1 - 1 == y2) ||
           (y1 + 2 == y2) && (Math.Abs(x1 - 1) == x2) ||

           (Math.Abs(x1 - 2) == x2) && (y1 - 1 == y2) ||
           (y1 - 2 == y2) && (Math.Abs(x1 - 1) == x2) ||
           (Math.Abs(x1 - 2) == x2) && (y1 + 1 == y2) ||
           (y1 - 2 == y2) && (x1 + 1 == x2)

           )
        {
            condition_matrix[x1, y1] = "1"; // فعلا 1 می گذاریم
            condition_matrix[x2, y2] = NO_DIE;
            return true;
        }

        return false;
    }


    void doMove(Transform x)
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
    }



}
