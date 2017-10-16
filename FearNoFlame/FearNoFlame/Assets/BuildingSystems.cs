using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystems : MonoBehaviour {

	public Button Dozerspawnbutton;
	public Button ICVspawnbutton;
	public Button LTspawnbutton;
	public Button FourFourspawnbutton;
	public Button ThreeFourspawnbutton;
	public Button Twofourspawnbutton;
	public Button waterbomerspawnbutton;
	public Button helitackspawnbutton;


	// Use this for initialization
	void Start () 
	{
		Button DozerspawnBTN = Dozerspawnbutton.GetComponent<Button>();
		DozerspawnBTN.onClick.AddListener();

		Button ICVspawnBTN = ICVspawnbutton.GetComponent<Button>();
		ICVspawnBTN.onClick.AddListener();

		Button LTspawnBTN = LTspawnbutton.GetComponent<Button>();
		LTspawnBTN.onClick.AddListener();

		Button FourFourspawnBTN = FourFourspawnbutton.GetComponent<Button>();
		FourFourspawnBTN.onClick.AddListener();

		Button ThreeFourspawnBTN = ThreeFourspawnbutton.GetComponent<Button>();
		ThreeFourspawnBTN.onClick.AddListener();

		Button TwofourspawnBTN = Twofourspawnbutton.GetComponent<Button>();
		TwofourspawnBTN.onClick.AddListener();

		Button waterbomerspawnBTN= waterbomerspawnbutton.GetComponent<Button>();
		waterbomerspawnBTN.onClick.AddListener();

		Button helitackspawnBTN = helitackspawnbutton.GetComponent<Button>();
		helitackspawnBTN.onClick.AddListener();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Dozerspawn()
	{
		
	}
}
