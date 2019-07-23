using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMove : MonoBehaviour {
    string[,] condition_matrix;

    string randomValueGenereated;
    // Use this for initialization
    void Start () {



        //this.GetComponent<butt>().printGameobject(x);
       


    }

    // Update is called once per frame
    void Update () {
      /*  if (Input.GetKey(KeyCode.A))
        {
            printCondtionMatrix2();
        }*/
	}

   /* public void printCondtionMatrix2()
    {


        for (int i = 0; i <= 24; i++)
            print("" +
                 condition_matrix[i, 0] + " |" +
                 condition_matrix[i, 1] + " |" +
                 condition_matrix[i, 2] + " |" +
                 condition_matrix[i, 3] + " |" +
                 condition_matrix[i, 4] + " |" +
                 condition_matrix[i, 5] + " |" +
                 condition_matrix[i, 6]
                );

    }
    public void printCondtionMatrix()
    {
        condition_matrix = this.GetComponent<butt>().condition_matrix;

        //condition_matrix = Board.condition_matrix;
        for (int i = 0; i <= 24; i++)
            print("" +
                 condition_matrix[i, 0] + " |" +
                 condition_matrix[i, 1] + " |" +
                 condition_matrix[i, 2] + " |" +
                 condition_matrix[i, 3] + " |" +
                 condition_matrix[i, 4] + " |" +
                 condition_matrix[i, 5] + " |" +
                 condition_matrix[i, 6]
                );

    }*/

    public void randomMoveGeneration(string[,] matrix)
    {
     
        int a = Random.Range(0, matrix.GetLength(0));
        int b = Random.Range(0, matrix.GetLength(1));

        if (/*اگر در آن خانه مهره بود*/matrix[a, b] == "1"  &&
            /*اگر در خانه بعدی مهره نبود*/ matrix[a, b+1]=="")
            randomValueGenereated = (a + "_" + b);
        else
            randomMoveGeneration(matrix);


       
    }
    public void domMove(string randomObjName)
    {
        
        /*
        GameObject randomObj = GameObject.Find(randomObjName);
        string[] s = randomObjName.Split('_');
        int x = System.Int32.Parse(s[1]);
        x++;

        condition_matrix[System.Int32.Parse(s[0]), x - 1] = "";
        condition_matrix[System.Int32.Parse(s[0]), x] = "1";

        Transform nextObj = GameObject.Find((s[0]+"_"+x).ToString()).transform;
        print(":" + randomObj.name);
        Transform innerObj = randomObj.transform.GetChild(0);
        innerObj.SetParent(nextObj);
        innerObj.transform.localPosition = Vector3.zero;

        innerObj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        innerObj.transform.Rotate(0f, 0f, -7f, Space.World);*/
    }

  /*
    public void randomeMove()
    {
        condition_matrix = this.GetComponent<butt>().condition_matrix;
        //condition_matrix = Board.condition_matrix;
        randomMoveGeneration(condition_matrix);
        domMove(randomValueGenereated);
    }*/

}
