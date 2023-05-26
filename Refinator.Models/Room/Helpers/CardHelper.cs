using Refinator.Models.Room.Enums;

namespace Refinator.Models.Room.Helpers
{
    public static class CardHelper
    {
        public static double ConvertToDouble(this AgileCardEnum card)
        {
            double result;
            switch (card)
            {
                case AgileCardEnum.Half: result = 0.5d; break;
                case AgileCardEnum.One: result = 1d; break;
                case AgileCardEnum.Two: result = 2d; break;
                case AgileCardEnum.Three: result = 3d; break;
                case AgileCardEnum.Five: result = 5d; break;
                case AgileCardEnum.Height: result = 8d; break;
                case AgileCardEnum.Thirteen: result = 13d; break;
                case AgileCardEnum.Twenty: result = 20d; break;
                case AgileCardEnum.Forty: result = 40d; break;
                case AgileCardEnum.OneHundred: result = 100d; break;
                case AgileCardEnum.InterogationMark:
                case AgileCardEnum.Coffee:
                case AgileCardEnum.Zero:
                default: result = 0d; break;
            }

            return result;
        }

        public static string ConvertToString(this AgileCardEnum card)
        {
            string result;
            switch (card)
            {
                case AgileCardEnum.Half: result = "0.5"; break;
                case AgileCardEnum.One: result = "1"; break;
                case AgileCardEnum.Two: result = "2"; break;
                case AgileCardEnum.Three: result = "3"; break;
                case AgileCardEnum.Five: result = "5"; break;
                case AgileCardEnum.Height: result = "8"; break;
                case AgileCardEnum.Thirteen: result = "13"; break;
                case AgileCardEnum.Twenty: result = "20"; break;
                case AgileCardEnum.Forty: result = "40"; break;
                case AgileCardEnum.OneHundred: result = "100"; break;
                case AgileCardEnum.InterogationMark: result = "?"; break;
                case AgileCardEnum.Coffee: result = @"\u2615\"; break;
                case AgileCardEnum.Zero:
                default: result = "0"; break;
            }

            return result;
        }
    }
}
