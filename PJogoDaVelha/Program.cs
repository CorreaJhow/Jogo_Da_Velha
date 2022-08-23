using System;

namespace PJogoDaVelha
{
    internal class Program
    {

        static void MenuInicial() //lembrar de melhorar ("front-end")

        {
            BordaJogo();
            Console.WriteLine("\t\t\t\tPressione qualquer tecla para prosseguir...");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nProduzido por: Try Jhow");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            //*****Jogo da velha*****
            string[,] jogadores = new string[2, 2]; //define usuario e a peça escolhida
            string[] areaTabuleiro = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }; //tabuleiro
            bool proximaJogada = true;
            bool jogadorUmVencedor = true;
            bool jogadorDoisVencedor = true;
            int contadorVerificaVelha = 0;
            int jogadasMax;

            MenuInicial(); //Mensagem de inicio

            //Identificador do nome | OBSERVAÇÕES: usuario1 = Usuario[0,0] | usuario2 [1,0]
            for (int i = 0; i < 2; i++)
            {
                BordaJogo();
                Console.Write("Informe o nome do " + (i + 1) + "º jogador: ");
                jogadores[i, 0] = Console.ReadLine();
            }
            Console.Clear();
            BordaJogo();
            do //Usuario 1 escolhe X ou O  
            {
                DefinicaoPecaUsuario(jogadores);
            } while (jogadores[0, 1] != "X" && jogadores[0, 1] != "O");

            Console.WriteLine("Aperte qualquer tecla para iniciar");
            BordaJogo();
            Console.ReadKey();
            Console.Clear();
            string jogada;
            bool VerificaVitoria(string jogador, ref int contadorVerificaVelha)
            {
                if (areaTabuleiro[0] == areaTabuleiro[1] && areaTabuleiro[1] == areaTabuleiro[2]) //linha 1
                {
                    Console.Clear();
                    jogadasMax += 100;
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    return false;
                }
                else if (areaTabuleiro[3] == areaTabuleiro[4] && areaTabuleiro[4] == areaTabuleiro[5]) //linha 2
                {
                    Console.Clear();
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    jogadasMax += 100;
                    return false;
                }
                else if (areaTabuleiro[6] == areaTabuleiro[7] && areaTabuleiro[7] == areaTabuleiro[8]) //linha 3 
                {
                    Console.Clear();
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    jogadasMax += 100;
                    return false;
                }
                else if (areaTabuleiro[0] == areaTabuleiro[3] && areaTabuleiro[3] == areaTabuleiro[6]) //coluna 1
                {
                    Console.Clear();
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    jogadasMax += 100;
                    return false;
                }
                else if (areaTabuleiro[1] == areaTabuleiro[4] && areaTabuleiro[4] == areaTabuleiro[7]) //coluna 2
                {
                    Console.Clear();
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    jogadasMax += 100;
                    return false;
                }
                else if (areaTabuleiro[2] == areaTabuleiro[5] && areaTabuleiro[5] == areaTabuleiro[8]) //coluna 3
                {
                    Console.Clear();
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    jogadasMax += 100;
                    return false;
                }
                else if (areaTabuleiro[0] == areaTabuleiro[4] && areaTabuleiro[4] == areaTabuleiro[8]) //diagonal 1 
                {
                    Console.Clear();
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    jogadasMax += 100;
                    return false;
                }
                else if (areaTabuleiro[2] == areaTabuleiro[4] && areaTabuleiro[4] == areaTabuleiro[6]) //diagonal 2
                {
                    Console.Clear();
                    Console.WriteLine("**********O JOGADOR {0} FOI O VENCEDOR!**********", jogador);
                    jogadasMax += 100;
                    return false;
                }
                else
                {
                    if (contadorVerificaVelha == 9)
                    {
                        Console.WriteLine("Que pena, o jogo deu velha :((");
                        jogadasMax += 100;
                        return false;
                    }
                }
                return true;
            } //verifica se o primeiro jogador venceu ou deu velha
           
