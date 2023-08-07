using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skor : MonoBehaviour
{
    static public int i = 0;
    static public int[] skor_ = new int[5];

   
    public static void point2()
    {
        skor_[i] = 2;
        i++;
        Debug.Log("2 puan");
    }
    public static void point4()
    {
        skor_[i] = 4;
        i++;
        Debug.Log("4 puan");
    }
    public static void point6()
    {
        skor_[i] = 6;
        i++;
        Debug.Log("6 puan");
    }
    public static void point8()
    {
        skor_[i] = 8;
        i++;
        Debug.Log("8 puan");
    }
    public static void point10()
    {
        skor_[i] = 10;
        i++;
        Debug.Log("10 puan");
    }
    public static void point12()
    {
        skor_[i] = 12;
        i++;
        Debug.Log("12 puan");
    }
}
