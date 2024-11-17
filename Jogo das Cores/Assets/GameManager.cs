using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerBase : MonoBehaviour
{
    #region Singleton
    public static GameManagerBase instance;

    // M�todo de inicializa��o do Singleton
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: mant�m a inst�ncia entre as cenas
        }
        else
        {
            Destroy(gameObject); // Destr�i inst�ncias duplicadas
        }
    }
    #endregion

    // Atributos comuns a todos os gerenciadores
    protected int corDaVez, acertos, erros;
    protected string[] nomes;

    public virtual void GerarSequencia()
    {
        corDaVez = 0;
        UIManager.instance.LimparTexto();
    }

    // M�todos comuns para manipula��o de acertos e erros
    public void AtualizarAcertos(int acertos)
    {
        this.acertos = acertos;
        UIManager.instance.AtualizarAcertos(acertos);
    }

    public void AtualizarErros(int erros)
    {
        this.erros = erros;
        UIManager.instance.AtualizarErros(erros);
    }

    // M�todo que pode ser sobrescrito nas classes derivadas
    public abstract void ChecarCor(int corIndex);
}
