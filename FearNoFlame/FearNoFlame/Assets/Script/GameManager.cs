using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameManagerStates {
        Idle,Running
    }
    public int CellNumber;
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
    public List<CellBehaviour> movementlist;

  

    public int startFire;

    void Awake()
    {
        mycelllist = new List<CellBehaviour>();
        Init(50,50 );
       

        Debug.Log(startFire);

        //Run();

        SetOnFire();

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
                cells[i, j].neighbours = GetMovement(i, j);

            }
        }

    }


    // create array with adjacent cells to cell with coordinates (x,y)
    public CellBehaviour[] GetNeighbours(int x, int y)
    {
        CellBehaviour[] result = new CellBehaviour[4];
        result[0] = cells[x, (y + 1) % sizeY]; //top
        result[1] = cells[(x + 1) % sizeX, y % sizeY]; //right
        result[2] = cells[x % sizeX, (sizeY + y - 1) % sizeY];//bottom
        result[3] = cells[(sizeX + x - 1) % sizeX, y % sizeY]; //left

        return result;


    }

    public CellBehaviour[] GetMovement(int x,int y)
    {
        CellBehaviour[] result = new CellBehaviour[76];
        result[0] = cells[x, (y + 1) % sizeY]; //top
        result[1] = cells[(x + 1) % sizeX, y % sizeY]; //right
        result[2] = cells[x % sizeX, (sizeY + y - 1) % sizeY];//bottom
        result[3] = cells[(sizeX + x - 1) % sizeX, y % sizeY]; //left
        result[4] = cells[x, (y + 1) % sizeY]; // top
        result[5] = cells[(x + 1) % sizeX, (y + 1) % sizeY]; // top right
        result[6] = cells[(x + 1) % sizeX, y % sizeY]; // right
        result[7] = cells[(x + 1) % sizeX, (sizeY + y - 1) % sizeY]; // bottom right
        result[8] = cells[x % sizeX, (sizeY + y - 1) % sizeY]; // bottom
        result[9] = cells[(sizeX + x - 1) % sizeX, (sizeY + y - 1) % sizeY]; // bottom left
        result[10] = cells[(sizeX + x - 1) % sizeX, y % sizeY]; // left
        result[11] = cells[(sizeX + x - 1) % sizeX, (y + 1) % sizeY]; // top left
        result[12] = cells[x, (y + 2) % sizeY]; // top
        result[13] = cells[(x + 2) % sizeX, (y + 2) % sizeY]; // top right
        result[14] = cells[(x + 2) % sizeX, y % sizeY]; // right
        result[15] = cells[(x + 2) % sizeX, (sizeY + y - 2) % sizeY]; // bottom right
        result[16] = cells[x % sizeX, (sizeY + y - 2) % sizeY]; // bottom
        result[17] = cells[(sizeX + x - 2) % sizeX, (sizeY + y - 2) % sizeY]; // bottom left
        result[18] = cells[(sizeX + x - 2) % sizeX, y % sizeY]; // left
        result[19] = cells[(sizeX + x - 2) % sizeX, (y + 2) % sizeY]; // top left
        result[20] = cells[x, (y + 3) % sizeY]; // top
        result[21] = cells[(x + 3) % sizeX, (y + 3) % sizeY]; // top right
        result[22] = cells[(x + 3) % sizeX, y % sizeY]; // right
        result[23] = cells[(x + 3) % sizeX, (sizeY + y - 3) % sizeY]; // bottom right
        result[24] = cells[x % sizeX, (sizeY + y - 3) % sizeY]; // bottom
        result[25] = cells[(sizeX + x - 3) % sizeX, (sizeY + y - 3) % sizeY]; // bottom left
        result[26] = cells[(sizeX + x - 4) % sizeX, y % sizeY]; // left
        result[27] = cells[(sizeX + x - 4) % sizeX, (y + 4) % sizeY]; // top left
        result[28] = cells[x, (y + 5) % sizeY]; // top
        result[29] = cells[(x + 5) % sizeX, (y + 5) % sizeY]; // top right
        result[30] = cells[(x + 5) % sizeX, y % sizeY]; // right
        result[31] = cells[(x + 5) % sizeX, (sizeY + y - 5) % sizeY]; // bottom right
        result[32] = cells[x % sizeX, (sizeY + y - 5) % sizeY]; // bottom
        result[33] = cells[(sizeX + x - 5) % sizeX, (sizeY + y - 5) % sizeY]; // bottom left
        result[34] = cells[(sizeX + x - 5) % sizeX, y % sizeY]; // left
        result[35] = cells[(sizeX + x - 5) % sizeX, (y + 5) % sizeY]; // top left
        result[36] = cells[x, (y + 6) % sizeY]; // top
        result[37] = cells[(x + 6) % sizeX, (y + 6) % sizeY]; // top right
        result[38] = cells[(x + 6) % sizeX, y % sizeY]; // right
        result[39] = cells[(x + 6) % sizeX, (sizeY + y - 6) % sizeY]; // bottom right
        result[40] = cells[x % sizeX, (sizeY + y - 6) % sizeY]; // bottom
        result[41] = cells[(sizeX + x - 6) % sizeX, (sizeY + y - 1) % sizeY]; // bottom left
        result[42] = cells[(sizeX + x - 6) % sizeX, y % sizeY]; // left
        result[43] = cells[(sizeX + x - 6) % sizeX, (y + 6) % sizeY]; // top left
        result[44] = cells[x, (y + 7) % sizeY]; // top
        result[45] = cells[(x + 7) % sizeX, (y + 7) % sizeY]; // top right
        result[46] = cells[(x + 7) % sizeX, y % sizeY]; // right
        result[47] = cells[(x + 7) % sizeX, (sizeY + y - 7) % sizeY]; // bottom right
        result[48] = cells[x % sizeX, (sizeY + y - 7) % sizeY]; // bottom
        result[49] = cells[(sizeX + x - 7) % sizeX, (sizeY + y - 7) % sizeY]; // bottom left
        result[50] = cells[(sizeX + x - 7) % sizeX, y % sizeY]; // left
        result[51] = cells[(sizeX + x - 7) % sizeX, (y + 7) % sizeY]; // top left
        result[52] = cells[x, (y + 8) % sizeY]; // top
        result[53] = cells[(x + 8) % sizeX, (y + 8) % sizeY]; // top right
        result[54] = cells[(x + 8) % sizeX, y % sizeY]; // right
        result[55] = cells[(x + 8) % sizeX, (sizeY + y - 8) % sizeY]; // bottom right
        result[56] = cells[x % sizeX, (sizeY + y - 8) % sizeY]; // bottom
        result[57] = cells[(sizeX + x - 8) % sizeX, (sizeY + y - 8) % sizeY]; // bottom left
        result[58] = cells[(sizeX + x - 8) % sizeX, y % sizeY]; // left
        result[59] = cells[(sizeX + x - 8) % sizeX, (y + 8) % sizeY]; // top left
        result[60] = cells[x, (y + 9) % sizeY]; // top
        result[61] = cells[(x + 9) % sizeX, (y + 9) % sizeY]; // top right
        result[62] = cells[(x + 9) % sizeX, y % sizeY]; // right
        result[63] = cells[(x + 9) % sizeX, (sizeY + y - 9) % sizeY]; // bottom right
        result[64] = cells[x % sizeX, (sizeY + y - 9) % sizeY]; // bottom
        result[65] = cells[(sizeX + x - 9) % sizeX, (sizeY + y - 9) % sizeY]; // bottom left
        result[66] = cells[(sizeX + x - 9) % sizeX, y % sizeY]; // left
        result[67] = cells[(sizeX + x - 9) % sizeX, (y + 9) % sizeY]; // top left
        result[68] = cells[x, (y + 10) % sizeY]; // top
        result[69] = cells[(x + 10) % sizeX, (y + 10) % sizeY]; // top right
        result[70] = cells[(x + 10) % sizeX, y % sizeY]; // right
        result[71] = cells[(x + 10) % sizeX, (sizeY + y - 10) % sizeY]; // bottom right
        result[72] = cells[x % sizeX, (sizeY + y - 10) % sizeY]; // bottom
        result[73] = cells[(sizeX + x - 10) % sizeX, (sizeY + y - 10) % sizeY]; // bottom left
        result[74] = cells[(sizeX + x - 10) % sizeX, y % sizeY]; // left
        result[75] = cells[(sizeX + x - 10) % sizeX, (y + 10) % sizeY]; // top left

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

    void CallNextUpdate()
    {
        UpdateCells();
    }

  
        // Use this for initialization
        void Start ()
    {
        CallNextUpdate();

    }
	
	// Update is called once per frame
	void Update ()
    {

       CallNextUpdate();
    }
}
