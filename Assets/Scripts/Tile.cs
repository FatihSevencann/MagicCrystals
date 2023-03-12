using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class Tile : MonoBehaviour
{
    #region Variables
    public bool mergedThisTurn=false;
    public int indRow,indCol;
    private int number ;
    //image
    [SerializeField] private Image crystal ;

    [FormerlySerializedAs("back_Fonts")] [SerializeField] private Image backFonts ;
    //anim
    [SerializeField] private Animator anim; //Singleton
    #endregion
    
    public int Number{
        get
        {
            return number;
        }
        set
        {
            number = value;
                if(number==0){
                    SetEmpty();
                }
                else
                {
                    SetVisible();
                    ApplyStyle(number);
                }
        }
    }

void Awake()
{

    anim = GetComponent<Animator>();

}
#region Animations
    public void PlayMergedAnimation()
    {
        anim.SetTrigger("Merge");

    }

    public void PlayAppearAnimation()
    {
        anim.SetTrigger("Appear");

    }

    

    #endregion
    void ApplyStyleFromHolder(int index)
{
    crystal.GetComponent<Image>().sprite = TileHolderStyle.Instance.TileStyles[index].Sprite;
    backFonts.color=TileHolderStyle.Instance.TileStyles[index].TileColor;
}
void ApplyStyle(int num){
   
    switch(num){
        case 2:
        ApplyStyleFromHolder(0);
        break;
        case 4:
        ApplyStyleFromHolder(1);
        break;
        case 8:    
        ApplyStyleFromHolder(2);
        break;
        case 16:
        ApplyStyleFromHolder(3);
        break;
        case 32:
        ApplyStyleFromHolder(4);
        break;
        case 64:
        ApplyStyleFromHolder(5);
        break;
        case 128:
        ApplyStyleFromHolder(6);
        break;
        case 256:
        ApplyStyleFromHolder(7);
        break;
        case 512:
        ApplyStyleFromHolder(8);
        break;
        case 1024:
        ApplyStyleFromHolder(9);
        break;
        default:
        Debug.LogError("Check the numbers that you pass to AppleStyle ");
        break;
    }


}

#region SETTER
public void SetVisible(){

    backFonts.enabled=true;
    crystal.enabled=true;
}
private void SetEmpty(){
    backFonts.enabled=false;
    crystal.enabled=false;
}
#endregion




}
