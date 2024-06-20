using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWinAnimation : MonoBehaviour
{
    [SerializeField] Animator _animatorEnemyWin;

   

    private void Awake()
    {
        _animatorEnemyWin = GetComponent<Animator>();
    }

    // M�todo llamado desde el evento de la animaci�n
    public void StartLoopAnimation()
    {
        // Activar el trigger para reproducir LoopingAnimation inmediatamente
        _animatorEnemyWin.SetTrigger("StartLoop");
    }

}
