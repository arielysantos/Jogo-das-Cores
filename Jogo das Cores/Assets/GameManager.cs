using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public abstract class GameManagerBase : MonoBehaviour
{
    #region Singleton
    public static GameManagerBase instance;

<<<<<<< Updated upstream
    public int[] sequencia;
    private object nomes;
    private int acertos;
    private int erros;
    private readonly int corDaVez;

    private void Start()
    {
        // Chama o m�todo da classe base
        GerarSequencia();
    }

    // Sobrescreve o m�todo GerarSequencia da classe base, se necess�rio
    public override void GerarSequencia()
    {
        base.GerarSequencia();  // Chama a implementa��o base

        // Ajuste da l�gica de gera��o da sequ�ncia
        sequencia = new int[Random.Range(3, Mathf.Max(nomes.Length, 3))];

        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = Random.Range(0, nomes.Length);
            UIManager.instance.AtualizarSequencia(nomes[sequencia[i]]);
        }
    }

    public override int GetCorDaVez()
    {
        return corDaVez;
    }

    // Implementa o comportamento espec�fico para checar a cor
    public override void ChecarCor(int corIndex, int corDaVez)
    {
        if (corIndex == sequencia[corDaVez])
        {
            corDaVez++;
            if (corDaVez == sequencia.Length)
            {
                acertos++;
                UIManager.instance.AtualizarAcertos(acertos);
                GerarSequencia(); // Nova sequ�ncia
            }
        }
        else
        {
            erros++;
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia(); // Resetando a sequ�ncia
=======
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
>>>>>>> Stashed changes
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
