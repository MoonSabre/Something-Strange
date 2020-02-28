using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiahrette_3
{
    class Amaranthus
    { /// <summary>
      /// Head of the Doublelinked cycling List.
      /// </summary>
        public Viola Head { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        public Amaranthus()
        {
            Head = new Viola();
            Head.Next = Head;
            Head.Prev = Head;
        }

        /// <summary>
        /// Add at First.
        /// </summary>
        /// <param name="Info"></param>
        public void AddFirst(int Info, char St)
        {
            if (Head != null)
            {
                Head.Next = new Viola(Info, Head, Head.Next, St);
                Head.Next.Next.Prev = Head.Next;
            }
            else
            {
                Head = new Viola();
                Head.Next = new Viola(Info, Head, Head, St);
            }
        }

        /// <summary>
        /// Add at Last.
        /// </summary>
        /// <param name="Info"></param>
        public void AddLast(int Info, char St)
        {
            if (Head != null)
            {
                Viola p = new Viola(Info, Head.Prev, Head, St);
                Head.Prev.Next = p;
                Head.Prev = p;
            }
            else
            {
                Head = new Viola();
                Head.Next = new Viola(Info, Head, Head, St);
            }
        }

        public int ListLength()
        {
            int cnt = 0;
            Viola p = Head.Next;
            while (p != Head)
            {
                cnt++;
                p = p.Next;
            }
            return cnt;
        }
        /// <summary>
        /// Count of the selected node.
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public Viola CountedNode(int cnt)
        {
            if (Head != null)
            {
                Viola p = Head.Next;
                while (p != Head.Prev && cnt > 0)
                {
                    cnt--;
                    p = p.Next;
                }

                return p;
            }
            else return null;
        }

        /// <summary>
        ///  Add somewhere you want.
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Index"></param>
        public void AddSomewhere(int Info, char St, int Index)
        {
            Viola p = CountedNode(Index);
            Viola q = new Viola(Info, p, p.Next, St);
            q.Next.Prev = q;
            q.Prev.Next = q;
        }


        /*  Node q = new Node(Info);
            Node p = Count(Index);
            if (p.Next != null)
            {
                q.Next = p.Next.Next;
                p.Next = q;
            }
            else
            {
                q.Next = null;
                p.Next = q;
            }
        }*/

        /// <summary>
        ///  Print the List.
        /// </summary>
        /// <param name="LB"></param>
        public void PrintList(System.Windows.Forms.ListBox LB)
        {
            LB.Items.Clear();
            if (Head != null && Head.Next != null)
            {
                Viola p = Head.Next;
                while (p != Head)
                {
                    LB.Items.Add(p.Info);
                    p = p.Next;
                }
            }
        }

        /// <summary>
        /// Delete First element.
        /// </summary>
        public void DelFirst()
        {
            if (Head != null && Head.Next != null)
            {
                Viola p = Head.Next;
                p.Next.Prev = Head;
                Head.Next = p.Next;
                p.Next = null;
                p.Prev = null;
                p = null;
            }
        }

        /// <summary>
        /// Delete Last element.
        /// </summary>
        public void DelLast()
        {
            if (Head != null && Head.Next != null)
            {
                Viola p = Head.Prev;
                p.Prev.Next = Head;
                Head.Prev = p.Prev;
                p.Next = null;
                p.Prev = null;
                p = null;
            }
        }

        /// <summary>
        /// Delete selected element.
        /// </summary>
        /// <param name="Index"></param>
        public void DelMarked(int Index)
        {
            if (Head != null && Head.Next != null && Index >= 0)
            {
                Viola p = CountedNode(Index);
                p.Next.Prev = p.Prev;
                p.Prev.Next = p.Next;
                p = null;

            }
        }
         
        public void DelList()
        {
            if (Head != null && Head.Next != null)
            {
                Head.Next = Head;
                Head.Prev = Head;
            }
        }
        /// <summary>
        /// Main method of the programm and main function.
        /// </summary>
        public void Transfer(Amaranthus List, int a)
        {
            if (Head != null && List != null)
            {
                Viola p = List.Head.Next;
                while (p != List.Head)
                {
                    Viola q = CountedNode(p.Info - 1);
                    if (q != null)
                    {
                        q.Info = a;
                    }
                    p = p.Next;
                }
            }
        }
    }
}
