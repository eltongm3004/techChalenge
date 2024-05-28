using System.ComponentModel;

namespace ApiLoja.Core.Enums
{
    public enum StatusPedido
    {
        [Description("Recebido")]
        Recebido = 1,
        [Description("Pago")]
        Pago = 2,
        [Description("Preparação")]
        Preparacao = 3,
        [Description("Pronto")]
        Pronto = 4,
        [Description("Finalizado")]
        Finalizado = 5
    }
}
