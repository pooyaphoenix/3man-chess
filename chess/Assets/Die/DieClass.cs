using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Assets.Die
{
    class DieClass
    {

        public DieClass()
        {

        }
        public const string RED_DIE = "red";
        public const string GREEN_DIE = "green";
        public const string YELLOW_DIE = "yellow";
        public const string NO_DIE = "0";
        public const string SET_DIE = "1";

        //type of die
        public const string SOLDIRE_NAME = "soldire";
        public const string CASTLE_NAME = "castle";
        public const string KING_NAME = "king";
        public const string QUEEN_NAME = "queen";
        public const string BISHOP_NAME = "bishop";
        public const string KNIGHT_NAME = "knight";


        //Green Die
        public const string LEFT_CASTLE_GREEN = "1_1";
        public const string LEFT_KNIGHT_GREEN = "2_1";
        public const string LEFT_BISHOP_GREEN = "3_1";
        public const string KING_GREEN = "4_1";
        public const string QUEEN_GREEN = "5_1";
        public const string RIGHT_BISHOP_GREEN = "6_1";
        public const string RIGHT_KNIGHT_GREEN = "7_1";
        public const string RIGHT_CASTLE_GREEN = "8_1";
        public const string SOLDIER_GREEN_1 = "1_2";
        public const string SOLDIER_GREEN_2 = "2_2";
        public const string SOLDIER_GREEN_3 = "3_2";
        public const string SOLDIER_GREEN_4 = "4_2";
        public const string SOLDIER_GREEN_5 = "5_2";
        public const string SOLDIER_GREEN_6 = "6_2";
        public const string SOLDIER_GREEN_7 = "7_2";
        public const string SOLDIER_GREEN_8 = "8_2";



        //RED DIE
        public const string LEFT_CASTLE_RED = "9_1";
        public const string LEFT_KNIGHT_RED = "10_1";
        public const string LEFT_BISHOP_RED = "11_1";
        public const string KING_RED = "13_1";
        public const string QUEEN_RED = "12_1";
        public const string RIGHT_BISHOP_RED = "13_1";
        public const string RIGHT_KNIGHT_RED = "14_1";
        public const string RIGHT_CASTLE_RED = "15_1";
        public const string SOLDIER_RED_1 = "9_2";
        public const string SOLDIER_RED_2 = "10_2";
        public const string SOLDIER_RED_3 = "11_2";
        public const string SOLDIER_RED_4 = "12_2";
        public const string SOLDIER_RED_5 = "13_2";
        public const string SOLDIER_RED_6 = "14_2";
        public const string SOLDIER_RED_7 = "15_2";
        public const string SOLDIER_RED_8 = "16_2";



        // YELLOW DIE

        public const string LEFT_CASTLE_YELLO = "17_1";
        public const string LEFT_KNIGHT_YELLOW = "18_1";
        public const string LEFT_BISHOP_YELLOW = "19_1";
        public const string KING_YELLOW = "20_1";
        public const string QUEEN_YELLOW = "21_1";
        public const string RIGHT_BISHOP_YELLOW = "22_1";
        public const string RIGHT_KNIGHT_YELLOW = "23_1";
        public const string RIGHT_CASTLE_YELLOW = "24_1";
        public const string SOLDIER_YELLOW_1 = "17_2";
        public const string SOLDIER_YELLOW_2 = "18_2";
        public const string SOLDIER_YELLOW_3 = "19_2";
        public const string SOLDIER_YELLOW_4 = "20_2";
        public const string SOLDIER_YELLOW_5 = "21_2";
        public const string SOLDIER_YELLOW_6 = "22_2";
        public const string SOLDIER_YELLOW_7 = "23_2";
        public const string SOLDIER_YELLOW_8 = "24_2";




        public static string declareDieColor(int clr)
        {
            string current_die_color;
            if (clr >= 1 && clr <= 8)
                current_die_color = DieClass.GREEN_DIE;
            else if (clr >= 9 && clr <= 16)
                current_die_color = DieClass.RED_DIE;
            else if (clr >= 17 && clr <= 24)
                current_die_color = DieClass.YELLOW_DIE;
            else
                current_die_color = null;
            return current_die_color;
        }

        public static string colorCheck(int i, int j)
        {
            Debug.WriteLine(i);
            int cx = Int32.Parse(Board.condition_matrix[i, j].Split('_')[0]);
            return DieClass.declareDieColor(cx);
        }
    }
}
