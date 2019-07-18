﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Die
{
    class Board
    {


        public static string[,] condition_matrix = new string[25, 7] {
        {"","","","","","",""},//0

        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},//1,2
        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},//3
        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE },//5
        {"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.GREEN_DIE,DieClass.GREEN_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE },//7

        {"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},//9
        {"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE },//11
        {"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE },//13
        {"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.RED_DIE,DieClass.RED_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},//15

        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},//17
        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},//19
        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE },{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE },//21
        {"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE},{"",DieClass.YELLOW_DIE,DieClass.YELLOW_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE,DieClass.NO_DIE}//23
    };

        public static string[,] board_Matrix = new string[24, 6]
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






        public String[,] getConditionMatrix()
        {
            return condition_matrix;
        }
        public void setConditionMatrix(string[,] matrix)
        {
            condition_matrix = matrix;
        }

    }



}