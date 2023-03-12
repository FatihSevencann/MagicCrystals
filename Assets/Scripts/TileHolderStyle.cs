using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TileStyle{

public int Number;
public Color32 TileColor;
public Sprite Sprite;
}


public class TileHolderStyle : MonoBehaviour
{
    //Singleton 
    public static TileHolderStyle Instance;

    public TileStyle[] TileStyles;

 private void Awake() {
     
     Instance=this;

 }

}
