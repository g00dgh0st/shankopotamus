using UnityEngine;
using System.Collections;

public class LayerSetter : MonoBehaviour {
  public enum SortLayer { Background, Main, Foreground };
  
  public SortLayer sortingLayer = SortLayer.Main;
  public int sortingOrder = 10;

  void Start() { 
    Reset();
  }
  
  private void Reset() {
    foreach( MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>() ) {
      renderer.sortingLayerName = sortingLayer.ToString();
      renderer.sortingOrder = sortingOrder;
      switch( sortingLayer ) {
        case SortLayer.Background:
          renderer.sortingLayerID = SortingLayer.NameToID("Background");
          break;
        case SortLayer.Main:
          renderer.sortingLayerID = SortingLayer.NameToID("Main");
          break;
        case SortLayer.Foreground:
          renderer.sortingLayerID = SortingLayer.NameToID("Foreground");
          break;
          default:
          break;
      }
    }
    
    foreach( SkinnedMeshRenderer renderer in GetComponentsInChildren<SkinnedMeshRenderer>() ) {
      renderer.sortingLayerName = sortingLayer.ToString();
      renderer.sortingOrder = sortingOrder;
      switch( sortingLayer ) {
        case SortLayer.Background:
          renderer.sortingLayerID = SortingLayer.NameToID("Background");
          break;
        case SortLayer.Main:
          renderer.sortingLayerID = SortingLayer.NameToID("Main");
          break;
        case SortLayer.Foreground:
          renderer.sortingLayerID = SortingLayer.NameToID("Foreground");
          break;
          default:
          break;
      }
    }
  }
  
  public void SetOrder( int o ) {
    sortingOrder = o;
    Reset();
  }
}
