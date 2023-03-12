using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    #region Variables
    public Text TotalPointText,level,BubbleText;
    public static int LevelCount=1;
    public Text OnecrystalText,TwocrystalText,TwoCrystalNext,OneCrystalNext;
    public Image OnecrystalImage,TwocrystalImage,OneCrystalSpriteNext,TwoCrystalSpriteNext;
    private UIManager UIManager;

    public static GameManager instance;
    #endregion
    #region Lists and Definations
    private int[,] CrystalNumbers = new int[,] { { 2, 0 }, { 4, 0 }, { 8, 0 }, { 16, 0 }, { 32, 0 }, { 64, 0 }, { 128, 0 }, { 256, 0 }, { 512, 0 } };
    private Tile[,] AllTiles = new Tile[4,4];
    private List<Tile[]> columns=new List<Tile[]>();
    private List<Tile[]> rows=new List<Tile[]>();
    private List<Tile>EmptyTiles=new List<Tile>();
    #endregion
    
    void Start()
    {
        LevelManager();
        level.text="LEVEL " + LevelCount.ToString();
        TilesController();
        AddTiles();
        Generate();
    }

    private void Awake()
    {
        if (instance)
            return;
        instance = this;
    }

    #region MakeMoveIndex
    public bool MakeOneMoveDownIndex(Tile[] LineOfTiles){

        for(int i=0; i<LineOfTiles.Length-1;i++)
        {
            //Move BLOCK
            if (DownMoveBlock(LineOfTiles, i)) return true;


            //Merge Block

            if(LineOfTiles[i].Number!=0 &&  LineOfTiles[i].Number==LineOfTiles[i+1].Number && LineOfTiles[i].mergedThisTurn==false
               && LineOfTiles[i+1].mergedThisTurn==false&& Mathf.Pow(2,LevelCount)>=LineOfTiles[i].Number)
            {

                DownMergeBlock(LineOfTiles, i);
                ScoreUpdate(LineOfTiles, i);
            //  UIManager.VoiceController();

                CheckCrystals(LineOfTiles, i);
                
                LevelManager();
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
                return UpIndexMoveBlock(LineOfTiles, i);
            }

            // Merge block 
            if(LineOfTiles[i].Number!=0 &&  LineOfTiles[i].Number==LineOfTiles[i-1].Number
                                        && LineOfTiles[i].mergedThisTurn==false && LineOfTiles[i-1].mergedThisTurn==false && Mathf.Pow(2,LevelCount)>=LineOfTiles[i].Number  )
            {
                UpIndexMergeBlock(LineOfTiles, i);
                ScoreUpdate(LineOfTiles,i);
             // UIManager.Voice.PlayOneShot(UIManager.mergeVoice);
                CheckCrystals(LineOfTiles, i);
                LevelManager();
                // UIManager.Voice.PlayOneShot(UIManager.mergeVoice);
                // UIManager.Voice.Pause();
                // LineOfTiles[i].PlayMergedAnimation();
                return true;
            }
        }
        return false;
    }
    #endregion

    #region MovesBlock
    private static bool DownMoveBlock(Tile[] LineOfTiles, int i)
    {
        if (LineOfTiles[i].Number == 0 && LineOfTiles[i + 1].Number != 0)
        {
            LineOfTiles[i].Number = LineOfTiles[i + 1].Number;
            LineOfTiles[i + 1].Number = 0;

            return true;
        }

        return false;
    }
    private static bool UpIndexMoveBlock(Tile[] LineOfTiles, int i)
    {
        LineOfTiles[i].Number = LineOfTiles[i - 1].Number;
        LineOfTiles[i - 1].Number = 0;

        return true;
    }
    
    #endregion

    #region UIUpdate
    private void ScoreUpdate(Tile[] LineOfTiles, int i)
    {
        Score.TotalScore += LineOfTiles[i].Number;
        TotalPointText.text = Score.TotalScore.ToString();
       // GameOverTextt.text = Score.TotalScore.ToString();
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
    private bool CheckColums()
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
    
    bool CanMove(){
        if(EmptyTiles.Count>0)
            return true;

        else
        {
            //check colums
            if (CheckColums()) return true;
            //check rows 
            if (CheckRows()) return true;
        }
        return false ; 


    }

    #endregion

    #region MergeBlocks

    private static void UpIndexMergeBlock(Tile[] LineOfTiles, int i)
    {
        LineOfTiles[i].Number *= 2;
        LineOfTiles[i - 1].Number = 0;
        LineOfTiles[i].mergedThisTurn = true;
    }
    private static void DownMergeBlock(Tile[] LineOfTiles, int i)
    {
        LineOfTiles[i].Number *= 2;
        LineOfTiles[i + 1].Number = 0;
        LineOfTiles[i].mergedThisTurn = true;
    }

    #endregion
    
    #region GeneralMethod
    private void AddTiles()
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
           UIManager.GameOver();
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

            //EmptyTiles[indexForNewNumber].PlayAppearAnimation();
            
            EmptyTiles.RemoveAt(indexForNewNumber);
            LevelManager();

        }
       
    }
    private void WhichNumberGenerate(int randomNum, int indexForNewNumber)
    {
        if (randomNum == 0)
        {
            EmptyTiles[indexForNewNumber].Number = 4;
          // UIManager.Voice.Play();
            CrystalNumbers[1, 1]++;
        }


        else
        {
            EmptyTiles[indexForNewNumber].Number = 2;
          //  UIManager.Voice.Play();
            CrystalNumbers[0, 1]++;
        }
    }

    #endregion

    #region LevelManager
 public void LevelManager(){

         int Level1(int i)
         {
             OneCrystalNext.text="3";
             TwoCrystalNext.text="5";
             
            if((3-CrystalNumbers[0,1])<0)  OnecrystalText.text="0";
            else  OnecrystalText.text=(3-CrystalNumbers[0,1]).ToString();
            
            if((5-CrystalNumbers[1,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(5-CrystalNumbers[1,1]).ToString();
                                 
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
         }
         int Level2(int i)
        {
            OneCrystalNext.text="2";
            TwoCrystalNext.text="3";
            
            if((2-CrystalNumbers[1,1])<0) OnecrystalText.text="0";
            else OnecrystalText.text=(2-CrystalNumbers[1,1]).ToString();        
            
            if((3-CrystalNumbers[2,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(3-CrystalNumbers[2,1]).ToString();
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
        }
         int Level3(int i){
            OneCrystalNext.text="2";
            TwoCrystalNext.text="3";
            if((2-CrystalNumbers[2,1])<0) OnecrystalText.text="0";
            else OnecrystalText.text=(2-CrystalNumbers[2,1]).ToString();
            
            if((3-CrystalNumbers[3,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(3-CrystalNumbers[3,1]).ToString();
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
        }
         int Level4(int i)
        {
            OneCrystalNext.text="2";
            TwoCrystalNext.text="4";
            
            if((2-CrystalNumbers[3,1])<0) OnecrystalText.text="0";
            else OnecrystalText.text=(2-CrystalNumbers[3,1]).ToString();
            
            if((4-CrystalNumbers[4,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(4-CrystalNumbers[4,1]).ToString();
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
        }
         int Level5(int i)
        {
            OneCrystalNext.text="3";
            TwoCrystalNext.text="2";
            if((3-CrystalNumbers[4,1])<0) OnecrystalText.text="0";
            else OnecrystalText.text=(3-CrystalNumbers[4,1]).ToString();
            
            if((2-CrystalNumbers[5,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(2-CrystalNumbers[5,1]).ToString();
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
        }
         int  Level6(int i)
        {
            OneCrystalNext.text="3";
            TwoCrystalNext.text="2";
            if((3-CrystalNumbers[5,1])<0) OnecrystalText.text="0";
            else OnecrystalText.text=(3-CrystalNumbers[5,1]).ToString();
            
            if((2-CrystalNumbers[6,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(2-CrystalNumbers[6,1]).ToString();
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
        }
         int Level7(int i)
        {
            if((4-CrystalNumbers[6,1])<0) OnecrystalText.text="0";
            else OnecrystalText.text=(4-CrystalNumbers[6,1]).ToString();
            
            if((2-CrystalNumbers[7,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(2-CrystalNumbers[7,1]).ToString(); 
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
        }
         int  Level8(int i)
         {
             OneCrystalNext.text="5";
             TwoCrystalNext.text="3";
             
            if((5-CrystalNumbers[7,1])<0) OnecrystalText.text="0";
            else OnecrystalText.text=(5-CrystalNumbers[7,1]).ToString();
            
            if((3-CrystalNumbers[8,1])<0) TwocrystalText.text="0";
            else TwocrystalText.text=(3-CrystalNumbers[8,1]).ToString();
            SpriteController(i);
            BubbleTextController();
            TargetScore();
            return i;
         }
         
       int Levels = LevelCount switch
        {
            1=>Level1(LevelCount),
            2=>Level2(LevelCount),
            3=>Level3(LevelCount),
            4=>Level4(LevelCount),
            5=>Level5(LevelCount),
            6=>Level6(LevelCount),
            7=>Level7(LevelCount),
            8=>Level8(LevelCount),
        };
    }
 private void TargetScore()
 {
     if (OnecrystalText.text == "0" && TwocrystalText.text == "0")
     {
         UIManager.instance.YouWon();
         LevelCount++;
     }
 }
 private void BubbleTextController()
 {
     if (CrystalNumbers[0, 1] - 2 == 0 && CrystalNumbers[1, 1] - 2 == 0)
     {
         BubbleText.text = "Level 2 yolu gözüktü :) ";
     }
     if (CrystalNumbers[0, 1] - 2 == 0 && CrystalNumbers[1, 1] - 1 == 0)
     {
         BubbleText.text = "Hadi çok az kaldı :) ";
     }
 }
 private void SpriteController(int i)
 {
     OnecrystalImage.sprite = TileHolderStyle.Instance.TileStyles[i - 1].Sprite;
     TwocrystalImage.sprite = TileHolderStyle.Instance.TileStyles[i].Sprite;
     OneCrystalSpriteNext.sprite = TileHolderStyle.Instance.TileStyles[i - 1].Sprite;
     TwoCrystalSpriteNext.sprite = TileHolderStyle.Instance.TileStyles[i].Sprite;
 }

    #endregion
    
   
}
