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
    string dieColor;
    public Transform nowObject;
    public Transform pastX;
    public String[] s;
    public string current_position;
    public string goal_position;
    public string current_die_color_id;
    public string goal_die_color_id;
    public string current_die_color;
    public string goal_die_color;
    public Text conditionText;
    public Text timeText;
    public GameObject rightTurn, leftTurn, bottomTurn;
    float Timer;
    public int turn_count = -1;
    int turn = 0;
    private string whoIs = null;
    bool isSecondClick = false;
    string[] nowplaces = new string [100];
    Color32[] previous_places_color = new Color32[100];

    Color32 selectedColor = new Color32(69, 178, 13, 255);
    Image previous_obj;
    Color32 previous_color; // dont initialize

    public string[,] condition_matrix = new string[25, 7] {
        {"","","","","","",""},//0

        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2

        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2

        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
        {"","1","1","","","",""},{"","1","1","","","",""},//1,2
    };



    public AudioSource audioData;

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

        turn %= 3;
        checkTurn();

        if (x.transform.childCount == 1)
        {
            if (previous_obj)
            {
                previous_obj.color = previous_color;
            }
            Image im = x.gameObject.GetComponent<Image>();
            previous_color = im.GetComponent<Image>().color;
            print(previous_color);
            previous_obj = im;
            im.color = selectedColor;


            whoIs = x.transform.GetChild(0).name;
            nowObject = x.transform.GetChild(0);
            pastX = x;
            string nameX = pastX.transform.name;
            s = nameX.Split('_');
            current_position = nameX;



            int cx = Int32.Parse(current_position.Split('_')[0]);
            int cy = Int32.Parse(current_position.Split('_')[1]);

            current_die_color_id = Board.condition_matrix[cx, cy];
            int clr = Int32.Parse(current_die_color_id.Split('_')[0]);

            current_die_color = DieClass.declareDieColor(clr);

            myKnight = new KnightClass(current_die_color);
            myCastle = new CastleClass(current_die_color);
            mySoldire = new SoldireClass(current_die_color);
            myBishop = new BishopClass(current_die_color);
            myQueen = new QueenClass(current_die_color);
            myKing = new KingClass(current_die_color);

            if (turn == 0 && current_die_color == DieClass.YELLOW_DIE ||
                turn == 1 && current_die_color == DieClass.GREEN_DIE ||
                turn == 2 && current_die_color == DieClass.RED_DIE )
            {
                if (whoIs == DieClass.KNIGHT_NAME)
                {
                    String[] a = myKnight.showKnightMovementSuggestion(current_position);
                    doColorHomes(a);
                    int i = 0;

                    foreach (string c in a)
                    {
                        print(i + ": " + c);
                        i++;

                        // Color the Homes for knight
                    }
                }
                else if (whoIs == DieClass.CASTLE_NAME)
                {
                    String[] arr = myCastle.showCastleMovementSuggestion(current_position);
                    doColorHomes(arr);

                    foreach (string c in arr)
                    {
                        print(c);
                        // Color the Homes for castle
                    }
                }
                else if (whoIs == DieClass.SOLDIRE_NAME)
                {
                    String[] a = mySoldire.showSoldireMovementSuggestion(current_position);
                    doColorHomes(a);
                    int i = 0;

                    foreach (string c in a)
                    {
                        print(i + ": " + c);
                        i++;

                        // Color the Homes for knight
                    }

                }
                else if (whoIs == DieClass.BISHOP_NAME)
                {
                    String[] arr = myBishop.showBishopMovementSuggestion(current_position);
                    int i = 0;
                    doColorHomes(arr);
                    foreach (string c in arr)
                    {

                        print(i + ": " + c);
                        i++;
                        // Color the Homes for bishop
                    }
                }
                else if (whoIs == DieClass.QUEEN_NAME)
                {
                    String[] arr = myQueen.showQueenMovementSuggestion(current_position);
                    int i = 0;
                    doColorHomes(arr);
                    foreach (string c in arr)
                    {

                        print(i + ": " + c);
                        i++;
                        // Color the Homes for queen
                    }
                }
            }
        }

        else if ((x.transform.childCount == 0) && (turn == 0 && current_die_color == DieClass.YELLOW_DIE ||
                turn == 1 && current_die_color == DieClass.GREEN_DIE ||
                turn == 2 && current_die_color == DieClass.RED_DIE))
        {

            audioData = GetComponent<AudioSource>();

            goal_position = x.transform.name;


            int gx = Int32.Parse(goal_position.Split('_')[0]);
            int gy = Int32.Parse(goal_position.Split('_')[1]);

            goal_die_color_id = Board.condition_matrix[gx, gy];
            int clr = Int32.Parse(goal_die_color_id.Split('_')[0]);

            if (clr >= 1 && clr <= 8)
                goal_die_color = DieClass.GREEN_DIE;
            else if (clr >= 9 && clr <= 16)
                goal_die_color = DieClass.RED_DIE;
            else
                goal_die_color = DieClass.YELLOW_DIE;


            /**/


            isSecondClick = true;

            if (isSecondClick == true)
            {
                for (int i = 0; i < nowplaces.Length; i++)
                {
                    if (nowplaces[i] != null && nowplaces[i] != "")
                    {    
                        Image im = GameObject.Find(nowplaces[i]).gameObject.GetComponent<Image>();
                        im.color = previous_places_color[i];
                    }
                  


                }

                print("isSecondClick");

                isSecondClick = false;

            }

            turn_count++;


            if (whoIs == DieClass.SOLDIRE_NAME)
            {

                if (mySoldire.checkSoldiertMovementValidity(goal_position, current_position, current_die_color))
                {


                    conditionText.text = ("SOLDIRE MOVED").ToString();
                    string temp_current_position = current_position;
                    try
                    {
                        if (doMove(x))
                        {
                            Board.condition_matrix[Int32.Parse(goal_position.Split('_')[0]), Int32.Parse(goal_position.Split('_')[1])] = current_die_color_id;
                            print(goal_position.Split('_')[0] + "_" + goal_position.Split('_')[1] + " Set Die");
                            Board.condition_matrix[Int32.Parse(temp_current_position.Split('_')[0]), Int32.Parse(temp_current_position.Split('_')[1])] = DieClass.NO_DIE;
                            print(temp_current_position.Split('_')[0] + "_" + temp_current_position.Split('_')[1] + " Reset Die");
                            turn++;
                            checkTurn();
                        }
                        else
                        {
                            print("(200) Trouble ...");
                        }
                    }
                    catch (Exception)
                    {
                        print("(201) Trouble ...");

                    }
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

                if (myCastle.checkCastleMovementValidity(goal_position, current_position))
                {
                    string temp_current_position = current_position;
                    conditionText.text = ("CASTLE MOVED").ToString();
                    try
                    {
                        if (doMove(x))
                        {
                            Board.condition_matrix[Int32.Parse(goal_position.Split('_')[0]), Int32.Parse(goal_position.Split('_')[1])] = current_die_color_id;
                            print(goal_position.Split('_')[0] + "_" + goal_position.Split('_')[1] + "Set Die");
                            Board.condition_matrix[Int32.Parse(temp_current_position.Split('_')[0]), Int32.Parse(temp_current_position.Split('_')[1])] = DieClass.NO_DIE;
                            print(temp_current_position.Split('_')[0] + "_" + temp_current_position.Split('_')[1] + "No Die");
                            turn++;
                            checkTurn();

                        }
                        else
                        {
                            print("(100) Trouble ...");
                        }
                    }
                    catch (Exception)
                    {
                        print("(101) Trouble ...");

                    }

                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
            }

            else if (whoIs == DieClass.KNIGHT_NAME)
            {

                if (myKnight.checkKnightMovementValidity(goal_position, current_position))
                {

                    string temp_current_position;
                    temp_current_position = current_position;

                    conditionText.text = ("KNIGHT MOVED").ToString();
                    if (doMove(x))
                    {
                        Board.condition_matrix[Int32.Parse(goal_position.Split('_')[0]), Int32.Parse(goal_position.Split('_')[1])] = current_die_color_id;
                        print(goal_position.Split('_')[0] + "_" + goal_position.Split('_')[1] + "Set Die");
                        Board.condition_matrix[Int32.Parse(temp_current_position.Split('_')[0]), Int32.Parse(temp_current_position.Split('_')[1])] = DieClass.NO_DIE;
                        print(temp_current_position.Split('_')[0] + "_" + temp_current_position.Split('_')[1] + "No Die");
                        turn++;
                        checkTurn();

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

            }
            else if (whoIs == DieClass.BISHOP_NAME)
            {
                if (myBishop.checkBishopMovementValidity(goal_position, current_position))
                {
                    string temp_current_position = current_position;
                    conditionText.text = ("BISHOP MOVED").ToString();
                    try
                    {
                        if (doMove(x))
                        {
                            Board.condition_matrix[Int32.Parse(goal_position.Split('_')[0]), Int32.Parse(goal_position.Split('_')[1])] = current_die_color_id;
                            print(goal_position.Split('_')[0] + "_" + goal_position.Split('_')[1] + " Set Die");
                            Board.condition_matrix[Int32.Parse(temp_current_position.Split('_')[0]), Int32.Parse(temp_current_position.Split('_')[1])] = DieClass.NO_DIE;
                            print(temp_current_position.Split('_')[0] + "_" + temp_current_position.Split('_')[1] + " No Die");
                            turn++;
                            checkTurn();

                        }
                        else
                        {
                            print("(300) Trouble ...");
                        }
                    }
                    catch (Exception)
                    {
                        print("(301) Trouble ...");

                    }

                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
            }

            else if (whoIs == DieClass.QUEEN_NAME)
            {
                if (myQueen.checkQueenMovementValidity(goal_position, current_position))
                {
                    string temp_current_position = current_position;
                    conditionText.text = ("QUEEN MOVED").ToString();
                    try
                    {
                        if (doMove(x))
                        {
                            Board.condition_matrix[Int32.Parse(goal_position.Split('_')[0]), Int32.Parse(goal_position.Split('_')[1])] = current_die_color_id;
                            print(goal_position.Split('_')[0] + "_" + goal_position.Split('_')[1] + " Set Die");
                            Board.condition_matrix[Int32.Parse(temp_current_position.Split('_')[0]), Int32.Parse(temp_current_position.Split('_')[1])] = DieClass.NO_DIE;
                            print(temp_current_position.Split('_')[0] + "_" + temp_current_position.Split('_')[1] + " No Die");
                            checkTurn();

                        }
                        else
                        {
                            print("(400) Trouble ...");
                        }
                    }
                    catch (Exception)
                    {
                        print("(401) Trouble ...");

                    }

                }
                else
                {
                    conditionText.text = ("WRONG").ToString();
                    conditionText.color = Color.red;
                }
            }

        }



    }

    private void checkTurn()
    {
        switch (turn % 3)
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

    public void doColorHomes(string[] arr)
    {
        for (int i = 0; i < nowplaces.Length; i++)
        {
            if (nowplaces[i] != null && nowplaces[i] != "")
            {
               // print("for yellow color :" + nowplaces[i]);

                nowplaces[i] = null;
               
            }
        }


        int counter = -1;
        /********* normalize to optimal array ******//////
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                counter++;
               // print("in arr :" + arr[i]);
                nowplaces[counter] = arr[i];

            }
        }
        //print("Length :" + nowplaces.Length.ToString());

        /********* get colors like a array ******//////

        int counter1 = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                counter1++;
                previous_places_color[counter1] = GameObject.Find(arr[i]).gameObject.GetComponent<Image>().color;
            }
        }
        /********* set color to suggestion homes ******//////

        for (int i = 0; i < nowplaces.Length; i++)
        {
            if (nowplaces[i] != null && nowplaces[i] != "")
            {
              //  print("for yellow color :" + nowplaces[i]);

                Image im = GameObject.Find(nowplaces[i]).gameObject.GetComponent<Image>();
                im.color = new Color32(255, 170, 7, 255);
            }
        }
    }

    public void setColor1()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("darkIndex");
        foreach (GameObject obst in obstacles)
        {
            Image im = obst.gameObject.GetComponent<Image>();
            im.color = new Color32(5, 108, 111, 255);

        }
    }

    public void setColor2()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("darkIndex");
        foreach (GameObject obst in obstacles)
        {
            Image im = obst.gameObject.GetComponent<Image>();
            im.color = new Color32(51, 51, 51, 255);

        }
    }

    public void setColor3()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("darkIndex");
        foreach (GameObject obst in obstacles)
        {
            Image im = obst.gameObject.GetComponent<Image>();
            im.color = new Color32(127, 130, 47, 255);

        }
    }





}