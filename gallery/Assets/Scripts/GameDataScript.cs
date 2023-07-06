using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "GameDataScript")]
public class GameDataScript : ScriptableObject
{
    public int imageCount;
    public int numberOfTabImage;

    public void ResetData()
    {
        imageCount = 1;
    }
    
}
