
namespace JOGO_DA_VELHA
{
     class JOGO_DA_VELHA
    {
        private bool fim_de_jogo;
        private char[] posicoes;
        private char vez;
        private int jogadas_feitas;

        public JOGO_DA_VELHA()
        {
            fim_de_jogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
        }
        
        public void iniciar()
        {
            while (!fim_de_jogo)
            {
                renderizar_tabela();
                ler_escolha_do_usuario();
                renderizar_tabela();
                verificar_fim_de_jogo();
                mudara_vez();
            }
        }

        private string tabela()
        {
            return $"__{ posicoes[0]}__|__{ posicoes[1]}__|__{ posicoes[2]}__\n" +
                   $"__{ posicoes[3]}__|__{ posicoes[4]}__|__{ posicoes[5]}__\n" +
                   $"  { posicoes[6]}  |  { posicoes[7]}  |  { posicoes[8]}  \n\n";
        }

       

        private bool validar_escolha(int posicao)
        {
            int indice = posicao -1;

            return posicoes [indice] != '0' && posicoes[indice] != 'X';
        }

        private void renderizar_tabela()
        {
            Console.Clear();
            Console.WriteLine(tabela());
        }

        private void ler_escolha_do_usuario()
        {
            Console.WriteLine($"Agora é a vez de {vez} , digite uma posicao de 1 a 9");

            bool escolha_do_usuario = int.TryParse(Console.ReadLine(), out int posicao_escolhida);

            while (!escolha_do_usuario || !validar_escolha(posicao_escolhida))
            {
                Console.WriteLine("O campo escolhido é invalido , por favor digite um numero de 1 a 9 que esteja disponivel na tabela");
                escolha_do_usuario = int.TryParse(Console.ReadLine(), out posicao_escolhida);
            }
            preencher_escolha (posicao_escolhida);
        }

        private void preencher_escolha(int posicao_escolhida)
        {
            int indice = posicao_escolhida - 1;
            posicoes[indice] = vez;
            jogadas_feitas++;
        }

        private void mudara_vez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        

        private void verificar_fim_de_jogo()
        {
            if (jogadas_feitas < 5)
                return;

            if(vitoria_diagonal() || vitoria_horizontal() || vitoria_vertical())
            {
                fim_de_jogo = true;
                Console.WriteLine ($"Fim de jogo ! Vitoria de {vez}");
            }

            if (jogadas_feitas is 9)
            {
                fim_de_jogo = true;
                Console.WriteLine("Fim de Jogo ! EMPATE! ");
            }

        }

        private bool vitoria_horizontal()
        {
            bool linha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return linha1 || linha2 || linha3;
        }
        private bool vitoria_vertical()
        {
            bool linha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool linha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool linha3 = posicoes[3] == posicoes[5] && posicoes[3] == posicoes[8];

            return linha1 || linha2 || linha3;
        }
        private bool vitoria_diagonal()
        {
            bool linha1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool linha2 = posicoes[6] == posicoes[4] && posicoes[6] == posicoes[2];
            
            return linha1 || linha2;
        }


    }
}
