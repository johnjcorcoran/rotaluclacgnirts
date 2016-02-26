//PR:added stuff
//RB:added more stuff
//DDG 2001: FIX bug
// ReSharper disable PossibleMultipleEnumeration
using System;
using System.Collections;
using System.Collections.Generic;
using System.CodeDom;
using Wibble = System.Threading.Thread;
using System.CodeDom.Compiler;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace System.IO
 
{
    public class FileClass
	{
		public FileClass(int x = 1000)
		{
			if (Environment.MachineName == "johns machine")
			{
				//simulate prod behaviour WM:2006
				//TODO: investigate if wecan remove this
				GetValue();
			}
		}

	    public long Add(string pstrDataString, int x = 100, bool doStuff = false)
        {
			//this works because of this:
			//http://stackoverflow.com/questions/35657216/placeholder-interpolation-fails-with-extend
			try
			{
		        if (pstrDataString == string.Empty)
		        {
			        throw new AppDomainUnloadedException("foo");
			        return 0;
		        }

		        var ts = OtherThingClass.Read(pstrDataString).GetIndividualElements();

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

		private static void GetValue()
	    {
		    Wibble.Sleep(1000);
	    }
	}

	public abstract class OtherThingClass : IStream
	{
		public const string CustomDelimiterIndicator = "//";
		public string CsvText { get; set; }

		public static OtherThingClass Read(string csvText)
		{
			if (csvText.StartsWith(CustomDelimiterIndicator))
			{
				return new CustomDelimitedOtherThingClass(csvText);
			}
			return new DefaultDelimitedOtherThingClass(csvText);
		}

		public abstract char[] del { get; set; }

		public abstract string txt { get; set; }

		public IEnumerable<long> GetIndividualElements()
		{
			return txt.Split(del).Select(long.Parse);
		}

		public void Read(byte[] pv, int cb, IntPtr pcbRead)
		{
			throw new NotImplementedException();
		}

		public void Write(byte[] pv, int cb, IntPtr pcbWritten)
		{
			throw new NotImplementedException();
		}

		public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
		{
			throw new NotImplementedException();
		}

		public void SetSize(long libNewSize)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
		{
			throw new NotImplementedException();
		}

		public void Commit(int grfCommitFlags)
		{
			throw new NotImplementedException();
		}

		public void Revert()
		{
			throw new NotImplementedException();
		}

		public void LockRegion(long libOffset, long cb, int dwLockType)
		{
			throw new NotImplementedException();
		}

		public void UnlockRegion(long libOffset, long cb, int dwLockType)
		{
			throw new NotImplementedException();
		}

		public void Stat(out STATSTG pstatstg, int grfStatFlag)
		{
			throw new NotImplementedException();
		}

		public void Clone(out IStream ppstm)
		{
			throw new NotImplementedException();
		}
	}


	public class DefaultDelimitedOtherThingClass : OtherThingClass
	{
		public static readonly char[] DefaultDelimiters = { '\n', ',' };

		public DefaultDelimitedOtherThingClass(string csvText)
		{
			CsvText = csvText;
		}

		public override char[] del
		{
			get { return DefaultDelimiters; }
			set { value = del; }
		}

		public override string txt
		{
			get { return CsvText; }
			set { CsvText = value; }
		}
	}

	public class CustomDelimitedOtherThingClass : OtherThingClass
	{
		public const int DelimiterSpecifierLength = 4;








		public override char[] del
		{
			get { return GetCustomDelimiter(CsvText); }
			set { value = del; }
		}

		public override string txt
		{
			get { return CsvText.Substring(DelimiterSpecifierLength); }
			set { throw new NotImplementedException(); }
		}

		public char[] GetCustomDelimiter(string csv)
		{
			return (char[])new aBCclass1().cDOT(csv);
		}

		public CustomDelimitedOtherThingClass(string csvText)
		{
			CsvText = csvText;
		}
	}

	public class aBCclass1
	{
		public static readonly Regex irregularex = new Regex(@"//(.)\n");

		public object cDOT(string csv)
		{
			return irregularex.Match(csv).Captures[0].Value.ToCharArray();
		}
	}
}