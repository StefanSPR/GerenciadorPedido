using System.ComponentModel;
using System.Reflection;

namespace GerenciadorPedido.Web
{
    public static class Extension
    {
        /// <summary>
        /// Retornar a Descrição do Enum para exibir em tela
        /// Caso não tenha descrição retorna o nome do enum utilizado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetEnumDisplayName<T>(this T value) where T : struct
        {

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }

            FieldInfo? field = value.GetType().GetField(value.ToString() ?? "");
            DescriptionAttribute[]? attributes = (DescriptionAttribute[]?)field
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes?.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();

        }

    }
}
