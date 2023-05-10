using System.Collections;
using System.Collections.Generic;

namespace RPG.Stats
{
	public interface IModifierProvider
	{
        //IEnumerable in order to use them into the foreach loop.
        IEnumerable<float> GetAdditiveModifiers(Stat stat);
		IEnumerable<float> GetPercentageModifiers(Stat stat);
    }
}