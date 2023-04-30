using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Program
{
    public class House
    {
        public string zoneDangerous { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Apartment
    {
        public bool isPetFriendly { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Premise
    {
        public string[] commercialActivities { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Builds
    {
        public Premise[]? Premises { get; set; }
        public Apartment[]? Apartments { get; set; }
        public House[]? Houses { get; set; }
    }
    public class Input1
    {
        public Dictionary<string, bool> services { get; set; }
        public Builds builds { get; set; }

    }
    public class Input2
    {
        public double budget { get; set; }
        public string typeBuilder { get; set; }
        public string[] requiredServices { get; set; }
        public string? commercialActivity { get; set; }
        public bool? wannaPetFriendly { get; set; }
        public string? minDanger { get; set; }
    }
    public class InputLab
    {
        public Input1[] input1 { get; set; }
        public Input2 input2 { get; set; }
    }

    public static void Main()
    {
        Console.WriteLine("hola");
        string jsonText = File.ReadAllText(@"C:\Users\Alison Gatica Rivera\Documents\A.G\UNIVERSIDAD\ESTRCTURA DE DATOS 1\LaboratorioEDI_2\input_lab_2_example.jsonl");
        string[] jsonObjects = jsonText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string i in jsonObjects)
        {
            List <object> construcciones = new List<object>();
            InputLab input2 = JsonSerializer.Deserialize<InputLab>(i)!;
            foreach (Input1 zona in input2.input1)
            {
                if (input2.input2.typeBuilder == "Apartments")
                {
                    if(zona.builds.Apartments!=null)
                    {
                        foreach (Apartment apartment in zona.builds.Apartments)
                        {
                            if (input2.input2.budget >= apartment.price)
                            {
                                
                                if (input2.input2.wannaPetFriendly == apartment.isPetFriendly)
                                {
                                        construcciones.Add(apartment);
                                }
                                
                            }
                        }

                    } 
                }
                else if (input2.input2.typeBuilder == "Houses")
                {
                    if (zona.builds.Houses != null)
                    {
                        foreach (House house in zona.builds.Houses)
                        {
                            if (input2.input2.budget>=house.price)
                            {
                                
                                //if (input2.input2.minDanger == house.zoneDangerous)
                                //{
                                    construcciones.Add(house);
                                //}
                            }
                            
                        }
                    }      
                }
                else {
                    if (zona.builds.Premises != null)
                    {
                        foreach (Premise premise in zona.builds.Premises)
                        {
                            if (input2.input2.budget >= premise.price)
                            {
                                //if (input2.input2.requiredServices == premise.commercialActivities)
                                //{
                                    construcciones.Add(premise);
                                //}
                            }
                        }
                    }
                }
            }
                Console.WriteLine(input2.input2.typeBuilder);
            Console.WriteLine(construcciones.Count);
        }
        InputLab input = JsonSerializer.Deserialize<InputLab>(jsonObjects[0])!;
        bool[] TypeBuilders = new bool[3];

        //Se revisa lo que desea el cliente//
        if(input.input2.typeBuilder == "Apartment")
        {

        }

        //Se revisa lo que desea el cliente//


        if (input.input1[0].builds.Apartments != null){TypeBuilders[0] = true;}
        if (input.input1[0].builds.Houses != null) {TypeBuilders[1] = true;}
        if (input.input1[0].builds.Premises != null) {TypeBuilders[0] = true;}

        bool[] ContainsTBI2 = new bool[input.input1.Length];
        
        for(int i = 0; i < input.input1.Length; i++)
        {
            
        }

        
    }

 
}
