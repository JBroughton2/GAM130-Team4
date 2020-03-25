using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FillBarColorChange))]
public class AmmoCounter : MonoBehaviour
{
    [Tooltip("CanvasGroup to fade the ammo UI")]
    public CanvasGroup canvasGroup;
    [Tooltip("Image for the weapon icon")]
    public Image weaponImage;
    [Tooltip("Image component for the background")]
    public Image ammoBackgroundImage;
    [Tooltip("Image component to display fill ratio")]
    public Image ammoFillImage;
    [Tooltip("Text for image index")]
    public TMPro.TextMeshProUGUI weaponIndexText;

    [Header("Selection")]
    [Range(0, 1)]
    [Tooltip("Opacity when weapon not selected")]
    public float unselectedOpacity = 0.5f;
    [Tooltip("Scale when weapon not selected")]
    public Vector3 unselectedScale = Vector3.one * 0.8f;
    [Tooltip("Root for the control keys")]
    public GameObject controlKeysRoot;

    [Header("Feedback")]
    [Tooltip("Component to animate the color when empty or full")]
    public FillBarColorChange FillBarColorChange;
    [Tooltip("Sharpness for the fill ratio movements")]
    public float ammoFillMovementSharpness = 20f;

    public int weaponCounterIndex { get; set; }


}
