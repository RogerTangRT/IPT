using System.Runtime.Serialization;
using System.ServiceModel;

namespace GerenciadorCor
{
    [ServiceContract]
    public interface IService_GerenciadorCor
    {
        /// <summary>
        /// Retorna uma estrutura de cor no frmato RGB
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Cor ObtemCor();
    }
    /// <summary>
    /// Estrutura de Cor
    /// </summary>
    [DataContract]
    public class Cor
    {
        int r = 0;
        int g = 0;
        int b = 0;

        [DataMember]
        public int R
        {
            get { return r; }
            set { r = value; }
        }
        [DataMember]
        public int G
        {
            get { return g; }
            set { g = value; }
        }
        [DataMember]
        public int B
        {
            get { return b; }
            set { b = value; }
        }


    }
}
