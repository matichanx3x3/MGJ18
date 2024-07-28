using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniGame"))
        {
            switch (other.transform.name)
            {
                case "MiniPlanta":
                    MiniGameBubbleCanvas.Instance.minigamesBbls[0].SetActive(true);
                    MiniGameBubbleCanvas.Instance.actualMinigame = MiniGameBubbleCanvas.Instance.minigamesBbls[0];
                    transform.parent.GetComponent<CC_Player>().canInteract = true;
                    SoundManager.Instance.PlaySFX("EnterPlanta");
                    break;
                case "MiniPlatos":
                    MiniGameBubbleCanvas.Instance.minigamesBbls[1].SetActive(true);
                    MiniGameBubbleCanvas.Instance.actualMinigame = MiniGameBubbleCanvas.Instance.minigamesBbls[1];
                    transform.parent.GetComponent<CC_Player>().canInteract = true;
                    SoundManager.Instance.PlaySFX("EnterPlato");
                    break;
                case "MiniVentana":
                    MiniGameBubbleCanvas.Instance.minigamesBbls[2].SetActive(true);
                    MiniGameBubbleCanvas.Instance.actualMinigame = MiniGameBubbleCanvas.Instance.minigamesBbls[2];
                    transform.parent.GetComponent<CC_Player>().canInteract = true;
                    SoundManager.Instance.PlaySFX("EnterVentana");
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MiniGame"))
        {
            switch (MiniGameBubbleCanvas.Instance.actualMinigame.transform.name)
            {
                case "BCPlanta":
                    MiniGameBubbleCanvas.Instance.minigamesBbls[0].SetActive(false);
                    MiniGameBubbleCanvas.Instance.actualMinigame = null;
                    transform.parent.GetComponent<CC_Player>().canInteract = false;
                    SoundManager.Instance.Stop("EnterPlanta");
                    break;
                case "BCPlatos":
                    MiniGameBubbleCanvas.Instance.minigamesBbls[1].SetActive(false);
                    MiniGameBubbleCanvas.Instance.actualMinigame = null;
                    transform.parent.GetComponent<CC_Player>().canInteract = false;
                    SoundManager.Instance.Stop("EnterPlato");
                    break;
                case "BPVentana":
                    MiniGameBubbleCanvas.Instance.minigamesBbls[2].SetActive(false);
                    MiniGameBubbleCanvas.Instance.actualMinigame = null;
                    transform.parent.GetComponent<CC_Player>().canInteract = false;
                    SoundManager.Instance.Stop("EnterVentana");
                    break;
                default:
                    break;
            }
        }
    }
}
