using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiahrette_3
{
    class Viola
    {
        /// <summary>
        /// Information field
        /// </summary>
        public int Info { get; set; }

        /// <summary>
        /// Next element
        /// </summary>
        public Viola Next { get; set; }

        /// <summary>
        /// Previous element
        /// </summary>
        public Viola Prev { get; set; }

        public char State { get; set; }

        /// <summary>
        /// A empty constructor
        /// </summary>
        public Viola()
        {
            Info = 0;
            Next = null;
            Prev = null;
            State = 'U';
        }

        /// <summary>
        /// Constructor 2 with Information field
        /// </summary>
        /// <param name="Info"></param>
        public Viola(int Info)
        {
            this.Info = Info;
            Next = null;
            Prev = null;
            State = 'U';
        }

        /// <summary>
        /// Constructor 3 with Info field and links for a previous and next elements
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Prev"></param>
        /// <param name="Next"></param>
        /// 
        public Viola(int Info, Viola Prev, Viola Next, char State)
        {
            this.Info = Info;
            this.Prev = Prev;
            this.Next = Next;
            switch (State)
            {
                case 'A':
                    {
                        State = 'A';
                        break;
                    }
                case 'D':
                    {
                        State = 'D';
                        break;
                    }
                case 'H':
                    {
                        State = 'H';
                        break;
                    }
                default:
                    {
                        State = 'U';
                        break;
                    }
            }
        }

    }
}
