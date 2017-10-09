using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameManagerStates {
        Idle,Running
    }

    public CellBehaviour cellPrefab; //Cell prefab

    public float updateInterval = 1000f; //delay between cell update

    [HideInInspector] public CellBehaviour[,] cells; // matrix of cells

    [HideInInspector] public GameManagerStates GMstate = GameManagerStates.Idle;

    [HideInInspector] public int sizeX; // game size in x-axis
    [HideInInspector] public int sizeY; // game size in y-axis

    public Action cellUpdates; //action which calls cells' update methods
    public Action cellApplyUpdates;//action which calls cells' apply update methods

    public IEnumerator coroutine;// reference to main coroutine

    [HideInInspector] public List<CellBehaviour> mycelllist;

    public int startFire;

    void Awake()
    {
        mycelllist = new List<CellBehaviour>();
        Init(25, 20);
        startFire = UnityEngine.Random.Range(0, 500);
      
        var firstItem = mycelllist.ElementAt(startFire);
    
        firstItem.IsonFire = true;
        
        Run();

        
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
        CellBehaviour[] result = new CellBehaviour[8];
        result[0] = cells[x, (y + 1) % sizeY]; //top
        result[1] = cells[(x + 1) % sizeX, y % sizeY]; //right
        result[2] = cells[x % sizeX, (sizeY + y - 1) % sizeY];//bottom
        result[3] = cells[(sizeX + x - 1) % sizeX, y % sizeY]; //left
        return result;


    }

    // this method stops current coroutine and starts new its instance
    public void Run()
    {
        GMstate = GameManagerStates.Running;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = RunCoroutine();
        StartCoroutine(coroutine);
    }
    private IEnumerator RunCoroutine()
    {
        while (GMstate == GameManagerStates.Running)
        {
            UpdateCells();
            yield return new WaitForSeconds(updateInterval);
        }
    }

  
        // Use this for initialization
        void Start ()
    {
        

    }
	
	// Update is called once per frame
	void Update ()
    {
       

    }
}
