using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {

    public enum StatesOfCell
    {
       LowIntFire,MiddleIntFire,HighIntFire, BurntGround,StillGreen,
    }

    public Material LowFire;
    public Material MiddleFire;
    public Material HighFire;
    public Material BurnGround;
    public Material GreenStillGreen;

    public GameManager GM;

    public int x, y;

    public CellBehaviour[] neighbours;

    public StatesOfCell currentState;

    public StatesOfCell nextState;

    private MeshRenderer meshRenderer;

    public int FireDangerIndex;

    public int FuelLoadsTones;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        FireDangerIndex = Random.Range(0, 100);

        FuelLoadsTones = Random.Range(0, 30);
    }

    

    //this method implements cell's behaviour

    void CellsUpdate()
    {
        nextState = currentState;
        int OnFireCells = GetCellOnFire();
        if(FireDangerIndex < 11)
        {
            nextState = StatesOfCell.StillGreen;
        }else if(FireDangerIndex >12 && FireDangerIndex < 24 )
        {
            nextState = StatesOfCell.LowIntFire;
            if (OnFireCells != 3) // if cell 3 alive neighbours
                nextState = StatesOfCell.BurntGround;
        }
        else if(FireDangerIndex > 25 && FireDangerIndex < 49 )
        {
            nextState = StatesOfCell.MiddleIntFire;
            if (OnFireCells != 3) // if cell 3 alive neighbours
                nextState = StatesOfCell.BurntGround;
        }
        else if(FireDangerIndex > 50 && FireDangerIndex <74)
        {
            nextState = StatesOfCell.MiddleIntFire;
            if (OnFireCells != 3) // if cell 3 alive neighbours
                nextState = StatesOfCell.BurntGround;
        }
        else if(FireDangerIndex >75 && FireDangerIndex < 99)
        {
            nextState = StatesOfCell.HighIntFire;
            if (OnFireCells != 3) // if cell 3 alive neighbours
                nextState = StatesOfCell.BurntGround;
        }
        else if(FireDangerIndex >99)
        {
            nextState = StatesOfCell.HighIntFire;
            if (OnFireCells != 3) // if cell 3 alive neighbours
                nextState = StatesOfCell.BurntGround;
        }
        else
        {
            nextState = StatesOfCell.StillGreen;
            if (OnFireCells != 3) // if cell 3 alive neighbours
                nextState = StatesOfCell.BurntGround;
        }
    }

    //apply new cell state and update the material

        public void CellApplyTheUpdate()
    {
        currentState = nextState;
        UpdateMaterialOnCell();
    }

    // Store x-axis and y-axis
    public void Init(GameManager gm,int x, int y)
    {
        GM = gm;
        transform.parent = gm.transform;

        this.x = x;
        this.y = y;
    }

    private void UpdateMaterialOnCell()
    {
        if(currentState == StatesOfCell.LowIntFire )
        {
            meshRenderer.sharedMaterial = LowFire;
        }else if(currentState == StatesOfCell.MiddleIntFire)
        {
            meshRenderer.sharedMaterial = MiddleFire;
        }else if(currentState == StatesOfCell.HighIntFire)
        {
            meshRenderer.sharedMaterial = HighFire; 
        }else if(currentState == StatesOfCell.BurntGround)
        {
            meshRenderer.sharedMaterial = BurnGround;
        }else if(currentState == StatesOfCell.StillGreen)
        {
            meshRenderer.sharedMaterial = GreenStillGreen;
        }
    }

    private int GetCellOnFire()
    {
        int ret = 0;

        for(int i = 0; i < neighbours.Length; i++)
        {
            if(neighbours[i] != null && neighbours[i].currentState == StatesOfCell.LowIntFire)
            {
                ret++;
            }else if(neighbours[i] != null && neighbours[i].currentState == StatesOfCell.MiddleIntFire)
            {
                ret++;
            }
            else if(neighbours[i] != null && neighbours[i].currentState == StatesOfCell.HighIntFire)
            {
                ret++;
            }
        }
        return ret;
    }



}
