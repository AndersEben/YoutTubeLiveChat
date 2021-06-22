using CefSharp;
using System;
using System.IO;
using System.Text;

namespace YoutTubeLiveChat
{
    public class MyResponseFilter : IResponseFilter
    {
        public string videoID;

        void IDisposable.Dispose()
        {

        }

        bool bigger = false;
        FilterStatus IResponseFilter.Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {

            if (!bigger)
            {
                byte[] _read = new byte[dataIn.Length];
                dataIn.Read(_read, 0, (int)dataIn.Length);

                string _test = Encoding.UTF8.GetString(_read);
                //Console.WriteLine(_test);
                System.IO.File.AppendAllText(@"C:\test\test_cef_" + videoID + ".txt", _test + System.Environment.NewLine);

            }


            if (dataIn.Length > dataOut.Length)
            {
                Console.WriteLine("Bigger");

                var data = new byte[dataOut.Length];
                dataIn.Seek(0, SeekOrigin.Begin);
                dataIn.Read(data, 0, data.Length);
                dataOut.Write(data, 0, data.Length);

                dataInRead = dataOut.Length;
                dataOutWritten = dataOut.Length;

                bigger = true;

                return FilterStatus.NeedMoreData;
            }
            else
            {
                dataIn.Position = 0;
                dataOut.Position = 0;
                dataIn.CopyTo(dataOut, (int)dataOut.Length);

                dataInRead = dataIn.Length;
                dataOutWritten = dataIn.Length;

                bigger = false;

                return FilterStatus.Done;
            }


        }

        bool IResponseFilter.InitFilter()
        {
            return true;
        }
    }

}
