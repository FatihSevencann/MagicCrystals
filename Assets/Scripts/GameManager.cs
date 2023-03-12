using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    
    public Text TotalPointText, level;
  
    
    /// <summary>
    /// deneme
    public int[,] CrystalNumbers = new int[,] { { 2, 0 }, { 4, 0 }, { 8, 0 }, { 16, 0 }, { 32, 0 }, { 64, 0 }, { 128, 0 }, { 256, 0 }, { 512, 0 } };
    public Text BubbleText,OnecrystalText,TwocrystalText,OneCrystalNext,TwoCrystalNext;
    public Image OnecrystalImage,TwocrystalImage,OneCrystalSpriteNext,TwoCrystalSpriteNext;
    public static int levelCount=1;
    /// </summary>
    #endregion
    
    #region ListsAndDefinations
    
    private Tile[,] AllTiles = new Tile[4,4];
    private List<Tile[]> columns=new List<Tile[]>();
    private List<Tile[]> rows=new List<Tile[]>();
    private List<Tile>EmptyTiles=new List<Tile>();
    
    #endregion
    void Start()
    { 
        LevelController();
        level.text = "LEVEL "+levelCount.ToString();
        TilesController();
        AddTiles();
        Generate();
    }
    #region MakeMoveIndex
    public bool MakeOneMoveDownIndex(Tile[] LineOfTiles){

        for(int i=0; i<LineOfTiles.Length-1;i++)
        {
            //Move BLOCK
            DownMoveBlock(LineOfTiles, i);
            
            //Merge Block
            if(LineOfTiles[i].Number!=0 &&  LineOfTiles[i].Number==LineOfTiles[i+1].Number && LineOfTiles[i].mergedThisTurn==false
               && LineOfTiles[i+1].mergedThisTurn==false&& Mathf.Pow(2,levelCount)>=LineOfTiles[i].Number)
            {
                DownMergeBlock(LineOfTiles, i);
                ScoreUpdate(LineOfTiles, i);
                UIManager.instance.VoiceController();
                CheckCrystals(LineOfTiles, i);
                LevelController();
                LineOfTiles[i].PlayMergedAnimation();
                return true;
            }
        }
        return false;
    }
    bool MakeOneMoveUpIndex(Tile[] LineOfTiles){

        for(int i=LineOfTiles.Length-1; i>0;i--)
        {
            //Move BLOCK
            if(LineOfTiles[i].Number==0 && LineOfTiles[i-1].Number !=0)
            {
                 UpIndexMoveBlock(LineOfTiles, i);
            }

            // Merge block 
            if(LineOfTiles[i].Number!=0 &&  LineOfTiles[i].Number==LineOfTiles[i-1].Number 
                                        && LineOfTiles[i].mergedThisTurn==false && LineOfTiles[i-1].mergedThisTurn==false && Mathf.Pow(2,levelCount)>=LineOfTiles[i].Number  )
            {
                UpIndexMergeBlock(LineOfTiles, i);
                ScoreUpdate(LineOfTiles, i);
                UIManager.instance.Voice.PlayOneShot(UIManager.instance.mergeVoice);
                CheckCrystals(LineOfTiles, i);
                LevelController();
                UIManager.instance.Voice.PlayOneShot(UIManager.instance.mergeVoice);
                UIManager.instance.Voice.Pause();
                LineOfTiles[i].PlayMergedAnimation();
                return true;
            }
        }
        return false;

    }
    #endregion
    
    #region MovesBlock
    public static bool DownMoveBlock(Tile[] LineOfTiles, int i)
    {
        if (LineOfTiles[i].Number == 0 && LineOfTiles[i + 1].Number != 0)
        {
            LineOfTiles[i].Number = LineOfTiles[i + 1].Number;
            LineOfTiles[i + 1].Number = 0;
            return true; 
        } 

        return false;
    }
    public  static bool UpIndexMoveBlock(Tile[] LineOfTiles, int i)
    {
        LineOfTiles[i].Number = LineOfTiles[i - 1].Number;
        LineOfTiles[i - 1].Number = 0;
        return true;
    }

    #endregion
    
    //deneme
  
    
      public void LevelController(){

         void Level1()
         {
            if((3-CrystalNumbers[0,1])<0)
            {
             OnecrystalText.text="0";

            }
            else       
            OnecrystalText.text=(3-CrystalNumbers[0,1]).ToString();
            if((5-CrystalNumbers[1,1])<0)
            {
            TwocrystalText.text="0";
            }
            else
            TwocrystalText.text=(5-CrystalNumbers[1,1]).ToString();
            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[0].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
            
            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[0].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
            OneCrystalNext.text="3";
            TwoCrystalNext.text="5";
            if(CrystalNumbers[0,1]==2 && CrystalNumbers[1,1]==2)
            {

            BubbleText.text="Level 2 yolu gözüktü :) " ;
            }
            if(CrystalNumbers[0,1]==2 && CrystalNumbers[1,1]==4)
            {
                BubbleText.text="Hadi çok az kaldı :) " ;
            }
            if(CrystalNumbers[0,1]==3 && CrystalNumbers[1,1]==5)
             {
                 UIManager.instance.YouWon();
                 levelCount++;
             }
         }
         void Level2()
        {
            
            if((2-CrystalNumbers[1,1])<0)
            {
                    OnecrystalText.text="0";

            }
            else
            {
                OnecrystalText.text=(2-CrystalNumbers[1,1]).ToString();        
            }

            if((3-CrystalNumbers[2,1])<0)
            {
                TwocrystalText.text="0";

            }
            else
                TwocrystalText.text=(3-CrystalNumbers[2,1]).ToString();
          
            OneCrystalNext.text="2";
            TwoCrystalNext.text="3";

            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;

            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[1].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;

                    
            if(CrystalNumbers[1,1]==1 && CrystalNumbers[2,1]==1)
            {

                BubbleText.text="hadi yapabilirsin " ;

            }

            if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==2)
            {
                 BubbleText.text="Çok yaklaştın  :) " ;

            }
            if(CrystalNumbers[1,1]==2 && CrystalNumbers[2,1]==3)
            {
                UIManager.instance.YouWon();
                levelCount++;
            }

        }

             
        void Level3(){
            if((2-CrystalNumbers[2,1])<0)
            {
                OnecrystalText.text="0";

            }
            else
            {
                OnecrystalText.text=(2-CrystalNumbers[2,1]).ToString();
            }

            if((3-CrystalNumbers[3,1])<0)
            {
                TwocrystalText.text="0";

            }
            else
            TwocrystalText.text=(3-CrystalNumbers[3,1]).ToString();
               
            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;

            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[2].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;

            OneCrystalNext.text="2";
            TwoCrystalNext.text="3";
            
            
            if(CrystalNumbers[2,1]==1 && CrystalNumbers[3,1]==1)
            {
                BubbleText.text="Wow çok iyi başladın " ;
            }
            if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==2)
            {
                 BubbleText.text="Son bir  KRİSTAL istiyorum senden :) " ;

            }


            if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==3)
            {
                UIManager.instance.YouWon();
                levelCount++;

            }
        }
             
        void Level4()
        {
            if((2-CrystalNumbers[3,1])<0)
            {
                OnecrystalText.text="0";

            }
            else
            {
                OnecrystalText.text=(2-CrystalNumbers[3,1]).ToString();
            }

            if((4-CrystalNumbers[4,1])<0)
            {
                TwocrystalText.text="0";
            }
            else
            TwocrystalText.text=(4-CrystalNumbers[4,1]).ToString();
               
            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;

            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[3].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;

            OneCrystalNext.text="2";
            TwoCrystalNext.text="4";
            
            if(CrystalNumbers[3,1]==1 && CrystalNumbers[4,1]==2)
            {

                BubbleText.text="Güzel başladın " ;

            }

            if(CrystalNumbers[2,1]==2 && CrystalNumbers[3,1]==2)
            {
                 BubbleText.text="Neredeyse bitti :)  " ;

            }

            if(CrystalNumbers[3,1]==2 && CrystalNumbers[4,1]==4)
            {
                UIManager.instance.YouWon();
                levelCount++;
            }

        }

             
        void Level5()
        {
            if((3-CrystalNumbers[4,1])<0)
            {
                 OnecrystalText.text="0";

             }
            else
            {
                OnecrystalText.text=(3-CrystalNumbers[4,1]).ToString();
    
            }
            if((2-CrystalNumbers[5,1])<0)
            {
                TwocrystalText.text="0";

            }
            else
            TwocrystalText.text=(2-CrystalNumbers[5,1]).ToString();
               
            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;
            
            

            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[4].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;

            OneCrystalNext.text="3";
            TwoCrystalNext.text="2";

            if(CrystalNumbers[4,1]==1 && CrystalNumbers[5,1]==1)
            {

                BubbleText.text="hadi yapabilirsin " ;

            }

            if(CrystalNumbers[4,1]==3 && CrystalNumbers[5,1]==1)
            {
                 BubbleText.text="Çok yaklaştın  :) " ;

            }

            if(CrystalNumbers[4,1]==3 && CrystalNumbers[5,1]==2)
            {
                UIManager.instance.YouWon();
                levelCount++;
            }

        }

             
        void Level6()
        {
            if((3-CrystalNumbers[5,1])<0)
            {
                 OnecrystalText.text="0";
            }
            else
            {
                OnecrystalText.text=(3-CrystalNumbers[5,1]).ToString();
            }

            if((2-CrystalNumbers[6,1])<0)
            {
                TwocrystalText.text="0";

            }
            else
                TwocrystalText.text=(2-CrystalNumbers[6,1]).ToString();
               
            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;

            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[5].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;

            OneCrystalNext.text="3";
            TwoCrystalNext.text="2";

            if(CrystalNumbers[5,1]==2 && CrystalNumbers[6,1]==1)
            {

                BubbleText.text="hadi yapabilirsin " ;

            }

            if(CrystalNumbers[5,1]==3 && CrystalNumbers[6,1]==1)
            {
                 BubbleText.text="Çok yaklaştın  :) " ;

            }

            if(CrystalNumbers[5,1]==3 && CrystalNumbers[6,1]==2)
            {
                UIManager.instance.YouWon();
                levelCount++;
            }

        }

             
        void Level7()
        {
            if((4-CrystalNumbers[6,1])<0)
            {
                OnecrystalText.text="0";

            }
            else
            {
             OnecrystalText.text=(4-CrystalNumbers[6,1]).ToString();
            }

            if((2-CrystalNumbers[7,1])<0)
            {
                TwocrystalText.text="0";

            }
            else
                TwocrystalText.text=(2-CrystalNumbers[7,1]).ToString(); 

            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;
            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[6].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;

            OneCrystalNext.text="4";
            TwoCrystalNext.text="2";

            if(CrystalNumbers[6,1]==2 && CrystalNumbers[7,1]==1)
            {

                BubbleText.text="hadi yapabilirsin " ;

            }

            if(CrystalNumbers[6,1]==4 && CrystalNumbers[7,1]==1)
            {
                 BubbleText.text="Çok yaklaştın  :) " ;

            }

            if(CrystalNumbers[6,1]==4 && CrystalNumbers[7,1]==2)
            {
                UIManager.instance.YouWon();
                levelCount++;

             }

         }

             
         void Level8()
         {
            if((5-CrystalNumbers[7,1])<0)
            {
                OnecrystalText.text="0";
            }
            else
            {
                OnecrystalText.text=(5-CrystalNumbers[7,1]).ToString();
            }

            if((3-CrystalNumbers[8,1])<0)
            {
                TwocrystalText.text="0";

            }
            else
            TwocrystalText.text=(3-CrystalNumbers[8,1]).ToString();    

            OnecrystalImage.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;
            TwocrystalImage.sprite=TileHolderStyle.Instance.TileStyles[8].Sprite;

            OneCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[7].Sprite;
            TwoCrystalSpriteNext.sprite=TileHolderStyle.Instance.TileStyles[8].Sprite;

            OneCrystalNext.text="5";
            TwoCrystalNext.text="3";

            if(CrystalNumbers[7,1]==3 && CrystalNumbers[2,1]==1)
            {

                BubbleText.text="hadi yapabilirsin " ;

            }

            if(CrystalNumbers[7,1]==5 && CrystalNumbers[8,1]==2)
            {
                 BubbleText.text="Çok yaklaştın  :) " ;

            }

            if(CrystalNumbers[7,1]==5 && CrystalNumbers[8,1]==3)
            {
                UIManager.instance.YouWon();
                levelCount++;

            }

        }
        
        switch(levelCount)
        {
            case 1:
            Level1();

            break;

            case 2:
            Level2();

            break;

            case 3:
            Level3();

            break;

            case 4:
            Level4();

            break;


            case 5:
            Level5();

            break;

            case 6:
            Level6();

            break;

            case 7:
            Level7();

            break;

            case 8:
            Level8();

            break;
            }
         }
    
    //deneme
    
    #region UIUpdate
    private void ScoreUpdate(Tile[] LineOfTiles, int i)
    {
        Score.TotalScore += LineOfTiles[i].Number;
        TotalPointText.text = Score.TotalScore.ToString();
      
    }
  
    #endregion

    #region CheckTiles
    private bool CheckRows()
    {
        for (int i = 0; i < rows.Count; i++)
        for (int j = 0; j < columns.Count - 1; j++)
            if (AllTiles[i, j].Number == AllTiles[i, j + 1].Number)
                return true;
        return false;
    }
    public bool CheckColums()
    {
        for (int i = 0; i < columns.Count; i++)
        for (int j = 0; j < rows.Count - 1; j++)
            if (AllTiles[j, i].Number == AllTiles[j + 1, i].Number)
                return true;
        return false;
    }
    private void CheckCrystals(Tile[] LineOfTiles, int i)
    {
        for (int k = 0; k < 9; k++)
        {
            if (CrystalNumbers[k, 0] == LineOfTiles[i].Number)
            {
               CrystalNumbers[k - 1, 1] -= 2;
               CrystalNumbers[k, 1]++;
            }
        }
    }
    bool CanMove(){
        if(EmptyTiles.Count>0)
            return true;
        else
        {
            //check colums
            CheckColums();
            //check rows 
            CheckRows();
        }
        return false ;
    }
    
    
    private void TilesController()
    {
        Tile[] AllTimesOneDim = GameObject.FindObjectsOfType<Tile>();
        
        foreach (Tile t in AllTimesOneDim)
        {
            t.Number = 0;

            AllTiles[t.indRow, t.indCol] = t;
            EmptyTiles.Add(t);
        }
    }
    #endregion
    
 
    
    #region MergesBlocks
    public  static void UpIndexMergeBlock(Tile[] LineOfTiles, int i)
    {
        LineOfTiles[i].Number *= 2;
        LineOfTiles[i - 1].Number = 0;
        LineOfTiles[i].mergedThisTurn = true;
    }
    public static void DownMergeBlock(Tile[] LineOfTiles, int i)
    {
        LineOfTiles[i].Number *= 2;
        LineOfTiles[i + 1].Number = 0;
        LineOfTiles[i].mergedThisTurn = true;
    }
    
    #endregion
    
    #region GeneralMethods
   
    public void AddTiles()
    {
        columns.Add(new Tile[] { AllTiles[0, 0], AllTiles[1, 0], AllTiles[2, 0], AllTiles[3, 0] });
        columns.Add(new Tile[] { AllTiles[0, 1], AllTiles[1, 1], AllTiles[2, 1], AllTiles[3, 1] });
        columns.Add(new Tile[] { AllTiles[0, 2], AllTiles[1, 2], AllTiles[2, 2], AllTiles[3, 2] });
        columns.Add(new Tile[] { AllTiles[0, 3], AllTiles[1, 3], AllTiles[2, 3], AllTiles[3, 3] });

        rows.Add(new Tile[] { AllTiles[0, 0], AllTiles[0, 1], AllTiles[0, 2], AllTiles[0, 3] });
        rows.Add(new Tile[] { AllTiles[1, 0], AllTiles[1, 1], AllTiles[1, 2], AllTiles[1, 3] });
        rows.Add(new Tile[] { AllTiles[2, 0], AllTiles[2, 1], AllTiles[2, 2], AllTiles[2, 3] });
        rows.Add(new Tile[] { AllTiles[3, 0], AllTiles[3, 1], AllTiles[3, 2], AllTiles[3, 3] });
    }
    
    private void ResetMergedFlags(){

        foreach (var t in AllTiles)
        {
            t.mergedThisTurn=false;
           
        }
    }

    private  void UpdateEmptyTiles(){

        EmptyTiles.Clear();
        foreach (Tile t in AllTiles)
        {
            if(t.Number==0)
                EmptyTiles.Add(t);
        }
    }

    
    public void Move( MoveDirection md){

        bool moveMade=false;

        ResetMergedFlags();
  
        for(int i=0; i<rows.Count; i++)
        {
            switch(md){

                case MoveDirection.Down:
                    while(MakeOneMoveUpIndex(columns[i])) {

                        moveMade=true;
                    }
                    break;

                case MoveDirection.Up:
                    while(MakeOneMoveDownIndex(columns[i])) {
                        moveMade=true;
                    }
                    break;


                case MoveDirection.Left:
                    while(MakeOneMoveDownIndex(rows[i])) {
                        moveMade=true;
                    }
                    break;

                case MoveDirection Right:
                    while(MakeOneMoveUpIndex(rows[i])) {
                        moveMade=true;
                    }

                    break;

            }
        }
        if(moveMade){
            UpdateEmptyTiles();
            Generate();
        }

        if(!CanMove()){
            UIManager.instance.GameOver();
        }   
    
    }
    

    #endregion
    
    #region GenerateMethods
    void Generate()
    {
        if(EmptyTiles.Count>0)
        {
            int indexForNewNumber=Random.Range(0,EmptyTiles.Count);
            int randomNum=Random.Range(0,10);
            WhichNumberGenerate(randomNum, indexForNewNumber);
            EmptyTiles[indexForNewNumber].PlayAppearAnimation();
            EmptyTiles.RemoveAt(indexForNewNumber);
            LevelController();
        }
    }
    private void WhichNumberGenerate(int randomNum, int indexForNewNumber)
    {
        if (randomNum == 0)
        {
            EmptyTiles[indexForNewNumber].Number = 4;
            UIManager.instance.Voice.Play();
          CrystalNumbers[1,1]++;
        }
        else
        {
            EmptyTiles[indexForNewNumber].Number = 2;
            UIManager.instance.Voice.Play();
            CrystalNumbers[0, 1]++;
        }
    }
    #endregion
}