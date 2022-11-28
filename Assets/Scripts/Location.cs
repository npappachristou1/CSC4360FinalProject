using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Location
{
    public static Vector3 overworldLocation = Vector3.zero;
    public static string menuLocationName = "Overworld";
    public static Vector3 menuLocationGrid = Vector3.zero;
    public static bool menuOn = false;
    public static bool battleOn = false;
    
    public static string battleLocationName = "";
    public static Vector3 battleLocationGrid = Vector3.zero;
}
