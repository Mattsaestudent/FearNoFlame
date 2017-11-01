using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public enum GameManagerStates {
        Idle,Running
    }

	public enum TurnBasedStates
	{
		FireSpread,PlayersTurn,PlayerWin,PlayerLose
	}


    public int CellNumber;
    public CellBehaviour cellPrefab; //Cell prefab

    public float updateInterval = 1000f; //delay between cell update

    [HideInInspector] public CellBehaviour[,] cells; // matrix of cells

    [HideInInspector] public GameManagerStates GMstate = GameManagerStates.Idle;

	public TurnBasedStates TBStates = TurnBasedStates.FireSpread;

    [HideInInspector] public int sizeX; // game size in x-axis
    [HideInInspector] public int sizeY; // game size in y-axis

    public Action cellUpdates; //action which calls cells' update methods
    public Action cellApplyUpdates;//action which calls cells' apply update methods

    public IEnumerator coroutine;// reference to main coroutine

	[HideInInspector]public List<CellBehaviour> mycelllist;


    public Movement move;

    public int startFire;

	public bool isStartOfGame = true;

    public bool isFirstMovePlayer = true;

    public bool isPlayerSecondTurn;

    public Button icvSpawnButton;
    public Button ltSpawnButton;
    public Button fourfourSpawnButton;
    public Button threefourSpawnButton;
    public Button twofourSpawnButton;
    public Button waterbomberSpawnButton;
    public Button helitackSpawnButton;
    public Button dozerSpawnButton;


    void Awake()
    {
        mycelllist = new List<CellBehaviour>();

        Init(50,50 );
       
		isStartOfGame = true;

        isFirstMovePlayer = true;
        //Run();

        

       

    }


    void SetOnFire()
    {
        startFire = UnityEngine.Random.Range(1, 6);

        
            if (startFire == 1)
        {
            var firstItem = mycelllist[149];
            firstItem.IsonFire = true;
        }

        if (startFire == 2)
        {
            var firstItem = mycelllist[599];
            firstItem.IsonFire = true;
        }

        if (startFire == 3)
        {
            var firstItem = mycelllist[1049];
            firstItem.IsonFire = true;
        }

        if (startFire == 4)
        {
            var firstItem = mycelllist[1499];
            firstItem.IsonFire = true;
        }

        if (startFire == 5)
        {
            var firstItem = mycelllist[1849];
            firstItem.IsonFire = true;
        }

        if (startFire == 6)
        {
            var firstItem = mycelllist[2299];
            firstItem.IsonFire = true;
        }


    }



    public void Init(int x, int y)
    {
        // make sure that cells' matrix is empty and there is no cell object in the scene
        if (cells != null)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    GameObject.Destroy(cells[i, j].gameObject);
                }
            }
        }

        // clear actions
        cellUpdates = null;
        cellApplyUpdates = null;

        coroutine = null;

        sizeX = x;
        sizeY = y;
        SpawnCells(sizeX, sizeY);
    }

    // this method invokes actions which call update and apply methods in cells
    public void UpdateCells()
    {
        cellUpdates();
        cellApplyUpdates();
     
    }

    public void SpawnCells(int x, int y)
    {
    
        cells = new CellBehaviour[x, y]; // create new cells' matrix



        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                CellBehaviour c = Instantiate(cellPrefab, new Vector3((float)i, 0f,(float)j), Quaternion.identity) as CellBehaviour; // create new cell in scene
                mycelllist.Add(c);
                cells[i, j] = c;
                c.Init(this, i, j); // init cell by passing this object to it

                c.name = CellNumber++.ToString();
                // register cell's methods to proper actions
                cellUpdates += c.CellsUpdate;
                cellApplyUpdates += c.CellApplyTheUpdate;



            }
        }





      
        // get and set references to neighbours for every cell
        for (int i = 0; i < x; i++)
        {
            for(int j = 0; j < y; j++)
            {
                cells[i, j].neighbours = GetNeighbours(i, j);
               

            }
        }



    }


    // create array with adjacent cells to cell with coordinates (x,y)
    public CellBehaviour[] GetNeighbours(int x, int y)
    {
        CellBehaviour[] result = new CellBehaviour[12];
        result[0] = cells[x, (y + 1) % sizeY]; //top
        result[1] = cells[(x + 1) % sizeX, y % sizeY]; //right
        result[2] = cells[x % sizeX, (sizeY + y - 1) % sizeY];//bottom
        result[3] = cells[(sizeX + x - 1) % sizeX, y % sizeY]; //left
       
       

        return result;


    }

    

    

    

   

    // this method stops current coroutine and starts new its instance
    public void Run()
    {
        StartCoroutine(RunCoroutine());
    }
    private IEnumerator RunCoroutine()
    {
        yield return new WaitForSeconds(555);
        UpdateCells();
        yield return new WaitForSeconds(555);
        UpdateCells();
        yield return new WaitForSeconds(555);
        UpdateCells();
        yield return new WaitForSeconds(555);
        UpdateCells();
        yield return new WaitForSeconds(555);
        


    }

	public void WhoTurnIsIT()
	{


			if (TBStates == TurnBasedStates.FireSpread) {
			if (isStartOfGame == true)
			{
				SetOnFire();
				isStartOfGame = false;
			}
			CallNextUpdate ();
			CallNextUpdate ();
			CallNextUpdate ();
			CallNextUpdate ();
				TBStates = TurnBasedStates.PlayersTurn;
			} else if (TBStates == TurnBasedStates.PlayersTurn)
			{
				if (isFirstMovePlayer == true)
            {
                icvSpawnButton.interactable = true;
                ltSpawnButton.interactable = false;
                fourfourSpawnButton.interactable = false;
                threefourSpawnButton.interactable = false;
                twofourSpawnButton.interactable = false;
                waterbomberSpawnButton.interactable = false;
                helitackSpawnButton.interactable = false;
                dozerSpawnButton.interactable = false;

                isFirstMovePlayer = false;
                isPlayerSecondTurn = true;

            }
            if (GameObject.Find("ICV(Clone)") != null)
            {
                icvSpawnButton.interactable = false;
                ltSpawnButton.interactable = false;
                fourfourSpawnButton.interactable = false;
                threefourSpawnButton.interactable = false;
                twofourSpawnButton.interactable = false;
                waterbomberSpawnButton.interactable = false;
                helitackSpawnButton.interactable = false;
                dozerSpawnButton.interactable = true;

                isPlayerSecondTurn = false;
            }
             if(isPlayerSecondTurn == false)
            {
                icvSpawnButton.interactable = false;
                ltSpawnButton.interactable = true;
                fourfourSpawnButton.interactable = true;
                threefourSpawnButton.interactable = true;
                twofourSpawnButton.interactable = true;
                waterbomberSpawnButton.interactable = true;
                helitackSpawnButton.interactable = true;
                dozerSpawnButton.interactable = true;
            }
            if (GameObject.Find("D10spawn(Clone)") !=null)
            {
         
                icvSpawnButton.interactable = false;
                ltSpawnButton.interactable = true;
                fourfourSpawnButton.interactable = true;
                threefourSpawnButton.interactable = true;
                twofourSpawnButton.interactable = true;
                waterbomberSpawnButton.interactable = true;
                helitackSpawnButton.interactable = true;
                dozerSpawnButton.interactable = false;
            }

			}
			







	}













	void CallNextUpdate()
    {
        UpdateCells();
    }

  
        // Use this for initialization
        void Start ()
    {
       



    }
	
	// Update is called once per frame
	void Update ()
    {
		WhoTurnIsIT ();
       
    }
}
