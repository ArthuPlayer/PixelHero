using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioSource player; //Referência ao componente AudioSource
    [SerializeField] private AudioClip som; //Arquivo (Clip) de áudio a ser reproduzido

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<AudioSource>(); //Guarda a referência do AudioSource
    }

    public void Jogar()
    {
        TocarSom(); //Chama a função para tocar o som
        Invoke("SelecionaPersonagen", 1f); //Chama a função SelecionaPersonagens após 1 segundo
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void SelecionaPersonagen()
    {
        SceneManager.LoadScene("SelecionaPersonagen");
    }

    public void Personagen_1()
    {
        SceneManager.LoadScene("Personagen_1");
    }

    public void Personegen_2()
    {
        SceneManager.LoadScene("Personagen_2");
    }

    public void Cena1() 
    {
        SceneManager.LoadScene("Cena1");
    }

    public void CenaDaBatalha()
    {
        SceneManager.LoadScene("CenaDaBatalha");
    }

    public void CenaDaFuga()
    {
        SceneManager.LoadScene("CenaDaFuga");
    }

    private void TocarSom()
    {
        player.PlayOneShot(som);
    }

}
