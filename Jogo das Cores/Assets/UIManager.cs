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
            DontDestroyOnLoad(gameObject); // Garante que a UI não será destruída ao trocar de cena
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destrói instâncias duplicadas
        }
    }
    #endregion

    // Referências comuns para UI, como textos de acertos e erros
    [SerializeField] protected TextMeshProUGUI errouTexto, acertouTexto;

    // Método para atualizar acertos na UI
    public virtual void AtualizarAcertos(int acertos)
    {
        if (acertouTexto != null)
        {
            acertouTexto.text = acertos.ToString();
        }
    }

    // Método para atualizar erros na UI
    public virtual void AtualizarErros(int erros)
    {
        if (errouTexto != null)
        {
            errouTexto.text = erros.ToString();
        }
    }

    // Método que pode ser sobrescrito para manipular outros elementos da UI
    public abstract void LimparTexto();

    // Este método pode ser sobrescrito para atualizar sequências específicas
    public abstract void AtualizarSequencia(string nomeDaCor);
}
