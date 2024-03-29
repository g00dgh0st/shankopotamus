﻿using UnityEngine;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour {
  
  public bool inDialogue = false;
  private Step step;
  private Dialogue dialogue;
  
  public GameObject bub;
  public GameObject opt;
  
  public void StartDialogue( Dialogue dlg, int idx ) {
    inDialogue = true;
    
    GameObject.Find( "DialogueContainer" ).transform.Find( "DialogueFade" ).gameObject.SetActive( true );
    
    Game.HideMenu();
    Game.PauseClicks();
    Game.PauseCam();
    
    dialogue = dlg;
    
    step = dialogue.steps[idx];
    
    if( step.action != null && !step.actionLast ) step.action();
    
    Camera.main.orthographicSize = 0.6f;
    Game.TargetCam( step.speaker );
    bub.SetActive( true );
    bub.GetComponent<DialogueBubble>().SetText( step.text );
    
    Game.player.FaceTarget( step.speaker.transform.position, 0.1f );
  }
  
  public void ChangeStep( int idx ) {
    ClearOptions();
    
    step = dialogue.steps[idx];
    if( step.action != null && !step.actionLast ) step.action();
    
    Game.TargetCam( step.speaker );
    bub.SetActive( true );
    bub.GetComponent<DialogueBubble>().SetText( step.text );
    
    Game.player.FaceTarget( step.speaker.transform.position, 0.1f );
  }
  
  public void ContinueDialogue() {
    Step startedStep = step;
    
    if( step.actionLast ) step.action();
    if( step == null ) return;
    if( step != startedStep ) return;
    // end dialogue if last step
    if( step.endStep ) {
      StopDialogue();
      return;
    }
    
    if( step.options != null ) {
      // check for options
      bub.SetActive( false );
      
      Game.TargetCam( Game.player.transform.Find( "CamTarget" ) );
      
      int optCount = -1;
      
      for( int i = step.options.Length - 1; i >= 0; i-- ) {
        if( step.options[i].condition != null && step.options[i].condition() == false ) continue;
        optCount++;
        GameObject newOpt = Instantiate( opt ) as GameObject;
        newOpt.SetActive( true );
        newOpt.transform.parent = opt.transform.parent;
        newOpt.transform.localScale = new Vector3( 1f, 1f, 1f );
        newOpt.transform.position = opt.transform.position;
        newOpt.GetComponent<OptionButton>().Setup( step.options[i].text, i, optCount );
      }
    } else {
      // if no options, go to the next step in the array
      int stepIdx = Array.IndexOf( dialogue.steps, step ); 
      if( dialogue.steps.Length > stepIdx + 1 )
        ChangeStep( stepIdx + 1 );
      else
        StopDialogue();
    }
  }
  
  public void StopDialogue() {
    inDialogue = false;
    
    GameObject.Find( "DialogueContainer" ).transform.Find( "DialogueFade" ).gameObject.SetActive( false );
    
    Game.ShowMenu();
    Game.ResumeClicks();
    Game.ResumeCam();
    
    dialogue = null;
    step = null;
    
    Camera.main.orthographicSize = 1f;
    Game.TargetCam( Game.player.transform.Find( "CamTarget" ) );
    bub.SetActive( false );
    ClearOptions();
  }

  public void ChooseOption( int optionIndex ) {
    step.options[optionIndex].action();
    Game.cursor.GetComponent<CustomCursor>().SetCursor( "PointerCursor" );
  }
  
  private void ClearOptions() {
    foreach( GameObject obj in GameObject.FindGameObjectsWithTag( "OptionButton" ) ) {
      Destroy( obj );
    }
  }
  
  public void ShowDialogueBubble( string text ) {
    Game.HideMenu();
    bub.SetActive( true );
    bub.GetComponent<DialogueBubble>().SetText( text );
  }
  
  public void HideDialogueBubble() {
    Game.ShowMenu();
    bub.SetActive( false );
  }

}

