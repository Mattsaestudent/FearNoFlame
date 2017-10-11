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
    public Material TreeGreen;
    public Material bushMat;
    public Material grassMatt;


    [HideInInspector] public GameManager GM;

    [HideInInspector] public int x, y;
    
     public CellBehaviour[] neighbours;

    [HideInInspector] public StatesOfCell currentState;

    public StatesOfCell nextState;

    private MeshRenderer meshRenderer;

    public int FireDangerIndex;

    public int FuelLoadsTones;

    public int enviromentalMakeUp;

    public int BurnOut;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        FireDangerIndex = Random.Range(13, 100);

        enviromentalMakeUp = Random.Range(1, 100);

        GM = GetComponent<GameManager>();

        IsonFire = false;

       
    }

    

    //this method implements cell's behaviour

   

    public void CellsUpdate()
    {
        nextState = currentState;
        int OnFireCells = GetCellOnFire();

       
            if (this.IsonFire == true && FireDangerIndex >= 12 && FireDangerIndex <= 24)
            {
                if (neighbours[0].IsonFire == false)
                {
                    neighbours[0].IsonFire = true;
                }


            }
            else if (this.IsonFire == true && FireDangerIndex >= 25 && FireDangerIndex <= 49)
            {
                if (neighbours[2].IsonFire == false)
                {
                    neighbours[2].IsonFire = true;
                }
                if (neighbours[1].IsonFire == false)
                {
                    neighbours[1].IsonFire = true;
                }

            }
            else if (this.IsonFire == true && FireDangerIndex >= 50 && FireDangerIndex <= 74)
            {
                if (neighbours[3].IsonFire == false)
                {
                    neighbours[3].IsonFire = true;
                }
                if (neighbours[2].IsonFire == false)
                {
                    neighbours[2].IsonFire = true;
                }



            }
            else if (this.IsonFire == true && FireDangerIndex >= 75 && FireDangerIndex <= 99)
            {
                if (neighbours[1].IsonFire == false)
                {
                    neighbours[1].IsonFire = true;
                }
                if (neighbours[3].IsonFire == false)
                {
                    neighbours[3].IsonFire = true;
                }

            }
            else if (this.IsonFire == true && FireDangerIndex > 99)
            {
                if (neighbours[2].IsonFire == false)
                {
                    neighbours[2].IsonFire = true;
                }
                if (neighbours[3].IsonFire == false)
                {
                    neighbours[3].IsonFire = true;
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
            else if(FireDangerIndex >1)
            {
                nextState = StatesOfCell.StillGreen;

            }
        

        if (currentState == StatesOfCell.LowIntFire && IsonFire == true)
        {

            nextState = StatesOfCell.BurntGround;
            FireDangerIndex = 0;

        }

        if (currentState == StatesOfCell.MiddleIntFire && IsonFire == true)
        {

            nextState = StatesOfCell.BurntGround;
            FireDangerIndex = 0;

        }

        if (currentState == StatesOfCell.HighIntFire )
        {

            nextState = StatesOfCell.BurntGround;
            FireDangerIndex = 0;

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
        if (currentState == StatesOfCell.LowIntFire)
        {
            meshRenderer.sharedMaterial = LowFire;
        } else if (currentState == StatesOfCell.MiddleIntFire)
        {
            meshRenderer.sharedMaterial = MiddleFire;
        } else if (currentState == StatesOfCell.HighIntFire)
        {
            meshRenderer.sharedMaterial = HighFire;
        } else if (currentState == StatesOfCell.BurntGround)
        {
            meshRenderer.sharedMaterial = BurnGround;
        } else
        {
            if (currentState == StatesOfCell.StillGreen)
            {
                if (enviromentalMakeUp <= 25)
                {
                    meshRenderer.sharedMaterial = TreeGreen;
                }

                if (enviromentalMakeUp >= 26 && enviromentalMakeUp <= 60)
                {
                    meshRenderer.sharedMaterial = bushMat;
                }

                if (enviromentalMakeUp >= 61)
                {
                    meshRenderer.sharedMaterial = bushMat;
                }
            }
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

    public IEnumerator BurnOuts()
    {
        yield return new WaitForSeconds(5);
        currentState = StatesOfCell.BurntGround;

    }

}
