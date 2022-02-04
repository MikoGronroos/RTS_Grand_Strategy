using System.Collections.Generic;

public static class CombatCalculations
{

    public static float AverageOrganization(List<DivisionHolder> divisions)
    {
        float index = 0;
        float numbersAddedTogether = 0;
        foreach (var division in divisions)
        {
            index++;
            numbersAddedTogether += division.GetDivision().Organization;
        }

        float averageOrganization = numbersAddedTogether / index;

        return averageOrganization;
    }

    public static float AverageDamage(List<DivisionHolder> divisions)
    {
        float index = 0;
        float numbersAddedTogether = 0;
        foreach (var division in divisions)
        {
            index++;
            numbersAddedTogether += division.GetDivision().Damage;
        }

        float averageDamage = numbersAddedTogether / index;

        return averageDamage;
    }

}
