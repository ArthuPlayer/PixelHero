using System.Collections;
using TMPro;
using UnityEngine;

public class DiretorBatalha : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Player inimigo;
    [SerializeField] TextMeshProUGUI vidaPlayer;
    [SerializeField] TextMeshProUGUI vidaInimigo;
    [SerializeField] TextMeshProUGUI nomePlayer;
    [SerializeField] TextMeshProUGUI nomeInimigo;
    [SerializeField] TextMeshProUGUI informativo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaPlayer.text = player.GetVida().ToString();
        vidaInimigo.text = inimigo.GetVida().ToString();
        nomePlayer.text = player.GetNomePersonagem();
        nomeInimigo.text = inimigo.GetNomePersonagem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtaquePlayer()
    {
        inimigo.LevarDano(player.Ataque());
        player.LevarDano(inimigo.Ataque());
        AtualizaDadosTela();
    }

    public void AtaqueEspecial()
    {
        inimigo.LevarDano(player.Especial());
        player.LevarDano(inimigo.Ataque());
        AtualizaDadosTela();
    }

    private void AtualizaDadosTela()
    {
        vidaPlayer.text = player.GetVida().ToString();
        vidaInimigo.text = inimigo.GetVida().ToString();
    }

    public void RecebeTexto(string texto)
    {
        StartCoroutine(ExibeTexto(texto));
    }

    private IEnumerator ExibeTexto(string texto)
    {
        informativo.text = texto;
        yield return new WaitForSeconds(1f);
        //informativo.text = "";
    }
}
