using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public interface IMakeNoise
    {
        // subroutine is just an method...

        // 3 x implimenteren..
        void MakeNoise();

    }

    public class eikel01 : IMakeNoise
    {
        public void MakeNoise()
        {
            Console.WriteLine("geweldig");
        }
    }

    public class eikel02 : IMakeNoise
    {
        public void MakeNoise()
        {
            Console.WriteLine("bye");
        }
    }

    public class eikel03 : IMakeNoise
    {
        public void MakeNoise()
        {
            Console.WriteLine("test");
        }
    }

    public static class program02
    {
        // wat is dit? dis is een method zou maak je een method
        public static void Main02()
        {
            //dit is de knipper
            IMakeNoise eikel = new eikel03();
            // hier wordt de knipper gebruikt
            eikel.MakeNoise();

            eikel = new eikel02();
            eikel.MakeNoise();
            
            eikel = new eikel01();
            eikel.MakeNoise();
        }
    }

    
}