            void inicioJogo() //mostra o tabuleiro e suas respectivas posições
            {

                for (jogadasMax = 0; jogadasMax < 9; jogadasMax++)
                {
                    for (int jogador1 = 0; jogador1 < 1; jogador1++)
                    {
                        do
                        {
                            BordaJogo();
                            Console.WriteLine("");
                            Console.WriteLine(jogadores[0, 0] + "(" + jogadores[0, 1] + ") contra " + jogadores[1, 0] + " (" + jogadores[1, 1] + ")");
                            ImprimiTabuleiro(areaTabuleiro);
                            Console.WriteLine("");
                            Console.WriteLine("Jogador {0} faça sua jogada: (numero de 1 - 9)", jogadores[0, 0]);
                            jogada = Console.ReadLine();
                            BordaJogo();
                            Console.Clear();
                            proximaJogada = VerificaJogada(jogadores[0, 1], areaTabuleiro, ref contadorVerificaVelha, jogada);
                        } while (proximaJogada);
                    }
                    jogadorUmVencedor = VerificaVitoria(jogadores[0,0],  ref contadorVerificaVelha);
                    if (jogadorUmVencedor == false)
                    {
                        FimDeJogo(areaTabuleiro);
                    }
                    else
                    {
                        for (int jogador2 = 0; jogador2 < 1; jogador2++) //jogada do jogador 2 
                        {
                            do
                            {
                                BordaJogo();
                                Console.WriteLine("");
                                Console.WriteLine(jogadores[0, 0] + "(" + jogadores[0, 1] + ") vs. " + jogadores[1, 0] + " (" + jogadores[1, 1] + ")");
                                ImprimiTabuleiro(areaTabuleiro);
                                Console.WriteLine("");
                                Console.WriteLine("Jogador {0} faça sua jogada: (numero de 1 - 9)", jogadores[1, 0]);
                                jogada = Console.ReadLine();
                                BordaJogo();
                                Console.Clear();
                                proximaJogada = VerificaJogada(jogadores[1,1], areaTabuleiro,  ref contadorVerificaVelha, jogada);
                            } while (proximaJogada);
                        }
                    }
                    if (jogadorUmVencedor) //se for verdadeiro 
                    {
                        jogadorDoisVencedor = VerificaVitoria(jogadores[1,0], ref contadorVerificaVelha);
                    }
                    if (!jogadorDoisVencedor) //retornar falso
                    {
                        FimDeJogo(areaTabuleiro); //encerra o jogo 
                    }
                }
            }
            inicioJogo(); //O jogo se inicia 
        }

