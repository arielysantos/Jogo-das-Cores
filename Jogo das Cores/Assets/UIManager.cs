using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIManagerBase : MonoBehaviour
{
    #region Singleton
    public static UIManagerBase instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Garante que a UI n�o ser� destru�da ao trocar de cena
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destr�i inst�ncias duplicadas
        }
    }
    #endregion

    // Refer�ncias comuns para UI, como textos de acertos e erros
    [SerializeField] protected TextMeshProUGUI errouTexto, acertouTexto;

    // M�todo para atualizar acertos na UI
    public virtual void AtualizarAcertos(int acertos)
    {
        if (acertouTexto != null)
        {
            acertouTexto.text = acertos.ToString();
        }
    }

    // M�todo para atualizar erros na UI
    public virtual void AtualizarErros(int erros)
    {
        if (errouTexto != null)
        {
            errouTexto.text = erros.ToString();
        }
    }

    // M�todo que pode ser sobrescrito para manipular outros elementos da UI
    public abstract void LimparTexto();

    // Este m�todo pode ser sobrescrito para atualizar sequ�ncias espec�ficas
    public abstract void AtualizarSequencia(string nomeDaCor);
}
