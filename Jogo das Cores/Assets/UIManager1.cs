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
        // Verificação de inicialização
        if (botoes.Length == 0 || sequenciaTexto == null || errouTexto == null || acertouTexto == null)
        {
            Debug.LogError("Por favor, verifique se todos os campos foram atribuídos no Inspector!");
            return;
        }

        // Configura o evento de clique para cada botão
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i; // Para evitar problemas com o uso de variáveis dentro do delegate
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(x));
        }
    }

    // Sobrescreve o método LimparTexto da classe base
    public override void LimparTexto()
    {
        sequenciaTexto.text = "";
    }

    // Sobrescreve o método AtualizarSequencia da classe base
    public override void AtualizarSequencia(string nomeDaCor)
    {
        StartCoroutine(ExibirSequencia(nomeDaCor));
    }

    // Coroutine para exibir a sequência com atraso
    private IEnumerator ExibirSequencia(string nomeDaCor)
    {
        sequenciaTexto.text = nomeDaCor;
        yield return new WaitForSeconds(delayEntreCores);
        sequenciaTexto.text = ""; // Limpa o texto após o atraso (para o efeito de transição)
    }

    // Métodos adicionais para interações específicas com a UI, como animações, transições, etc.
}
