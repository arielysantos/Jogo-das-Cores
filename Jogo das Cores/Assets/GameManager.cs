using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : GameManagerBase
{
    public int[] sequencia;

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

    // Implementa o comportamento espec�fico para checar a cor
    public override void ChecarCor(int corIndex)
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
        }
    }
}
