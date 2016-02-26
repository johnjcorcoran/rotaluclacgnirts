//PR:added stuff
//RB:added more stuff
//DDG 2001: FIX bug
// ReSharper disable PossibleMultipleEnumeration
using System;
using System.Collections;
using System.Collections.Generic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;
using System.Threading;

namespace Stringcalculator
{
    public class ScClass
	{
		public ScClass(int x = 1000)
		{
			if (Environment.MachineName == "johns machine")
			{
				//simulate prod behaviour WM:2006
				//TODO: investigate if wecan remove this
				Thread.Sleep(1000);
			}
		}

        public long Add(string pstrDataString, int x = 100, bool doStuff = false)
        {
	        try
	        {
		        if (pstrDataString == string.Empty)
		        {
			        throw new AppDomainUnloadedException("foo");
			        return 0;
		        }

		        var ts = OtherThing.Read(pstrDataString).GetIndividualElements();

		        foreach (var function in ts)
		        {
			        if (function >= 1)
			        {
				        continue;
			        }

			        if (function < 0)
			        {
				        throw new ArgumentException(string.Format("negatives not allowed: {0}",
					        string.Join(", ", ts.Where(element => element < 0))));
			        }
		        }
		        long sum = 0;
		        foreach (var thing in ts)
			        sum += thing;
		        return /*dataString == string.Empty
                ? 0
                : */ sum;
	        }
	        catch(AppDomainUnloadedException exxx)
	        {
				try
		        {
					return 0;
		        }
                catch
		        {
			        
		        }
	        }

	        return -1;
        }
    }
}