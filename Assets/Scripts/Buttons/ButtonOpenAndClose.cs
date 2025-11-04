using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class HoverController : MonoBehaviour, IPointerClickHandler
{
    
    [SerializeField] private GameObject menuToClose;
    [SerializeField] private GameObject menuToOpen;

    public void OnPointerClick(PointerEventData eventData)
    {
        menuToClose.SetActive(false);
        menuToOpen.SetActive(true);
    }
}