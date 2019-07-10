using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// Hi Successfully , Im here :)

public class butt : MonoBehaviour
{

    public Transform nowObject;
    public Transform pastX;
    public string[] s;
    public const string SOLDIRE_NAME = "soldire";
    public const string CASTLE_NAME = "castle";
    public const string KING_NAME = "king";
    public const string QUEEN_NAME = "queen";
    public const string BISHOP_NAME = "bishop";
    public const string KNIGHT_NAME = "knight";
    public Text conditionText;
    public Text timeText;
    float Timer;

    private string whoIs = null;
    bool isSecondClick= false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if(nowObject!=null){
			print(nowObject);
		}*/

      //  Timer += Time.deltaTime;
       // timeText.text = Timer.ToString();

    }

    public void printGameobject(Transform x)
    {
        // nowObject = x.GetChild(0);
        //print(Int32.Parse(x.transform.name.Split('_')[1]) - Int32.Parse(s[1]));


        /** we have two position (1_2) : first position => 1 , second position => 2 **/
        /** for pawn **/
       
        if ((x.transform.childCount == 0))
        {

            if (isSecondClick == true)
            {
                print("isSecondClick");
                isSecondClick = false;
                print(x.transform.name.ToString());
            }


            isSecondClick = true;

            if (whoIs == SOLDIRE_NAME)
            {
                if (((Int32.Parse(x.transform.name.Split('_')[0]) - Int32.Parse(s[0])) == 0 || (Int32.Parse(x.transform.name.Split('_')[0]) - Int32.Parse(s[0])) == 12))
                    switch ((Int32.Parse(x.transform.name.Split('_')[1]) - Int32.Parse(s[1])))/** parent first position - child **/
                    {
                        case (1):
                            conditionText.text = ("PAWN MOVED").ToString();
                            doMove(x);
                            break;
                        case (2):
                            /**if second position be 2, its ok otherwise its wrong movement.... Lets implement this**/
                            if (Int32.Parse(s[1]) == 2)
                            {
                                conditionText.text = ("PAWN MOVED").ToString();
                                doMove(x);

                            }
                            else
                            {
                                conditionText.text = ("check if first move").ToString();
                                conditionText.color = Color.red;
                            }

                            break;
                        case (0):
                            conditionText.text = ("PAWN MOVED").ToString();
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
                if (checkCastleMove(Int32.Parse(x.transform.name.Split('_')[0]), Int32.Parse(x.transform.name.Split('_')[1]), Int32.Parse(s[0]), Int32.Parse(s[1])))
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
                if (checkBishopMove(Int32.Parse(x.transform.name.Split('_')[0]), Int32.Parse(x.transform.name.Split('_')[1]), Int32.Parse(s[0]), Int32.Parse(s[1])))
                {
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
            //print(s.ToString());
            print("firstClick");
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
        if (Math.Abs(x1 - x2) % 12 == 0 || (y1 == y2))
            return true;
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
            return true;
        return false;
    }


    void doMove(Transform x)
    {
        conditionText.color = Color.white;


        pastX = x;
        string nameX = pastX.transform.name;
        s = nameX.Split('_');

        nowObject.SetParent(x);
        nowObject.transform.localPosition = Vector3.zero;

        nowObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        nowObject.transform.Rotate(0f, 0f, -7f, Space.World);
    }
    
		

}