        static bool VerificaJogada(string valorPeca, string[] areaTabuleiro, ref int contadorVerificaVelha, string jogada)
        {
            bool testeJogada;
            if (jogada == "1")
            {
                if (areaTabuleiro[0] != "X" && areaTabuleiro[0] != "O")
                {
                    areaTabuleiro[0] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "2")
            {
                if (areaTabuleiro[1] != "X" && areaTabuleiro[1] != "O")
                {

                    areaTabuleiro[1] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "3")
            {
                if (areaTabuleiro[2] != "X" && areaTabuleiro[2] != "O")
                {
                    areaTabuleiro[2] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "4")
            {
                if (areaTabuleiro[3] != "X" && areaTabuleiro[3] != "O")
                {
                    areaTabuleiro[3] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "5")
            {
                if (areaTabuleiro[4] != "X" && areaTabuleiro[4] != "O")
                {
                    areaTabuleiro[4] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "6")
            {
                if (areaTabuleiro[5] != "X" && areaTabuleiro[5] != "O")
                {
                    areaTabuleiro[5] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "7")
            {
                if (areaTabuleiro[6] != "X" && areaTabuleiro[6] != "O")
                {
                    areaTabuleiro[6] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "8")
            {
                if (areaTabuleiro[7] != "X" && areaTabuleiro[7] != "O")
                {
                    areaTabuleiro[7] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else if (jogada == "9")
            {
                if (areaTabuleiro[8] != "X" && areaTabuleiro[8] != "O")
                {
                    areaTabuleiro[8] = (valorPeca);
                    testeJogada = false;
                    contadorVerificaVelha++;
                }
                else
                {
                    Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                    testeJogada = true;
                }
            }
            else
            {
                Console.WriteLine("Posição inválida ou já ocupada, escolha outra.");
                testeJogada = true;
            }

            return testeJogada;
        }

        static void BordaJogo()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("JOGO | DA | VELHA | JOGO | DE | VELHA | JOGO | DA | VELHA | JOGO | DE | VELHA | JOGO | DA | VELHA | JOGO | DA | VELHA |J");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }

        static void DefinicaoPecaUsuario(string[,] usuario)
        {
            Console.WriteLine(usuario[0, 0] + ", faça as honras e escolha entre sua peça (entre 'X' ou 'O')");
            usuario[0, 1] = Console.ReadLine().ToUpper();
            if (usuario[0, 1] == "X")
            {
                usuario[1, 1] = "O";
                Console.WriteLine(usuario[0, 0] + " escolheu o 'X', consequentemente o " + usuario[1, 0] + " ficara com o 'O'");
            }
            else if (usuario[0, 1] == "O")
            {
                usuario[1, 1] = "X";
                Console.WriteLine(usuario[0, 0] + " escolheu 'O', consequentemente o " + usuario[1, 0] + " ficara com o 'X'");
            }
            else
                Console.WriteLine("Voce escolheu opções inválidas para nossa plataforma, volte e escolha conforme o padrão. =)");
        }

        static void FimDeJogo(string[] areaTabuleiro) //encerra o jogo 
        {
            ImprimiTabuleiro(areaTabuleiro);
            Console.WriteLine(" O jogo acaba aqui, obrigado pela participação..");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t ████▀░░░░░░░░░░░░░░░░░▀████");
            Console.WriteLine("\t\t\t\t ██▌│░░░░░░░░░░░░░░░░░░░│▐██");
            Console.WriteLine("\t\t\t\t ██░░└┐░░░░░░░░░░░░░░░┌┘░░██");
            Console.WriteLine("\t\t\t\t ██▌░│██████▌░░░▐██████│░▐██");
            Console.WriteLine("\t\t\t\t ██▀─┘░░░░░░░▐█▌░░░░░░░└─▀██");
            Console.WriteLine("\t\t\t\t ████▄─┘██▌░░░░░░░▐██└─▄████");
            Console.WriteLine("\t\t\t\t ████▌░░░▀┬┼┼┼┼┼┼┼┬▀░░░▐████");
            Console.WriteLine("\t\t\t\t ███████▄░░░░░░░░░░░▄███████");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("JOGO | DA | VELHA | JOGO | DE | VELHA | JOGO | DA | VELHA | JOGO | DE | VELHA | JOGO | DA | VELHA | JOGO | DA | VELHA |J");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }

        static void ImprimiTabuleiro(string[] areaTabuleiro)
        {
            Console.WriteLine("\t\t\t\t      |     |      ");
            Console.WriteLine("\t\t\t\t   {0}  |  {1}  |  {2}", areaTabuleiro[0], areaTabuleiro[1], areaTabuleiro[2]);
            Console.WriteLine("\t\t\t\t _____|_____|_____ ");
            Console.WriteLine("\t\t\t\t      |     |      ");
            Console.WriteLine("\t\t\t\t   {0}  |  {1}  |  {2}", areaTabuleiro[3], areaTabuleiro[4], areaTabuleiro[5]);
            Console.WriteLine("\t\t\t\t _____|_____|_____ ");
            Console.WriteLine("\t\t\t\t      |     |      ");
            Console.WriteLine("\t\t\t\t   {0}  |  {1}  |  {2}", areaTabuleiro[6], areaTabuleiro[7], areaTabuleiro[8]);
            Console.WriteLine("\t\t\t\t      |     |      ");
        }
    }
}
