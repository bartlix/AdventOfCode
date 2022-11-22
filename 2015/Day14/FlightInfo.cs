using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class FlightInfo
    {
        public FlightInfo(string data)
        {
            Parse(data);
        }

        public string Name { get; private set; }

        public int Speed { get; private set; }

        public int Duration { get; private set; }

        public int Sleep { get; private set; }

        public int Points { get; set; }

        public int Distance { get; private set; }

        public int GetDistance(int duration)
        {
            var track = 0;

            var rest = duration;

            while(rest > 0)
            {
                var time = Duration < rest ? Duration : rest;

                track += time * Speed;

                rest -= time;

                var pause = Sleep < rest ? Sleep : rest;

                rest -= pause;
                

            }

            return track;
        }

        public void SetDistance(int seconds)
        {
            Distance = GetDistance(seconds);
        }

        private void Parse(string data)
        {
            data = data.Replace("can fly", "").Replace("km/s for", "").Replace("seconds,", "").Replace("but then must rest for","").Replace("seconds.", "");
            var pars = data.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();

            Name = pars[0];
            Speed = int.Parse(pars[1]);
            Duration = int.Parse(pars[2]);
            Sleep = int.Parse(pars[3]);
        }
    }
}
