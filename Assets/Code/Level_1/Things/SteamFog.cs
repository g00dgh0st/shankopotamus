using UnityEngine;
using System.Collections;

public class SteamFog : MonoBehaviour {
  
  public int noShower = 3;
  public int oneShower = 25;
  public int twoShower = 100;
  public int threeShower = 200;
  public int fourShower = 400;
  
  void OnEnable() {
    if( Game.cookies != null ) CheckShowers();
  }
  
  public void CheckShowers() {
    if( Game.cookies.Contains( "showersOn" ) ) {
      switch( (int)Game.cookies["showersOn"] ) {
        case 0:
          gameObject.GetComponent<ParticleSystem>().emissionRate = noShower;
          break;
        case 1:
          gameObject.GetComponent<ParticleSystem>().emissionRate = oneShower;
          break;
        case 2:
          gameObject.GetComponent<ParticleSystem>().emissionRate = twoShower;
          break;
        case 3:
          gameObject.GetComponent<ParticleSystem>().emissionRate = threeShower;
          break;
        case 4:
          gameObject.GetComponent<ParticleSystem>().emissionRate = fourShower;
          break;
        default:
          gameObject.GetComponent<ParticleSystem>().emissionRate = noShower;
          break;
      }
    } else {
      gameObject.GetComponent<ParticleSystem>().emissionRate = noShower;
    }
  }
}
