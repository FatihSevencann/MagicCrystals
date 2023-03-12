using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelManager: MonoBehaviour
    {
   
        // public int[,] CrystalNumbers = new int[,] { { 2, 0 }, { 4, 0 }, { 8, 0 }, { 16, 0 }, { 32, 0 }, { 64, 0 }, { 128, 0 }, { 256, 0 }, { 512, 0 } };
        // public Text BubbleText,OnecrystalText,TwocrystalText,OneCrystalNext,TwoCrystalNext;
        // public Image OnecrystalImage,TwocrystalImage,OneCrystalSpriteNext,TwoCrystalSpriteNext;
        // public static int levelCount=1;
        public static LevelManager instance;

        private void Awake()
        {
          

        }

        // public static int LevelCount
        // {
        //     get => levelCount;
        //     set => levelCount = value;
        // }
        
        //  public void LevelController(){
        //
        //  void Level1()
        //  {
        //     if((3-CrystalNumbers[0,1])<0)
        //     {
        //      OnecrystalText.text="0";
        //
        //     }
        //     else       
        //     OnecrystalText.text=(3-CrystalNumbers[0,1]).ToString();
        //     if((5-CrystalNumbers[1,1])<0)
        //     {
        //     TwocrystalText.text="0";
        //     }
        //     else
        //     TwocrystalText.text=(5-CrystalNumbers[1,1]).ToString();
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[0].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
        //     
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[0].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
        //     OneCrystalNext.text="3";
        //     TwoCrystalNext.text="5";
        //     if(CrystalNumbers[0,1]==2 && CrystalNumbers[1,1]==2)
        //     {
        //
        //     BubbleText.text="Level 2 yolu gözüktü :) " ;
        //     }
        //     if(CrystalNumbers[0,1]==2 && CrystalNumbers[1,1]==4)
        //     {
        //         BubbleText.text="Hadi çok az kaldı :) " ;
        //     }
        //     if(CrystalNumbers[0,1]==3 && CrystalNumbers[1,1]==5)
        //      {
        //          UIManager.instance.YouWon();
        //          levelCount++;
        //      }
        //  }
        //  void Level2()
        // {
        //     
        //     if((2-CrystalNumbers[1,1])<0)
        //     {
        //             OnecrystalText.text="0";
        //
        //     }
        //     else
        //     {
        //         OnecrystalText.text=(2-CrystalNumbers[1,1]).ToString();        
        //     }
        //
        //     if((3-CrystalNumbers[2,1])<0)
        //     {
        //         TwocrystalText.text="0";
        //
        //     }
        //     else
        //         TwocrystalText.text=(3-CrystalNumbers[2,1]).ToString();
        //   
        //     OneCrystalNext.text="2";
        //     TwoCrystalNext.text="3";
        //
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;
        //
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;
        //
        //             
        //     if(CrystalNumbers[1,1]==1 && CrystalNumbers[2,1]==1)
        //     {
        //
        //         BubbleText.text="hadi yapabilirsin " ;
        //
        //     }
        //
        //     if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==2)
        //     {
        //          BubbleText.text="Çok yaklaştın  :) " ;
        //
        //     }
        //     if(CrystalNumbers[1,1]==2 && CrystalNumbers[2,1]==3)
        //     {
        //         UIManager.instance.YouWon();
        //         levelCount++;
        //     }
        //
        // }
        //
        //      
        // void Level3(){
        //     if((2-CrystalNumbers[2,1])<0)
        //     {
        //         OnecrystalText.text="0";
        //
        //     }
        //     else
        //     {
        //         OnecrystalText.text=(2-CrystalNumbers[2,1]).ToString();
        //     }
        //
        //     if((3-CrystalNumbers[3,1])<0)
        //     {
        //         TwocrystalText.text="0";
        //
        //     }
        //     else
        //     TwocrystalText.text=(3-CrystalNumbers[3,1]).ToString();
        //        
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;
        //
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;
        //
        //     OneCrystalNext.text="2";
        //     TwoCrystalNext.text="3";
        //     
        //     
        //     if(CrystalNumbers[2,1]==1 && CrystalNumbers[3,1]==1)
        //     {
        //         BubbleText.text="Wow çok iyi başladın " ;
        //     }
        //     if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==2)
        //     {
        //          BubbleText.text="Son bir  KRİSTAL istiyorum senden :) " ;
        //
        //     }
        //
        //
        //     if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==3)
        //     {
        //         UIManager.instance.YouWon();
        //         levelCount++;
        //
        //     }
        // }
        //      
        // void Level4()
        // {
        //     if((2-CrystalNumbers[3,1])<0)
        //     {
        //         OnecrystalText.text="0";
        //
        //     }
        //     else
        //     {
        //         OnecrystalText.text=(2-CrystalNumbers[3,1]).ToString();
        //     }
        //
        //     if((4-CrystalNumbers[4,1])<0)
        //     {
        //         TwocrystalText.text="0";
        //     }
        //     else
        //     TwocrystalText.text=(4-CrystalNumbers[4,1]).ToString();
        //        
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;
        //
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;
        //
        //     OneCrystalNext.text="2";
        //     TwoCrystalNext.text="4";
        //     
        //     if(CrystalNumbers[3,1]==1 && CrystalNumbers[4,1]==2)
        //     {
        //
        //         BubbleText.text="Güzel başladın " ;
        //
        //     }
        //
        //     if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==2)
        //     {
        //          BubbleText.text="Neredeyse bitti :)  " ;
        //
        //     }
        //
        //     if(CrystalNumbers[3,1]==2 && CrystalNumbers[4,1]==4)
        //     {
        //         UIManager.instance.YouWon();
        //         levelCount++;
        //     }
        //
        // }
        //
        //      
        // void Level5()
        // {
        //     if((3-CrystalNumbers[4,1])<0)
        //     {
        //          OnecrystalText.text="0";
        //
        //      }
        //     else
        //     {
        //         OnecrystalText.text=(3-CrystalNumbers[4,1]).ToString();
        //
        //     }
        //     if((2-CrystalNumbers[5,1])<0)
        //     {
        //         TwocrystalText.text="0";
        //
        //     }
        //     else
        //     TwocrystalText.text=(2-CrystalNumbers[5,1]).ToString();
        //        
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;
        //     
        //     
        //
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;
        //
        //     OneCrystalNext.text="3";
        //     TwoCrystalNext.text="2";
        //
        //     if(CrystalNumbers[4,1]==1 && CrystalNumbers[5,1]==1)
        //     {
        //
        //         BubbleText.text="hadi yapabilirsin " ;
        //
        //     }
        //
        //     if(CrystalNumbers[4,1]==3 && CrystalNumbers[5,1]==1)
        //     {
        //          BubbleText.text="Çok yaklaştın  :) " ;
        //
        //     }
        //
        //     if(CrystalNumbers[4,1]==3 && CrystalNumbers[5,1]==2)
        //     {
        //         UIManager.instance.YouWon();
        //         levelCount++;
        //     }
        //
        // }
        //
        //      
        // void Level6()
        // {
        //     if((3-CrystalNumbers[5,1])<0)
        //     {
        //          OnecrystalText.text="0";
        //     }
        //     else
        //     {
        //         OnecrystalText.text=(3-CrystalNumbers[5,1]).ToString();
        //     }
        //
        //     if((2-CrystalNumbers[6,1])<0)
        //     {
        //         TwocrystalText.text="0";
        //
        //     }
        //     else
        //         TwocrystalText.text=(2-CrystalNumbers[6,1]).ToString();
        //        
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;
        //
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;
        //
        //     OneCrystalNext.text="3";
        //     TwoCrystalNext.text="2";
        //
        //     if(CrystalNumbers[5,1]==2 && CrystalNumbers[6,1]==1)
        //     {
        //
        //         BubbleText.text="hadi yapabilirsin " ;
        //
        //     }
        //
        //     if(CrystalNumbers[5,1]==3 && CrystalNumbers[6,1]==1)
        //     {
        //          BubbleText.text="Çok yaklaştın  :) " ;
        //
        //     }
        //
        //     if(CrystalNumbers[5,1]==3 && CrystalNumbers[6,1]==2)
        //     {
        //         UIManager.instance.YouWon();
        //         levelCount++;
        //     }
        //
        // }
        //
        //      
        // void Level7()
        // {
        //     if((4-CrystalNumbers[6,1])<0)
        //     {
        //         OnecrystalText.text="0";
        //
        //     }
        //     else
        //     {
        //      OnecrystalText.text=(4-CrystalNumbers[6,1]).ToString();
        //     }
        //
        //     if((2-CrystalNumbers[7,1])<0)
        //     {
        //         TwocrystalText.text="0";
        //
        //     }
        //     else
        //         TwocrystalText.text=(2-CrystalNumbers[7,1]).ToString(); 
        //
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;
        //
        //     OneCrystalNext.text="4";
        //     TwoCrystalNext.text="2";
        //
        //     if(CrystalNumbers[6,1]==2 && CrystalNumbers[7,1]==1)
        //     {
        //
        //         BubbleText.text="hadi yapabilirsin " ;
        //
        //     }
        //
        //     if(CrystalNumbers[6,1]==4 && CrystalNumbers[7,1]==1)
        //     {
        //          BubbleText.text="Çok yaklaştın  :) " ;
        //
        //     }
        //
        //     if(CrystalNumbers[6,1]==4 && CrystalNumbers[7,1]==2)
        //     {
        //         UIManager.instance.YouWon();
        //         levelCount++;
        //
        //      }
        //
        //  }
        //
        //      
        //  void Level8()
        //  {
        //     if((5-CrystalNumbers[7,1])<0)
        //     {
        //         OnecrystalText.text="0";
        //     }
        //     else
        //     {
        //         OnecrystalText.text=(5-CrystalNumbers[7,1]).ToString();
        //     }
        //
        //     if((3-CrystalNumbers[8,1])<0)
        //     {
        //         TwocrystalText.text="0";
        //
        //     }
        //     else
        //     TwocrystalText.text=(3-CrystalNumbers[8,1]).ToString();    
        //
        //     OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;
        //     TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[8].Sprite;
        //
        //     OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;
        //     TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[8].Sprite;
        //
        //     OneCrystalNext.text="5";
        //     TwoCrystalNext.text="3";
        //
        //     if(CrystalNumbers[7,1]==3 && CrystalNumbers[2,1]==1)
        //     {
        //
        //         BubbleText.text="hadi yapabilirsin " ;
        //
        //     }
        //
        //     if(CrystalNumbers[7,1]==5 && CrystalNumbers[8,1]==2)
        //     {
        //          BubbleText.text="Çok yaklaştın  :) " ;
        //
        //     }
        //
        //     if(CrystalNumbers[7,1]==5 && CrystalNumbers[8,1]==3)
        //     {
        //         UIManager.instance.YouWon();
        //         levelCount++;
        //
        //     }
        //
        // }
        //
        // switch(levelCount)
        // {
        //     case 1:
        //     Level1();
        //
        //     break;
        //
        //     case 2:
        //     Level2();
        //
        //     break;
        //
        //     case 3:
        //     Level3();
        //
        //     break;
        //
        //     case 4:
        //     Level4();
        //
        //     break;
        //
        //
        //     case 5:
        //     Level5();
        //
        //     break;
        //
        //     case 6:
        //     Level6();
        //
        //     break;
        //
        //     case 7:
        //     Level7();
        //
        //     break;
        //
        //     case 8:
        //     Level8();
        //
        //     break;
        //     }
        //  }

    }
}