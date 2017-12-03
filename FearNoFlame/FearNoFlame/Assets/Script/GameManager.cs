using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public enum GameManagerStates {
        Idle,Running
    }

	public enum TurnBasedStates
	{
		FireSpread,PlayersTurn,PlayerMove,PlayerAction,PlayerWin,PlayerLose
	}

    public int waterTotal;
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

    public Slider waterBar;

    public Text waterDisplay;

    public GameObject EndApplianceCallOut;

    public GameObject EndMovementRound;

    public GameObject EndActionRound;

    public Button endApplianceCallOut;
    public Button endMovementRound;
    public Button endActionRound;

    public BuildingSystems BSs;


    public GameObject prefabtwofour;
    public GameObject prefabthreefour;
    public GameObject prefabfourfour;
    public GameObject prefabHelitack;
    public GameObject prefabwaterbomer;
    

    public bool isLowIntFire;
    public bool isMiddleIntFire;
    public bool isHighIntFire;

    public bool moneyplease;



    public GameObject ICVstat;

    public GameObject win;
    public GameObject lose;

    public GameOverScript gameoverscript;

	public List<GameObject> lts;
	public List<GameObject> twofourss;
	public List<GameObject> threefourss;
	public List<GameObject> fourfours;
	public List<GameObject> planes;
	public List<GameObject> helitack;
    public List<GameObject> dozer;

    public Button mainLTButton;
    public Button mainFireTruck;
    public Button mainPlane;
    public Button mainEarthmoving;

    public GameObject Lookforthefire;






    void Awake()
    {
        mainLTButton.GetComponent<Button>();
        mainFireTruck.GetComponent<Button>();
        mainPlane.GetComponent<Button>();
        mainEarthmoving.GetComponent<Button>();



        mycelllist = new List<CellBehaviour>();

        Init(50,50 );
       
		isStartOfGame = true;

        isFirstMovePlayer = true;
        //Run();

        EndApplianceCallOut.GetComponent<GameObject>();
        EndMovementRound.GetComponent<GameObject>();
        EndActionRound.GetComponent<GameObject>();
        endApplianceCallOut.GetComponent<Button>();
        endMovementRound.GetComponent<Button>();
        endActionRound.GetComponent<Button>();

        BSs.GetComponent<BuildingSystems>();

		lts = new List<GameObject> ();
		twofourss = new List<GameObject> ();
		threefourss = new List<GameObject> ();
		fourfours = new List<GameObject> ();
		planes = new List<GameObject> ();
		helitack = new List<GameObject> ();
        dozer = new List<GameObject>();








    }


    void SetOnFire()
    {
        startFire = UnityEngine.Random.Range(2, 4);

        
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
            for (int o = 0; o < dozer.Count; o++)
            {
                dozer[o].GetComponent<GradingGround>().movementNumber = 0;
                
               
            }

            for (int a = 0; a < lts.Count; a++ )
            {
                lts.Remove(GameObject.FindGameObjectWithTag("car"));
            }
            for(int c = 0; c < twofourss.Count; c++)
            {
                twofourss.Remove(GameObject.FindGameObjectWithTag("24"));
            }

            for(int d = 0; d < threefourss.Count; d++)
            {
                threefourss.Remove(GameObject.FindGameObjectWithTag("34"));
            }

            for(int e = 0; e < fourfours.Count; e++)
            {
                fourfours.Remove(GameObject.FindGameObjectWithTag("44"));
            }
            for(int f =0; f < planes.Count; f++)
            {
                planes.Remove(GameObject.FindGameObjectWithTag("plane"));
            }
            for(int g = 0; g < helitack.Count; g++)
            {
                helitack.Remove(GameObject.FindGameObjectWithTag("heli"));
            }

			if (isStartOfGame == true)
			{
				SetOnFire();
				isStartOfGame = false;

			}
			CallNextUpdate ();
			CallNextUpdate ();
			CallNextUpdate ();
			CallNextUpdate ();
         

            if (moneyplease == true)
            {
                waterTotal += 350;
            }
    

            AreTheySellsstillalite();

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

                mainLTButton.interactable = true;
                mainFireTruck.interactable = false;
                mainPlane.interactable = false;
                mainEarthmoving.interactable = false;

            }
            if (GameObject.Find("ICV(Clone)") != null)
            {
                icvSpawnButton.interactable = true;
                ltSpawnButton.interactable = false;
                fourfourSpawnButton.interactable = false;
                threefourSpawnButton.interactable = false;
                twofourSpawnButton.interactable = false;
                waterbomberSpawnButton.interactable = false;
                helitackSpawnButton.interactable = false;
                dozerSpawnButton.interactable = true;

                isPlayerSecondTurn = false;

                mainLTButton.interactable = true;
                mainFireTruck.interactable = false;
                mainPlane.interactable = false;
                mainEarthmoving.interactable = true;
                
            }
            
             if(isPlayerSecondTurn == false)
            {
                icvSpawnButton.interactable = false;
               
                fourfourSpawnButton.interactable = true;
                threefourSpawnButton.interactable = true;
                twofourSpawnButton.interactable = true;
                waterbomberSpawnButton.interactable = true;
                helitackSpawnButton.interactable = true;
                dozerSpawnButton.interactable = true;

                mainLTButton.interactable = true;
                mainFireTruck.interactable = true;
                mainPlane.interactable = true;
                mainEarthmoving.interactable = true;



            }
            if (GameObject.Find("Dozer_low(Clone)") !=null)
            {
         
                icvSpawnButton.interactable = false;
                ltSpawnButton.interactable = true;
                fourfourSpawnButton.interactable = true;
                threefourSpawnButton.interactable = true;
                twofourSpawnButton.interactable = true;
                waterbomberSpawnButton.interactable = true;
                helitackSpawnButton.interactable = true;
                dozerSpawnButton.interactable = false;
                EndMovementRound.SetActive(false);

                mainLTButton.interactable = true;
                mainFireTruck.interactable = true;
                mainPlane.interactable = true;
                mainEarthmoving.interactable = true;


                dozer.AddRange(GameObject.FindGameObjectsWithTag("dozer"));
            }

           

            if (waterTotal<999)
            {
                helitackSpawnButton.interactable = false;
            }
            if (waterTotal < 949)
            {
                waterbomberSpawnButton.interactable = false; 
            }
            if (waterTotal < 349)
            {
                twofourSpawnButton.interactable = false;
            }
            if (waterTotal < 449)
            {
                threefourSpawnButton.interactable = false;
            }
            if (waterTotal < 549)
            {
                fourfourSpawnButton.interactable = false;
            }
            if (waterTotal < 150)
            {
                ltSpawnButton.interactable = false;
               
            }
            if(waterTotal < 250)
            {
                dozerSpawnButton.interactable = false;
            }
            
        }else if(TBStates == TurnBasedStates.PlayerMove)
        {
            icvSpawnButton.interactable = false;
            ltSpawnButton.interactable = false;
            fourfourSpawnButton.interactable = false;
            threefourSpawnButton.interactable = false;
            twofourSpawnButton.interactable = false;
            waterbomberSpawnButton.interactable = false;
            helitackSpawnButton.interactable = false;
            dozerSpawnButton.interactable = false;

            if(BSs.selectedObject != null)
            {
                BSs.selectedObject = null;
            }


        }else if(TBStates == TurnBasedStates.PlayerAction)
        {
            
			for (int i = 0; i < lts.Count; i++)
			{
                lts[i].GetComponent<PutfireoutLT>().GetActive();

			}
            for(int h = 0; h < twofourss.Count; h++ )
            {
                twofourss[h].GetComponent<PutoutFire24>().CheckforFire();
            }
            for(int j = 0; j < threefourss.Count; j++)
            {
                threefourss[j].GetComponent<PutOutFire34>();
            }
            for(int k =0; k < fourfours.Count; k++ )
            {
                fourfours[k].GetComponent<UfourfourPutoutfire>().CheckforFire();
            }
            for(int l = 0; l < planes.Count; l++ )
            {
                planes[l].GetComponent<PlanePutoutfire>().CheckforFire();
            }
            for(int m =0; m < helitack.Count; m++)
            {
                helitack[m].GetComponent<PutOutFireHelitack>().CheckforFire();
            }



        }
        else if(TBStates == TurnBasedStates.PlayerWin)
        {
            win.SetActive(true);
            StartCoroutine(FinishGame());
            
            
        }
        else if(TBStates == TurnBasedStates.PlayerLose)
        {
            lose.SetActive(true);
            StartCoroutine(FinishGame());

        }
			







	}

    void NextEndBuildTurn()
    {
        TBStates = TurnBasedStates.PlayerMove;

        EndApplianceCallOut.SetActive(false);
        EndMovementRound.SetActive(true);
        EndActionRound.SetActive(false);
    

    }

    void NextMovementTurn()
    {
        TBStates = TurnBasedStates.PlayerAction;
        EndActionRound.SetActive(false);
        EndApplianceCallOut.SetActive(false);
        EndActionRound.SetActive(true);
        EndMovementRound.SetActive(false);
        if (GameObject.Find("ICV(Clone)") == null)
        {
            TBStates = TurnBasedStates.PlayerLose;
        }
       
        lts.AddRange(GameObject.FindGameObjectsWithTag("car"));
        twofourss.AddRange(GameObject.FindGameObjectsWithTag("24"));
        threefourss.AddRange(GameObject.FindGameObjectsWithTag("34"));
        fourfours.AddRange(GameObject.FindGameObjectsWithTag("44"));
        planes.AddRange(GameObject.FindGameObjectsWithTag("plane"));
        helitack.AddRange(GameObject.FindGameObjectsWithTag("heli"));


    }


    void NextActionTurn()
    {
        TBStates = TurnBasedStates.FireSpread;
        EndActionRound.SetActive(false);
        EndApplianceCallOut.SetActive(true);
        EndActionRound.SetActive(false);
        moneyplease = true;
    }




    void AreTheySellsstillalite()
    {
        isLowIntFire = false;
        isMiddleIntFire = false;
        isHighIntFire = false;

        for (int i = 0; i < mycelllist.Count; i++)
        {
            if (mycelllist[i].GetComponent<CellBehaviour>().IsonFire == true && mycelllist[i].GetComponent<CellBehaviour>().currentState == CellBehaviour.StatesOfCell.LowIntFire)
            {
                isLowIntFire = true;
            }

            if (mycelllist[i].GetComponent<CellBehaviour>().IsonFire == true && mycelllist[i].GetComponent<CellBehaviour>().currentState == CellBehaviour.StatesOfCell.MiddleIntFire)
            {
                isMiddleIntFire = true;
            }

            if (mycelllist[i].GetComponent<CellBehaviour>().IsonFire == true && mycelllist[i].GetComponent<CellBehaviour>().currentState == CellBehaviour.StatesOfCell.HighIntFire)
            {
                isHighIntFire = true;
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

        waterDisplay = GameObject.FindGameObjectWithTag("waterText").GetComponent<Text>();
        waterBar = GameObject.FindGameObjectWithTag("water").GetComponent<Slider>();

       

        EndMovementRound.SetActive(false);
        EndApplianceCallOut.SetActive(true);

        endApplianceCallOut.onClick.AddListener(NextEndBuildTurn);
        endMovementRound.onClick.AddListener(NextMovementTurn);
        endActionRound.onClick.AddListener(NextActionTurn);


        win.SetActive(false);
        lose.SetActive(false);

        

    }

    // Update is called once per frame
    void Update()
    {
        WhoTurnIsIT();

        waterBar.value = waterTotal;

        waterDisplay.text = "1000 / " + waterTotal;

        if (waterTotal < 0)
        {
            waterTotal = 0;
        }

        if(waterTotal > 1000)
        {
            waterTotal = 1000;
        }

        if (isLowIntFire == false && isMiddleIntFire == false && isHighIntFire == false && GameObject.Find("ICV(Clone)") != null)
        {
            TBStates = TurnBasedStates.PlayerWin;
        }


       
            
       
        

    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }



}
