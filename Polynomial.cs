using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public class Polynomial
    {
        List<Term> terms;
        struct Term
        {
            public int cofficient;
            public int exponantdegree;

            public Term(int cofficient, int exponantdegree)
            {
                this.cofficient = cofficient;
                this.exponantdegree = exponantdegree;
            }
        }

        public Polynomial() { 

            terms = new List<Term>();
        }
        public void Addterm(int cofficient , int degree)
        {
            int i = terms.Count()-1;
            while (i >= 0)
            {
                if (terms[i].exponantdegree == degree)
                {
                    Term newterm = new Term(terms[i].cofficient + cofficient, degree);
                    terms[i] = newterm;
                    return;
                }
                i--;
            }
            Term term = new Term(cofficient,degree); 
            terms.Add(term);
        }   

        

        private void sort()
        {
            terms.Sort((t1, t2) => t2.exponantdegree.CompareTo(t1.exponantdegree));
        }
        public static Polynomial operator+(Polynomial polynomial1  , Polynomial polynomial2)
        {

           
            Polynomial polynomial3  =new();

            foreach (var item in polynomial1.terms)
            {
                polynomial3.Addterm(item.cofficient, item.exponantdegree);
            }
            foreach (var item in polynomial2.terms)
            {
                polynomial3.Addterm(item.cofficient, item.exponantdegree);
            }

            return polynomial3;
        }

        public static Polynomial operator*(Polynomial poly1, Polynomial poly2)
        {
            List<Term> terms = new List<Term>();
            if (poly1.terms.Count==0)
            {
                poly1.Addterm(1, 0);
            }
            foreach (var term1 in poly1.terms)
            {
                foreach (var term2 in poly2.terms)
                {
                    var term = new Term();
                    term.cofficient = term1.cofficient * term2.cofficient;
                    term.exponantdegree = term1.exponantdegree + term2.exponantdegree;
                    terms.Add(term);
                }
            }
            var poly3 = new Polynomial();
            foreach ( var item in terms)
            {
                poly3.Addterm(item.cofficient,item.exponantdegree);
            }
            return poly3;
        }
        
        public void print()
        {
             sort();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < terms.Count; i++)
            {
                if (terms[i].cofficient == 0)
                {
                    continue;
                }
                else if (terms[i].exponantdegree == 0)
                {
                    builder.Append($"{(terms[i].cofficient > 0 ? '+' : "")}{(terms[i].cofficient !=1  && terms[i].cofficient != -1 ? terms[i].cofficient : "")}");
                }
                else if (terms[i].exponantdegree == 1)
                {
                    builder.Append($"{(terms[i].cofficient > 0 ? '+' : "")}{(terms[i].cofficient != 1 && terms[i].cofficient != -1 ? terms[i].cofficient : "")}x");
                }
                else
                    builder.Append($"{(terms[i].cofficient > 0 ? '+' : "")}{(terms[i].cofficient != 1 && terms[i].cofficient != -1 ? terms[i].cofficient : "")}x^{terms[i].exponantdegree}");
            }
            Console.WriteLine(builder.ToString().TrimStart('+'));
        }
    }
}
