using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSoundFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool hover = false;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        SoundManager.PlaySound(SoundManager.Sound.ButtonPress);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        SoundManager.PlaySound(SoundManager.Sound.ButtonHover);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }
}
