using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public Image crosshairImage;
    public Sprite nullCrosshairSprite;
    public float crosshairUpdateshrpness = 5f;

    bool m_WasPointingAtEnemy;
    RectTransform m_CrosshairRectTransform;
    CrosshairData m_CrosshairDataDefault;
    CrosshairData m_CrosshairDataTarget;
    CrosshairData m_CurrentCrosshair;


    void UpdateCrosshairPointingAtEnemy(bool force)
    {
        if (m_CrosshairDataDefault.crosshairSprite == null)
            return;

        crosshairImage.color = Color.Lerp(crosshairImage.color, m_CurrentCrosshair.crosshairColor, Time.deltaTime * crosshairUpdateshrpness);

        m_CrosshairRectTransform.sizeDelta = Mathf.Lerp(m_CrosshairRectTransform.sizeDelta.x,
             m_CurrentCrosshair.crosshairSize, Time.deltaTime * crosshairUpdateshrpness) * Vector2.one;
    }

    void OnWeaponChanged(WeaponController newWeapon)
    {
        if(newWeapon)
        {
            crosshairImage.enabled = true;
            m_CrosshairDataDefault = newWeapon.crosshairDataDefault;
            m_CrosshairDataTarget = newWeapon.crosshairDataTargetInSight;
            m_CrosshairRectTransform = crosshairImage.GetComponent<RectTransform>();
            DebugUtility.HandleErrorIfNullGetComponent<RectTransform, CrosshairManager>(m_CrosshairRectTransform, this, crosshairImage.gameObject);
        }
        else
        {
            if (nullCrosshairSprite)
            {
                crosshairImage.sprite = nullCrosshairSprite;
            }
            else
            {
                crosshairImage.enabled = false;
            }
        }

        UpdateCrosshairPointingAtEnemy(true);
    }
}
