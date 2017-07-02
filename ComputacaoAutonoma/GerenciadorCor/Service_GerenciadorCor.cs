using System;

namespace GerenciadorCor
{
    /// <summary>
    /// Implementação do Serviço de Obtenção de COR
    /// </summary>
    public class Service_GerenciadorCor : IService_GerenciadorCor
    {
        /// <summary>
        /// Retorna uma estrutura de cor no frmato RGB
        /// </summary>
        /// <returns></returns>
        public Cor ObtemCor()
        {
            Cor cor = new Cor(); ;
            Random random = new Random();
            cor.R = random.Next(0, 255);
            cor.G = random.Next(0, 255);
            cor.B = random.Next(0, 255);

            return cor;
        }
    }
}
