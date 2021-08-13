using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineFractions : MonoBehaviour
{
    [SerializeField]
    string[] _equations;
    int[] _numbers = new int[4];
    int[] _fraction = new int[2];

    private void Start()
    {
        
        foreach (string equation in _equations)
        {
            _numbers = ParseNumbers(equation);  //Pull numbers from Equation
            _fraction = Combine(_numbers);      //Add Fractions
            _fraction = Reduce(_fraction);      //Reduce Fractions
            Debug.Log($"{equation} = {_fraction[0]}/{_fraction[1]}");
        }

    }

    int[] ParseNumbers(string equation) 
    {
        equation = equation.Replace("/", " ").Replace("+", " ");
        string[] numArray = equation.Split(' ');

        for (int i=0; i<numArray.Length; i++)
        {
            _numbers[i] = int.Parse(numArray[i]);
        }

        return _numbers;
    }

    int[] Combine(int[] Numbers)
    {
        int[] Fraction = new int[2];
        int N1 = Numbers[0];
        int D1 = Numbers[1];
        int N2 = Numbers[2];
        int D2 = Numbers[3];

        if (D1 == D2)       //Add Numerators Together
        {
            Fraction[0] = N1 + N2;
            Fraction[1] = D1;
            return Fraction;
        }
        else                //Cross Multiply Numerators
        {                   //Multiply Denomiinators
            Fraction[0] = (N1 * D2) + (N2 * D1);
            Fraction[1] = D1 * D2;
            return Fraction;
        }
    }

    int[] Reduce(int[] fraction)
    {
        int GCF = 0;
        List<int> FactorsN = new List<int>();
        List<int> FactorsD = new List<int>();

        FactorsN = GetFactors(fraction[0]);
        FactorsD = GetFactors(fraction[1]);

        while (GCF == 0)       //Work through Factors in reverse to find
        {                      //Greatest Common Factor by Comparision
            for (int n = FactorsN.Count-1; n >=0 ; n--)
            {
                for (int d = FactorsD.Count-1; d >=0; d--)
                {
                    if (FactorsN[n] == FactorsD[d])
                    {
                        fraction[0] /= FactorsN[n];
                        fraction[1] /= FactorsN[n];
                        return fraction;
                    }
                }
            } //Number 1 is always a common Factor and will atleast Return it
        }
        return null;
    }

    List<int> GetFactors(int num)
    {
        List<int> Factors = new List<int>();
        int f = 1;
        while (f<=num)
        {   //Brute Force Facotring by checking all numbers under Number
            if (num % f == 0)
                Factors.Add(f);
            f++;
        }   

        return Factors;
    }
}