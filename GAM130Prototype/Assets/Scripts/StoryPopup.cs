using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 This is a very simple class for displaying notes or clues that the player picks up. 
 It could be made with a UI image of a fixed size containing a child textbox.

 Someone should also make a basic prefab with programmer graphics and all the 
 objects correctly set up.

 Update this class description when you've done all this.
     */

public class StoryPopup : MonoBehaviour {
    //This contains the data written by the writers
    public string[] m_pages;

    //The Unity text object to write to
    public Text m_text;
    //Buttons for scrolling between pages
    public Button m_nextButton;
    public Button m_prevButton;
    //Button for closing the popup at the last page
    public Button m_closeButton;
    //Keeps track of which page the player is on
    int m_curPage = 0;
        
    //Sets the object to active and starts on the first page
    public void open() {

    }

    //button functions//
    //Disables the object
    void close() {

    }
    //go to next page
    void nextPage() {

    }
    //go to previous page
    void prevPage() {

    }

    //optional extras//
    //handles text overflow by splitting too-long text up into separate pages
    //and adjusting the array accordingly.
    //Called on each page in the array at initialisation.
    void printPage() {

    }
}
