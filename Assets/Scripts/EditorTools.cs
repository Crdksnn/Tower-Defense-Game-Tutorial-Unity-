using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorTools : EditorWindow
{
    [MenuItem("Tools/Reset Player Pref")]
    public static void REsetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }
}
