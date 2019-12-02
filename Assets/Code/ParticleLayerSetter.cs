using UnityEngine;
using System.Collections;

public class ParticleLayerSetter : MonoBehaviour {
  public enum SortLayer { Background, Main, Foreground };
  
  public SortLayer sortingLayer = SortLayer.Main;
  

  public int layer = 10;

  void Start () {
    // Set the sorting layer of the particle system.
    switch( sortingLayer ) {
      case SortLayer.Background:
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Background");
        break;
      case SortLayer.Main:
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Main");
        break;
      case SortLayer.Foreground:
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Foreground");
        break;
      default:
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Background");
        break;
    }
    GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = layer;
  }
}
