using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
  
  public void OnClick() {
    GameObject obj = GameObject.Instantiate( Resources.Load( "GUI/ExitConfirm" ) ) as GameObject;
    obj.transform.parent = GameObject.Find( "UI Root" ).transform;
    obj.transform.localScale = new Vector3( 1f, 1f, 1f );
    obj.transform.localPosition = new Vector3( 1f, 1f, 1f );
    obj.name = "ExitConfirm";
  }
}
