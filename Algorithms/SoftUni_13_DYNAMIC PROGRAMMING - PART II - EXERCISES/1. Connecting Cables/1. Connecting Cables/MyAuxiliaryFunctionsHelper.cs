using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MyAuxiliaryFunctionsHelper
{

    private static bool VectorReverseCombinationExtended(int[] elements, int[] vector, int minIndex = -1, int maxIndex = -1, bool increasingOrder = false)
    {

        int i, j;

        if (minIndex == -1) minIndex = 0;
        if (maxIndex < 0) maxIndex = elements.Length - 1;

        for (i = vector.Length - 1; i >= 0; i--)
        {
            if (vector[i] > minIndex)
            {
                vector[i]--;

                for (j = vector.Length - 1; j > i; j--)
                {
                    if (increasingOrder)
                    {
                        vector[j] = vector[i];
                    }
                    else
                    {
                        vector[j] = maxIndex;
                    }

                }

                break;

            }
        }

        if (i < 0) return true;
        return false;
    }

    private static bool VectorNextCombinationExtended(int[] elements, int[] vector, int minIndex = -1, int maxIndex = -1, bool increasingOrder = false)
    {

        int i, j;

        if (minIndex == -1) minIndex = 0;
        if (maxIndex < 0) maxIndex = elements.Length - 1;

        for (i = vector.Length - 1; i >= 0; i--)
        {
            if (vector[i] < maxIndex)
            {
                vector[i]++;

                for (j = i + 1; j < vector.Length; j++)
                {
                    if (increasingOrder)
                    {
                        vector[j] = vector[i];
                    }
                    else
                    {
                        vector[j] = minIndex;
                    }

                }

                break;

            }
        }

        if (i < 0) return true;
        return false;
    }

    private static bool VectorNextCombination(int[] elements, int[] vector)
    {

        int i, j;
        int elementsEnd = elements.Length - 1;

        for (i = vector.Length - 1; i >= 0; i--)
        {
            if (vector[i] < elementsEnd)
            {
                vector[i]++;

                for (j = i + 1; j < vector.Length; j++)
                {
                    vector[j] = 0;
                }

                break;

            }
        }

        if (i < 0) return true;
        return false;
    }

}

