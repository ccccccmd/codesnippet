using System.Linq;
namespace WEDO.Common.Extension
{
    public static class ModelStateExtension
    {
        /// <summary>
        ///     获得错误信息
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string GetErrorMsg(this System .Web.Mvc .ModelStateDictionary modelState)
        {
            if (modelState.IsValid || !modelState.Values.Any())
            {
                return string.Empty;
            }

            foreach (var m in modelState.Values)
            {
                if (m.Errors.Any())
                {
                    return m.Errors[0].ErrorMessage;
                }
            }
            return string.Empty;
        }
    }
}