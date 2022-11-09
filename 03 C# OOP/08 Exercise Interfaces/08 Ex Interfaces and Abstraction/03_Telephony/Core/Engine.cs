namespace Telephony.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Telephony.Core.Interfaces;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    using Telephony.Models.Exceptions;
    using Telephony.Models.Interfaces;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartPhone;

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartPhone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            string[] arrPhoneNumbers = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] arrURLs = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            foreach (var v in arrPhoneNumbers)
            {
                try
                {
                    if (v.Length == 10)
                    {
                        this.writer.WriteLine(this.smartPhone.Call(v));
                    }
                    else if (v.Length == 7)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(v));
                    }
                    else
                    {
                        // throw new InvalidProgramException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    this.writer.WriteLine(ipne.Message);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message); ;
                }
            }


            foreach (var v in arrURLs)
            {
                try
                {
                    this.writer.WriteLine(this.smartPhone.BroseURL(v));
                }
                catch (InvalidURLException iue)
                {
                    this.writer.WriteLine(iue.Message);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

        }
    }
}
