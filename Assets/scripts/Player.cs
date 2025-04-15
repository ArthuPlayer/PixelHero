using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string nomePersonagem;
    [SerializeField] private int vida;
    [SerializeField] private int ataque;
    [SerializeField] private int defesa;
    [SerializeField] private int especial;
    [SerializeField] private bool estahVivo = true;
    [SerializeField] private DiretorBatalha dB;

    public string GetNomePersonagem()
    {
        return nomePersonagem;
    }

    public int GetVida()
    {
        return vida;
    }

    public bool VerificaVida() //retorna true se o jogador esta vivo e false se esta morto
    {
        return estahVivo;
    }


    public int Ataque()
    {
        int valorAtaque = Random.Range(0,ataque);

        this.especial++;


        if (valorAtaque > 0)
        {
            dB.RecebeTexto("ARgh! Sinta Minha Furia!");
            dB.RecebeTexto($"{nomePersonagem} ataca com {valorAtaque}");
            Debug.Log($"Especial: {this.especial}");
        }
        else
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} erra o ataque.");
            Debug.Log($"Especial: {this.especial}");
        }


        return valorAtaque;
    }

    public int Defesa()
    {
        int valorDefesa = Random.Range(0, defesa);

        this.especial++;

        
        if(valorDefesa > 0)
        {
            Debug.Log("");
            Debug.Log("ARgh!");
            dB.RecebeTexto($"{nomePersonagem} defende com {valorDefesa}");
            Debug.Log($"Especial: {this.especial}");
        }
        else
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} nao consegue defender.");
            Debug.Log($"Especial: {this.especial}");
        }
        

        return valorDefesa;
    }

    public int Especial()
    {
        int valorEspecial = Random.Range(20, ataque);
        int chanceDeDobrar = Random.Range(0, 100);

        if (chanceDeDobrar >= 90 && this.especial == 3)
        {
            int valorEspecialDobrado = valorEspecial * 2;
            Debug.Log("");
            dB.RecebeTexto("ARgh! Sede de Vinguança!");
            dB.RecebeTexto($"{nomePersonagem} ataca com {valorEspecialDobrado}");
            this.especial = 0;
            return valorEspecialDobrado;
        }
        else if (this.especial == 3)
        {
            Debug.Log("");
            dB.RecebeTexto("ARgh! Vou te esmagar!");
            dB.RecebeTexto($"{nomePersonagem} ataca com {valorEspecial}");
            this.especial = 0;
            return valorEspecial;
        }
        else
        {
            Debug.Log("");
            dB.RecebeTexto("Seu especial nao esta carregado!");
            return 0;
        }
    }

    public void LevarDano(int dano)
    {
        int danoFinal = dano - Defesa();

        if (danoFinal <= 0)
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} consegue se defender!");
        }
        else if (danoFinal <= 25)
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} leva dano de {danoFinal}.");
            vida -= danoFinal; //vida = vida - danoFinal;
        }
        else
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} toma uma porrada de {danoFinal}.");
            vida -= danoFinal;
        }

        DefineVida();

        if (estahVivo)
        {
            Debug.Log("");
            Debug.Log($"{nomePersonagem}, vida: {vida}");
        }
        else
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem}, morreu!");
        }

    }
    private void DefineVida() //Verifica o valor da vida e define como morto
    {
        if (vida <= 0)
        {
            estahVivo = false; //Ta morto
        }
    }    
}
