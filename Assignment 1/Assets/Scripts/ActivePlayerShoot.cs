using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePlayerShoot : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ButtonPressed);
    }

    public void ButtonPressed()
    {
       ActivePlayer currentPlayer = manager.GetCurrentPlayer();
       currentPlayer.FireProjectile();
    }
}
