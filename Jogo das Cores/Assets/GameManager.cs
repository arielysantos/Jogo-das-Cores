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
        // Chama o método da classe base
        GerarSequencia();
    }

    // Sobrescreve o método GerarSequencia da classe base, se necessário
    public override void GerarSequencia()
    {
        base.GerarSequencia();  // Chama a implementação base

        // Ajuste da lógica de geração da sequência
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

    // Implementa o comportamento específico para checar a cor
    public override void ChecarCor(int corIndex, int corDaVez)
    {
        if (corIndex == sequencia[corDaVez])
        {
            corDaVez++;
            if (corDaVez == sequencia.Length)
            {
                acertos++;
                UIManager.instance.AtualizarAcertos(acertos);
                GerarSequencia(); // Nova sequência
            }
        }
        else
        {
            erros++;
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia(); // Resetando a sequência
=======
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
