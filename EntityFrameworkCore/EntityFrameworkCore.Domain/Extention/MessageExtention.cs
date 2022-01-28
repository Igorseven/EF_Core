using EFCore.Domain.Enums;
using System.ComponentModel;

namespace EFCore.Domain.Extention
{
    public static class MessageExtention
    {
        public static string Description(this EMessage message)
        {
            var type = message.GetType();
            var memberInfo = type.GetMember(message.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
