using System;
using System.IO;
using System.Collections.Generic;

namespace N1POO2
{
class Corpo{

    protected int QntCorpos;
    public int qntCorpos    
    {
        get => QntCorpos;
        set => QntCorpos = value;
    }

    protected int QntIteracoes;
    public int qntIteracoes    
    {
        get => QntIteracoes;
        set => QntIteracoes = value;
    }
    protected double Tempo;
    public double tempo    
    {
        get => Tempo;
        set => Tempo = value;
    }
    protected string[] Nome;
    public string[] nome    
    {
        get
            {
                return Nome;
            }
            set
            {
                Nome = value;
            }
    }
    protected double[] Massa;
    public double[] massa    
    {
        get
            {
                return Massa;
            }
            set
            {
                Massa = value;
            }
    }
    protected double[] Raio;
    public double[] raio    
    {
        get
            {
                return Raio;
            }
            set
            {
                Raio = value;
            }
    }
    protected double[] PosX;
    public double[] posX    
    {
        get
            {
                return PosX;
            }
            set
            {
                PosX = value;
            }
    }
    protected double[] PosY;
    public double[] posY    
    {
        get
            {
                return PosY;
            }
            set
            {
                PosY = value;
            }
    }
    protected double[] VelX;
    public double[] velX    
    {
        get
            {
                return VelX;
            }
            set
            {
                VelX = value;
            }
    }
    protected double[] VelY;
    public double[] velY    
    {
        get
            {
                return VelY;
            }
            set
            {
                VelY = value;
            }
    }
    protected double[] ResultsD;
    public double[] resultsD    
    {
        get
            {
                return ResultsD;
            }
            set
            {
                ResultsD = value;
            }
    }
    protected double[] ResultsF;
    public double[] resultsF    
    {
        get
            {
                return ResultsF;
            }
            set
            {
                ResultsF = value;
            }
    }
    protected double[] ResultsAdjacente;
    public double[] resultsAdjacente    
    {
        get
            {
                return ResultsAdjacente;
            }
            set
            {
                ResultsAdjacente = value;
            }
    }
    protected double[] ResultsOposto;
    public double[] resultsOposto    
    {
        get
            {
                return ResultsOposto;
            }
            set
            {
                ResultsOposto = value;
            }
    }
    protected double[] ResultsFx;
    public double[] resultsFx    
    {
        get
            {
                return ResultsFx;
            }
            set
            {
                ResultsFx = value;
            }
    }
    protected double[] ResultsFy;
    public double[] resultsFy    
    {
        get
            {
                return ResultsFy;
            }
            set
            {
                ResultsFy = value;
            }
    }
    protected double[] ResultsAx;
    public double[] resultsAx    
    {
        get
            {
                return ResultsAx;
            }
            set
            {
                ResultsAx = value;
            }
    }
    protected double[] ResultsAy;
    public double[] resultsAy    
    {
        get
            {
                return ResultsAy;
            }
            set
            {
                ResultsAy = value;
            }
    }
    
    protected double[] ResultSomafx;
    public double[] resultSomafx    
    {
        get
            {
                return ResultSomafx;
            }
            set
            {
                ResultSomafx = value;
            }
    }
    protected double[] ResultSomafy;
    public double[] resultSomafy    
    {
        get
            {
                return ResultSomafy;
            }
            set
            {
                ResultSomafy = value;
            }
    }
    protected double[] ResultsSx;
    public double[] resultsSx    
    {
        get
            {
                return ResultsSx;
            }
            set
            {
                ResultsSx = value;
            }
    } 
    protected double[] ResultsSy;
    public double[] resultsSy    
    {
        get
            {
                return ResultsSy;
            }
            set
            {
                ResultsSy = value;
            }
    }
    protected double[] ResultsVx;
    public double[] resultsVx    
    {
        get
            {
                return ResultsVx;
            }
            set
            {
                ResultsVx = value;
            }
    }
    protected double[] ResultsVy;
    public double[] resultsVy    
    {
        get
            {
                return ResultsVy;
            }
            set
            {
                ResultsVy = value;
            }
    }
    protected int ContadorIteracao;
    public int contadorIteracao    
    {
        get
            {
                return ContadorIteracao;
            }
            set
            {
                ContadorIteracao = value;
            }
    }  


    
    public void lerArquivo(){
        //Nessa parte eu uso uma logica de leitura linha por linha para obter as informações dos arquivos. O comando Split divide a linha em strings e facilita a leitura.
        const string filePath = "C:\\Bares.txt";
        var data = File.ReadAllLines(filePath);
        string linhaa = data[0];
        string[] dadosLinhaa = linhaa.Split(';');
        tempo = Convert.ToDouble(dadosLinhaa[2]);
        //Console.WriteLine(tempo);
        qntIteracoes = Int32.Parse(dadosLinhaa[1]);
        //Console.WriteLine(qntIteracoes);
        qntCorpos = Int32.Parse(dadosLinhaa[0]);
        //Console.WriteLine(qntCorpos);
        int posicao = 0;
        int count = 1;

        for (int i = 0; i < qntCorpos; i++)
        {
            string linha = data[count];
            string[] dadosLinha = linha.Split(';');
            //Console.WriteLine("Corpo {0}------------------", i);
            nome[i] = dadosLinha[posicao];
            //Console.WriteLine(nome[i]);
            posicao++;
            massa[i] = Convert.ToDouble(dadosLinha[posicao]);
            //Console.WriteLine(massa[i]);
            posicao++;
            raio[i] = Convert.ToDouble(dadosLinha[posicao]);
            //Console.WriteLine(raio[i]);
            posicao++;
            posX[i] = Convert.ToDouble(dadosLinha[posicao]);
            //Console.WriteLine(posX[i]);
            posicao++;
            posY[i] = Convert.ToDouble(dadosLinha[posicao]);
            //Console.WriteLine(posY[i]);
            posicao++;
            velX[i] = Convert.ToDouble(dadosLinha[posicao]);
            //Console.WriteLine(velX[i]);
            posicao++;
            velY[i] = Convert.ToDouble(dadosLinha[posicao]);
            //Console.WriteLine(velY[i]);
            posicao = 0;
            count++;
        }

        


    }
    }
}

