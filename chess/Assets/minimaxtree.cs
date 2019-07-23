using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class minimaxtree : MonoBehaviour {
    public const string RED_DIE = "1";
    public const string GREEN_DIE = "1";
    public const string YELLOW_DIE = "1";
    public const string NO_DIE = "";
    // Use this for initialization
    void Start () {
     



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


    string[,] condition_matrix1 = new string[2, 2] { 
            { "1","a" }, { "1" ,"a"}
        };
        string[,] condition_matrix2 = new string[2, 2] {
            { "2","b" }, { "2" ,"b"}
        };
        string[,] condition_matrix3 = new string[2, 2] {
            { "3","c" }, { "3" ,"c"}
        };

        string[,] condition_matrix4 = new string[2, 2] {
            { "3","c" }, { "3" ,"c"}
        };
        string[,] condition_matrix5 = new string[2, 2] {
            { "3","c" }, { "3" ,"c"}
        };
        string[,] condition_matrix6 = new string[2, 2] {
            { "3","c" }, { "3" ,"c"}
        };

        string[,] condition_matrix7 = new string[2, 2] {
            { "3","c" }, { "3" ,"c"}
        };
        

    TreeNode<Condition> rootNode = new TreeNode<Condition>(new Condition(111, "animals","level0", condition_matrix));
        
        TreeNode<Condition> birds = rootNode.AddChild(new Condition(222, "birds", "level1", condition_matrix));
        TreeNode<Condition> mamels = rootNode.AddChild(new Condition(222, "mamels", "level1", condition_matrix));
        TreeNode<Condition> crawler = rootNode.AddChild(new Condition(222, "crawlers", "level1", condition_matrix));

          TreeNode<Condition> cat = mamels.AddChild(new Condition(222, "cat", "level2", condition_matrix));
          cat.AddChild(new Condition(333, "asia", "level3", condition_matrix));
          cat.AddChild(new Condition(333, "persian", "level3", condition_matrix));
        /*
          mamels.AddChild(new Condition(333, "dog"));

          birds.AddChild(new Condition(444, "chicken 1"));
          birds.AddChild(new Condition(555, "chicken 2"));
          birds.AddChild(new Condition(555, "chicken 3"));

          crawler.AddChild(new Condition(333, "snake"));
          crawler.AddChild(new Condition(333, "fog"));*/

       
      /* foreach (var item in rootNode.Children)
        {
            for (int i=0; i<=24; i++ )
                     print("" + 
                          item.Data.Matrix[i, 0] + " |" +
                          item.Data.Matrix[i, 1] + " |" +
                          item.Data.Matrix[i, 2] + " |" +
                          item.Data.Matrix[i, 3] + " |" +
                          item.Data.Matrix[i, 4] + " |" +
                          item.Data.Matrix[i, 5] + " |" +
                          item.Data.Matrix[i, 6]
                         );
            print("********************");
            foreach (var item2 in item.Children)
            {
                for (int i = 0; i <= 24; i++)
                        print("     |"+
                                item2.Data.Matrix[i, 0] + " |" +
                                item2.Data.Matrix[i, 1] + " |" +
                                item2.Data.Matrix[i, 2] + " |" +
                                item2.Data.Matrix[i, 3] + " |" +
                                item2.Data.Matrix[i, 4] + " |" +
                                item2.Data.Matrix[i, 5] + " |" +
                                item2.Data.Matrix[i, 6]
                            );
                print("********************");

                foreach (var item3 in item2.Children)
                {
                    for (int i = 0; i <= 24; i++)
                            print("          |" +
                                     item3.Data.Matrix[i, 0] + " |" +
                                     item3.Data.Matrix[i, 1] + " |" +
                                     item3.Data.Matrix[i, 2] + " |" +
                                     item3.Data.Matrix[i, 3] + " |" +
                                     item3.Data.Matrix[i, 4] + " |" +
                                     item3.Data.Matrix[i, 5] + " |" +
                                     item3.Data.Matrix[i, 6]
                                    );

                    print("********************");

                }

            }

        }*/
        
    }

    void Update () {
		
	}
}

public class Condition
{
    private int _id = 0;
    private string _name = null;
    private string _name2 = null;
    string[,] _matrix = new string[25, 7];

    public Condition(int id, string name, string name2, string[,] matrix)
    {
        this._id = id;
        this._name = name;
        this._name2 = name2;
        this._matrix = matrix;

    }

    public int Id
    {
        get { return this._id; }
    }

    public string Name
    {
        get { return this._name; }
    }

    public string Name2
    {
        get { return this._name2; }
    }
    public string[,] Matrix
    {
        get { return this._matrix; }
    }
    public override string ToString()
    {
        string s = this._name + " " + this._name2;
        //return this._matrix.ToString;
        return this.Name;


    }


}
public class TreeNode<T>
{
    private T _nodeData;
    private ArrayList _childNodes;


    public TreeNode(T nodeData)
    {
        this._nodeData = nodeData;
        this._childNodes = new ArrayList();
    }

    public T Data
    {
        get { return this._nodeData; }
    }

    public TreeNode<T>[] Children
    {
        get { return (TreeNode<T>[])this._childNodes.ToArray(typeof(TreeNode<T>)); }
    }

  


    public TreeNode<T> this[int index]
    {
        get { return (TreeNode<T>)this._childNodes[index]; }
    }

    public TreeNode<T> AddChild(T nodeData)
    {
        TreeNode<T> newNode = new TreeNode<T>(nodeData);
        this._childNodes.Add(newNode);
        return newNode;
    }

    public override string ToString()
    {
        return this._nodeData.ToString();
        
    }

    

}

