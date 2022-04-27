using System;
using System.IO;
using System.Collections.Generic;

namespace N1POO2
{
class Universo : Corpo {

    StreamWriter escritor = new StreamWriter("resultados.txt");
    //declaração de variaveis no construtor Universo
    public Universo(){
        QntCorpos = 0;
        QntIteracoes = 0;
        Tempo = 0;
        Nome = new string[55];
        Massa = new double[55];
        Raio = new double[55];
        PosX = new double[55];
        PosY = new double[55];
        VelX = new double[55];
        VelY = new double[55];
        ResultsD = new double [3000];
        ResultsF = new double [3000];
        ResultsAdjacente = new double [3000];
        ResultsOposto = new double [3000];
        ResultsFx = new double [3000]; 
        ResultsFy = new double [3000];
        ResultsAx = new double [55];
        ResultsAy = new double [55];
        ResultSomafx = new double [55];
        ResultSomafy = new double [55];
        ResultsSx = new double [55];
        ResultsSy = new double [55];
        ResultsVx = new double [55];
        ResultsVy = new double [55];
        ContadorIteracao = 0;
    }

    //funções das formulas para facilitar o processo
    private double distancia(double posX1, double posY1, double posX2, double posY2 ){
        double x = posX2 - posX1;
        double y = posY2 - posY1;
        double z = x*x + y*y;
        return Math.Sqrt(z);
    }
    private double adjacente(double posX1, double posX2){
        double x = posX2 - posX1;
        return Math.Abs(x);
     }

    private double oposto(double posY1, double posY2 ){ 
        double y = posY2 - posY1;
        return Math.Abs(y);
    }
    private double forca(double massaX, double massaY, double distancia){
        double g = 6.67 * Math.Pow(10, -11);
        return (g * massaX * massaY)/Math.Pow(distancia, 2);
    } 
    private double fx(double catetoA, double distancia, double forca){
        return (catetoA/distancia)*forca;
    }
    private double fy(double catetoO, double distancia, double forca){
        return (catetoO/distancia)*forca;
    }
    private double s(double s0, double v0, double tempo, double a){
        return s0+v0*tempo+(a*(tempo*tempo))/2;
    }
    private double a(double somaFxy, double massa){
        return (somaFxy/massa);
    }
    private double v(double v0, double a, double t){
        return v0 + a*t;
    }



    //aqui calculo fx e fy de cada força resultante e salvo em arrays para usar depois.
    private void obterDados(){
        int count = 0;
        
            for (int j = 0; j < qntCorpos; j++)
            {
                for (int k = 0; k < qntCorpos; k++)
                {
                    if(j!=k){

                    resultsD[count] = distancia(posX[j], posY[j], posX[k], posY[k]);
                    //Console.WriteLine("{0} {1}",count, resultsD[count]);
                    resultsAdjacente[count] = adjacente(posX[j], posX[k]);
                    //Console.WriteLine(resultsAdjacente[count]);
                    resultsOposto[count] = oposto(posY[j], posY[k]);
                    //Console.WriteLine(resultsOposto[count]);
                    double teste = 0;
                    foreach (double item in resultsF)
                    {
                        if (forca(massa[j],massa[k],resultsD[count]) == item){
                            teste = forca(massa[j],massa[k],resultsD[count]) *-1;
                    
                        }
                    }

                    if (teste == 0)
                    {
                        resultsF[count] = forca(massa[j],massa[k],resultsD[count]);
                        //Console.WriteLine("{0} {1}",count,resultsF[count]);
                        
                    }
                    if (teste != 0){    
                        resultsF[count] = teste;
                        //Console.WriteLine(resultsF[count]);
                    }
                    //Console.WriteLine("{0} {1}",count,resultsF[count]);
                    //Console.WriteLine(resultsAdjacente[count]);
                    //Console.WriteLine(resultsD[count]);

                    resultsFx[count] = fx(resultsAdjacente[count], resultsD[count],resultsF[count]);
                    //Console.WriteLine(resultsFx[count]);
                    resultsFy[count] = fy(resultsOposto[count], resultsD[count],resultsF[count]);
                    //Console.WriteLine(resultsFy[count]);

                    count++;
                    
                    }

                }
            }        
        
    
    }
    //aqui obtenho os valores necessarios (nova posição x e y e nova velocidade x e y)
    private void calcularDistancia(){
        escritor.WriteLine("ITERAÇÃO {0} ----------------------------", contadorIteracao);
        int count1 = 0;
        int count2 = 0;
        int qntFx = 0;
        int qntFy= 0;
        foreach (var item in resultsFx)
        {
            if (item!=0){
                qntFx++;
            }
        }
        foreach (var item in resultsFy)
        {
            if (item!=0){
                qntFy++;
            }
        }
        for (int i = 0; i < qntCorpos; i++)
        {   
            double somafx = 0;
            for (int j = 0; j < (qntFx/qntCorpos); j++)
            {
                somafx = somafx + resultsFx[count1];
                count1++;
            }
            resultSomafx[i] = somafx;
            //Console.WriteLine("{0} {1}",resultSomafx[i], i);
        }
        for (int i = 0; i < qntCorpos; i++)
        {   
            double somafy = 0;
            for (int j = 0; j < (qntFy/qntCorpos); j++)
            {
                somafy = somafy + resultsFy[count2];
                count2++;
            }
            resultSomafy[i] =  somafy;
            //Console.WriteLine("{0} {1}",resultSomafy[i], i);
        }
        for (int i = 0; i < qntCorpos; i++)
        {   
            resultsSx[i] = s(posX[i], velX[i],tempo, a(resultSomafx[i],massa[i]));
            resultsSy[i] = s(posY[i], velY[i],tempo, a(resultSomafy[i],massa[i]));
            resultsVx[i] = v(velX[i], a(resultSomafx[i],massa[i]), tempo);
            resultsVy[i] = v(velY[i], a(resultSomafy[i],massa[i]), tempo);
                        
            escritor.WriteLine("{0};{1};{2};{3};{4};{5};{6}",nome[i], massa[i],raio[i],resultsSx[i],resultsSy[i],resultsVx[i],resultsVy[i]);
            //escritor.WriteLine("Nova posição X de Corpo {0}: {1}", i, resultsSx[i]);
            //escritor.WriteLine("Nova posição Y de Corpo {0}: {1}", i, resultsSy[i]);
            //escritor.WriteLine("Nova velociadade X de Corpo {0}: {1}", i, resultsVx[i]);
            //escritor.WriteLine("Nova velocidade Y de Corpo {0}: {1}", i, resultsVy[i]);
            

            posX[i] = resultsSx[i];
            posY[i] = resultsSy[i];
            velX[i] = resultsVx[i];
            velY[i] = resultsVy[i];
        }
        
    }

    public void corpoCelestes(){
        //StreamWriter escritor = new StreamWriter ("resultados.txt");
        for (int i = 0; i < qntIteracoes; i++)
        {   
            
            obterDados();
            calcularDistancia();
            contadorIteracao++;
            
        }
        escritor.Close();
    }
    
}
}
