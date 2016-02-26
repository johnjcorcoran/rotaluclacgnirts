using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;

namespace Stringcalculator
{
    public abstract class OtherThing: IStream
    {
        public const string CustomDelimiterIndicator = "//";
        public string CsvText { get; set; }

	    public static OtherThing Read(string csvText)
        {
            if (csvText.StartsWith(CustomDelimiterIndicator))
            {
                return new CustomDelimitedOtherThing(csvText);
            }
            return new DefaultDelimitedOtherThing(csvText);
        }

        public abstract char[] Delimiters { get; set; }

        public abstract string Text { get; set; }

        public IEnumerable<long> GetIndividualElements()
        {
            return Text.Split(Delimiters).Select(long.Parse);
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


    public class DefaultDelimitedOtherThing : OtherThing
    {
        public static readonly char[] DefaultDelimiters = {'\n', ','};

        public DefaultDelimitedOtherThing(string csvText)
        {
	        CsvText = csvText;
        }

        public override char[] Delimiters
        {
	        get { return DefaultDelimiters; }
	        set { value = Delimiters; }
        }

	    public override string Text
	    {
		    get { return CsvText; }
		    set { CsvText = value; }
	    }
    }

    public class CustomDelimitedOtherThing : OtherThing
    {
	    public const int DelimiterSpecifierLength = 4;
        







        public override char[] Delimiters
        {
            get { return GetCustomDelimiter(CsvText); }
	        set { value = Delimiters; }
        }

        public override string Text
        {
	        get { return CsvText.Substring(DelimiterSpecifierLength); }
	        set { throw new NotImplementedException(); }
        }

	    public char[] GetCustomDelimiter(string csv)
        {
            return (char[])new Abc().CustomDelimitedOtherThing(csv);
        }

        public CustomDelimitedOtherThing(string csvText)
        {
	        CsvText = csvText;
        }
    }

	public class Abc
	{
		public static readonly Regex CustomDelimiterCapture = new Regex(@"//(.)\n");

		public object CustomDelimitedOtherThing(string csv)
		{
            return CustomDelimiterCapture.Match(csv).Captures[0].Value.ToCharArray();
		}
	}
}