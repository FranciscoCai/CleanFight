using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiamantesCanvas : MonoBehaviour
{
    [SerializeField] private Sprite DiamanteRoto;
     private Image imagen;
    [SerializeField] private GameObject Diamante;
    [SerializeField] private AudioClip DiamanteRomper;
    [SerializeField] private GameObject Particula;
    private void OnDestroy()
    {
        imagen = Diamante.GetComponent<Image>();
        Particula.SetActive(false);
        SoundManager.instance.ReproducirSonido(DiamanteRomper);
        imagen.sprite = DiamanteRoto;
    }

}
