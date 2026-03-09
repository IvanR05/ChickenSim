using System;
using System.Collections.Generic;

namespace gallinas
{
    class Program
    {
        public static int generacionActual = 0;
        public static Gallina[] padres = new Gallina[]{};
        public static Gallina[] newborns = new Gallina[]{};
        public static bool fertilityOverride = false;
        public static void Main()
	    {
            
            //📌 1. Analize Input's gender and count (e.g. "8f")
            Console.WriteLine("==============================================================");
            string input = Console.ReadLine();
            Genero desiredGender = Genero.MALE;
            int desiredCount = 0;
            if(input.EndsWith("m"))
            {
                desiredGender = Genero.MALE;
                desiredCount = Int32.Parse(input.Replace("m", ""));
                
            } else if(input.EndsWith("f"))
            {
                desiredGender = Genero.FEMALE;
                desiredCount = Int32.Parse(input.Replace("f", ""));
            }

            if(desiredCount < 2)
            {
                Console.WriteLine("Mejor sube el valor, okay?");
            } else {
                birthProcess(desiredGender, desiredCount);
                Console.WriteLine("Males: " + Gallina.males.Count + " - Females: " + Gallina.females.Count);
            }

	    }

        //📌 2.Sets birthProcess: prim hens and their reproductive chain
        public static void birthProcess(Genero generoDeseado, int numerodeGallinas)
        {
            Gallina primM = new Gallina(Genero.MALE, "Dionisus, father of all Hens,"); 
            Gallina primF = new Gallina(Genero.FEMALE, "Epistomisya, mother of all Hens,");
            primM.Reproduce(primF); 

            switch(generoDeseado)
            {
                case Genero.MALE:
                    while(Gallina.males.Count <= numerodeGallinas)
                    {
                        padres[0].Reproduce(padres[1]); //using reproduce()
                        if(fertilityOverride)
                        {
                            Console.WriteLine("Se acabo lo que se daba");
                            break;
                        }
                    }
                    break;
                case Genero.FEMALE:
                    while(Gallina.females.Count <= numerodeGallinas)
                    {
                        padres[0].Reproduce(padres[1]); //using reproduce()
                        if(fertilityOverride)
                        {
                            Console.WriteLine("Se acabo lo que se daba");
                            break;
                            
                        }
                    }
                    break;
            }
            
        }
    }

    //📌 3.Class definition, with automatic random gender
    public enum Genero 
    {
        MALE,
        FEMALE,
    }

    public class Gallina 
    {
        public static List<Gallina> males = new List<Gallina>();
        public static List<Gallina> females = new List<Gallina>();
        public Genero genero;
        public string nombre;
        public int fertility;

        //CONSTRUCTOR WITHOUT PARAMETERS (random gender)
        public Gallina()
        {
            this.fertility = 50;
            Random ran = new Random();
            int ranNum = ran.Next(0,2);
            
            if (ranNum == 1)
            {
                this.genero = Genero.MALE;
                Gallina.males.Add(this);
            } else 
            {
                this.genero = Genero.FEMALE;
                Gallina.females.Add(this);
            }
            
            string[] nombres = new string[]{"Protágoras", "Sócrates", "Anaxágoras", "Aquiles", "Ulises", "Demócrito", "Gorgias", "Antonio"};
            int ranNum2 = ran.Next(0, nombres.Length);
            this.nombre = nombres[ranNum2];
            
            Console.WriteLine(this.nombre + " has been born; it's a " + this.genero + "! (" + Program.generacionActual + ")");
        }




        // CONSTRUCTOR WITH PARAMETERS
        public Gallina(Genero genero, string nombre)
        {
            this.fertility = 3;
            this.genero = genero;
            this.nombre = nombre;
            if(this.genero == Genero.MALE)
            {
                Gallina.males.Add(this);
            }
            else if(this.genero == Genero.FEMALE)
            {
                Gallina.females.Add(this);
            }
            Console.WriteLine(this.nombre + " has been awakened! (" + Program.generacionActual + ") \n");
        }



        //📌 4.check couple gender
        public bool isSameGen(Gallina couple)
        {
            if (this.genero == couple.genero)
            {
                return true;
            } else
            {
                return false;
            }
        }

        //📌 5.reproduce (check gender, create Program.newborns, change fathers)
        public void Reproduce(Gallina couple)
        {
            if(!this.isSameGen(couple)){
                if(this.fertility > 0 || couple.fertility > 0){
                    Program.padres = new Gallina[]{this,couple};
                    Program.newborns = new Gallina[]{new Gallina(), new Gallina()};
                    this.fertility--;
                    couple.fertility--;
                    Console.WriteLine("Padres: " + this.nombre + " and " + couple.nombre +  $" with fertility {fertility} \n");

                    //if childs are different gender, they turn into new parents
                    if(!Program.newborns[0].isSameGen(Program.newborns[1]))
                    {
                        Program.padres = Program.newborns;
                        Program.generacionActual++;
                    } 
                    //donde
                    
                } else Program.fertilityOverride = true;
            } 
            else
            {
                Program.newborns = new Gallina[]{new Gallina(), new Gallina()};
            }
        }

    
    }
}