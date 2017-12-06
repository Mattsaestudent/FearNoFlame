using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {
    public enum StatesOfCell
    {
       LowIntFire,MiddleIntFire,HighIntFire, BurntGround,StillGreen,
    }


    public bool IsonFire;
   // public Material LowFire;
   // public Material MiddleFire;
  //  public Material HighFire;
    public Material BurnGround;
    public Material TreeGreen;
    public Material bushMat;
    public Material grassMatt;
    public Material dirtMat;


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

    public int CellsOnFire;

    public bool fireisvisablelow;

    public bool fireisvisablemed;

    public bool fireisvisablehigh;
    public GameObject Lookforthefire;

    public GameObject BuildICV;

    public GameObject WheretobuildICV;
    public GameObject WheretobuildICVOne;
    public GameObject WheretobuildICVTwo;
    public GameObject WheretobuildICVThree;

    public GameObject mainTutScript;
    public GameObject fire;

    public bool ltputthefireout;
    public bool twofourputthefireout;
    public bool threefourputthefireout;
    public bool fourfourputthefireout;
    public bool planeputthefireout;
    public bool helitackputtheplaneout;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        FireDangerIndex = Random.Range(13, 100);

        enviromentalMakeUp = Random.Range(1, 100);

        GM = GetComponent<GameManager>();

        IsonFire = false;

        fireisvisablelow = false;
        fireisvisablemed = false;
        fireisvisablehigh = false;

        Lookforthefire = GameObject.Find("Look for the fire");
        BuildICV = GameObject.Find("BuildICV");

        WheretobuildICV = GameObject.Find("WheretobuildICV");
        WheretobuildICVOne = GameObject.Find("WheretobuildICV (1)");
        WheretobuildICVTwo = GameObject.Find("WheretobuildICV (2)");
        WheretobuildICVThree = GameObject.Find("WheretobuildICV (3)");

        mainTutScript = GameObject.Find("Canvas");

        fire = GameObject.Find("Fireformyproject_0");
        fire.SetActive(false);

        
    }

    void Start()
    {
        ltputthefireout = false;
        ltputthefireout = false;
        twofourputthefireout = false;
        threefourputthefireout = false;
        fourfourputthefireout = false;
        planeputthefireout = false;
        helitackputtheplaneout = false;
}



    //this method implements cell's behaviour



    public void CellsUpdate()
    {
        nextState = currentState;
        int CellsOnFire = GetCellOnFire();

       
            if (this.IsonFire == true && FireDangerIndex >= 12 && FireDangerIndex <= 24)
            {
                if (neighbours[0].IsonFire == false)
                {
                    neighbours[0].IsonFire = true;
                }
            if (neighbours[3].IsonFire == false)
            {
                neighbours[3].IsonFire = true;
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
            fire.SetActive(true);
        } else if (currentState == StatesOfCell.MiddleIntFire)
        {
            fire.SetActive(true);
        } else if (currentState == StatesOfCell.HighIntFire)
        {
            fire.SetActive(true);
        } else if (currentState == StatesOfCell.BurntGround)
        {
            meshRenderer.sharedMaterial = BurnGround;
            fire.SetActive(false);
        } else
        {
            if (currentState == StatesOfCell.StillGreen)
            {
                if (enviromentalMakeUp >=1 && enviromentalMakeUp <= 25)
                {
                    meshRenderer.sharedMaterial = TreeGreen;
                }

                if (enviromentalMakeUp >= 26 && enviromentalMakeUp <= 60)
                {
                    meshRenderer.sharedMaterial = grassMatt;
                }

                if (enviromentalMakeUp >= 61)
                {
                    meshRenderer.sharedMaterial = bushMat;
                }

                if(enviromentalMakeUp == 0)
                {
                    meshRenderer.sharedMaterial = dirtMat;
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

    void Update()
    {
        if(currentState == StatesOfCell.BurntGround)
        {
            IsonFire = false;
        }

        GetCellOnFire();
        DistancetoCamera();
    }

   public void DistancetoCamera()
    {
        if (currentState == StatesOfCell.LowIntFire)
        {
            var disone = Vector3.Distance(Camera.main.transform.position, this.transform.position);
            if (this.GetComponent<Renderer>().isVisible)
            {
                fireisvisablelow = true;
                

                if (fireisvisablelow == true)
                {
                    if (disone <= 28)
                    {
                        Lookforthefire.SetActive(false);
                        BuildICV.SetActive(true);

                        if (mainTutScript.GetComponent<PlayTheTutorial>().actionbuttonis == true)
                        {
                            BuildICV.SetActive(false);
                        }

                    }
                  
                }
                 
               
        
            }
            else
            {
                fireisvisablelow = false;
            }

           

        }
        
        if (currentState == StatesOfCell.MiddleIntFire)
        {
            var distwo = Vector3.Distance(Camera.main.transform.position, this.transform.position);
            if (this.GetComponent<Renderer>().isVisible)
            {
                fireisvisablemed = true;
                

                if (fireisvisablemed == true)
                {
                    if (distwo <= 28)
                    {
                        Lookforthefire.SetActive(false);
                        BuildICV.SetActive(true);

                        if (mainTutScript.GetComponent<PlayTheTutorial>().actionbuttonis == true)
                        {
                            BuildICV.SetActive(false);
                        }



                    }
                }
            }
            else
            {
                fireisvisablemed = false;
            }
           
        }
        if (currentState == StatesOfCell.HighIntFire)
        {
            var disthree = Vector3.Distance(Camera.main.transform.position, this.transform.position);
            if (this.GetComponent<Renderer>().isVisible)
            {
                fireisvisablehigh = true;
                 
 
                if (fireisvisablehigh == true)
                {
                    if (disthree <= 28)
                    {
                        Lookforthefire.SetActive(false);
                        BuildICV.SetActive(true);

                        if (mainTutScript.GetComponent<PlayTheTutorial>().actionbuttonis == true)
                        {
                            BuildICV.SetActive(false);
                        }




                    }
                }
            }
            else
            {
                fireisvisablehigh = false;
            }

          


        }



    }

}
