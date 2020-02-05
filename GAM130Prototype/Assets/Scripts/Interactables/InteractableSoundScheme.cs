using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Interactable Sound Scheme", menuName = "Interactable Sound Scheme")]
public class InteractableSoundScheme : ScriptableObject
{
    public AudioClip m_highlightSound;
    public AudioClip m_unHighlightSound;
    public AudioClip m_interactSound;
}
