using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : UIManagerBase
{
    [SerializeField] Button[] botoes;
    [SerializeField] TextMeshProUGUI sequenciaTexto;
    [SerializeField] float delayEntreCores = 0.5f;

    private void Start()
    {
        // Verifica��o de inicializa��o
        if (botoes.Length == 0 || sequenciaTexto == null || errouTexto == null || acertouTexto == null)
        {
            Debug.LogError("Por favor, verifique se todos os campos foram atribu�dos no Inspector!");
            return;
        }

        // Configura o evento de clique para cada bot�o
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i; // Para evitar problemas com o uso de vari�veis dentro do delegate
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(x));
        }
    }

    // Sobrescreve o m�todo LimparTexto da classe base
    public override void LimparTexto()
    {
        sequenciaTexto.text = "";
    }

    // Sobrescreve o m�todo AtualizarSequencia da classe base
    public override void AtualizarSequencia(string nomeDaCor)
    {
        StartCoroutine(ExibirSequencia(nomeDaCor));
    }

    // Coroutine para exibir a sequ�ncia com atraso
    private IEnumerator ExibirSequencia(string nomeDaCor)
    {
        sequenciaTexto.text = nomeDaCor;
        yield return new WaitForSeconds(delayEntreCores);
        sequenciaTexto.text = ""; // Limpa o texto ap�s o atraso (para o efeito de transi��o)
    }

    // M�todos adicionais para intera��es espec�ficas com a UI, como anima��es, transi��es, etc.
}
