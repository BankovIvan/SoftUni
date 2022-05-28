using System;

namespace _10_Rage
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nTrashKeyboard, nTrashBoth, nGamesCount;
            double dPriceHeadset, dPriceMouse, dPriceKeyboard, dPriceDisplay, dTotalPrice;

            nGamesCount = int.Parse(Console.ReadLine());
            dPriceHeadset = double.Parse(Console.ReadLine());
            dPriceMouse = double.Parse(Console.ReadLine());
            dPriceKeyboard = double.Parse(Console.ReadLine());
            dPriceDisplay = double.Parse(Console.ReadLine());
            dTotalPrice = 0.0;
            nTrashKeyboard = 0;
            nTrashBoth = 0;

            for (i = 1; i <= nGamesCount; i++)
            {
                nTrashBoth = 0;

                //headset
                if ((i & 1) == 0)
                {
                    dTotalPrice += dPriceHeadset;
                    nTrashBoth++;
                }

                //mouse
                if (i % 3 == 0)
                {
                    dTotalPrice += dPriceMouse;
                    nTrashBoth++;
                }

                //keyboard
                if (nTrashBoth == 2)
                {
                    nTrashKeyboard++;
                    dTotalPrice += dPriceKeyboard;

                    //display
                    if ((nTrashKeyboard & 1) == 0)
                    {
                        dTotalPrice += dPriceDisplay;

                    }

                }


            }

            Console.WriteLine("Rage expenses: {0:F2} lv.", dTotalPrice);

        }
    }
}
