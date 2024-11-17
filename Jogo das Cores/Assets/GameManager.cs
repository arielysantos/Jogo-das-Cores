using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerBase : MonoBehaviour
{
    #region Singleton
    public static GameManagerBase instance;

    // Método de inicialização do Singleton
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: mantém a instância entre as cenas
        }
        else
        {
            Destroy(gameObject); // Destrói instâncias duplicadas
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

    // Métodos comuns para manipulação de acertos e erros
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

    // Método que pode ser sobrescrito nas classes derivadas
    public abstract void ChecarCor(int corIndex);
}
