using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScore : MonoBehaviour
{
    public static int enemyScore;
    
    public static int score;
    // Start is called before the first frame update
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Your Score " + enemyScore);
        GUI.Label(new Rect(10, 30, 100, 20), "Enemy Score " + score);
    }
}
