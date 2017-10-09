using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {

    public enum StatesOfCell
    {
       LowIntFire,MiddleIntFire,HighIntFire, BurntGround,StillGreen,
    }


    public bool IsonFire;
    public Material LowFire;
    public Material MiddleFire;
    public Material HighFire;
    public Material BurnGround;
    public Material GreenStillGreen;

    [HideInInspector] public GameManager GM;

    [HideInInspector] public int x, y;

    public CellBehaviour[] neighbours;

    [HideInInspector] public StatesOfCell currentState;

    public StatesOfCell nextState;

    private MeshRenderer meshRenderer;

    public int FireDangerIndex;

    public int FuelLoadsTones;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        FireDangerIndex = Random.Range(12, 100);

        GM = GetComponent<GameManager>();

        IsonFire = false;

        
    }

    

    //this method implements cell's behaviour

   

    public void CellsUpdate()
    {
        nextState = currentState;
        int OnFireCells = GetCellOnFire();

        if (this.IsonFire == true)
        {
            if (neighbours[0].IsonFire == false)
            {
                neighbours[0].IsonFire = true;
            }
            else
            {
                nextState = StatesOfCell.BurntGround;
            }

            if (neighbours[1].IsonFire == false)
            {
                neighbours[1].IsonFire = true;
            }
            else
            {
                nextState = StatesOfCell.BurntGround;
            }
        }
        
       
            if (FireDangerIndex > 12 && FireDangerIndex < 24 && IsonFire == true)
            {
                nextState = StatesOfCell.LowIntFire;

            }
            else if (FireDangerIndex > 25 && FireDangerIndex < 49 && IsonFire == true)
            {
                nextState = StatesOfCell.MiddleIntFire;

            }
            else if (FireDangerIndex > 50 && FireDangerIndex < 74 && IsonFire == true)
            {
                nextState = StatesOfCell.MiddleIntFire;

            }
            else if (FireDangerIndex > 75 && FireDangerIndex < 99 && IsonFire == true)
            {
                nextState = StatesOfCell.HighIntFire;

            }
            else if (FireDangerIndex > 99 && IsonFire == true)
            {
                nextState = StatesOfCell.HighIntFire;

            }
            else
            {
                nextState = StatesOfCell.StillGreen;

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
            if(neighbours[i] != null && neighbours[i].IsonFire == true)
            {
                ret+=1;
            }else if(neighbours[i] != null && neighbours[i].IsonFire == true)
            {
                ret += 1;
            }
            else if(neighbours[i] != null && neighbours[i].IsonFire == true)
            {
                ret += 1;
            }
        }
        return ret;
    }



}
